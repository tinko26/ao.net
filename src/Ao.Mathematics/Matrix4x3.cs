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
    public struct Matrix4x3 : IEquatable<Matrix4x3>
    {
        #region Constants

        public static readonly Matrix4x3 Zero = new Matrix4x3();

        #endregion

        #region Construction

        public Matrix4x3
        (
            double m11, double m12, double m13,
            double m21, double m22, double m23,
            double m31, double m32, double m33,
            double m41, double m42, double m43
        )
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M41 = m41;
            M42 = m42;
            M43 = m43;
        }

        #endregion

        #region Methods

        public bool Equals(Matrix4x3 x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Matrix4x3)) return false;

            var y = (Matrix4x3)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^
            M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode() ^
            M31.GetHashCode() ^ M32.GetHashCode() ^ M33.GetHashCode() ^
            M41.GetHashCode() ^ M42.GetHashCode() ^ M43.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix4x3 FromColumnAndRow(Vector4 column, Vector3 row)
        {
            return new Matrix4x3
            (
                column.M1 * row.M1,
                column.M1 * row.M2,
                column.M1 * row.M3,

                column.M2 * row.M1,
                column.M2 * row.M2,
                column.M2 * row.M3,

                column.M3 * row.M1,
                column.M3 * row.M2,
                column.M3 * row.M3,

                column.M4 * row.M1,
                column.M4 * row.M2,
                column.M4 * row.M3
            );
        }

        public static Matrix4x3 FromColumns(Vector4 column1, Vector4 column2, Vector4 column3)
        {
            return new Matrix4x3
            (
                column1.M1, column2.M1, column3.M1,
                column1.M2, column2.M2, column3.M2,
                column1.M3, column2.M3, column3.M3,
                column1.M4, column2.M4, column3.M4
            );
        }

        public static Matrix4x3 FromRows(Vector3 row1, Vector3 row2, Vector3 row3, Vector3 row4)
        {
            return new Matrix4x3
            (
                row1.M1, row1.M2, row1.M3,
                row2.M1, row2.M2, row2.M3,
                row3.M1, row3.M2, row3.M3,
                row4.M1, row4.M2, row4.M3
            );
        }

        #endregion

        #region Operators

        public static Matrix4x3 operator +(Matrix4x3 a) => a;

        public static Matrix4x3 operator +(Matrix4x3 a, Matrix4x3 b)
        {
            return new Matrix4x3
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23,
                a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33,
                a.M41 + b.M41, a.M42 + b.M42, a.M43 + b.M43
            );
        }

        public static Matrix4x3 operator -(Matrix4x3 a) => a.Negated;

        public static Matrix4x3 operator -(Matrix4x3 a, Matrix4x3 b)
        {
            return new Matrix4x3
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23,
                a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33,
                a.M41 - b.M41, a.M42 - b.M42, a.M43 - b.M43
            );
        }

        public static Matrix4x3 operator *(Matrix4x3 a, double b)
        {
            return new Matrix4x3
            (
                a.M11 * b, a.M12 * b, a.M13 * b,
                a.M21 * b, a.M22 * b, a.M23 * b,
                a.M31 * b, a.M32 * b, a.M33 * b,
                a.M41 * b, a.M42 * b, a.M43 * b
            );
        }

        public static Matrix4x3 operator *(double a, Matrix4x3 b)
        {
            return new Matrix4x3
            (
                a * b.M11, a * b.M12, a * b.M13,
                a * b.M21, a * b.M22, a * b.M23,
                a * b.M31, a * b.M32, a * b.M33,
                a * b.M41, a * b.M42, a * b.M43
            );
        }

        public static Matrix4x3 operator /(Matrix4x3 a, double b)
        {
            return new Matrix4x3
            (
                a.M11 / b, a.M12 / b, a.M13 / b,
                a.M21 / b, a.M22 / b, a.M23 / b,
                a.M31 / b, a.M32 / b, a.M33 / b,
                a.M41 / b, a.M42 / b, a.M43 / b
            );
        }

        public static Matrix3x4 operator ~(Matrix4x3 a) => a.Transposed;

        #endregion

        #region Operators

        public static Matrix4x2 operator *(Matrix4x3 a, Matrix3x2 b)
        {
            return new Matrix4x2
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32
            );
        }

        public static Matrix4x3 operator *(Matrix4x3 a, Matrix3x3 b)
        {
            return new Matrix4x3
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33
            );
        }

        public static Matrix4x4 operator *(Matrix4x3 a, Matrix3x4 b)
        {
            return new Matrix4x4
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34
            );
        }

        public static Matrix4x5 operator *(Matrix4x3 a, Matrix3x5 b)
        {
            return new Matrix4x5
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34,
                a.M11 * b.M15 + a.M12 * b.M25 + a.M13 * b.M35,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34,
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34,
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34,
                a.M41 * b.M15 + a.M42 * b.M25 + a.M43 * b.M35
            );
        }

        public static Matrix4x6 operator *(Matrix4x3 a, Matrix3x6 b)
        {
            return new Matrix4x6
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34,
                a.M11 * b.M15 + a.M12 * b.M25 + a.M13 * b.M35,
                a.M11 * b.M16 + a.M12 * b.M26 + a.M13 * b.M36,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34,
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35,
                a.M21 * b.M16 + a.M22 * b.M26 + a.M23 * b.M36,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34,
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35,
                a.M31 * b.M16 + a.M32 * b.M26 + a.M33 * b.M36,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34,
                a.M41 * b.M15 + a.M42 * b.M25 + a.M43 * b.M35,
                a.M41 * b.M16 + a.M42 * b.M26 + a.M43 * b.M36
            );
        }

        #endregion

        #region Operators

        public static Vector4 operator *(Matrix4x3 a, Vector3 b)
        {
            return new Vector4
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3,
                a.M31 * b.M1 + a.M32 * b.M2 + a.M33 * b.M3,
                a.M41 * b.M1 + a.M42 * b.M2 + a.M43 * b.M3
            );
        }

        public static Vector3 operator *(Vector4 a, Matrix4x3 b)
        {
            return new Vector3
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31 + a.M4 * b.M41,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32 + a.M4 * b.M42,
                a.M1 * b.M13 + a.M2 * b.M23 + a.M3 * b.M33 + a.M4 * b.M43
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix4x3 a, Matrix4x3 b) =>
            a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 &&
            a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 &&
            a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33 &&
            a.M41 == b.M41 && a.M42 == b.M42 && a.M43 == b.M43;

        public static bool operator !=(Matrix4x3 a, Matrix4x3 b) =>
            a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 ||
            a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 ||
            a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33 ||
            a.M41 != b.M41 || a.M42 != b.M42 || a.M43 != b.M43;

        #endregion

        #region Properties

        public Vector4 Column1 => new Vector4(M11, M21, M31, M41);

        public Vector4 Column2 => new Vector4(M12, M22, M32, M42);

        public Vector4 Column3 => new Vector4(M13, M23, M33, M43);

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M13 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double M23 { get; set; }

        public double M31 { get; set; }

        public double M32 { get; set; }

        public double M33 { get; set; }

        public double M41 { get; set; }

        public double M42 { get; set; }

        public double M43 { get; set; }

        public Matrix4x3 Negated
        {
            get
            {
                return new Matrix4x3
                (
                    -M11, -M12, -M13,
                    -M21, -M22, -M23,
                    -M31, -M32, -M33,
                    -M41, -M42, -M43
                );
            }
        }

        public Vector3 Row1 => new Vector3(M11, M12, M13);

        public Vector3 Row2 => new Vector3(M21, M22, M23);

        public Vector3 Row3 => new Vector3(M31, M32, M33);

        public Vector3 Row4 => new Vector3(M41, M42, M43);

        public Matrix3x4 Transposed
        {
            get
            {
                return new Matrix3x4
                (
                    M11, M21, M31, M41,
                    M12, M22, M32, M42,
                    M13, M23, M33, M43
                );
            }
        }

        #endregion
    }
}
