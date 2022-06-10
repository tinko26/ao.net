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

using System;
using System.Collections.Generic;

namespace Ao.Logging
{
	public class Log
	{
		#region Construction

		public Log(string path)
		{
			Path = path;

			Control = new LogControl();

			Control.Started += Started;
			Control.Stopped += Stopped;
		}

		public Log(string path, LogControl control)
		{
			Path = path;

			Control = control ?? throw new ArgumentNullException();

			Control.Started += Started;
			Control.Stopped += Stopped;
		}

		#endregion

		#region Fields

		private Dictionary<string, LogFile> Files;

		#endregion

		#region Methods

		public void Add(string fileName, string line)
		{
			var F = File(fileName);

			if (F != null)
			{
				F.Lines.Add(line);

				if (F.Lines.Count >= FileLineBufferSize)
				{
					F.Append();
				}
			}
		}

		public void Start() => Control.Start();

		public void Stop() => Control.Stop();

		#endregion

		#region Methods (Protected)

		protected virtual void Started(object sender, EventArgs e)
		{
			Files = new Dictionary<string, LogFile>();
		}

		protected virtual void Stopped(object sender, EventArgs e)
		{
			foreach (var X in Files.Values)
			{
				X.Append();
			}

			Files = null;
		}

		#endregion

		#region Methods (Private)

		private LogFile File(string F)
		{
			var X = Files;

			if (X != null)
			{
				if (!X.ContainsKey(F))
				{
					var P = string.Format("{0}{1}{2}", Path, System.IO.Path.DirectorySeparatorChar, F);

					X[F] = new LogFile(P);

					X[F].Delete();
				}

				return X[F];
			}

			else
			{
				return null;
			}
		}

		#endregion

		#region Properties

		public LogControl Control { get; }

		public int FileLineBufferSize { get; set; } = 10000;

		public string Path { get; }

		public bool Running => Control.Running;

		#endregion
	}
}
