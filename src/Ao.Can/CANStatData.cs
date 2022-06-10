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
using System.Collections.Generic;
using System.Linq;

namespace Ao.Can
{
	public sealed class CANStatData
	{
		#region Methods

		public void Add(Time T, CAN C)
		{
			var E = new Entry
			{
				Data = C.Data,

				DLC = C.DLC,

				Time = T
			};

			if (HasEntries)
			{
				var L = Last;

				if 
				(
					L.Data != E.Data || 
					L.DLC != E.DLC
				)
				{
					Entries.Add(E);
				}
			}

			else
			{
				Entries.Add(E);
			}
		}

		#endregion

		#region Properties

		public bool HasEntries => Entries.Count > 0;

		public List<Entry> Entries { get; } = new List<Entry>();

		public Entry Last => Entries.Last();

		#endregion

		#region Types

		public sealed class Entry
		{
			public Time Time { get; set; }

			public ulong Data { get; set; }

			public uint DLC { get; set; }
		}

		#endregion
	}
}
