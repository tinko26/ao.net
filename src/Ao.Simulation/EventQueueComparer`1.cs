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
using System;
using System.Collections.Generic;

namespace Ao.Simulation
{
	public sealed class EventQueueComparer<T> : IComparer<T>
	{
		#region Construction

		public EventQueueComparer(Func<T, Time> getEventTime) => GetEventTime = getEventTime ?? throw new ArgumentNullException();

		#endregion

		#region Methods

		public int Compare(T event1, T event2)
		{
			var T1 = GetEventTime(event1);
			var T2 = GetEventTime(event2);

			return T1.CompareTo(T2);
		}

		#endregion

		#region Properties

		public Func<T, Time> GetEventTime { get; }

		#endregion
	}
}
