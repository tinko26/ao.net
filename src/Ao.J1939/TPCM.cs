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

using Ao.Bits;
using System;

namespace Ao.J1939
{
	public sealed class TPCM : PG
	{
		#region Fields

		private ulong Value;

		#endregion

		#region Properties

		public TPCMAbortReason AbortReason
		{
			get => (TPCMAbortReason)Value.GetBits(8, 8);
			set
			{
				var T = Value;

				Value.SetBits(8, 8, (ulong)value);

				Value = T;
			}
		}

		public int AbortReasonValue
		{
			get => (int)Value.GetBits(8, 8);
			set
			{
				var T = Value;

				T.SetBits(8, 8, (ulong)value);

				Value = T;
			}
		}

		public override string Acronym => "TP.CM";

		public int BAMMessagePackages
		{
			get => (int)Value.GetBits(24, 8);
			set
			{
				var T = Value;

				T.SetBits(24, 8, (ulong)value);

				Value = T;
			}
		}

		public int BAMMessageSize
		{
			get => (int)Value.GetBits(8, 16);
			set
			{
				var T = Value;

				T.SetBits(8, 16, (ulong)value);

				Value = T;
			}
		}

		public int CTSMessagePackageNext
		{
			get => (int)Value.GetBits(16, 8);
			set
			{
				var T = Value;

				T.SetBits(16, 8, (ulong)value);

				Value = T;
			}
		}

		public int CTSMessagePackages
		{
			get => (int)Value.GetBits(8, 8);
			set
			{
				var T = Value;

				T.SetBits(8, 8, (ulong)value);

				Value = T;
			}
		}

		public override byte[] Data
		{
			get
			{
				var B = BitConverter.GetBytes(Value);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				switch (Mode)
				{
					case TPCMMode.BAM:
					case TPCMMode.EOM:

						B[4] = 0xFF;

						break;

					case TPCMMode.CTS:

						B[3] = 0xFF;
						B[4] = 0xFF;

						break;

					case TPCMMode.Abort:

						B[2] = 0xFF;
						B[3] = 0xFF;
						B[4] = 0xFF;

						break;

					default:

						break;
				}

				return B;
			}
			set
			{
				var B = value;

				B = B.Resize(8);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				Value = BitConverter.ToUInt64(B, 0);
			}
		}

		public override int DataLength => 8;

		public override DataPage DataPage => DataPage.DataPage0;

		public override DataPage DataPageExtended => DataPage.DataPage0;

		public int EOMMessagePackages
		{
			get => (int)Value.GetBits(24, 8);
			set
			{
				var T = Value;

				T.SetBits(24, 8, (ulong)value);

				Value = T;
			}
		}

		public int EOMMessageSize
		{
			get => (int)Value.GetBits(8, 16);
			set
			{
				var T = Value;

				T.SetBits(8, 16, (ulong)value);

				Value = T;
			}
		}

		public override byte GroupExtension => 0;

		public bool IsAbort => Mode == TPCMMode.Abort;

		public bool IsBAM => Mode == TPCMMode.BAM;

		public bool IsCTS => Mode == TPCMMode.CTS;

		public override bool IsDataLengthVariable => false;

		public bool IsEOM => Mode == TPCMMode.EOM;

		public override bool IsMultipacket => false;

		public bool IsRTS => Mode == TPCMMode.RTS;

		public override string Label => "Transport Protocol - Connection Management";

		public PGN MessagePGN
		{
			get => new PGN
			{
				Value = (uint)Value.GetBits(40, 24)
			};
			set
			{
				var T = Value;

				T.SetBits(40, 24, value.Value);

				Value = T;
			}
		}

		public TPCMMode Mode
		{
			get => (TPCMMode)Value.GetBits(0, 8);
			set
			{
				var T = Value;

				Value.SetBits(0, 8, (ulong)value);

				Value = T;
			}
		}

		public override byte PF => 0xEC;

		public int RTSMessagePackagesMax
		{
			get => (int)Value.GetBits(32, 8);
			set
			{
				var T = Value;

				T.SetBits(32, 8, (ulong)value);

				Value = T;
			}
		}

		public int RTSMessagePackagesTotal
		{
			get => (int)Value.GetBits(24, 8);
			set
			{
				var T = Value;

				T.SetBits(24, 8, (ulong)value);

				Value = T;
			}
		}

		public int RTSMessageSize
		{
			get => (int)Value.GetBits(8, 16);
			set
			{
				var T = Value;

				T.SetBits(8, 16, (ulong)value);

				Value = T;
			}
		}

		#endregion
	}
}
