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
    public struct Matrix2x5 : IEquatable<Matrix2x5>
    {
        #region Constants

        public static readonly Matrix2x5 Zero = new Matrix2x5();

        #endregion

        #region Construction

        public Matrix2x5
        (
            double m11, double m12, double m13, double m14, double m15,
            double m21, double m22, double m23, double m24, double m25
        )
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M15 = m15;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M25 = m25;
        }

        #endregion

        #region Methods

        public bool Equals(Matrix2x5 x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Matrix2x5)) return false;

            var y = (Matrix2x5)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^ M14.GetHashCode() ^ M15.GetHashCode() ^
            M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode() ^ M24.GetHashCode() ^ M25.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix2x5 FromColumnAndRow(Vector2 column, Vector5 row)
        {
            return new Matrix2x5
            (
                column.M1 * row.M1,
                column.M1 * row.M2,
                column.M1 * row.M3,
                column.M1 * row.M4,
                column.M1 * row.M5,

                column.M2 * row.M1,
                column.M2 * row.M2,
                column.M2 * row.M3,
                column.M2 * row.M4,
                column.M2 * row.M5
            );
        }

        public static Matrix2x5 FromColumns(Vector2 column1, Vector2 column2, Vector2 column3, Vector2 column4, Vector2 column5)
        {
            return new Matrix2x5
            (
                column1.M1, column2.M1, column3.M1, column4.M1, column5.M1,
                column1.M2, column2.M2, column3.M2, column4.M2, column5.M2
            );
        }

        public static Matrix2x5 FromRows(Vector5 row1, Vector5 row2)
        {
            return new Matrix2x5
            (
                row1.M1, row1.M2, row1.M3, row1.M4, row1.M5,
                row2.M1, row2.M2, row2.M3, row2.M4, row2.M5
            );
        }

        #endregion

        #region Operators

        public static Matrix2x5 operator +(Matrix2x5 a) => a;

        public static Matrix2x5 operator +(Matrix2x5 a, Matrix2x5 b)
        {
            return new Matrix2x5
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13, a.M14 + b.M14, a.M15 + b.M15,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23, a.M24 + b.M24, a.M25 + b.M25
            );
        }

        public static Matrix2x5 operator -(Matrix2x5 a) => a.Negated;

        public static Matrix2x5 operator -(Matrix2x5 a, Matrix2x5 b)
        {
            return new Matrix2x5
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13, a.M14 - b.M14, a.M15 - b.M15,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23, a.M24 - b.M24, a.M25 - b.M25
            );
        }

        public static Matrix2x5 operator *(Matrix2x5 a, double b)
        {
            return new Matrix2x5
            (
                a.M11 * b, a.M12 * b, a.M13 * b, a.M14 * b, a.M15 * b,
                a.M21 * b, a.M22 * b, a.M23 * b, a.M24 * b, a.M25 * b
            );
        }

        public static Matrix2x5 operator *(double a, Matrix2x5 b)
        {
            return new Matrix2x5
            (
                a * b.M11, a * b.M12, a * b.M13, a * b.M14, a * b.M15,
                a * b.M21, a * b.M22, a * b.M23, a * b.M24, a * b.M25
            );
        }

        public static Matrix2x5 operator /(Matrix2x5 a, double b)
        {
            return new Matrix2x5
            (
                a.M11 / b, a.M12 / b, a.M13 / b, a.M14 / b, a.M15 / b,
                a.M21 / b, a.M22 / b, a.M23 / b, a.M24 / b, a.M25 / b
            );
        }

        public static Matrix5x2 operator ~(Matrix2x5 a) => a.Transposed;

        #endregion

        #region Operators

        public static Matrix2x2 operator *(Matrix2x5 a, Matrix5x2 b)
        {
            return new Matrix2x2
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52
            );
        }

        public static Matrix2x3 operator *(Matrix2x5 a, Matrix5x3 b)
        {
            return new Matrix2x3
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53
            );
        }

        public static Matrix2x4 operator *(Matrix2x5 a, Matrix5x4 b)
        {
            return new Matrix2x4
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44 + a.M15 * b.M54,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44 + a.M25 * b.M54
            );
        }

        public static Matrix2x5 operator *(Matrix2x5 a, Matrix5x5 b)
        {
            return new Matrix2x5
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44 + a.M15 * b.M54,
                a.M11 * b.M15 + a.M12 * b.M25 + a.M13 * b.M35 + a.M14 * b.M45 + a.M15 * b.M55,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44 + a.M25 * b.M54,
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35 + a.M24 * b.M45 + a.M25 * b.M55
            );
        }

        public static Matrix2x6 operator *(Matrix2x5 a, Matrix5x6 b)
        {
            return new Matrix2x6
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44 + a.M15 * b.M54,
                a.M11 * b.M15 + a.M12 * b.M25 + a.M13 * b.M35 + a.M14 * b.M45 + a.M15 * b.M55,
                a.M11 * b.M16 + a.M12 * b.M26 + a.M13 * b.M36 + a.M14 * b.M46 + a.M15 * b.M56,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44 + a.M25 * b.M54,
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35 + a.M24 * b.M45 + a.M25 * b.M55,
                a.M21 * b.M16 + a.M22 * b.M26 + a.M23 * b.M36 + a.M24 * b.M46 + a.M25 * b.M56
            );
        }

        #endregion

        #region Operators

        public static Vector2 operator *(Matrix2x5 a, Vector5 b)
        {
            return new Vector2
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3 + a.M14 * b.M4 + a.M15 * b.M5,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3 + a.M24 * b.M4 + a.M25 * b.M5
            );
        }

        public static Vector5 operator *(Vector2 a, Matrix2x5 b)
        {
            return new Vector5
            (
                a.M1 * b.M11 + a.M2 * b.M21,
                a.M1 * b.M12 + a.M2 * b.M22,
                a.M1 * b.M13 + a.M2 * b.M23,
                a.M1 * b.M14 + a.M2 * b.M24,
                a.M1 * b.M15 + a.M2 * b.M25
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix2x5 a, Matrix2x5 b) =>
            a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 && a.M14 == b.M14 && a.M15 == b.M15 &&
            a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 && a.M24 == b.M24 && a.M25 == b.M25;

        public static bool operator !=(Matrix2x5 a, Matrix2x5 b) =>
            a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 || a.M14 != b.M14 || a.M15 != b.M15 ||
            a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 || a.M24 != b.M24 || a.M25 != b.M25;

        #endregion

        #region Properties

        public Vector2 Column1 => new Vector2(M11, M21);

        public Vector2 Column2 => new Vector2(M12, M22);

        public Vector2 Column3 => new Vector2(M13, M23);

        public Vector2 Column4 => new Vector2(M14, M24);

        public Vector2 Column5 => new Vector2(M15, M25);

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M13 { get; set; }

        public double M14 { get; set; }

        public double M15 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double M23 { get; set; }

        public double M24 { get; set; }

        public double M25 { get; set; }

        public Matrix2x5 Negated
        {
            get
            {
                return new Matrix2x5
                (
                    -M11, -M12, -M13, -M14, -M15,
                    -M21, -M22, -M23, -M24, -M25
                );
            }
        }

        public Vector5 Row1 => new Vector5(M11, M12, M13, M14, M15);

        public Vector5 Row2 => new Vector5(M21, M22, M23, M24, M25);

        public Matrix5x2 Transposed
        {
            get
            {
                return new Matrix5x2
                (
                    M11, M21,
                    M12, M22,
                    M13, M23,
                    M14, M24,
                    M15, M25
                );
            }
        }

        #endregion
    }
}
