// MIT License

// Copyright (c) 2022 Stefan Wagner

// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using Ao.Measurements;
using System.IO.Ports;
using System.Linq;
using System.Threading;

namespace Ao.Serial
{
	public sealed class Port
	{
		#region Events

		public event PortDataEventHandler Received;

		#endregion

		#region Fields

		private readonly PortCounter CounterReceive = new PortCounter();

		private readonly PortCounter CounterSend = new PortCounter();

		private SerialPort P;

		private readonly object Sync = new object();

		#endregion

		#region Methods

		public void Receive(byte x) => Receive(new byte[1] { x });

		public void Receive(byte[] buffer) => Received?.Invoke(this, new PortDataEventArgs(buffer));

		public void Receive(byte[] buffer, int offset) => Received?.Invoke(this, new PortDataEventArgs(buffer, offset));

		public void Receive(byte[] buffer, int offset, int count)
		{
			if (count > 0)
			{
				lock (Sync)
				{
					if (Running)
					{
						CounterReceive.Next(count);

						Received?.Invoke(this, new PortDataEventArgs(buffer, offset, count));
					}
				}
			}
		}

		public void Send(byte x) => Send(new byte[1] { x }, 0, 1);

		public void Send(byte[] buffer) => Send(buffer, 0, buffer.Length);

		public void Send(byte[] buffer, int offset) => Send(buffer, offset, buffer.Length - offset);

		public void Send(byte[] buffer, int offset, int count)
		{
			if (count > 0)
			{
				lock (Sync)
				{
					if (Running)
					{
						CounterSend.Next(count);

						if (P != null)
						{
							try
							{
								if (P.IsOpen)
								{
									P.Write(buffer, offset, count);
								}
							}

							catch { }
						}
					}
				}
			}
		}

		public void Start()
		{
			lock (Sync)
			{
				if (!Running)
				{
					Running = true;

					RunningName = Name;

					if (RunningName == null)
					{
						RunningName = PortManager.Ports.FirstOrDefault();
					}

					PortManager.PortConnected += PortConnected;

					PortManager.PortDisconnected += PortDisconnected;

					StartPort();
				}
			}
		}

		public void Stop()
		{
			lock (Sync)
			{
				if (Running)
				{
					StopPort();

					PortManager.PortConnected -= PortConnected;

					PortManager.PortDisconnected -= PortDisconnected;

					Running = false;
				}
			}
		}

		#endregion

		#region Methods (Private)

		private void Data(object sender, SerialDataReceivedEventArgs e) => Data(sender as SerialPort);

		private void Data(SerialPort P)
		{
			while (true)
			{
				try
				{
					if (P.IsOpen)
					{
						var N = P.BytesToRead;

						if (N > 0)
						{
							var B = new byte[N];

							var C = P.Read(B, 0, N);

							Receive(B, 0, C);

							continue;
						}
					}
				}

				catch { }

				break;
			}
		}

		private void PortConnected(object sender, PortEventArgs e)
		{
			lock (Sync)
			{
				if (Running && RunningName == e.Name)
				{
					StartPort();
				}
			}
		}

		private void PortDisconnected(object sender, PortEventArgs e)
		{
			lock (Sync)
			{
				if (Running && RunningName == e.Name)
				{
					StopPort();
				}
			}
		}

		private void StartPort()
		{
			if (P == null)
			{
				var TR = ReadTimeout.Milliseconds;

				var TW = WriteTimeout.Milliseconds;

				P = new SerialPort
				{
					BaudRate = Baud,

					DataBits = DataBits,

					Handshake = Handshake,

					Parity = Parity,

					PortName = RunningName,

					ReadBufferSize = ReadBufferSize,

					ReadTimeout = TR > int.MaxValue ? Timeout.Infinite : (int)TR,

					ReceivedBytesThreshold = ReceivedBytesThreshold,

					StopBits = StopBits,

					WriteBufferSize = WriteBufferSize,

					WriteTimeout = TW > int.MaxValue ? Timeout.Infinite : (int)TW
				};

				P.DataReceived += Data;

				try
				{
					P.Open();

					if (P.IsOpen)
					{
						P.DiscardInBuffer();

						P.DiscardOutBuffer();
					}
				}

				catch { }
			}
		}

		private void StopPort()
		{
			if (P != null)
			{
				try
				{
					if (P.IsOpen)
					{
						P.DiscardInBuffer();

						P.DiscardOutBuffer();

						P.Close();
					}
				}

				catch { }

				P.DataReceived -= Data;
			}

			P = null;

			CounterReceive.Reset();

			CounterSend.Reset();
		}

		#endregion

		#region Properties

		public int Baud { get; set; } = 921600;

		public double BaudReceive => CounterReceive.Rate.Hertz * BitsPerByte;

		public double BaudSend => CounterSend.Rate.Hertz * BitsPerByte;

		public int BitsPerByte => BitsStart + BitsData + BitsParity + BitsStop;

		private int BitsData => DataBits;

		private int BitsParity => Parity == Parity.None ? 0 : 1;

		private int BitsStart => 1;

		private int BitsStop => StopBits == StopBits.One ? 1 : 2;

		public int DataBits { get; set; } = 8;

		public Handshake Handshake { get; set; } = Handshake.None;

		public double LoadReceive => BaudReceive / Baud;

		public double LoadSend => BaudSend / Baud;

		public string Name { get; set; }

		public Parity Parity { get; set; } = Parity.None;

		public int ReadBufferSize { get; set; } = 12800;

		public Time ReadTimeout { get; set; } = Time.PositiveInfinity;

		public int ReceivedBytesThreshold { get; set; } = 16;

		public bool Running { get; private set; }

		public string RunningName { get; private set; }

		public StopBits StopBits { get; set; } = StopBits.One;

		public int WriteBufferSize { get; set; } = 12800;

		public Time WriteTimeout { get; set; } = Time.PositiveInfinity;

		#endregion
	}
}
