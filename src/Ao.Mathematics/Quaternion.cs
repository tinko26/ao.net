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
    public struct Quaternion : IEquatable<Quaternion>
    {
        #region Constants

        public static readonly Quaternion I = new Quaternion(0, 1, 0, 0);

        public static readonly Quaternion J = new Quaternion(0, 0, 1, 0);

        public static readonly Quaternion K = new Quaternion(0, 0, 0, 1);

        #endregion

        #region Construction

        public Quaternion(double real)
        {
            Real = real;

            Imaginary1 = 0;
            Imaginary2 = 0;
            Imaginary3 = 0;
        }

        public Quaternion(double real, double imaginary1, double imaginary2, double imaginary3)
        {
            Real = real;

            Imaginary1 = imaginary1;
            Imaginary2 = imaginary2;
            Imaginary3 = imaginary3;
        }

        #endregion

        #region Methods

        public bool Equals(Quaternion x) => this == x;

        public Vector4 ToVector() => new Vector4(Real, Imaginary1, Imaginary2, Imaginary3);

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Quaternion)) return false;

            var y = (Quaternion)x;

            return this == y;
        }

        public override int GetHashCode() =>
            Real.GetHashCode() ^
            Imaginary1.GetHashCode() ^
            Imaginary2.GetHashCode() ^
            Imaginary3.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Quaternion FromImaginary1(double imaginary1) => new Quaternion(0, imaginary1, 0, 0);

        public static Quaternion FromImaginary2(double imaginary2) => new Quaternion(0, 0, imaginary2, 0);

        public static Quaternion FromImaginary3(double imaginary3) => new Quaternion(0, 0, 0, imaginary3);

        public static Quaternion FromReal(double real) => new Quaternion(real);

        public static Quaternion FromVector(Vector4 vector) => vector.ToQuaternion();

        public static Quaternion Rotation(double angle, Vector3 vector)
        {
            var a = angle * 0.5;

            var ca = Math.Cos(a);
            var sa = Math.Sin(a);

            var n = vector.Normalized;

            return new Quaternion(ca, sa * n.M1, sa * n.M2, sa * n.M3);
        }

        #endregion

        #region Operators

        public static Quaternion operator +(Quaternion a) => a;

        public static Quaternion operator +(Quaternion a, Quaternion b) => new Quaternion(a.Real + b.Real, a.Imaginary1 + b.Imaginary1, a.Imaginary2 + b.Imaginary2, a.Imaginary3 + b.Imaginary3);

        public static Quaternion operator +(Quaternion a, double b) => new Quaternion(a.Real + b, a.Imaginary1, a.Imaginary2, a.Imaginary3);

        public static Quaternion operator +(double a, Quaternion b) => new Quaternion(a + b.Real, b.Imaginary1, b.Imaginary2, b.Imaginary3);

        public static Quaternion operator -(Quaternion a) => new Quaternion(-a.Real, -a.Imaginary1, -a.Imaginary2, -a.Imaginary3);

        public static Quaternion operator -(Quaternion a, Quaternion b) => new Quaternion(a.Real - b.Real, a.Imaginary1 - b.Imaginary1, a.Imaginary2 - b.Imaginary2, a.Imaginary3 - b.Imaginary3);

        public static Quaternion operator -(Quaternion a, double b) => new Quaternion(a.Real - b, a.Imaginary1, a.Imaginary2, a.Imaginary3);

        public static Quaternion operator -(double a, Quaternion b) => new Quaternion(a - b.Real, -b.Imaginary1, -b.Imaginary2, -b.Imaginary3);

        public static Quaternion operator *(Quaternion a, Quaternion b)
        {
            var a1 = a.Real;
            var a2 = a.Imaginary1;
            var a3 = a.Imaginary2;
            var a4 = a.Imaginary3;

            var b1 = b.Real;
            var b2 = b.Imaginary1;
            var b3 = b.Imaginary2;
            var b4 = b.Imaginary3;

            return new Quaternion
            (
                b1 * a1 - b2 * a2 - b3 * a3 - b4 * a4,
                b1 * a2 + b2 * a1 - b3 * a4 + b4 * a3,
                b1 * a3 + b2 * a4 + b3 * a1 - b4 * a2,
                b1 * a4 - b2 * a3 + b3 * a2 + b4 * a1
            );
        }

        public static Quaternion operator *(Quaternion a, double b) => new Quaternion(a.Real * b, a.Imaginary1 * b, a.Imaginary2 * b, a.Imaginary3 * b);

        public static Quaternion operator *(double a, Quaternion b) => new Quaternion(a * b.Real, a * b.Imaginary1, a * b.Imaginary2, a * b.Imaginary3);

        public static Quaternion operator /(Quaternion a, Quaternion b) => a * b.Conjugate / b.ModulusSqr;

        public static Quaternion operator /(Quaternion a, double b) => new Quaternion(a.Real / b, a.Imaginary1 / b, a.Imaginary2 / b, a.Imaginary3 / b);

        public static Quaternion operator /(double a, Quaternion b) => a * b.Conjugate / b.ModulusSqr;

        #endregion

        #region Operators

        public static bool operator ==(Quaternion a, Quaternion b) => a.Real == b.Real && a.Imaginary1 == b.Imaginary1 && a.Imaginary2 == b.Imaginary2 && a.Imaginary3 == b.Imaginary3;

        public static bool operator ==(Quaternion a, double b) => a.Real == b && a.Imaginary1 == 0 && a.Imaginary2 == 0 && a.Imaginary3 == 0;

        public static bool operator ==(double a, Quaternion b) => a == b.Real && 0 == b.Imaginary1 && 0 == b.Imaginary2 && 0 == b.Imaginary3;

        public static bool operator !=(Quaternion a, Quaternion b) => a.Real != b.Real || a.Imaginary1 != b.Imaginary1 || a.Imaginary2 != b.Imaginary2 || a.Imaginary3 != b.Imaginary3;

        public static bool operator !=(Quaternion a, double b) => a.Real != b || a.Imaginary1 != 0 || a.Imaginary2 != 0 || a.Imaginary3 != 0;

        public static bool operator !=(double a, Quaternion b) => a != b.Real || 0 != b.Imaginary1 || 0 != b.Imaginary2 || 0 != b.Imaginary3;

        #endregion

        #region Properties

        public Quaternion Conjugate => new Quaternion(Real, -Imaginary1, -Imaginary2, -Imaginary3);

        public double Imaginary1 { get; set; }

        public double Imaginary2 { get; set; }

        public double Imaginary3 { get; set; }

        public double Modulus => Math.Sqrt(ModulusSqr);

        public double ModulusSqr =>
            Real * Real +
            Imaginary1 * Imaginary1 +
            Imaginary2 * Imaginary2 +
            Imaginary3 * Imaginary3;

        public double Real { get; set; }

        public double RotationAngle
        {
            get
            {
                var r = Real;

                var i1 = Imaginary1;
                var i2 = Imaginary2;
                var i3 = Imaginary3;

                var m = Math.Sqrt(i1 * i1 + i2 * i2 + i3 * i3);

                var y = m;
                var x = r;

                return 2.0 * Math.Atan2(y, x);
            }
        }

        public Vector3 RotationAxis
        {
            get
            {
                var i1 = Imaginary1;
                var i2 = Imaginary2;
                var i3 = Imaginary3;

                var m = Math.Sqrt(i1 * i1 + i2 * i2 + i3 * i3);

                var x = i1 / m;
                var y = i2 / m;
                var z = i3 / m;

                return new Vector3(x, y, z);
            }
        }

        public Matrix3x3 RotationMatrix
        {
            get
            {
                var r = Real;

                var i = Imaginary1;
                var j = Imaginary2;
                var k = Imaginary3;

                var ii = i * i;
                var ij = i * j;
                var ik = i * k;
                var ir = i * r;
                var jj = j * j;
                var jk = j * k;
                var jr = j * r;
                var kk = k * k;
                var kr = k * r;

                var m11 = 1.0 - 2.0 * (jj + kk);
                var m22 = 1.0 - 2.0 * (ii + kk);
                var m33 = 1.0 - 2.0 * (ii + jj);

                var m12 = 2.0 * (ij - kr);
                var m13 = 2.0 * (ik + jr);

                var m21 = 2.0 * (ij + kr);
                var m23 = 2.0 * (jk - ir);

                var m31 = 2.0 * (ik - jr);
                var m32 = 2.0 * (jk + ir);

                return new Matrix3x3
                (
                    m11, m12, m13,
                    m21, m22, m23,
                    m31, m32, m33
                );
            }
        }

        #endregion
    }
}
