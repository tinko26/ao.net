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
    public struct Matrix2x3 : IEquatable<Matrix2x3>
    {
        #region Constants

        public static readonly Matrix2x3 Zero = new Matrix2x3();

        #endregion

        #region Construction

        public Matrix2x3
        (
            double m11, double m12, double m13,
            double m21, double m22, double m23
        )
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
        }

        #endregion

        #region Methods

        public bool Equals(Matrix2x3 x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Matrix2x3)) return false;

            var y = (Matrix2x3)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^
            M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix2x3 FromColumnAndRow(Vector2 column, Vector3 row)
        {
            return new Matrix2x3
            (
                column.M1 * row.M1,
                column.M1 * row.M2,
                column.M1 * row.M3,

                column.M2 * row.M1,
                column.M2 * row.M2,
                column.M2 * row.M3
            );
        }

        public static Matrix2x3 FromColumns(Vector2 column1, Vector2 column2, Vector2 column3)
        {
            return new Matrix2x3
            (
                column1.M1, column2.M1, column3.M1,
                column1.M2, column2.M2, column3.M2
            );
        }

        public static Matrix2x3 FromRows(Vector3 row1, Vector3 row2)
        {
            return new Matrix2x3
            (
                row1.M1, row1.M2, row1.M3,
                row2.M1, row2.M2, row2.M3
            );
        }

        #endregion

        #region Operators

        public static Matrix2x3 operator +(Matrix2x3 a) => a;

        public static Matrix2x3 operator +(Matrix2x3 a, Matrix2x3 b)
        {
            return new Matrix2x3
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23
            );
        }

        public static Matrix2x3 operator -(Matrix2x3 a) => a.Negated;

        public static Matrix2x3 operator -(Matrix2x3 a, Matrix2x3 b)
        {
            return new Matrix2x3
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23
            );
        }

        public static Matrix2x3 operator *(Matrix2x3 a, double b)
        {
            return new Matrix2x3
            (
                a.M11 * b, a.M12 * b, a.M13 * b,
                a.M21 * b, a.M22 * b, a.M23 * b
            );
        }

        public static Matrix2x3 operator *(double a, Matrix2x3 b)
        {
            return new Matrix2x3
            (
                a * b.M11, a * b.M12, a * b.M13,
                a * b.M21, a * b.M22, a * b.M23
            );
        }

        public static Matrix2x3 operator /(Matrix2x3 a, double b)
        {
            return new Matrix2x3
            (
                a.M11 / b, a.M12 / b, a.M13 / b,
                a.M21 / b, a.M22 / b, a.M23 / b
            );
        }

        public static Matrix3x2 operator ~(Matrix2x3 a) => a.Transposed;

        #endregion

        #region Operators

        public static Matrix2x2 operator *(Matrix2x3 a, Matrix3x2 b)
        {
            return new Matrix2x2
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32
            );
        }

        public static Matrix2x3 operator *(Matrix2x3 a, Matrix3x3 b)
        {
            return new Matrix2x3
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33
            );
        }

        public static Matrix2x4 operator *(Matrix2x3 a, Matrix3x4 b)
        {
            return new Matrix2x4
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34
            );
        }

        public static Matrix2x5 operator *(Matrix2x3 a, Matrix3x5 b)
        {
            return new Matrix2x5
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
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35
            );
        }

        public static Matrix2x6 operator *(Matrix2x3 a, Matrix3x6 b)
        {
            return new Matrix2x6
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
                a.M21 * b.M16 + a.M22 * b.M26 + a.M23 * b.M36
            );
        }

        #endregion

        #region Operators

        public static Vector2 operator *(Matrix2x3 a, Vector3 b)
        {
            return new Vector2
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3
            );
        }

        public static Vector3 operator *(Vector2 a, Matrix2x3 b)
        {
            return new Vector3
            (
                a.M1 * b.M11 + a.M2 * b.M21,
                a.M1 * b.M12 + a.M2 * b.M22,
                a.M1 * b.M13 + a.M2 * b.M23
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix2x3 a, Matrix2x3 b) =>
            a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 &&
            a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23;

        public static bool operator !=(Matrix2x3 a, Matrix2x3 b) =>
            a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 ||
            a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23;

        #endregion

        #region Properties

        public Vector2 Column1 => new Vector2(M11, M21);

        public Vector2 Column2 => new Vector2(M12, M22);

        public Vector2 Column3 => new Vector2(M13, M23);

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M13 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double M23 { get; set; }

        public Matrix2x3 Negated
        {
            get
            {
                return new Matrix2x3
                (
                    -M11, -M12, -M13,
                    -M21, -M22, -M23
                );
            }
        }

        public Vector3 Row1 => new Vector3(M11, M12, M13);

        public Vector3 Row2 => new Vector3(M21, M22, M23);

        public Matrix3x2 Transposed
        {
            get
            {
                return new Matrix3x2
                (
                    M11, M21,
                    M12, M22,
                    M13, M23
                );
            }
        }

        #endregion
    }
}
