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
    public struct Point4 : IEquatable<Point4>
    {
        #region Constants

        public static readonly Point4 Origin = new Point4();

        #endregion

        #region Construction

        public Point4(double m1, double m2, double m3, double m4)
        {
            M1 = m1;
            M2 = m2;
            M3 = m3;
            M4 = m4;
        }

        #endregion

        #region Methods

        public bool Equals(Point4 x) => this == x;

        public double Distance(Point4 point) => (this - point).Length;

        public double DistanceSqr(Point4 point) => (this - point).LengthSqr;

        public Vector4 ToVector() => new Vector4(M1, M2, M3, M4);

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Point4)) return false;

            var y = (Point4)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M1.GetHashCode() ^
            M2.GetHashCode() ^
            M3.GetHashCode() ^
            M4.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Point4 FromVector(Vector4 vector) => vector.ToPoint();

        #endregion

        #region Operators

        public static Point4 operator +(Point4 a, Point4 b) => new Point4(a.M1 + b.M1, a.M2 + b.M2, a.M3 + b.M3, a.M4 + b.M4);

        public static Point4 operator +(Point4 a, Vector4 b) => new Point4(a.M1 + b.M1, a.M2 + b.M2, a.M3 + b.M3, a.M4 + b.M4);

        public static Point4 operator -(Point4 a, Vector4 b) => new Point4(a.M1 - b.M1, a.M2 - b.M2, a.M3 - b.M3, a.M3 - b.M4);

        public static Vector4 operator -(Point4 a, Point4 b) => new Vector4(a.M1 - b.M1, a.M2 - b.M2, a.M3 - b.M3, a.M4 - b.M4);

        public static Point4 operator *(Point4 a, double b) => new Point4(a.M1 * b, a.M2 * b, a.M3 * b, a.M4 * b);

        public static Point4 operator *(double a, Point4 b) => new Point4(a * b.M1, a * b.M2, a * b.M3, a * b.M4);

        public static Point4 operator /(Point4 a, double b) => new Point4(a.M1 / b, a.M2 / b, a.M3 / b, a.M4 / b);

        #endregion

        #region Operators

        public static bool operator ==(Point4 a, Point4 b) => a.M1 == b.M1 && a.M2 == b.M2 && a.M3 == b.M3 && a.M4 == b.M4;

        public static bool operator !=(Point4 a, Point4 b) => a.M1 != b.M1 || a.M2 != b.M2 || a.M3 != b.M3 || a.M4 != b.M4;

        #endregion

        #region Properties

        public double M1 { get; set; }

        public double M2 { get; set; }

        public double M3 { get; set; }

        public double M4 { get; set; }

        public double W
        {
            get => M4;
            set => M4 = value;
        }

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

        public double Z
        {
            get => M3;
            set => M3 = value;
        }

        #endregion
    }
}
