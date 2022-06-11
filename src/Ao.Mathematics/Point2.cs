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
    public struct Point2 : IEquatable<Point2>
    {
        #region Constants

        public static readonly Point2 Origin = new Point2();

        #endregion

        #region Construction

        public Point2(double m1, double m2)
        {
            M1 = m1;
            M2 = m2;
        }

        #endregion

        #region Methods

        public double Distance(Point2 point) => (this - point).Length;

        public double DistanceSqr(Point2 point) => (this - point).LengthSqr;

        public bool Equals(Point2 x) => this == x;

        public Complex ToComplex() => new Complex(M1, M2);

        public Polar ToPolar() => new Polar(Math.Sqrt(M1 * M1 + M2 * M2), Math.Atan2(M2, M1));

        public Vector2 ToVector() => new Vector2(M1, M2);

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Point2)) return false;

            var y = (Point2)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M1.GetHashCode() ^
            M2.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Point2 FromComplex(Complex complex) => complex.ToPoint();

        public static Point2 FromPolar(Polar polar) => polar.ToPoint();

        public static Point2 FromVector(Vector2 vector) => vector.ToPoint();

        #endregion

        #region Operators

        public static Point2 operator +(Point2 a, Point2 b) => new Point2(a.M1 + b.M1, a.M2 + b.M2);

        public static Point2 operator +(Point2 a, Vector2 b) => new Point2(a.M1 + b.M1, a.M2 + b.M2);

        public static Point2 operator -(Point2 a, Vector2 b) => new Point2(a.M1 - b.M1, a.M2 - b.M2);

        public static Vector2 operator -(Point2 a, Point2 b) => new Vector2(a.M1 - b.M1, a.M2 - b.M2);

        public static Point2 operator *(Point2 a, double b) => new Point2(a.M1 * b, a.M2 * b);

        public static Point2 operator *(double a, Point2 b) => new Point2(a * b.M1, a * b.M2);

        public static Point2 operator /(Point2 a, double b) => new Point2(a.M1 / b, a.M2 / b);

        #endregion

        #region Operators

        public static bool operator ==(Point2 a, Point2 b) => a.M1 == b.M1 && a.M2 == b.M2;

        public static bool operator !=(Point2 a, Point2 b) => a.M1 != b.M1 || a.M2 != b.M2;

        #endregion

        #region Properties

        public double M1 { get; set; }

        public double M2 { get; set; }

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
