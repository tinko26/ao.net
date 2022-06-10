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

using System.Collections.Generic;
using System.IO;

namespace Ao.Logging
{
	public sealed class LogFile
	{
		#region Construction

		public LogFile(string path) => Path = path;

		public LogFile(string path, string fileName) => Path = string.Format("{0}{1}{2}", path, System.IO.Path.DirectorySeparatorChar, fileName);

		#endregion

		#region Methods

		public void Append()
		{
			var F = new FileInfo(Path);

			var D = F.Directory;

			D.Create();

			File.AppendAllLines(Path, Lines);

			Lines.Clear();
		}

		public void Delete()
		{
			if (Exists)
			{
				File.Delete(Path);
			}
		}

		public void Read()
		{
			Lines.Clear();

			var L = File.ReadAllLines(Path);

			Lines.Capacity = L.Length;

			Lines.AddRange(L);
		}

		public void Write()
		{
			var F = new FileInfo(Path);

			var D = F.Directory;

			D.Create();

			File.WriteAllLines(Path, Lines);

			Lines.Clear();
		}

		#endregion

		#region Properties

		public bool Exists => File.Exists(Path);

		public List<string> Lines { get; } = new List<string>();

		public string Path { get; }

		#endregion
	}
}
