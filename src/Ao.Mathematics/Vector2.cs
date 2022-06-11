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
    public struct Vector2 : IEquatable<Vector2>
    {
        #region Constants

        public static readonly Vector2 Unit1 = new Vector2(1, 0);

        public static readonly Vector2 Unit2 = new Vector2(0, 1);

        public static readonly Vector2 Zero = new Vector2();

        #endregion

        #region Construction

        public Vector2(double m1, double m2)
        {
            M1 = m1;
            M2 = m2;
        }

        #endregion

        #region Methods

        public bool Equals(Vector2 x) => this == x;

        public double Norm(double p)
        {
            var s1 = Math.Pow(Math.Abs(M1), p);
            var s2 = Math.Pow(Math.Abs(M2), p);

            var s = s1 + s2;

            return Math.Pow(s, 1 / p);
        }

        public Complex ToComplex() => new Complex(M1, M2);

        public Point2 ToPoint() => new Point2(M1, M2);

        public Polar ToPolar() => new Polar(Length, Math.Atan2(M2, M1));

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Vector2)) return false;

            var y = (Vector2)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M1.GetHashCode() ^
            M2.GetHashCode();

        #endregion

        #region Methods (Static)

        public static double Angle(Vector2 a, Vector2 b)
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

        public static double Area(Vector2 a, Vector2 b) => Math.Abs(a % b);

        public static double Determinant(Vector2 a, Vector2 b) => a % b;

        public static Vector2 FromComplex(Complex complex) => complex.ToVector();

        public static Vector2 FromPoint(Point2 point) => point.ToVector();

        public static Vector2 FromPolar(Polar polar) => polar.ToVector();

        public static Vector2 Project(Vector2 a, Vector2 b) => a * b / b.LengthSqr * b;

        #endregion

        #region Operators

        public static Vector2 operator +(Vector2 a) => a;

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.M1 + b.M1, a.M2 + b.M2);

        public static Vector2 operator -(Vector2 a) => new Vector2(-a.M1, -a.M2);

        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.M1 - b.M1, a.M2 - b.M2);

        public static double operator *(Vector2 a, Vector2 b) => a.M1 * b.M1 + a.M2 * b.M2;

        public static Vector2 operator *(Vector2 a, double b) => new Vector2(a.M1 * b, a.M2 * b);

        public static Vector2 operator *(double a, Vector2 b) => new Vector2(a * b.M1, a * b.M2);

        public static Vector2 operator /(Vector2 a, double b) => new Vector2(a.M1 / b, a.M2 / b);

        public static double operator %(Vector2 a, Vector2 b) => a.M1 * b.M2 - a.M2 * b.M1;

        #endregion

        #region Operators

        public static bool operator ==(Vector2 a, Vector2 b) => a.M1 == b.M1 && a.M2 == b.M2;

        public static bool operator !=(Vector2 a, Vector2 b) => a.M1 != b.M1 || a.M2 != b.M2;

        #endregion

        #region Properties

        public double Chebyshev =>
            Math.Max
            (
                Math.Abs(M1),
                Math.Abs(M2)
            );

        public double Length => Math.Sqrt(LengthSqr);

        public double LengthSqr =>
            M1 * M1 +
            M2 * M2;

        public double M1 { get; set; }

        public double M2 { get; set; }

        public double Manhattan =>
            Math.Abs(M1) +
            Math.Abs(M2);

        public Vector2 Negated => -this;

        public Vector2 Normalized => this / Length;

        public Vector2 OrthogonalCCW => new Vector2(-M2, M1);

        public Vector2 OrthogonalCW => new Vector2(M2, -M1);

        public double Slope => M2 / M1;

        public Vector2 TowardsNegative1 => M1 < 0 ? this : -this;

        public Vector2 TowardsNegative2 => M2 < 0 ? this : -this;

        public Vector2 TowardsPositive1 => M1 > 0 ? this : -this;

        public Vector2 TowardsPositive2 => M2 > 0 ? this : -this;

        public double X
        {
            get => M1;
            set => M1 = value;
        }

        public double Y
        {
            get => M2;
            set => M2 = value;
        }

        #endregion
    }
}
