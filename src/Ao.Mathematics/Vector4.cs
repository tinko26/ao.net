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
    public struct Vector4 : IEquatable<Vector4>
    {
        #region Constants

        public static readonly Vector4 Unit1 = new Vector4(1, 0, 0, 0);

        public static readonly Vector4 Unit2 = new Vector4(0, 1, 0, 0);

        public static readonly Vector4 Unit3 = new Vector4(0, 0, 1, 0);

        public static readonly Vector4 Unit4 = new Vector4(0, 0, 0, 1);

        public static readonly Vector4 Zero = new Vector4();

        #endregion

        #region Construction

        public Vector4(double m1, double m2, double m3, double m4)
        {
            M1 = m1;
            M2 = m2;
            M3 = m3;
            M4 = m4;
        }

        #endregion

        #region Methods

        public bool Equals(Vector4 x) => this == x;

        public double Norm(double p)
        {
            var s1 = Math.Pow(Math.Abs(M1), p);
            var s2 = Math.Pow(Math.Abs(M2), p);
            var s3 = Math.Pow(Math.Abs(M3), p);
            var s4 = Math.Pow(Math.Abs(M4), p);

            var s = s1 + s2 + s3 + s4;

            return Math.Pow(s, 1 / p);
        }

        public Point3 ToAffinePoint() => new Point3(M1 / M4, M2 / M4, M3 / M4);

        public Vector3 ToAffineVector() => new Vector3(M1, M2, M3);

        public Point4 ToPoint() => new Point4(M1, M2, M3, M4);

        public Quaternion ToQuaternion() => new Quaternion(M1, M2, M3, M4);

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Vector4)) return false;

            var y = (Vector4)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M1.GetHashCode() ^
            M2.GetHashCode() ^
            M3.GetHashCode() ^
            M4.GetHashCode();

        #endregion

        #region Methods (Static)

        public static double Angle(Vector4 a, Vector4 b)
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

        public static Vector4 Cross(Vector4 a, Vector4 b, Vector4 c)
        {
            var t1 = b.M1 * c.M2 - c.M1 * b.M2;
            var t2 = b.M1 * c.M3 - c.M1 * b.M3;
            var t3 = b.M1 * c.M4 - c.M1 * b.M4;
            var t4 = b.M2 * c.M3 - c.M2 * b.M3;
            var t5 = b.M2 * c.M4 - c.M2 * b.M4;
            var t6 = b.M3 * c.M4 - c.M3 * b.M4;

            return new Vector4
            (
                +(a.M2 * t6 - a.M3 * t5 + a.M4 * t4),
                -(a.M1 * t6 - a.M3 * t3 + a.M4 * t2),
                +(a.M1 * t5 - a.M2 * t3 + a.M4 * t1),
                -(a.M1 * t4 - a.M2 * t2 + a.M3 * t1)
            );
        }

        public static double Determinant(Vector4 a, Vector4 b, Vector4 c, Vector4 d)
        {
            var t1 = a.M3 * b.M4 - a.M4 * b.M4;
            var t2 = a.M3 * c.M4 - a.M4 * c.M4;
            var t3 = a.M3 * d.M4 - a.M4 * d.M4;
            var t4 = b.M3 * c.M4 - b.M4 * c.M4;
            var t5 = b.M3 * d.M4 - b.M4 * d.M4;
            var t6 = c.M3 * d.M4 - c.M4 * d.M4;

            return
                a.M1 * (b.M2 * t6 - c.M2 * t5 + d.M2 * t4) -
                b.M1 * (a.M2 * t6 - c.M2 * t3 + d.M2 * t2) +
                c.M1 * (a.M2 * t5 - b.M2 * t3 + d.M2 * t1) -
                d.M1 * (a.M2 * t4 - b.M2 * t2 + c.M2 * t1);
        }

        public static Vector4 FromAffinePoint(Point3 point) => new Vector4(point.X, point.Y, point.Z, 1);

        public static Vector4 FromAffineVector(Vector3 vector) => new Vector4(vector.M1, vector.M2, vector.M3, 0);

        public static Vector4 FromQuaternion(Quaternion quaternion) => quaternion.ToVector();

        public static Vector4 Project(Vector4 a, Vector4 b) => a * b / b.LengthSqr * b;

        #endregion

        #region Operators

        public static Vector4 operator +(Vector4 a) => a;

        public static Vector4 operator +(Vector4 a, Vector4 b) => new Vector4(a.M1 + b.M1, a.M2 + b.M2, a.M3 + b.M3, a.M4 + b.M4);

        public static Vector4 operator -(Vector4 a) => new Vector4(-a.M1, -a.M2, -a.M3, -a.M4);

        public static Vector4 operator -(Vector4 a, Vector4 b) => new Vector4(a.M1 - b.M1, a.M2 - b.M2, a.M3 - b.M3, a.M4 - b.M4);

        public static double operator *(Vector4 a, Vector4 b) => a.M1 * b.M1 + a.M2 * b.M2 + a.M3 * b.M3 + a.M4 * b.M4;

        public static Vector4 operator *(Vector4 a, double b) => new Vector4(a.M1 * b, a.M2 * b, a.M3 * b, a.M4 * b);

        public static Vector4 operator *(double a, Vector4 b) => new Vector4(a * b.M1, a * b.M2, a * b.M3, a * b.M4);

        public static Vector4 operator /(Vector4 a, double b) => new Vector4(a.M1 / b, a.M2 / b, a.M3 / b, a.M4 / b);

        #endregion

        #region Operators

        public static bool operator ==(Vector4 a, Vector4 b) => a.M1 == b.M1 && a.M2 == b.M2 && a.M3 == b.M3 && a.M4 == b.M4;

        public static bool operator !=(Vector4 a, Vector4 b) => a.M1 != b.M1 || a.M2 != b.M2 || a.M3 != b.M3 || a.M4 != b.M4;

        #endregion

        #region Properties

        public double Chebyshev =>
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
            );

        public double Length => Math.Sqrt(LengthSqr);

        public double LengthSqr =>
            M1 * M1 +
            M2 * M2 +
            M3 * M3 +
            M4 * M4;

        public double M1 { get; set; }

        public double M2 { get; set; }

        public double M3 { get; set; }

        public double M4 { get; set; }

        public double Manhattan =>
            Math.Abs(M1) +
            Math.Abs(M2) +
            Math.Abs(M3) +
            Math.Abs(M4);

        public Vector4 Negated => -this;

        public Vector4 Normalized => this / Length;

        public Vector4 TowardsNegative1 => M1 < 0 ? this : -this;

        public Vector4 TowardsNegative2 => M2 < 0 ? this : -this;

        public Vector4 TowardsNegative3 => M3 < 0 ? this : -this;

        public Vector4 TowardsNegative4 => M4 < 0 ? this : -this;

        public Vector4 TowardsPositive1 => M1 > 0 ? this : -this;

        public Vector4 TowardsPositive2 => M2 > 0 ? this : -this;

        public Vector4 TowardsPositive3 => M3 > 0 ? this : -this;

        public Vector4 TowardsPositive4 => M4 > 0 ? this : -this;

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
