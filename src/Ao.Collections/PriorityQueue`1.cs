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

namespace Ao.Collections
{
	public class PriorityQueue<T>
	{
		#region Construction

		public PriorityQueue() => Comparer = Comparer<T>.Default;

		public PriorityQueue(IComparer<T> comparer) => Comparer = comparer ?? throw new ArgumentNullException();

		#endregion

		#region Fields

		private readonly Dictionary<T, int> Indexes = new Dictionary<T, int>();

		private readonly List<T> Items = new List<T>();

		#endregion

		#region Methods

		public void Clear()
		{
			Count = 0;

			Indexes.Clear();

			Items.Clear();
		}

		public bool Contains(T x) => Indexes.ContainsKey(x);

		public T Peek()
		{
			if (Count > 0)
			{
				return Items[0];
			}

			else
			{
				throw new InvalidOperationException();
			}
		}

		public T Pop()
		{
			var c = Count;

			if (c > 0)
			{
				var x = Items[0];

				c = c - 1;

				Count = c;

				if (c > 0)
				{
					var y = Items[c];

					Items[0] = y;

					Indexes[y] = 0;

					Down(0, c);
				}

				Items.RemoveAt(c);

				Indexes.Remove(x);

				return x;
			}

			else
			{
				throw new InvalidOperationException();
			}
		}

		public void Push(T x)
		{
			if (Indexes.ContainsKey(x))
			{
				throw new InvalidOperationException();
			}

			else
			{
				var c = Count;

				Count = c + 1;

				Items.Add(x);

				Indexes[x] = c;

				Up(c);
			}
		}

		public void Remove(T x)
		{
			if (Indexes.ContainsKey(x))
			{
				var i = Indexes[x];

				var c = Count - 1;

				Count = c;

				if (i < c)
				{
					var y = Items[c];

					Items[i] = y;

					Indexes[y] = i;

					Down(i, c);
				}

				Items.RemoveAt(c);

				Indexes.Remove(x);
			}

			else
			{
				throw new InvalidOperationException();
			}
		}

		#endregion

		#region Methods (Private)

		private void Down(int i1, int c)
		{
			var b1 = true;

			var b2 = false;

			var x1 = Items[i1];

			do
			{
				var il = Left(i1);

				var ir = Right(i1);

				// Both left and right child.

				if (ir < c)
				{
					var xl = Items[il];

					var xr = Items[ir];

					// xr is less.

					if (Less(xr, x1))
					{
						// xr is less than x1.

						// xl is less than xr.

						if (Less(xl, xr))
						{
							Items[i1] = xl;

							Indexes[x1] = i1;

							i1 = il;

							b2 = true;
						}

						// xr is less than x1.

						// xl is not less than xr.

						else
						{
							Items[i1] = xr;

							Indexes[xr] = i1;

							i1 = ir;

							b2 = true;
						}
					}

					// xr is not less.

					// xl is less.

					else if (Less(xl, x1))
					{
						Items[i1] = xl;

						Indexes[xl] = i1;

						i1 = il;

						b2 = true;
					}

					// xr is not less.

					// xl is not less.

					else
					{
						b1 = false;
					}
				}

				// Left child only.

				else if (il < c)
				{
					var xl = Items[il];

					// xl is less.

					if (Less(xl, x1))
					{
						Items[i1] = xl;

						Indexes[xl] = i1;

						i1 = il;

						b2 = true;
					}

					// xl is not less.

					else
					{
						b1 = false;
					}
				}

				// No children.

				else
				{
					b1 = false;
				}
			}
			while (b1);

			if (b2)
			{
				Items[i1] = x1;

				Indexes[x1] = i1;
			}
		}

		private bool Less(T x1, T x2) => Comparer.Compare(x1, x2) < 0;

		private void Up(int i1)
		{
			var b1 = i1 > 0;

			if (b1)
			{
				var b2 = false;

				var x1 = Items[i1];

				do
				{
					var i2 = Parent(i1);

					var x2 = Items[i2];

					if (Less(x1, x2))
					{
						Items[i1] = x2;

						Indexes[x2] = i1;

						i1 = i2;

						b1 = i1 > 0;

						b2 = true;
					}

					else
					{
						b1 = false;
					}
				}
				while (b1);

				if (b2)
				{
					Items[i1] = x1;

					Indexes[x1] = i1;
				}
			}
		}

		#endregion

		#region Methods (Private Static)

		private static int Left(int i) => 2 * i + 1;

		private static int Parent(int i) => (i - 1) / 2;

		private static int Right(int i) => 2 * i + 2;

		#endregion

		#region Properties

		public int Capacity
		{
			get => Items.Capacity;
			set => Items.Capacity = value;
		}

		public IComparer<T> Comparer { get; }

		public int Count { get; private set; } = 0;

		#endregion
	}
}
