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

namespace Ao.Mathematics
{
    public static class Round
    {
        public static double AwayFromInfinity(double x) => Math.Truncate(x);

        public static double AwayFromInfinity(double x, double factor) => AwayFromInfinity(x / factor) * factor;

        public static double AwayFromInfinityDigits(double x, int digits) => AwayFromInfinity(x, Math.Pow(10, -digits));

		public static double AwayFromNegativeInfinity(double x) => Math.Ceiling(x);

		public static double AwayFromNegativeInfinity(double x, double factor) => AwayFromNegativeInfinity(x / factor) * factor;

		public static double AwayFromNegativeInfinityDigits(double x, int digits) => AwayFromNegativeInfinity(x, Math.Pow(10, -digits));

		public static double AwayFromPositiveInfinity(double x) => Math.Floor(x);

		public static double AwayFromPositiveInfinity(double x, double factor) => AwayFromPositiveInfinity(x / factor) * factor;

		public static double AwayFromPositiveInfinityDigits(double x, int digits) => AwayFromPositiveInfinity(x, Math.Pow(10, -digits));

		public static double AwayFromZero(double x) => x > 0 ? Ceil(x) : Floor(x);

		public static double AwayFromZero(double x, double factor) => AwayFromZero(x / factor) * factor;

		public static double AwayFromZeroDigits(double x, int digits) => AwayFromZero(x, Math.Pow(10, -digits));

		public static double Ceil(double x) => Math.Ceiling(x);

		public static double Ceil(double x, double factor) => Ceil(x / factor) * factor;

		public static double CeilDigits(double x, int digits) => Ceil(x, Math.Pow(10, -digits));

		public static double Down(double x) => Math.Floor(x);

		public static double Down(double x, double factor) => Down(x / factor) * factor;

		public static double DownDigits(double x, int digits) => Down(x, Math.Pow(10, -digits));

		public static double Floor(double x) => Math.Floor(x);

		public static double Floor(double x, double factor) => Floor(x / factor) * factor;

		public static double FloorDigits(double x, int digits) => Floor(x, Math.Pow(10, -digits));

		public static double HalfAwayFromInfinity(double x) => x > 0 ? Math.Ceiling(x - 0.5) : Math.Floor(x + 0.5);

		public static double HalfAwayFromInfinity(double x, double factor) => HalfAwayFromInfinity(x / factor) * factor;

		public static double HalfAwayFromInfinityDigits(double x, int digits) => HalfAwayFromInfinity(x, Math.Pow(10, -digits));

		public static double HalfAwayFromNegativeInfinity(double x) => Math.Floor(x + 0.5);

		public static double HalfAwayFromNegativeInfinity(double x, double factor) => HalfAwayFromNegativeInfinity(x / factor) * factor;

		public static double HalfAwayFromNegativeInfinityDigits(double x, int digits) => HalfAwayFromNegativeInfinity(x, Math.Pow(10, -digits));

		public static double HalfAwayFromPositiveInfinity(double x) => Math.Ceiling(x - 0.5);

		public static double HalfAwayFromPositiveInfinity(double x, double factor) => HalfAwayFromPositiveInfinity(x / factor) * factor;

		public static double HalfAwayFromPositiveInfinityDigits(double x, int digits) => HalfAwayFromPositiveInfinity(x, Math.Pow(10, -digits));

		public static double HalfAwayFromZero(double x) => x > 0 ? Math.Floor(x + 0.5) : Math.Ceiling(x - 0.5);

		public static double HalfAwayFromZero(double x, double factor) => HalfAwayFromZero(x / factor) * factor;

		public static double HalfAwayFromZeroDigits(double x, int digits) => HalfAwayFromZero(x, Math.Pow(10, -digits));

		public static double HalfDown(double x) => Math.Ceiling(x - 0.5);

		public static double HalfDown(double x, double factor) => HalfDown(x / factor) * factor;

		public static double HalfDownDigits(double x, int digits) => HalfDown(x, Math.Pow(10, -digits));

		public static double HalfToEven(double x)
		{
			if (x > 0)
			{
				var i = Math.Truncate(x);

				var f = x - i;

				if (f < 0.5)
				{
					return i;
				}

				else if (f > 0.5)
				{
					return i + 1;
				}

				else
				{
					if (i % 2 < 0.5) return i;

					else return i + 1;
				}
			}

			else if (x < 0)
			{
				var i = Math.Truncate(x);

				var f = i - x;

				if (f < 0.5)
				{
					return i;
				}

				else if (f > 0.5)
				{
					return i - 1;
				}

				else
				{
					if (Math.Abs(i % 2) < 0.5) return i;

					else return i - 1;
				}
			}

			else
			{
				return 0;
			}
		}

		public static double HalfToEven(double x, double factor) => HalfToEven(x / factor) * factor;

		public static double HalfToEvenDigits(double x, int digits) => HalfToEven(x, Math.Pow(10, -digits));

		public static double HalfToInfinity(double x) => x > 0 ? Math.Floor(x + 0.5) : Math.Ceiling(x - 0.5);

		public static double HalfToInfinity(double x, double factor) => HalfToInfinity(x / factor) * factor;

		public static double HalfToInfinityDigits(double x, int digits) => HalfToInfinity(x, Math.Pow(10, -digits));

		public static double HalfToNegativeInfinity(double x) => Math.Ceiling(x - 0.5);

		public static double HalfToNegativeInfinity(double x, double factor) => HalfToNegativeInfinity(x / factor) * factor;

		public static double HalfToNegativeInfinityDigits(double x, int digits) => HalfToNegativeInfinity(x, Math.Pow(10, -digits));

		public static double HalfToOdd(double x)
		{
			if (x > 0)
			{
				var i = Math.Truncate(x);

				var f = x - i;

				if (f < 0.5)
				{
					return i;
				}

				else if (f > 0.5)
				{
					return i + 1;
				}

				else
				{
					if (i % 2 < 0.5) return i + 1;

					else return i;
				}
			}

			else if (x < 0)
			{
				var i = Math.Truncate(x);

				var f = i - x;

				if (f < 0.5)
				{
					return i;
				}

				else if (f > 0.5)
				{
					return i - 1;
				}

				else
				{
					if (Math.Abs(i % 2) < 0.5) return i - 1;

					else return i;
				}
			}

			else
			{
				return 0;
			}
		}

		public static double HalfToOdd(double x, double factor) => HalfToOdd(x / factor) * factor;

		public static double HalfToOddDigits(double x, int digits) => HalfToOdd(x, Math.Pow(10, -digits));

		public static double HalfToPositiveInfinity(double x) => Math.Floor(x + 0.5);

		public static double HalfToPositiveInfinity(double x, double factor) => HalfToPositiveInfinity(x / factor) * factor;

		public static double HalfToPositiveInfinityDigits(double x, int digits) => HalfToPositiveInfinity(x, Math.Pow(10, -digits));

		public static double HalfToZero(double x) => x > 0 ? Math.Ceiling(x - 0.5) : Math.Floor(x + 0.5);

		public static double HalfToZero(double x, double factor) => HalfToZero(x / factor) * factor;

		public static double HalfToZeroDigits(double x, int digits) => HalfToZero(x, Math.Pow(10, -digits));

		public static double HalfUp(double x) => Math.Floor(x + 0.5);

		public static double HalfUp(double x, double factor) => HalfUp(x / factor) * factor;

		public static double HalfUpDigits(double x, int digits) => HalfUp(x, Math.Pow(10, -digits));

		public static double ToInfinity(double x) => x > 0 ? Ceil(x) : Floor(x);

		public static double ToInfinity(double x, double factor) => ToInfinity(x / factor) * factor;

		public static double ToInfinityDigits(double x, int digits) => ToInfinity(x, Math.Pow(10, -digits));

		public static double ToNegativeInfinity(double x) => Math.Floor(x);

		public static double ToNegativeInfinity(double x, double factor) => ToNegativeInfinity(x / factor) * factor;

		public static double ToNegativeInfinityDigits(double x, int digits) => ToNegativeInfinity(x, Math.Pow(10, -digits));

		public static double ToPositiveInfinity(double x) => Math.Ceiling(x);

		public static double ToPositiveInfinity(double x, double factor) => ToPositiveInfinity(x / factor) * factor;

		public static double ToPositiveInfinityDigits(double x, int digits) => ToPositiveInfinity(x, Math.Pow(10, -digits));

		public static double ToZero(double x) => Math.Truncate(x);

		public static double ToZero(double x, double factor) => ToZero(x / factor) * factor;

		public static double ToZeroDigits(double x, int digits) => ToZero(x, Math.Pow(10, -digits));

		public static double Trunc(double x) => Math.Truncate(x);

		public static double Trunc(double x, double factor) => Trunc(x / factor) * factor;

		public static double TruncDigits(double x, int digits) => Trunc(x, Math.Pow(10, -digits));

		public static double Up(double x) => Math.Ceiling(x);

		public static double Up(double x, double factor) => Up(x / factor) * factor;

		public static double UpDigits(double x, int digits) => Up(x, Math.Pow(10, -digits));
	}
}
