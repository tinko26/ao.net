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

namespace Ao.Serial
{
	sealed class PortCounter
	{
		#region Constants

		public const int Capacity = 128;

		#endregion

		#region Fields

		private readonly int[] C = new int[Capacity];

		private int I;

		private int N;

		private readonly Time[] T = new Time[Capacity];

		#endregion

		#region Methods

		public void Next() => Next(1);

		public void Next(int c)
		{
			var t = Now();

			if (N == 0)
			{
				I = 0;

				C[I] = c;

				T[I] = t;

				I = (I + 1) % Capacity;

				N++;

				Total = c;

				Rate = Frequency.Zero;
			}

			else if (N < Capacity)
			{
				C[I] = c;

				T[I] = t;

				I = (I + 1) % Capacity;

				N++;

				Total += c;

				Rate = Total / TT;
			}

			else
			{
				Total -= CB;

				Total += c;

				C[I] = c;

				T[I] = t;

				I = (I + 1) % Capacity;

				Rate = Total / TT;
			}
		}

		public void Reset()
		{
			N = 0;

			Total = 0;

			Rate = Frequency.Zero;
		}

		#endregion

		#region Methods (Private)

		private Time Now() => new Time((double)DateTime.Now.Ticks / TimeSpan.TicksPerSecond);

		#endregion

		#region Properties

		public Frequency Rate { get; private set; }

		public int Total { get; private set; }

		#endregion

		#region Properties (Private)

		private int B => (I + Capacity - N) % Capacity;

		private int CB => C[B];

		private int CE => C[E];

		private int E => (I + Capacity - 1) % Capacity;

		private Time TB => T[B];

		private Time TE => T[E];

		private Time TT => TE - TB;

		#endregion
	}
}
