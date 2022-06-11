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
    public struct Vector6 : IEquatable<Vector6>
    {
        #region Constants

        public static readonly Vector6 Unit1 = new Vector6(1, 0, 0, 0, 0, 0);

        public static readonly Vector6 Unit2 = new Vector6(0, 1, 0, 0, 0, 0);

        public static readonly Vector6 Unit3 = new Vector6(0, 0, 1, 0, 0, 0);

        public static readonly Vector6 Unit4 = new Vector6(0, 0, 0, 1, 0, 0);

        public static readonly Vector6 Unit5 = new Vector6(0, 0, 0, 0, 1, 0);

        public static readonly Vector6 Unit6 = new Vector6(0, 0, 0, 0, 0, 1);

        public static readonly Vector6 Zero = new Vector6();

        #endregion

        #region Construction

        public Vector6(double m1, double m2, double m3, double m4, double m5, double m6)
        {
            M1 = m1;
            M2 = m2;
            M3 = m3;
            M4 = m4;
            M5 = m5;
            M6 = m6;
        }

        #endregion

        #region Methods

        public bool Equals(Vector6 x) => this == x;

        public double Norm(double p)
        {
            var s1 = Math.Pow(Math.Abs(M1), p);
            var s2 = Math.Pow(Math.Abs(M2), p);
            var s3 = Math.Pow(Math.Abs(M3), p);
            var s4 = Math.Pow(Math.Abs(M4), p);
            var s5 = Math.Pow(Math.Abs(M5), p);
            var s6 = Math.Pow(Math.Abs(M6), p);

            var s = s1 + s2 + s3 + s4 + s5 + s6;

            return Math.Pow(s, 1 / p);
        }

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Vector6)) return false;

            var y = (Vector6)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M1.GetHashCode() ^
            M2.GetHashCode() ^
            M3.GetHashCode() ^
            M4.GetHashCode() ^
            M5.GetHashCode() ^
            M6.GetHashCode();

        #endregion

        #region Methods (Static)

        public static double Angle(Vector6 a, Vector6 b)
        {
            var t = a * b / Math.Sqrt(a.LengthSqr * b.LengthSqr);

            if (t <= -1)
            {
                return Math.PI;
            }

            else if (t >= +1)
            {
                return 0;
            }

            else
            {
                return Math.Acos(t);
            }
        }

        public static Vector6 Project(Vector6 a, Vector6 b) => a * b / b.LengthSqr * b;

        #endregion

        #region Operators

        public static Vector6 operator +(Vector6 a) => a;

        public static Vector6 operator +(Vector6 a, Vector6 b) => new Vector6(a.M1 + b.M1, a.M2 + b.M2, a.M3 + b.M3, a.M4 + b.M4, a.M5 + b.M5, a.M6 + b.M6);

        public static Vector6 operator -(Vector6 a) => new Vector6(-a.M1, -a.M2, -a.M3, -a.M4, -a.M5, -a.M6);

        public static Vector6 operator -(Vector6 a, Vector6 b) => new Vector6(a.M1 - b.M1, a.M2 - b.M2, a.M3 - b.M3, a.M4 - b.M4, a.M5 - b.M5, a.M6 - b.M6);

        public static double operator *(Vector6 a, Vector6 b) => a.M1 * b.M1 + a.M2 * b.M2 + a.M3 * b.M3 + a.M4 * b.M4 + a.M5 * b.M5 + a.M6 * b.M6;

        public static Vector6 operator *(Vector6 a, double b) => new Vector6(a.M1 * b, a.M2 * b, a.M3 * b, a.M4 * b, a.M5 * b, a.M6 * b);

        public static Vector6 operator *(double a, Vector6 b) => new Vector6(a * b.M1, a * b.M2, a * b.M3, a * b.M4, a * b.M5, a * b.M6);

        public static Vector6 operator /(Vector6 a, double b) => new Vector6(a.M1 / b, a.M2 / b, a.M3 / b, a.M4 / b, a.M5 / b, a.M6 / b);

        #endregion

        #region Operators

        public static bool operator ==(Vector6 a, Vector6 b) => a.M1 == b.M1 && a.M2 == b.M2 && a.M3 == b.M3 && a.M4 == b.M4 && a.M5 == b.M5 && a.M6 == b.M6;

        public static bool operator !=(Vector6 a, Vector6 b) => a.M1 != b.M1 || a.M2 != b.M2 || a.M3 != b.M3 || a.M4 != b.M4 || a.M5 != b.M5 || a.M6 != b.M6;

        #endregion

        #region Properties

        public double Chebyshev =>
            Math.Max
            (
                Math.Max
                (
                    Math.Max
                    (
                        Math.Abs(M1),
                        Math.Abs(M2)
                    ),
                    Math.Max
                    (
                        Math.Abs(M3),
                        Math.Abs(M4)
                    )
                ),
                Math.Max
                (
                    Math.Abs(M5),
                    Math.Abs(M6)
                )
            );

        public double Length => Math.Sqrt(LengthSqr);

        public double LengthSqr =>
            M1 * M1 +
            M2 * M2 +
            M3 * M3 +
            M4 * M4 +
            M5 * M5 +
            M6 * M6;

        public double M1 { get; set; }

        public double M2 { get; set; }

        public double M3 { get; set; }

        public double M4 { get; set; }

        public double M5 { get; set; }

        public double M6 { get; set; }

        public double Manhattan =>
            Math.Abs(M1) +
            Math.Abs(M2) +
            Math.Abs(M3) +
            Math.Abs(M4) +
            Math.Abs(M5) +
            Math.Abs(M6);

        public Vector6 Negated => -this;

        public Vector6 Normalized => this / Length;

        public Vector6 TowardsNegative1 => M1 < 0 ? this : -this;

        public Vector6 TowardsNegative2 => M2 < 0 ? this : -this;

        public Vector6 TowardsNegative3 => M3 < 0 ? this : -this;

        public Vector6 TowardsNegative4 => M4 < 0 ? this : -this;

        public Vector6 TowardsNegative5 => M5 < 0 ? this : -this;

        public Vector6 TowardsNegative6 => M6 < 0 ? this : -this;

        public Vector6 TowardsPositive1 => M1 > 0 ? this : -this;

        public Vector6 TowardsPositive2 => M2 > 0 ? this : -this;

        public Vector6 TowardsPositive3 => M3 > 0 ? this : -this;

        public Vector6 TowardsPositive4 => M4 > 0 ? this : -this;

        public Vector6 TowardsPositive5 => M5 > 0 ? this : -this;

        public Vector6 TowardsPositive6 => M6 > 0 ? this : -this;

        #endregion
    }
}
