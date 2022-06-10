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

namespace Ao.Bits
{
	public static class Extensions
	{
		public static byte GetBits(this byte X, int i, int n)
		{
			var T0 = (uint)X;

			var T1 = T0 >> i;

			var T2 = 1U << n;

			var T3 = T2 - 1U;

			var T4 = T1 & T3;

			var T5 = (byte)T4;

			return T5;
		}

		public static int GetBits(this int X, int i, int n)
		{
			var T1 = X >> i;

			var T2 = 1 << n;

			var T3 = T2 - 1;

			var T4 = T1 & T3;

			return T4;
		}

		public static long GetBits(this long X, int i, int n)
		{
			var T1 = X >> i;

			var T2 = 1L << n;

			var T3 = T2 - 1L;

			return T1 & T3;
		}

		public static sbyte GetBits(this sbyte X, int i, int n)
		{
			var T0 = (int)X;

			var T1 = T0 >> i;

			var T2 = 1 << n;

			var T3 = T2 - 1;

			var T4 = T1 & T3;

			var T5 = (sbyte)T4;

			return T5;
		}

		public static short GetBits(this short X, int i, int n)
		{
			var T0 = (int)X;

			var T1 = T0 >> i;

			var T2 = 1 << n;

			var T3 = T2 - 1;

			var T4 = T1 & T3;

			var T5 = (short)T4;

			return T5;
		}

		public static uint GetBits(this uint X, int i, int n)
		{
			var T1 = X >> i;

			var T2 = 1U << n;

			var T3 = T2 - 1U;

			return T1 & T3;
		}

		public static ulong GetBits(this ulong X, int i, int n)
		{
			var T1 = X >> i;

			var T2 = 1UL << n;

			var T3 = T2 - 1UL;

			return T1 & T3;
		}

		public static ushort GetBits(this ushort X, int i, int n)
		{
			var T0 = (uint)X;

			var T1 = T0 >> i;

			var T2 = 1U << n;

			var T3 = T2 - 1U;

			var T4 = T1 & T3;

			var T5 = (ushort)T4;

			return T5;
		}

		public static byte SetBits(this ref byte X, int i, int n, byte Y)
		{
			var TX = (uint)X;

			var TY = (uint)Y;

			var T1 = 1U << n;

			var T2 = T1 - 1U;

			var T3 = T2 << i;

			var T4 = ~T3;

			var T5 = TY << i;

			var T6 = T5 & T3;

			var T7 = T4 & TX;

			var T8 = T7 | T6;

			X = (byte)T8;

			return X;
		}

		public static int SetBits(this ref int X, int i, int n, int Y)
		{
			var T1 = 1 << n;

			var T2 = T1 - 1;

			var T3 = T2 << i;

			var T4 = ~T3;

			var T5 = Y << i;

			var T6 = T5 & T3;

			var T7 = T4 & X;

			var T8 = T7 | T6;

			X = T8;

			return X;
		}

		public static long SetBits(this ref long X, int i, int n, long Y)
		{
			var T1 = 1L << n;

			var T2 = T1 - 1L;

			var T3 = T2 << i;

			var T4 = ~T3;

			var T5 = Y << i;

			var T6 = T5 & T3;

			var T7 = T4 & X;

			var T8 = T7 | T6;

			X = T8;

			return X;
		}

		public static sbyte SetBits(this ref sbyte X, int i, int n, sbyte Y)
		{
			var TX = (int)X;

			var TY = (int)Y;

			var T1 = 1 << n;

			var T2 = T1 - 1;

			var T3 = T2 << i;

			var T4 = ~T3;

			var T5 = TY << i;

			var T6 = T5 & T3;

			var T7 = T4 & TX;

			var T8 = T7 | T6;

			X = (sbyte)T8;

			return X;
		}

		public static short SetBits(this ref short X, int i, int n, short Y)
		{
			var TX = (int)X;

			var TY = (int)Y;

			var T1 = 1 << n;

			var T2 = T1 - 1;

			var T3 = T2 << i;

			var T4 = ~T3;

			var T5 = TY << i;

			var T6 = T5 & T3;

			var T7 = T4 & TX;

			var T8 = T7 | T6;

			X = (short)T8;

			return X;
		}

		public static uint SetBits(this ref uint X, int i, int n, uint Y)
		{
			var T1 = 1U << n;

			var T2 = T1 - 1U;

			var T3 = T2 << i;

			var T4 = ~T3;

			var T5 = Y << i;

			var T6 = T5 & T3;

			var T7 = T4 & X;

			var T8 = T7 | T6;

			X = T8;

			return X;
		}

		public static ulong SetBits(this ref ulong X, int i, int n, ulong Y)
		{
			var T1 = 1UL << n;

			var T2 = T1 - 1UL;

			var T3 = T2 << i;

			var T4 = ~T3;

			var T5 = Y << i;

			var T6 = T5 & T3;

			var T7 = T4 & X;

			var T8 = T7 | T6;

			X = T8;

			return X;
		}

		public static ushort SetBits(this ref ushort X, int i, int n, ushort Y)
		{
			var TX = (uint)X;

			var TY = (uint)Y;

			var T1 = 1U << n;

			var T2 = T1 - 1U;

			var T3 = T2 << i;

			var T4 = ~T3;

			var T5 = TY << i;

			var T6 = T5 & T3;

			var T7 = T4 & TX;

			var T8 = T7 | T6;

			X = (ushort)T8;

			return X;
		}
	}
}
