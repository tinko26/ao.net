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

using System.Collections;
using System.Collections.Generic;

namespace Ao.Collections
{
	public class Deque<T> : IEnumerable<T>
	{
		#region Fields

		private readonly LinkedList<T> List = new LinkedList<T>();

		#endregion

		#region Methods

		public void Clear() => List.Clear();

		public void Contains(T x) => List.Contains(x);

		public void CopyTo(T[] array, int index) => List.CopyTo(array, index);

		public IEnumerator<T> GetEnumerator() => List.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public T PopBack()
		{
			var x = Back;

			RemoveBack();

			return x;
		}

		public T PopFront()
		{
			var x = Front;

			RemoveFront();

			return x;
		}

		public void PushBack(T x) => List.AddLast(x);

		public void PushFront(T x) => List.AddFirst(x);

		public void RemoveBack() => List.RemoveLast();

		public void RemoveFront() => List.RemoveFirst();

		#endregion

		#region Properties

		public T Back
		{
			get => List.Last.Value;
			set => List.Last.Value = value;
		}

		public int Count => List.Count;

		public T Front
		{
			get => List.First.Value;
			set => List.First.Value = value;
		}

		#endregion
	}
}
