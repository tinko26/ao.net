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

        public static double AwayFromInfinity(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Truncate(x * f) / f;
        }

        public static double AwayFromZero(double x) => Math.Sign(x) * Math.Ceiling(Math.Abs(x));

        public static double AwayFromZero(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            var s = Math.Sign(x);

            return s * Math.Ceiling(Math.Abs(x) * f) / f;
        }

        public static double Ceil(double x) => Math.Ceiling(x);

        public static double Ceil(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Ceiling(x * f) / f;
        }

        public static double Down(double x) => Math.Floor(x);

        public static double Down(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Floor(x * f) / f;
        }

        public static double Floor(double x) => Math.Floor(x);

        public static double Floor(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Floor(x * f) / f;
        }

        public static double HalfAwayFromInfinity(double x) => Math.Sign(x) * Math.Ceiling(Math.Abs(x) - 0.5);

        public static double HalfAwayFromInfinity(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            var s = Math.Sign(x);

            return s * Math.Ceiling(Math.Abs(x * f) - 0.5) / f;
        }

        public static double HalfAwayFromZero(double x) => Math.Sign(x) * Math.Floor(Math.Abs(x) + 0.5);

        public static double HalfAwayFromZero(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            var s = Math.Sign(x);

            return s * Math.Floor(Math.Abs(x) * f + 0.5) / f;
        }

        public static double HalfDown(double x) => Math.Ceiling(x - 0.5);

        public static double HalfDown(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Ceiling((x - 0.5) * f) / f;
        }

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
                    if (i % 2 == 0) return i;

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
                    if (i % 2 == 0) return i;

                    else return i - 1;
                }
            }

            else
            {
                return 0;
            }
        }

        public static double HalfToEven(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return HalfToEven(x * f) / f;
        }

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
                    if (i % 2 == 0) return i + 1;

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
                    if (i % 2 == 0) return i - 1;

                    else return i;
                }
            }

            else
            {
                return 0;
            }
        }

        public static double HalfToOdd(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return HalfToOdd(x * f) / f;
        }

        public static double HalfTowardsInfinity(double x) => Math.Sign(x) * Math.Floor(Math.Abs(x) + 0.5);

        public static double HalfTowardsInfinity(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            var s = Math.Sign(x);

            return s * Math.Floor(Math.Abs(x) * f + 0.5) / f;
        }

        public static double HalfTowardsMinusInfinity(double x) => Math.Ceiling(x - 0.5);

        public static double HalfTowardsMinusInfinity(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Ceiling((x - 0.5) * f) / f;
        }

        public static double HalfTowardsPlusInfinity(double x) => Math.Floor(x + 0.5);

        public static double HalfTowardsPlusInfinity(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Floor((x + 0.5) * f) / f;
        }

        public static double HalfTowardsZero(double x) => Math.Sign(x) * Math.Ceiling(Math.Abs(x) - 0.5);

        public static double HalfTowardsZero(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            var s = Math.Sign(x);

            return s * Math.Ceiling(Math.Abs(x * f) - 0.5) / f;
        }

        public static double HalfUp(double x) => Math.Floor(x + 0.5);

        public static double HalfUp(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Floor((x + 0.5) * f) / f;
        }

        public static double TowardsInfinity(double x) => Math.Sign(x) * Math.Ceiling(Math.Abs(x));

        public static double TowardsInfinity(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            var s = Math.Sign(x);

            return s * Math.Ceiling(Math.Abs(x) * f) / f;
        }

        public static double TowardsMinusInfinity(double x) => Math.Floor(x);

        public static double TowardsMinusInfinity(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Floor(x * f) / f;
        }

        public static double TowardsPlusInfinity(double x) => Math.Ceiling(x);

        public static double TowardsPlusInfinity(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Ceiling(x * f) / f;
        }

        public static double TowardsZero(double x) => Math.Truncate(x);

        public static double TowardsZero(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Truncate(x * f) / f;
        }

        public static double Trunc(double x) => Math.Truncate(x);

        public static double Trunc(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Truncate(x * f) / f;
        }

        public static double Up(double x) => Math.Ceiling(x);

        public static double Up(double x, int digits)
        {
            var f = Math.Pow(10, digits);

            return Math.Ceiling(x * f) / f;
        }
    }
}
