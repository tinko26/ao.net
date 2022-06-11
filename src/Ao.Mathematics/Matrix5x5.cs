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
    public struct Matrix5x5 : IEquatable<Matrix5x5>
    {
        #region Constants

        public static readonly Matrix5x5 Identity = new Matrix5x5(1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1);

        public static readonly Matrix5x5 Zero = new Matrix5x5();

        #endregion

        #region Construction

        public Matrix5x5
        (
            double m11, double m12, double m13, double m14, double m15,
            double m21, double m22, double m23, double m24, double m25,
            double m31, double m32, double m33, double m34, double m35,
            double m41, double m42, double m43, double m44, double m45,
            double m51, double m52, double m53, double m54, double m55
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
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M35 = m35;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
            M45 = m45;
            M51 = m51;
            M52 = m52;
            M53 = m53;
            M54 = m54;
            M55 = m55;
        }

        #endregion

        #region Methods

        public bool Equals(Matrix5x5 x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Matrix5x5)) return false;

            var y = (Matrix5x5)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^ M14.GetHashCode() ^ M15.GetHashCode() ^
            M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode() ^ M24.GetHashCode() ^ M25.GetHashCode() ^
            M31.GetHashCode() ^ M32.GetHashCode() ^ M33.GetHashCode() ^ M34.GetHashCode() ^ M35.GetHashCode() ^
            M41.GetHashCode() ^ M42.GetHashCode() ^ M43.GetHashCode() ^ M44.GetHashCode() ^ M45.GetHashCode() ^
            M51.GetHashCode() ^ M52.GetHashCode() ^ M53.GetHashCode() ^ M54.GetHashCode() ^ M55.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix5x5 FromColumnAndRow(Vector5 column, Vector5 row)
        {
            return new Matrix5x5
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
                column.M2 * row.M5,

                column.M3 * row.M1,
                column.M3 * row.M2,
                column.M3 * row.M3,
                column.M3 * row.M4,
                column.M3 * row.M5,

                column.M4 * row.M1,
                column.M4 * row.M2,
                column.M4 * row.M3,
                column.M4 * row.M4,
                column.M4 * row.M5,

                column.M5 * row.M1,
                column.M5 * row.M2,
                column.M5 * row.M3,
                column.M5 * row.M4,
                column.M5 * row.M5
            );
        }

        public static Matrix5x5 FromColumns(Vector5 column1, Vector5 column2, Vector5 column3, Vector5 column4, Vector5 column5)
        {
            return new Matrix5x5
            (
                column1.M1, column2.M1, column3.M1, column4.M1, column5.M1,
                column1.M2, column2.M2, column3.M2, column4.M2, column5.M2,
                column1.M3, column2.M3, column3.M3, column4.M3, column5.M3,
                column1.M4, column2.M4, column3.M4, column4.M4, column5.M4,
                column1.M5, column2.M5, column3.M5, column4.M5, column5.M5
            );
        }

        public static Matrix5x5 FromDiagonal(double m11, double m22, double m33, double m44, double m55)
        {
            return new Matrix5x5
            (
                m11, 0, 0, 0, 0,
                0, m22, 0, 0, 0,
                0, 0, m33, 0, 0,
                0, 0, 0, m44, 0,
                0, 0, 0, 0, m55
            );
        }

        public static Matrix5x5 FromDiagonal(Vector5 diagonal)
        {
            return new Matrix5x5
            (
                diagonal.M1, 0, 0, 0, 0,
                0, diagonal.M2, 0, 0, 0,
                0, 0, diagonal.M3, 0, 0,
                0, 0, 0, diagonal.M4, 0,
                0, 0, 0, 0, diagonal.M5
            );
        }

        public static Matrix5x5 FromRows(Vector5 row1, Vector5 row2, Vector5 row3, Vector5 row4, Vector5 row5)
        {
            return new Matrix5x5
            (
                row1.M1, row1.M2, row1.M3, row1.M4, row1.M5,
                row2.M1, row2.M2, row2.M3, row2.M4, row2.M5,
                row3.M1, row3.M2, row3.M3, row3.M4, row3.M5,
                row4.M1, row4.M2, row4.M3, row4.M4, row4.M5,
                row5.M1, row5.M2, row5.M3, row5.M4, row5.M5
            );
        }

        public static Matrix5x5 Householder(Vector5 vector) => Identity - 2 * FromColumnAndRow(vector, vector);

        #endregion

        #region Operators

        public static Matrix5x5 operator +(Matrix5x5 a) => a;

        public static Matrix5x5 operator +(Matrix5x5 a, Matrix5x5 b)
        {
            return new Matrix5x5
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13, a.M14 + b.M14, a.M15 + b.M15,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23, a.M24 + b.M24, a.M25 + b.M25,
                a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33, a.M34 + b.M34, a.M35 + b.M35,
                a.M41 + b.M41, a.M42 + b.M42, a.M43 + b.M43, a.M44 + b.M44, a.M45 + b.M45,
                a.M51 + b.M51, a.M52 + b.M52, a.M53 + b.M53, a.M54 + b.M54, a.M55 + b.M55
            );
        }

        public static Matrix5x5 operator -(Matrix5x5 a) => a.Negated;

        public static Matrix5x5 operator -(Matrix5x5 a, Matrix5x5 b)
        {
            return new Matrix5x5
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13, a.M14 - b.M14, a.M15 - b.M15,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23, a.M24 - b.M24, a.M25 - b.M25,
                a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33, a.M34 - b.M34, a.M35 - b.M35,
                a.M41 - b.M41, a.M42 - b.M42, a.M43 - b.M43, a.M44 - b.M44, a.M45 - b.M45,
                a.M51 - b.M51, a.M52 - b.M52, a.M53 - b.M53, a.M54 - b.M54, a.M55 - b.M55
            );
        }

        public static Matrix5x5 operator *(Matrix5x5 a, double b)
        {
            return new Matrix5x5
            (
                a.M11 * b, a.M12 * b, a.M13 * b, a.M14 * b, a.M15 * b,
                a.M21 * b, a.M22 * b, a.M23 * b, a.M24 * b, a.M25 * b,
                a.M31 * b, a.M32 * b, a.M33 * b, a.M34 * b, a.M35 * b,
                a.M41 * b, a.M42 * b, a.M43 * b, a.M44 * b, a.M45 * b,
                a.M51 * b, a.M52 * b, a.M53 * b, a.M54 * b, a.M55 * b
            );
        }

        public static Matrix5x5 operator *(double a, Matrix5x5 b)
        {
            return new Matrix5x5
            (
                a * b.M11, a * b.M12, a * b.M13, a * b.M14, a * b.M15,
                a * b.M21, a * b.M22, a * b.M23, a * b.M24, a * b.M25,
                a * b.M31, a * b.M32, a * b.M33, a * b.M34, a * b.M35,
                a * b.M41, a * b.M42, a * b.M43, a * b.M44, a * b.M45,
                a * b.M51, a * b.M52, a * b.M53, a * b.M54, a * b.M55
            );
        }

        public static Matrix5x5 operator /(Matrix5x5 a, double b)
        {
            return new Matrix5x5
            (
                a.M11 / b, a.M12 / b, a.M13 / b, a.M14 / b, a.M15 / b,
                a.M21 / b, a.M22 / b, a.M23 / b, a.M24 / b, a.M25 / b,
                a.M31 / b, a.M32 / b, a.M33 / b, a.M34 / b, a.M35 / b,
                a.M41 / b, a.M42 / b, a.M43 / b, a.M44 / b, a.M45 / b,
                a.M51 / b, a.M52 / b, a.M53 / b, a.M54 / b, a.M55 / b
            );
        }

        public static Matrix5x5 operator ~(Matrix5x5 a) => a.Transposed;

        public static Matrix5x5 operator !(Matrix5x5 a) => a.Inverted;

        #endregion

        #region Operators

        public static Matrix5x2 operator *(Matrix5x5 a, Matrix5x2 b)
        {
            return new Matrix5x2
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52
            );
        }

        public static Matrix5x3 operator *(Matrix5x5 a, Matrix5x3 b)
        {
            return new Matrix5x3
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43 + a.M35 * b.M53,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43 + a.M45 * b.M53,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33 + a.M54 * b.M43 + a.M55 * b.M53
            );
        }

        public static Matrix5x4 operator *(Matrix5x5 a, Matrix5x4 b)
        {
            return new Matrix5x4
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44 + a.M15 * b.M54,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44 + a.M25 * b.M54,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43 + a.M35 * b.M53,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44 + a.M35 * b.M54,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43 + a.M45 * b.M53,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44 + a.M45 * b.M54,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33 + a.M54 * b.M43 + a.M55 * b.M53,
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34 + a.M54 * b.M44 + a.M55 * b.M54
            );
        }

        public static Matrix5x5 operator *(Matrix5x5 a, Matrix5x5 b)
        {
            return new Matrix5x5
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
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35 + a.M24 * b.M45 + a.M25 * b.M55,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43 + a.M35 * b.M53,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44 + a.M35 * b.M54,
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35 + a.M34 * b.M45 + a.M35 * b.M55,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43 + a.M45 * b.M53,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44 + a.M45 * b.M54,
                a.M41 * b.M15 + a.M42 * b.M25 + a.M43 * b.M35 + a.M44 * b.M45 + a.M45 * b.M55,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33 + a.M54 * b.M43 + a.M55 * b.M53,
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34 + a.M54 * b.M44 + a.M55 * b.M54,
                a.M51 * b.M15 + a.M52 * b.M25 + a.M53 * b.M35 + a.M54 * b.M45 + a.M55 * b.M55
            );
        }

        public static Matrix5x6 operator *(Matrix5x5 a, Matrix5x6 b)
        {
            return new Matrix5x6
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
                a.M21 * b.M16 + a.M22 * b.M26 + a.M23 * b.M36 + a.M24 * b.M46 + a.M25 * b.M56,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43 + a.M35 * b.M53,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44 + a.M35 * b.M54,
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35 + a.M34 * b.M45 + a.M35 * b.M55,
                a.M31 * b.M16 + a.M32 * b.M26 + a.M33 * b.M36 + a.M34 * b.M46 + a.M35 * b.M56,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43 + a.M45 * b.M53,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44 + a.M45 * b.M54,
                a.M41 * b.M15 + a.M42 * b.M25 + a.M43 * b.M35 + a.M44 * b.M45 + a.M45 * b.M55,
                a.M41 * b.M16 + a.M42 * b.M26 + a.M43 * b.M36 + a.M44 * b.M46 + a.M45 * b.M56,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33 + a.M54 * b.M43 + a.M55 * b.M53,
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34 + a.M54 * b.M44 + a.M55 * b.M54,
                a.M51 * b.M15 + a.M52 * b.M25 + a.M53 * b.M35 + a.M54 * b.M45 + a.M55 * b.M55,
                a.M51 * b.M16 + a.M52 * b.M26 + a.M53 * b.M36 + a.M54 * b.M46 + a.M55 * b.M56
            );
        }

        #endregion

        #region Operators

        public static Vector5 operator *(Matrix5x5 a, Vector5 b)
        {
            return new Vector5
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3 + a.M14 * b.M4 + a.M15 * b.M5,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3 + a.M24 * b.M4 + a.M25 * b.M5,
                a.M31 * b.M1 + a.M32 * b.M2 + a.M33 * b.M3 + a.M34 * b.M4 + a.M35 * b.M5,
                a.M41 * b.M1 + a.M42 * b.M2 + a.M43 * b.M3 + a.M44 * b.M4 + a.M45 * b.M5,
                a.M51 * b.M1 + a.M52 * b.M2 + a.M53 * b.M3 + a.M54 * b.M4 + a.M55 * b.M5
            );
        }

        public static Vector5 operator *(Vector5 a, Matrix5x5 b)
        {
            return new Vector5
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31 + a.M4 * b.M41 + a.M5 * b.M51,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32 + a.M4 * b.M42 + a.M5 * b.M52,
                a.M1 * b.M13 + a.M2 * b.M23 + a.M3 * b.M33 + a.M4 * b.M43 + a.M5 * b.M53,
                a.M1 * b.M14 + a.M2 * b.M24 + a.M3 * b.M34 + a.M4 * b.M44 + a.M5 * b.M54,
                a.M1 * b.M15 + a.M2 * b.M25 + a.M3 * b.M35 + a.M4 * b.M45 + a.M5 * b.M55
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix5x5 a, Matrix5x5 b) =>
            a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 && a.M14 == b.M14 && a.M15 == b.M15 &&
            a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 && a.M24 == b.M24 && a.M25 == b.M25 &&
            a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33 && a.M34 == b.M34 && a.M35 == b.M35 &&
            a.M41 == b.M41 && a.M42 == b.M42 && a.M43 == b.M43 && a.M44 == b.M44 && a.M45 == b.M45 &&
            a.M51 == b.M51 && a.M52 == b.M52 && a.M53 == b.M53 && a.M54 == b.M54 && a.M55 == b.M55;

        public static bool operator !=(Matrix5x5 a, Matrix5x5 b) =>
            a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 || a.M14 != b.M14 || a.M15 != b.M15 ||
            a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 || a.M24 != b.M24 || a.M25 != b.M25 ||
            a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33 || a.M34 != b.M34 || a.M35 != b.M35 ||
            a.M41 != b.M41 || a.M42 != b.M42 || a.M43 != b.M43 || a.M44 != b.M44 || a.M45 != b.M45 ||
            a.M51 != b.M51 || a.M52 != b.M52 || a.M53 != b.M53 || a.M54 != b.M54 || a.M55 != b.M55;

        #endregion

        #region Properties

        public Matrix5x5 Adjugate => AdjugateFromCofactors;

        public Matrix5x5 AdjugateFromCofactors
        {
            get
            {
                return new Matrix5x5
                (
                    Cofactor11, Cofactor21, Cofactor31, Cofactor41, Cofactor51,
                    Cofactor12, Cofactor22, Cofactor32, Cofactor42, Cofactor52,
                    Cofactor13, Cofactor23, Cofactor33, Cofactor43, Cofactor53,
                    Cofactor14, Cofactor24, Cofactor34, Cofactor44, Cofactor54,
                    Cofactor15, Cofactor25, Cofactor35, Cofactor45, Cofactor55
                );
            }
        }

        public Matrix5x5 Cofactor
        {
            get
            {
                return new Matrix5x5
                (
                    Cofactor11, Cofactor12, Cofactor13, Cofactor14, Cofactor15,
                    Cofactor21, Cofactor22, Cofactor23, Cofactor24, Cofactor25,
                    Cofactor31, Cofactor32, Cofactor33, Cofactor34, Cofactor35,
                    Cofactor41, Cofactor42, Cofactor43, Cofactor44, Cofactor45,
                    Cofactor51, Cofactor52, Cofactor53, Cofactor54, Cofactor55
                );
            }
        }

        public double Cofactor11 => +Minor11;

        public double Cofactor12 => -Minor12;

        public double Cofactor13 => +Minor13;

        public double Cofactor14 => -Minor14;

        public double Cofactor15 => +Minor15;

        public double Cofactor21 => -Minor21;

        public double Cofactor22 => +Minor22;

        public double Cofactor23 => -Minor23;

        public double Cofactor24 => +Minor24;

        public double Cofactor25 => -Minor25;

        public double Cofactor31 => +Minor31;

        public double Cofactor32 => -Minor32;

        public double Cofactor33 => +Minor33;

        public double Cofactor34 => -Minor34;

        public double Cofactor35 => +Minor35;

        public double Cofactor41 => -Minor41;

        public double Cofactor42 => +Minor42;

        public double Cofactor43 => -Minor43;

        public double Cofactor44 => +Minor44;

        public double Cofactor45 => -Minor45;

        public double Cofactor51 => +Minor51;

        public double Cofactor52 => -Minor52;

        public double Cofactor53 => +Minor53;

        public double Cofactor54 => -Minor54;

        public double Cofactor55 => +Minor55;

        public Vector5 Column1 => new Vector5(M11, M21, M31, M41, M51);

        public Vector5 Column2 => new Vector5(M12, M22, M32, M42, M52);

        public Vector5 Column3 => new Vector5(M13, M23, M33, M43, M53);

        public Vector5 Column4 => new Vector5(M14, M24, M34, M44, M54);

        public Vector5 Column5 => new Vector5(M15, M25, M35, M45, M55);

        public double Determinant
        {
            get
            {
                return
                    M11 * (M22 * (M33 * (M44 * M55 - M45 * M54) - M34 * (M43 * M55 - M45 * M53) + M35 * (M43 * M54 - M44 * M53)) - M23 * (M32 * (M44 * M55 - M45 * M54) - M34 * (M42 * M55 - M45 * M52) + M35 * (M42 * M54 - M44 * M52)) + M24 * (M32 * (M43 * M55 - M45 * M53) - M33 * (M42 * M55 - M45 * M52) + M35 * (M42 * M53 - M43 * M52)) - M25 * (M32 * (M43 * M54 - M44 * M53) - M33 * (M42 * M54 - M44 * M52) + M34 * (M42 * M53 - M43 * M52))) -
                    M12 * (M21 * (M33 * (M44 * M55 - M45 * M54) - M34 * (M43 * M55 - M45 * M53) + M35 * (M43 * M54 - M44 * M53)) - M23 * (M31 * (M44 * M55 - M45 * M54) - M34 * (M41 * M55 - M45 * M51) + M35 * (M41 * M54 - M44 * M51)) + M24 * (M31 * (M43 * M55 - M45 * M53) - M33 * (M41 * M55 - M45 * M51) + M35 * (M41 * M53 - M43 * M51)) - M25 * (M31 * (M43 * M54 - M44 * M53) - M33 * (M41 * M54 - M44 * M51) + M34 * (M41 * M53 - M43 * M51))) +
                    M13 * (M21 * (M32 * (M44 * M55 - M45 * M54) - M34 * (M42 * M55 - M45 * M52) + M35 * (M42 * M54 - M44 * M52)) - M22 * (M31 * (M44 * M55 - M45 * M54) - M34 * (M41 * M55 - M45 * M51) + M35 * (M41 * M54 - M44 * M51)) + M24 * (M31 * (M42 * M55 - M45 * M52) - M32 * (M41 * M55 - M45 * M51) + M35 * (M41 * M52 - M42 * M51)) - M25 * (M31 * (M42 * M54 - M44 * M52) - M32 * (M41 * M54 - M44 * M51) + M34 * (M41 * M52 - M42 * M51))) -
                    M14 * (M21 * (M32 * (M43 * M55 - M45 * M53) - M33 * (M42 * M55 - M45 * M52) + M35 * (M42 * M53 - M43 * M52)) - M22 * (M31 * (M43 * M55 - M45 * M53) - M33 * (M41 * M55 - M45 * M51) + M35 * (M41 * M53 - M43 * M51)) + M23 * (M31 * (M42 * M55 - M45 * M52) - M32 * (M41 * M55 - M45 * M51) + M35 * (M41 * M52 - M42 * M51)) - M25 * (M31 * (M42 * M53 - M43 * M52) - M32 * (M41 * M53 - M43 * M51) + M33 * (M41 * M52 - M42 * M51))) +
                    M15 * (M21 * (M32 * (M43 * M54 - M44 * M53) - M33 * (M42 * M54 - M44 * M52) + M34 * (M42 * M53 - M43 * M52)) - M22 * (M31 * (M43 * M54 - M44 * M53) - M33 * (M41 * M54 - M44 * M51) + M34 * (M41 * M53 - M43 * M51)) + M23 * (M31 * (M42 * M54 - M44 * M52) - M32 * (M41 * M54 - M44 * M51) + M34 * (M41 * M52 - M42 * M51)) - M24 * (M31 * (M42 * M53 - M43 * M52) - M32 * (M41 * M53 - M43 * M51) + M33 * (M41 * M52 - M42 * M51)));
            }
        }

        public Vector5 Diagonal => new Vector5(M11, M22, M33, M44, M55);

        public Matrix5x5 Inverted => Adjugate / Determinant;

        public Matrix5x5 Lower
        {
            get
            {
                return new Matrix5x5
                (
                    M11, 0, 0, 0, 0,
                    M21, M22, 0, 0, 0,
                    M31, M32, M33, 0, 0,
                    M41, M42, M43, M44, 0,
                    M51, M52, M53, M54, M55
                );
            }
        }

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

        public double M31 { get; set; }

        public double M32 { get; set; }

        public double M33 { get; set; }

        public double M34 { get; set; }

        public double M35 { get; set; }

        public double M41 { get; set; }

        public double M42 { get; set; }

        public double M43 { get; set; }

        public double M44 { get; set; }

        public double M45 { get; set; }

        public double M51 { get; set; }

        public double M52 { get; set; }

        public double M53 { get; set; }

        public double M54 { get; set; }

        public double M55 { get; set; }

        public double Minor11 => Submatrix11.Determinant;

        public double Minor12 => Submatrix12.Determinant;

        public double Minor13 => Submatrix13.Determinant;

        public double Minor14 => Submatrix14.Determinant;

        public double Minor15 => Submatrix15.Determinant;

        public double Minor21 => Submatrix21.Determinant;

        public double Minor22 => Submatrix22.Determinant;

        public double Minor23 => Submatrix23.Determinant;

        public double Minor24 => Submatrix24.Determinant;

        public double Minor25 => Submatrix25.Determinant;

        public double Minor31 => Submatrix31.Determinant;

        public double Minor32 => Submatrix32.Determinant;

        public double Minor33 => Submatrix33.Determinant;

        public double Minor34 => Submatrix34.Determinant;

        public double Minor35 => Submatrix35.Determinant;

        public double Minor41 => Submatrix41.Determinant;

        public double Minor42 => Submatrix42.Determinant;

        public double Minor43 => Submatrix43.Determinant;

        public double Minor44 => Submatrix44.Determinant;

        public double Minor45 => Submatrix45.Determinant;

        public double Minor51 => Submatrix51.Determinant;

        public double Minor52 => Submatrix52.Determinant;

        public double Minor53 => Submatrix53.Determinant;

        public double Minor54 => Submatrix54.Determinant;

        public double Minor55 => Submatrix55.Determinant;

        public Matrix5x5 Negated
        {
            get
            {
                return new Matrix5x5
                (
                    -M11, -M12, -M13, -M14, -M15,
                    -M21, -M22, -M23, -M24, -M25,
                    -M31, -M32, -M33, -M34, -M35,
                    -M41, -M42, -M43, -M44, -M45,
                    -M51, -M52, -M53, -M54, -M55
                );
            }
        }

        public Vector5 Row1 => new Vector5(M11, M12, M13, M14, M15);

        public Vector5 Row2 => new Vector5(M21, M22, M23, M24, M25);

        public Vector5 Row3 => new Vector5(M31, M32, M33, M34, M35);

        public Vector5 Row4 => new Vector5(M41, M42, M43, M44, M45);

        public Vector5 Row5 => new Vector5(M51, M52, M53, M54, M55);

        public Matrix5x5 Squared => this * this;

        public Matrix4x4 Submatrix11 => new Matrix4x4(M22, M23, M24, M25, M32, M33, M34, M35, M42, M43, M44, M45, M52, M53, M54, M55);

        public Matrix4x4 Submatrix12 => new Matrix4x4(M21, M23, M24, M25, M31, M33, M34, M35, M41, M43, M44, M45, M51, M53, M54, M55);

        public Matrix4x4 Submatrix13 => new Matrix4x4(M21, M22, M24, M25, M31, M32, M34, M35, M41, M42, M44, M45, M51, M52, M54, M55);

        public Matrix4x4 Submatrix14 => new Matrix4x4(M21, M22, M23, M25, M31, M32, M33, M35, M41, M42, M43, M45, M51, M52, M53, M55);

        public Matrix4x4 Submatrix15 => new Matrix4x4(M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44, M51, M52, M53, M54);

        public Matrix4x4 Submatrix21 => new Matrix4x4(M12, M13, M14, M15, M32, M33, M34, M35, M42, M43, M44, M45, M52, M53, M54, M55);

        public Matrix4x4 Submatrix22 => new Matrix4x4(M11, M13, M14, M15, M31, M33, M34, M35, M41, M43, M44, M45, M51, M53, M54, M55);

        public Matrix4x4 Submatrix23 => new Matrix4x4(M11, M12, M14, M15, M31, M32, M34, M35, M41, M42, M44, M45, M51, M52, M54, M55);

        public Matrix4x4 Submatrix24 => new Matrix4x4(M11, M12, M13, M15, M31, M32, M33, M35, M41, M42, M43, M45, M51, M52, M53, M55);

        public Matrix4x4 Submatrix25 => new Matrix4x4(M11, M12, M13, M14, M31, M32, M33, M34, M41, M42, M43, M44, M51, M52, M53, M54);

        public Matrix4x4 Submatrix31 => new Matrix4x4(M12, M13, M14, M15, M22, M23, M24, M25, M42, M43, M44, M45, M52, M53, M54, M55);

        public Matrix4x4 Submatrix32 => new Matrix4x4(M11, M13, M14, M15, M21, M23, M24, M25, M41, M43, M44, M45, M51, M53, M54, M55);

        public Matrix4x4 Submatrix33 => new Matrix4x4(M11, M12, M14, M15, M21, M22, M24, M25, M41, M42, M44, M45, M51, M52, M54, M55);

        public Matrix4x4 Submatrix34 => new Matrix4x4(M11, M12, M13, M15, M21, M22, M23, M25, M41, M42, M43, M45, M51, M52, M53, M55);

        public Matrix4x4 Submatrix35 => new Matrix4x4(M11, M12, M13, M14, M21, M22, M23, M24, M41, M42, M43, M44, M51, M52, M53, M54);

        public Matrix4x4 Submatrix41 => new Matrix4x4(M12, M13, M14, M15, M22, M23, M24, M25, M32, M33, M34, M35, M52, M53, M54, M55);

        public Matrix4x4 Submatrix42 => new Matrix4x4(M11, M13, M14, M15, M21, M23, M24, M25, M31, M33, M34, M35, M51, M53, M54, M55);

        public Matrix4x4 Submatrix43 => new Matrix4x4(M11, M12, M14, M15, M21, M22, M24, M25, M31, M32, M34, M35, M51, M52, M54, M55);

        public Matrix4x4 Submatrix44 => new Matrix4x4(M11, M12, M13, M15, M21, M22, M23, M25, M31, M32, M33, M35, M51, M52, M53, M55);

        public Matrix4x4 Submatrix45 => new Matrix4x4(M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M51, M52, M53, M54);

        public Matrix4x4 Submatrix51 => new Matrix4x4(M12, M13, M14, M15, M22, M23, M24, M25, M32, M33, M34, M35, M42, M43, M44, M45);

        public Matrix4x4 Submatrix52 => new Matrix4x4(M11, M13, M14, M15, M21, M23, M24, M25, M31, M33, M34, M35, M41, M43, M44, M45);

        public Matrix4x4 Submatrix53 => new Matrix4x4(M11, M12, M14, M15, M21, M22, M24, M25, M31, M32, M34, M35, M41, M42, M44, M45);

        public Matrix4x4 Submatrix54 => new Matrix4x4(M11, M12, M13, M15, M21, M22, M23, M25, M31, M32, M33, M35, M41, M42, M43, M45);

        public Matrix4x4 Submatrix55 => new Matrix4x4(M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);

        public double Trace => M11 + M22 + M33 + M44 + M55;

        public Matrix5x5 Transposed
        {
            get
            {
                return new Matrix5x5
                (
                    M11, M21, M31, M41, M51,
                    M12, M22, M32, M42, M52,
                    M13, M23, M33, M43, M53,
                    M14, M24, M34, M44, M54,
                    M15, M25, M35, M45, M55
                );
            }
        }

        public Matrix5x5 Upper
        {
            get
            {
                return new Matrix5x5
                (
                    M11, M12, M13, M14, M15,
                    0, M22, M23, M24, M25,
                    0, 0, M33, M34, M35,
                    0, 0, 0, M44, M45,
                    0, 0, 0, 0, M55
                );
            }
        }

        #endregion
    }
}
