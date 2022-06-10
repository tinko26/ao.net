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
using System.Globalization;
using System.IO;
using System.Linq;

namespace Ao.Logging
{
	public sealed class SessionRoot
	{
		#region Construction

		public SessionRoot(string path) => Path = path;

		#endregion

		#region Methods

		public Session CreateSession() => CreateSession(DateTime.Now);

		public Session CreateSession(DateTime dateTime) => CreateSession(dateTime.ToString("yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture));

		public Session CreateSession(string name) => new Session(string.Format("{0}{1}{2}", Path, System.IO.Path.DirectorySeparatorChar, name));

		public IEnumerable<Session> GetSessions()
		{
			var D1 = new DirectoryInfo(Path);

			var D2 = D1.GetDirectories();

			var D3 = from x in D2 select x.Name;

			var D4 = from x in D3 select CreateSession(x);

			return D4;
		}

		#endregion

		#region Properties

		public string Path { get; }

		#endregion
	}
}
