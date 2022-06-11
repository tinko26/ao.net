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
    public struct Matrix6x6 : IEquatable<Matrix6x6>
    {
        #region Constants

        public static readonly Matrix6x6 Identity = new Matrix6x6(1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1);

        public static readonly Matrix6x6 Zero = new Matrix6x6();

        #endregion

        #region Construction

        public Matrix6x6
        (
            double m11, double m12, double m13, double m14, double m15, double m16,
            double m21, double m22, double m23, double m24, double m25, double m26,
            double m31, double m32, double m33, double m34, double m35, double m36,
            double m41, double m42, double m43, double m44, double m45, double m46,
            double m51, double m52, double m53, double m54, double m55, double m56,
            double m61, double m62, double m63, double m64, double m65, double m66
        )
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M15 = m15;
            M16 = m16;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M25 = m25;
            M26 = m26;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M35 = m35;
            M36 = m36;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
            M45 = m45;
            M46 = m46;
            M51 = m51;
            M52 = m52;
            M53 = m53;
            M54 = m54;
            M55 = m55;
            M56 = m56;
            M61 = m61;
            M62 = m62;
            M63 = m63;
            M64 = m64;
            M65 = m65;
            M66 = m66;
        }

        #endregion

        #region Methods

        public bool Equals(Matrix6x6 x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Matrix6x6)) return false;

            var y = (Matrix6x6)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^ M14.GetHashCode() ^ M15.GetHashCode() ^ M16.GetHashCode() ^
            M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode() ^ M24.GetHashCode() ^ M25.GetHashCode() ^ M26.GetHashCode() ^
            M31.GetHashCode() ^ M32.GetHashCode() ^ M33.GetHashCode() ^ M34.GetHashCode() ^ M35.GetHashCode() ^ M36.GetHashCode() ^
            M41.GetHashCode() ^ M42.GetHashCode() ^ M43.GetHashCode() ^ M44.GetHashCode() ^ M45.GetHashCode() ^ M46.GetHashCode() ^
            M51.GetHashCode() ^ M52.GetHashCode() ^ M53.GetHashCode() ^ M54.GetHashCode() ^ M55.GetHashCode() ^ M56.GetHashCode() ^
            M61.GetHashCode() ^ M62.GetHashCode() ^ M63.GetHashCode() ^ M64.GetHashCode() ^ M65.GetHashCode() ^ M66.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix6x6 FromColumnAndRow(Vector6 column, Vector6 row)
        {
            return new Matrix6x6
            (
                column.M1 * row.M1,
                column.M1 * row.M2,
                column.M1 * row.M3,
                column.M1 * row.M4,
                column.M1 * row.M5,
                column.M1 * row.M6,

                column.M2 * row.M1,
                column.M2 * row.M2,
                column.M2 * row.M3,
                column.M2 * row.M4,
                column.M2 * row.M5,
                column.M2 * row.M6,

                column.M3 * row.M1,
                column.M3 * row.M2,
                column.M3 * row.M3,
                column.M3 * row.M4,
                column.M3 * row.M5,
                column.M3 * row.M6,

                column.M4 * row.M1,
                column.M4 * row.M2,
                column.M4 * row.M3,
                column.M4 * row.M4,
                column.M4 * row.M5,
                column.M4 * row.M6,

                column.M5 * row.M1,
                column.M5 * row.M2,
                column.M5 * row.M3,
                column.M5 * row.M4,
                column.M5 * row.M5,
                column.M5 * row.M6,

                column.M6 * row.M1,
                column.M6 * row.M2,
                column.M6 * row.M3,
                column.M6 * row.M4,
                column.M6 * row.M5,
                column.M6 * row.M6
            );
        }

        public static Matrix6x6 FromColumns(Vector6 column1, Vector6 column2, Vector6 column3, Vector6 column4, Vector6 column5, Vector6 column6)
        {
            return new Matrix6x6
            (
                column1.M1, column2.M1, column3.M1, column4.M1, column5.M1, column6.M1,
                column1.M2, column2.M2, column3.M2, column4.M2, column5.M2, column6.M2,
                column1.M3, column2.M3, column3.M3, column4.M3, column5.M3, column6.M3,
                column1.M4, column2.M4, column3.M4, column4.M4, column5.M4, column6.M4,
                column1.M5, column2.M5, column3.M5, column4.M5, column5.M5, column6.M5,
                column1.M6, column2.M6, column3.M6, column4.M6, column5.M6, column6.M6
            );
        }

        public static Matrix6x6 FromDiagonal(double m11, double m22, double m33, double m44, double m55, double m66)
        {
            return new Matrix6x6
            (
                m11, 0, 0, 0, 0, 0,
                0, m22, 0, 0, 0, 0,
                0, 0, m33, 0, 0, 0,
                0, 0, 0, m44, 0, 0,
                0, 0, 0, 0, m55, 0,
                0, 0, 0, 0, 0, m66
            );
        }

        public static Matrix6x6 FromDiagonal(Vector6 diagonal)
        {
            return new Matrix6x6
            (
                diagonal.M1, 0, 0, 0, 0, 0,
                0, diagonal.M2, 0, 0, 0, 0,
                0, 0, diagonal.M3, 0, 0, 0,
                0, 0, 0, diagonal.M4, 0, 0,
                0, 0, 0, 0, diagonal.M5, 0,
                0, 0, 0, 0, 0, diagonal.M6
            );
        }

        public static Matrix6x6 FromRows(Vector6 row1, Vector6 row2, Vector6 row3, Vector6 row4, Vector6 row5, Vector6 row6)
        {
            return new Matrix6x6
            (
                row1.M1, row1.M2, row1.M3, row1.M4, row1.M5, row1.M6,
                row2.M1, row2.M2, row2.M3, row2.M4, row2.M5, row2.M6,
                row3.M1, row3.M2, row3.M3, row3.M4, row3.M5, row3.M6,
                row4.M1, row4.M2, row4.M3, row4.M4, row4.M5, row4.M6,
                row5.M1, row5.M2, row5.M3, row5.M4, row5.M5, row5.M6,
                row6.M1, row6.M2, row6.M3, row6.M4, row6.M5, row6.M6
            );
        }

        public static Matrix6x6 Householder(Vector6 vector) => Identity - 2 * FromColumnAndRow(vector, vector);

        #endregion

        #region Operators

        public static Matrix6x6 operator +(Matrix6x6 a) => a;

        public static Matrix6x6 operator +(Matrix6x6 a, Matrix6x6 b)
        {
            return new Matrix6x6
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13, a.M14 + b.M14, a.M15 + b.M15, a.M16 + b.M16,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23, a.M24 + b.M24, a.M25 + b.M25, a.M26 + b.M26,
                a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33, a.M34 + b.M34, a.M35 + b.M35, a.M36 + b.M36,
                a.M41 + b.M41, a.M42 + b.M42, a.M43 + b.M43, a.M44 + b.M44, a.M45 + b.M45, a.M46 + b.M46,
                a.M51 + b.M51, a.M52 + b.M52, a.M53 + b.M53, a.M54 + b.M54, a.M55 + b.M55, a.M56 + b.M56,
                a.M61 + b.M61, a.M62 + b.M62, a.M63 + b.M63, a.M64 + b.M64, a.M65 + b.M65, a.M66 + b.M66
            );
        }

        public static Matrix6x6 operator -(Matrix6x6 a) => a.Negated;

        public static Matrix6x6 operator -(Matrix6x6 a, Matrix6x6 b)
        {
            return new Matrix6x6
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13, a.M14 - b.M14, a.M15 - b.M15, a.M16 - b.M16,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23, a.M24 - b.M24, a.M25 - b.M25, a.M26 - b.M26,
                a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33, a.M34 - b.M34, a.M35 - b.M35, a.M36 - b.M36,
                a.M41 - b.M41, a.M42 - b.M42, a.M43 - b.M43, a.M44 - b.M44, a.M45 - b.M45, a.M46 - b.M46,
                a.M51 - b.M51, a.M52 - b.M52, a.M53 - b.M53, a.M54 - b.M54, a.M55 - b.M55, a.M56 - b.M56,
                a.M61 - b.M61, a.M62 - b.M62, a.M63 - b.M63, a.M64 - b.M64, a.M65 - b.M65, a.M66 - b.M66
            );
        }

        public static Matrix6x6 operator *(Matrix6x6 a, double b)
        {
            return new Matrix6x6
            (
                a.M11 * b, a.M12 * b, a.M13 * b, a.M14 * b, a.M15 * b, a.M16 * b,
                a.M21 * b, a.M22 * b, a.M23 * b, a.M24 * b, a.M25 * b, a.M26 * b,
                a.M31 * b, a.M32 * b, a.M33 * b, a.M34 * b, a.M35 * b, a.M36 * b,
                a.M41 * b, a.M42 * b, a.M43 * b, a.M44 * b, a.M45 * b, a.M46 * b,
                a.M51 * b, a.M52 * b, a.M53 * b, a.M54 * b, a.M55 * b, a.M56 * b,
                a.M61 * b, a.M62 * b, a.M63 * b, a.M64 * b, a.M65 * b, a.M66 * b
            );
        }

        public static Matrix6x6 operator *(double a, Matrix6x6 b)
        {
            return new Matrix6x6
            (
                a * b.M11, a * b.M12, a * b.M13, a * b.M14, a * b.M15, a * b.M16,
                a * b.M21, a * b.M22, a * b.M23, a * b.M24, a * b.M25, a * b.M26,
                a * b.M31, a * b.M32, a * b.M33, a * b.M34, a * b.M35, a * b.M36,
                a * b.M41, a * b.M42, a * b.M43, a * b.M44, a * b.M45, a * b.M46,
                a * b.M51, a * b.M52, a * b.M53, a * b.M54, a * b.M55, a * b.M56,
                a * b.M61, a * b.M62, a * b.M63, a * b.M64, a * b.M65, a * b.M66
            );
        }

        public static Matrix6x6 operator /(Matrix6x6 a, double b)
        {
            return new Matrix6x6
            (
                a.M11 / b, a.M12 / b, a.M13 / b, a.M14 / b, a.M15 / b, a.M16 / b,
                a.M21 / b, a.M22 / b, a.M23 / b, a.M24 / b, a.M25 / b, a.M26 / b,
                a.M31 / b, a.M32 / b, a.M33 / b, a.M34 / b, a.M35 / b, a.M36 / b,
                a.M41 / b, a.M42 / b, a.M43 / b, a.M44 / b, a.M45 / b, a.M46 / b,
                a.M51 / b, a.M52 / b, a.M53 / b, a.M54 / b, a.M55 / b, a.M56 / b,
                a.M61 / b, a.M62 / b, a.M63 / b, a.M64 / b, a.M65 / b, a.M66 / b
            );
        }

        public static Matrix6x6 operator ~(Matrix6x6 a) => a.Transposed;

        public static Matrix6x6 operator !(Matrix6x6 a) => a.Inverted;

        #endregion

        #region Operators

        public static Matrix6x2 operator *(Matrix6x6 a, Matrix6x2 b)
        {
            return new Matrix6x2
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51 + a.M16 * b.M61,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52 + a.M16 * b.M62,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51 + a.M26 * b.M61,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52 + a.M26 * b.M62,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51 + a.M36 * b.M61,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52 + a.M36 * b.M62,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51 + a.M46 * b.M61,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52 + a.M46 * b.M62,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51 + a.M56 * b.M61,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52 + a.M56 * b.M62,

                a.M61 * b.M11 + a.M62 * b.M21 + a.M63 * b.M31 + a.M64 * b.M41 + a.M65 * b.M51 + a.M66 * b.M61,
                a.M61 * b.M12 + a.M62 * b.M22 + a.M63 * b.M32 + a.M64 * b.M42 + a.M65 * b.M52 + a.M66 * b.M62
            );
        }

        public static Matrix6x3 operator *(Matrix6x6 a, Matrix6x3 b)
        {
            return new Matrix6x3
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51 + a.M16 * b.M61,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52 + a.M16 * b.M62,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53 + a.M16 * b.M63,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51 + a.M26 * b.M61,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52 + a.M26 * b.M62,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53 + a.M26 * b.M63,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51 + a.M36 * b.M61,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52 + a.M36 * b.M62,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43 + a.M35 * b.M53 + a.M36 * b.M63,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51 + a.M46 * b.M61,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52 + a.M46 * b.M62,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43 + a.M45 * b.M53 + a.M46 * b.M63,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51 + a.M56 * b.M61,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52 + a.M56 * b.M62,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33 + a.M54 * b.M43 + a.M55 * b.M53 + a.M56 * b.M63,

                a.M61 * b.M11 + a.M62 * b.M21 + a.M63 * b.M31 + a.M64 * b.M41 + a.M65 * b.M51 + a.M66 * b.M61,
                a.M61 * b.M12 + a.M62 * b.M22 + a.M63 * b.M32 + a.M64 * b.M42 + a.M65 * b.M52 + a.M66 * b.M62,
                a.M61 * b.M13 + a.M62 * b.M23 + a.M63 * b.M33 + a.M64 * b.M43 + a.M65 * b.M53 + a.M66 * b.M63
            );
        }

        public static Matrix6x4 operator *(Matrix6x6 a, Matrix6x4 b)
        {
            return new Matrix6x4
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51 + a.M16 * b.M61,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52 + a.M16 * b.M62,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53 + a.M16 * b.M63,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44 + a.M15 * b.M54 + a.M16 * b.M64,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51 + a.M26 * b.M61,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52 + a.M26 * b.M62,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53 + a.M26 * b.M63,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44 + a.M25 * b.M54 + a.M26 * b.M64,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51 + a.M36 * b.M61,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52 + a.M36 * b.M62,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43 + a.M35 * b.M53 + a.M36 * b.M63,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44 + a.M35 * b.M54 + a.M36 * b.M64,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51 + a.M46 * b.M61,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52 + a.M46 * b.M62,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43 + a.M45 * b.M53 + a.M46 * b.M63,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44 + a.M45 * b.M54 + a.M46 * b.M64,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51 + a.M56 * b.M61,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52 + a.M56 * b.M62,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33 + a.M54 * b.M43 + a.M55 * b.M53 + a.M56 * b.M63,
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34 + a.M54 * b.M44 + a.M55 * b.M54 + a.M56 * b.M64,

                a.M61 * b.M11 + a.M62 * b.M21 + a.M63 * b.M31 + a.M64 * b.M41 + a.M65 * b.M51 + a.M66 * b.M61,
                a.M61 * b.M12 + a.M62 * b.M22 + a.M63 * b.M32 + a.M64 * b.M42 + a.M65 * b.M52 + a.M66 * b.M62,
                a.M61 * b.M13 + a.M62 * b.M23 + a.M63 * b.M33 + a.M64 * b.M43 + a.M65 * b.M53 + a.M66 * b.M63,
                a.M61 * b.M14 + a.M62 * b.M24 + a.M63 * b.M34 + a.M64 * b.M44 + a.M65 * b.M54 + a.M66 * b.M64
            );
        }

        public static Matrix6x5 operator *(Matrix6x6 a, Matrix6x5 b)
        {
            return new Matrix6x5
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51 + a.M16 * b.M61,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52 + a.M16 * b.M62,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53 + a.M16 * b.M63,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44 + a.M15 * b.M54 + a.M16 * b.M64,
                a.M11 * b.M15 + a.M12 * b.M25 + a.M13 * b.M35 + a.M14 * b.M45 + a.M15 * b.M55 + a.M16 * b.M65,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51 + a.M26 * b.M61,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52 + a.M26 * b.M62,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53 + a.M26 * b.M63,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44 + a.M25 * b.M54 + a.M26 * b.M64,
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35 + a.M24 * b.M45 + a.M25 * b.M55 + a.M26 * b.M65,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51 + a.M36 * b.M61,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52 + a.M36 * b.M62,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43 + a.M35 * b.M53 + a.M36 * b.M63,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44 + a.M35 * b.M54 + a.M36 * b.M64,
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35 + a.M34 * b.M45 + a.M35 * b.M55 + a.M36 * b.M65,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51 + a.M46 * b.M61,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52 + a.M46 * b.M62,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43 + a.M45 * b.M53 + a.M46 * b.M63,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44 + a.M45 * b.M54 + a.M46 * b.M64,
                a.M41 * b.M15 + a.M42 * b.M25 + a.M43 * b.M35 + a.M44 * b.M45 + a.M45 * b.M55 + a.M46 * b.M65,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51 + a.M56 * b.M61,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52 + a.M56 * b.M62,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33 + a.M54 * b.M43 + a.M55 * b.M53 + a.M56 * b.M63,
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34 + a.M54 * b.M44 + a.M55 * b.M54 + a.M56 * b.M64,
                a.M51 * b.M15 + a.M52 * b.M25 + a.M53 * b.M35 + a.M54 * b.M45 + a.M55 * b.M55 + a.M56 * b.M65,

                a.M61 * b.M11 + a.M62 * b.M21 + a.M63 * b.M31 + a.M64 * b.M41 + a.M65 * b.M51 + a.M66 * b.M61,
                a.M61 * b.M12 + a.M62 * b.M22 + a.M63 * b.M32 + a.M64 * b.M42 + a.M65 * b.M52 + a.M66 * b.M62,
                a.M61 * b.M13 + a.M62 * b.M23 + a.M63 * b.M33 + a.M64 * b.M43 + a.M65 * b.M53 + a.M66 * b.M63,
                a.M61 * b.M14 + a.M62 * b.M24 + a.M63 * b.M34 + a.M64 * b.M44 + a.M65 * b.M54 + a.M66 * b.M64,
                a.M61 * b.M15 + a.M62 * b.M25 + a.M63 * b.M35 + a.M64 * b.M45 + a.M65 * b.M55 + a.M66 * b.M65
            );
        }

        public static Matrix6x6 operator *(Matrix6x6 a, Matrix6x6 b)
        {
            return new Matrix6x6
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41 + a.M15 * b.M51 + a.M16 * b.M61,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42 + a.M15 * b.M52 + a.M16 * b.M62,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43 + a.M15 * b.M53 + a.M16 * b.M63,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44 + a.M15 * b.M54 + a.M16 * b.M64,
                a.M11 * b.M15 + a.M12 * b.M25 + a.M13 * b.M35 + a.M14 * b.M45 + a.M15 * b.M55 + a.M16 * b.M65,
                a.M11 * b.M16 + a.M12 * b.M26 + a.M13 * b.M36 + a.M14 * b.M46 + a.M15 * b.M56 + a.M16 * b.M66,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41 + a.M25 * b.M51 + a.M26 * b.M61,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42 + a.M25 * b.M52 + a.M26 * b.M62,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43 + a.M25 * b.M53 + a.M26 * b.M63,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44 + a.M25 * b.M54 + a.M26 * b.M64,
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35 + a.M24 * b.M45 + a.M25 * b.M55 + a.M26 * b.M65,
                a.M21 * b.M16 + a.M22 * b.M26 + a.M23 * b.M36 + a.M24 * b.M46 + a.M25 * b.M56 + a.M26 * b.M66,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41 + a.M35 * b.M51 + a.M36 * b.M61,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42 + a.M35 * b.M52 + a.M36 * b.M62,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43 + a.M35 * b.M53 + a.M36 * b.M63,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44 + a.M35 * b.M54 + a.M36 * b.M64,
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35 + a.M34 * b.M45 + a.M35 * b.M55 + a.M36 * b.M65,
                a.M31 * b.M16 + a.M32 * b.M26 + a.M33 * b.M36 + a.M34 * b.M46 + a.M35 * b.M56 + a.M36 * b.M66,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41 + a.M45 * b.M51 + a.M46 * b.M61,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42 + a.M45 * b.M52 + a.M46 * b.M62,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43 + a.M45 * b.M53 + a.M46 * b.M63,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44 + a.M45 * b.M54 + a.M46 * b.M64,
                a.M41 * b.M15 + a.M42 * b.M25 + a.M43 * b.M35 + a.M44 * b.M45 + a.M45 * b.M55 + a.M46 * b.M65,
                a.M41 * b.M16 + a.M42 * b.M26 + a.M43 * b.M36 + a.M44 * b.M46 + a.M45 * b.M56 + a.M46 * b.M66,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31 + a.M54 * b.M41 + a.M55 * b.M51 + a.M56 * b.M61,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52 + a.M56 * b.M62,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33 + a.M54 * b.M43 + a.M55 * b.M53 + a.M56 * b.M63,
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34 + a.M54 * b.M44 + a.M55 * b.M54 + a.M56 * b.M64,
                a.M51 * b.M15 + a.M52 * b.M25 + a.M53 * b.M35 + a.M54 * b.M45 + a.M55 * b.M55 + a.M56 * b.M65,
                a.M51 * b.M16 + a.M52 * b.M26 + a.M53 * b.M36 + a.M54 * b.M46 + a.M55 * b.M56 + a.M56 * b.M66,

                a.M61 * b.M11 + a.M62 * b.M21 + a.M63 * b.M31 + a.M64 * b.M41 + a.M65 * b.M51 + a.M66 * b.M61,
                a.M61 * b.M12 + a.M62 * b.M22 + a.M63 * b.M32 + a.M64 * b.M42 + a.M65 * b.M52 + a.M66 * b.M62,
                a.M61 * b.M13 + a.M62 * b.M23 + a.M63 * b.M33 + a.M64 * b.M43 + a.M65 * b.M53 + a.M66 * b.M63,
                a.M61 * b.M14 + a.M62 * b.M24 + a.M63 * b.M34 + a.M64 * b.M44 + a.M65 * b.M54 + a.M66 * b.M64,
                a.M61 * b.M15 + a.M62 * b.M25 + a.M63 * b.M35 + a.M64 * b.M45 + a.M65 * b.M55 + a.M66 * b.M65,
                a.M61 * b.M16 + a.M62 * b.M26 + a.M63 * b.M36 + a.M64 * b.M46 + a.M65 * b.M56 + a.M66 * b.M66
            );
        }

        #endregion

        #region Operators

        public static Vector6 operator *(Matrix6x6 a, Vector6 b)
        {
            return new Vector6
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3 + a.M14 * b.M4 + a.M15 * b.M5 + a.M16 * b.M6,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3 + a.M24 * b.M4 + a.M25 * b.M5 + a.M26 * b.M6,
                a.M31 * b.M1 + a.M32 * b.M2 + a.M33 * b.M3 + a.M34 * b.M4 + a.M35 * b.M5 + a.M36 * b.M6,
                a.M41 * b.M1 + a.M42 * b.M2 + a.M43 * b.M3 + a.M44 * b.M4 + a.M45 * b.M5 + a.M46 * b.M6,
                a.M51 * b.M1 + a.M52 * b.M2 + a.M53 * b.M3 + a.M54 * b.M4 + a.M55 * b.M5 + a.M56 * b.M6,
                a.M61 * b.M1 + a.M62 * b.M2 + a.M63 * b.M3 + a.M64 * b.M4 + a.M65 * b.M5 + a.M66 * b.M6
            );
        }

        public static Vector6 operator *(Vector6 a, Matrix6x6 b)
        {
            return new Vector6
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31 + a.M4 * b.M41 + a.M5 * b.M51 + a.M6 * b.M61,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32 + a.M4 * b.M42 + a.M5 * b.M52 + a.M6 * b.M62,
                a.M1 * b.M13 + a.M2 * b.M23 + a.M3 * b.M33 + a.M4 * b.M43 + a.M5 * b.M53 + a.M6 * b.M63,
                a.M1 * b.M14 + a.M2 * b.M24 + a.M3 * b.M34 + a.M4 * b.M44 + a.M5 * b.M54 + a.M6 * b.M64,
                a.M1 * b.M15 + a.M2 * b.M25 + a.M3 * b.M35 + a.M4 * b.M45 + a.M5 * b.M55 + a.M6 * b.M65,
                a.M1 * b.M16 + a.M2 * b.M26 + a.M3 * b.M36 + a.M4 * b.M46 + a.M5 * b.M56 + a.M6 * b.M66
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix6x6 a, Matrix6x6 b) =>
            a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 && a.M14 == b.M14 && a.M15 == b.M15 && a.M16 == b.M16 &&
            a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 && a.M24 == b.M24 && a.M25 == b.M25 && a.M26 == b.M26 &&
            a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33 && a.M34 == b.M34 && a.M35 == b.M35 && a.M36 == b.M36 &&
            a.M41 == b.M41 && a.M42 == b.M42 && a.M43 == b.M43 && a.M44 == b.M44 && a.M45 == b.M45 && a.M46 == b.M46 &&
            a.M51 == b.M51 && a.M52 == b.M52 && a.M53 == b.M53 && a.M54 == b.M54 && a.M55 == b.M55 && a.M56 == b.M56 &&
            a.M61 == b.M61 && a.M62 == b.M62 && a.M63 == b.M63 && a.M64 == b.M64 && a.M65 == b.M65 && a.M66 == b.M66;

        public static bool operator !=(Matrix6x6 a, Matrix6x6 b) =>
            a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 || a.M14 != b.M14 || a.M15 != b.M15 || a.M16 != b.M16 ||
            a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 || a.M24 != b.M24 || a.M25 != b.M25 || a.M26 != b.M26 ||
            a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33 || a.M34 != b.M34 || a.M35 != b.M35 || a.M36 != b.M36 ||
            a.M41 != b.M41 || a.M42 != b.M42 || a.M43 != b.M43 || a.M44 != b.M44 || a.M45 != b.M45 || a.M46 != b.M46 ||
            a.M51 != b.M51 || a.M52 != b.M52 || a.M53 != b.M53 || a.M54 != b.M54 || a.M55 != b.M55 || a.M56 != b.M56 ||
            a.M61 != b.M61 || a.M62 != b.M62 || a.M63 != b.M63 || a.M64 != b.M64 || a.M65 != b.M65 || a.M66 != b.M66;

        #endregion

        #region Properties

        public Matrix6x6 Adjugate => AdjugateFromCofactors;

        public Matrix6x6 AdjugateFromCofactors
        {
            get
            {
                return new Matrix6x6
                (
                    Cofactor11, Cofactor21, Cofactor31, Cofactor41, Cofactor51, Cofactor61,
                    Cofactor12, Cofactor22, Cofactor32, Cofactor42, Cofactor52, Cofactor62,
                    Cofactor13, Cofactor23, Cofactor33, Cofactor43, Cofactor53, Cofactor63,
                    Cofactor14, Cofactor24, Cofactor34, Cofactor44, Cofactor54, Cofactor64,
                    Cofactor15, Cofactor25, Cofactor35, Cofactor45, Cofactor55, Cofactor65,
                    Cofactor16, Cofactor26, Cofactor36, Cofactor46, Cofactor56, Cofactor66
                );
            }
        }

        public Matrix6x6 Cofactor
        {
            get
            {
                return new Matrix6x6
                (
                    Cofactor11, Cofactor12, Cofactor13, Cofactor14, Cofactor15, Cofactor16,
                    Cofactor21, Cofactor22, Cofactor23, Cofactor24, Cofactor25, Cofactor26,
                    Cofactor31, Cofactor32, Cofactor33, Cofactor34, Cofactor35, Cofactor36,
                    Cofactor41, Cofactor42, Cofactor43, Cofactor44, Cofactor45, Cofactor46,
                    Cofactor51, Cofactor52, Cofactor53, Cofactor54, Cofactor55, Cofactor56,
                    Cofactor61, Cofactor62, Cofactor63, Cofactor64, Cofactor65, Cofactor66
                );
            }
        }

        public double Cofactor11 => +Minor11;

        public double Cofactor12 => -Minor12;

        public double Cofactor13 => +Minor13;

        public double Cofactor14 => -Minor14;

        public double Cofactor15 => +Minor15;

        public double Cofactor16 => -Minor16;

        public double Cofactor21 => -Minor21;

        public double Cofactor22 => +Minor22;

        public double Cofactor23 => -Minor23;

        public double Cofactor24 => +Minor24;

        public double Cofactor25 => -Minor25;

        public double Cofactor26 => +Minor26;

        public double Cofactor31 => +Minor31;

        public double Cofactor32 => -Minor32;

        public double Cofactor33 => +Minor33;

        public double Cofactor34 => -Minor34;

        public double Cofactor35 => +Minor35;

        public double Cofactor36 => -Minor36;

        public double Cofactor41 => -Minor41;

        public double Cofactor42 => +Minor42;

        public double Cofactor43 => -Minor43;

        public double Cofactor44 => +Minor44;

        public double Cofactor45 => -Minor45;

        public double Cofactor46 => +Minor46;

        public double Cofactor51 => +Minor51;

        public double Cofactor52 => -Minor52;

        public double Cofactor53 => +Minor53;

        public double Cofactor54 => -Minor54;

        public double Cofactor55 => +Minor55;

        public double Cofactor56 => -Minor56;

        public double Cofactor61 => -Minor61;

        public double Cofactor62 => +Minor62;

        public double Cofactor63 => -Minor63;

        public double Cofactor64 => +Minor64;

        public double Cofactor65 => -Minor65;

        public double Cofactor66 => +Minor66;

        public Vector6 Column1 => new Vector6(M11, M21, M31, M41, M51, M61);

        public Vector6 Column2 => new Vector6(M12, M22, M32, M42, M52, M62);

        public Vector6 Column3 => new Vector6(M13, M23, M33, M43, M53, M63);

        public Vector6 Column4 => new Vector6(M14, M24, M34, M44, M54, M64);

        public Vector6 Column5 => new Vector6(M15, M25, M35, M45, M55, M65);

        public Vector6 Column6 => new Vector6(M16, M26, M36, M46, M56, M66);

        public double Determinant
        {
            get
            {
                return
                    M11 * (M22 * (M33 * (M44 * (M55 * M66 - M56 * M65) - M45 * (M54 * M66 - M56 * M64) + M46 * (M54 * M65 - M55 * M64)) - M34 * (M43 * (M55 * M66 - M56 * M65) - M45 * (M53 * M66 - M56 * M63) + M46 * (M53 * M65 - M55 * M63)) + M35 * (M43 * (M54 * M66 - M56 * M64) - M44 * (M53 * M66 - M56 * M63) + M46 * (M53 * M64 - M54 * M63)) - M36 * (M43 * (M54 * M65 - M55 * M64) - M44 * (M53 * M65 - M55 * M63) + M45 * (M53 * M64 - M54 * M63))) - M23 * (M32 * (M44 * (M55 * M66 - M56 * M65) - M45 * (M54 * M66 - M56 * M64) + M46 * (M54 * M65 - M55 * M64)) - M34 * (M42 * (M55 * M66 - M56 * M65) - M45 * (M52 * M66 - M56 * M62) + M46 * (M52 * M65 - M55 * M62)) + M35 * (M42 * (M54 * M66 - M56 * M64) - M44 * (M52 * M66 - M56 * M62) + M46 * (M52 * M64 - M54 * M62)) - M36 * (M42 * (M54 * M65 - M55 * M64) - M44 * (M52 * M65 - M55 * M62) + M45 * (M52 * M64 - M54 * M62))) + M24 * (M32 * (M43 * (M55 * M66 - M56 * M65) - M45 * (M53 * M66 - M56 * M63) + M46 * (M53 * M65 - M55 * M63)) - M33 * (M42 * (M55 * M66 - M56 * M65) - M45 * (M52 * M66 - M56 * M62) + M46 * (M52 * M65 - M55 * M62)) + M35 * (M42 * (M53 * M66 - M56 * M63) - M43 * (M52 * M66 - M56 * M62) + M46 * (M52 * M63 - M53 * M62)) - M36 * (M42 * (M53 * M65 - M55 * M63) - M43 * (M52 * M65 - M55 * M62) + M45 * (M52 * M63 - M53 * M62))) - M25 * (M32 * (M43 * (M54 * M66 - M56 * M64) - M44 * (M53 * M66 - M56 * M63) + M46 * (M53 * M64 - M54 * M63)) - M33 * (M42 * (M54 * M66 - M56 * M64) - M44 * (M52 * M66 - M56 * M62) + M46 * (M52 * M64 - M54 * M62)) + M34 * (M42 * (M53 * M66 - M56 * M63) - M43 * (M52 * M66 - M56 * M62) + M46 * (M52 * M63 - M53 * M62)) - M36 * (M42 * (M53 * M64 - M54 * M63) - M43 * (M52 * M64 - M54 * M62) + M44 * (M52 * M63 - M53 * M62))) + M26 * (M32 * (M43 * (M54 * M65 - M55 * M64) - M44 * (M53 * M65 - M55 * M63) + M45 * (M53 * M64 - M54 * M63)) - M33 * (M42 * (M54 * M65 - M55 * M64) - M44 * (M52 * M65 - M55 * M62) + M45 * (M52 * M64 - M54 * M62)) + M34 * (M42 * (M53 * M65 - M55 * M63) - M43 * (M52 * M65 - M55 * M62) + M45 * (M52 * M63 - M53 * M62)) - M35 * (M42 * (M53 * M64 - M54 * M63) - M43 * (M52 * M64 - M54 * M62) + M44 * (M52 * M63 - M53 * M62)))) -
                    M12 * (M21 * (M33 * (M44 * (M55 * M66 - M56 * M65) - M45 * (M54 * M66 - M56 * M64) + M46 * (M54 * M65 - M55 * M64)) - M34 * (M43 * (M55 * M66 - M56 * M65) - M45 * (M53 * M66 - M56 * M63) + M46 * (M53 * M65 - M55 * M63)) + M35 * (M43 * (M54 * M66 - M56 * M64) - M44 * (M53 * M66 - M56 * M63) + M46 * (M53 * M64 - M54 * M63)) - M36 * (M43 * (M54 * M65 - M55 * M64) - M44 * (M53 * M65 - M55 * M63) + M45 * (M53 * M64 - M54 * M63))) - M23 * (M31 * (M44 * (M55 * M66 - M56 * M65) - M45 * (M54 * M66 - M56 * M64) + M46 * (M54 * M65 - M55 * M64)) - M34 * (M41 * (M55 * M66 - M56 * M65) - M45 * (M51 * M66 - M56 * M61) + M46 * (M51 * M65 - M55 * M61)) + M35 * (M41 * (M54 * M66 - M56 * M64) - M44 * (M51 * M66 - M56 * M61) + M46 * (M51 * M64 - M54 * M61)) - M36 * (M41 * (M54 * M65 - M55 * M64) - M44 * (M51 * M65 - M55 * M61) + M45 * (M51 * M64 - M54 * M61))) + M24 * (M31 * (M43 * (M55 * M66 - M56 * M65) - M45 * (M53 * M66 - M56 * M63) + M46 * (M53 * M65 - M55 * M63)) - M33 * (M41 * (M55 * M66 - M56 * M65) - M45 * (M51 * M66 - M56 * M61) + M46 * (M51 * M65 - M55 * M61)) + M35 * (M41 * (M53 * M66 - M56 * M63) - M43 * (M51 * M66 - M56 * M61) + M46 * (M51 * M63 - M53 * M61)) - M36 * (M41 * (M53 * M65 - M55 * M63) - M43 * (M51 * M65 - M55 * M61) + M45 * (M51 * M63 - M53 * M61))) - M25 * (M31 * (M43 * (M54 * M66 - M56 * M64) - M44 * (M53 * M66 - M56 * M63) + M46 * (M53 * M64 - M54 * M63)) - M33 * (M41 * (M54 * M66 - M56 * M64) - M44 * (M51 * M66 - M56 * M61) + M46 * (M51 * M64 - M54 * M61)) + M34 * (M41 * (M53 * M66 - M56 * M63) - M43 * (M51 * M66 - M56 * M61) + M46 * (M51 * M63 - M53 * M61)) - M36 * (M41 * (M53 * M64 - M54 * M63) - M43 * (M51 * M64 - M54 * M61) + M44 * (M51 * M63 - M53 * M61))) + M26 * (M31 * (M43 * (M54 * M65 - M55 * M64) - M44 * (M53 * M65 - M55 * M63) + M45 * (M53 * M64 - M54 * M63)) - M33 * (M41 * (M54 * M65 - M55 * M64) - M44 * (M51 * M65 - M55 * M61) + M45 * (M51 * M64 - M54 * M61)) + M34 * (M41 * (M53 * M65 - M55 * M63) - M43 * (M51 * M65 - M55 * M61) + M45 * (M51 * M63 - M53 * M61)) - M35 * (M41 * (M53 * M64 - M54 * M63) - M43 * (M51 * M64 - M54 * M61) + M44 * (M51 * M63 - M53 * M61)))) +
                    M13 * (M21 * (M32 * (M44 * (M55 * M66 - M56 * M65) - M45 * (M54 * M66 - M56 * M64) + M46 * (M54 * M65 - M55 * M64)) - M34 * (M42 * (M55 * M66 - M56 * M65) - M45 * (M52 * M66 - M56 * M62) + M46 * (M52 * M65 - M55 * M62)) + M35 * (M42 * (M54 * M66 - M56 * M64) - M44 * (M52 * M66 - M56 * M62) + M46 * (M52 * M64 - M54 * M62)) - M36 * (M42 * (M54 * M65 - M55 * M64) - M44 * (M52 * M65 - M55 * M62) + M45 * (M52 * M64 - M54 * M62))) - M22 * (M31 * (M44 * (M55 * M66 - M56 * M65) - M45 * (M54 * M66 - M56 * M64) + M46 * (M54 * M65 - M55 * M64)) - M34 * (M41 * (M55 * M66 - M56 * M65) - M45 * (M51 * M66 - M56 * M61) + M46 * (M51 * M65 - M55 * M61)) + M35 * (M41 * (M54 * M66 - M56 * M64) - M44 * (M51 * M66 - M56 * M61) + M46 * (M51 * M64 - M54 * M61)) - M36 * (M41 * (M54 * M65 - M55 * M64) - M44 * (M51 * M65 - M55 * M61) + M45 * (M51 * M64 - M54 * M61))) + M24 * (M31 * (M42 * (M55 * M66 - M56 * M65) - M45 * (M52 * M66 - M56 * M62) + M46 * (M52 * M65 - M55 * M62)) - M32 * (M41 * (M55 * M66 - M56 * M65) - M45 * (M51 * M66 - M56 * M61) + M46 * (M51 * M65 - M55 * M61)) + M35 * (M41 * (M52 * M66 - M56 * M62) - M42 * (M51 * M66 - M56 * M61) + M46 * (M51 * M62 - M52 * M61)) - M36 * (M41 * (M52 * M65 - M55 * M62) - M42 * (M51 * M65 - M55 * M61) + M45 * (M51 * M62 - M52 * M61))) - M25 * (M31 * (M42 * (M54 * M66 - M56 * M64) - M44 * (M52 * M66 - M56 * M62) + M46 * (M52 * M64 - M54 * M62)) - M32 * (M41 * (M54 * M66 - M56 * M64) - M44 * (M51 * M66 - M56 * M61) + M46 * (M51 * M64 - M54 * M61)) + M34 * (M41 * (M52 * M66 - M56 * M62) - M42 * (M51 * M66 - M56 * M61) + M46 * (M51 * M62 - M52 * M61)) - M36 * (M41 * (M52 * M64 - M54 * M62) - M42 * (M51 * M64 - M54 * M61) + M44 * (M51 * M62 - M52 * M61))) + M26 * (M31 * (M42 * (M54 * M65 - M55 * M64) - M44 * (M52 * M65 - M55 * M62) + M45 * (M52 * M64 - M54 * M62)) - M32 * (M41 * (M54 * M65 - M55 * M64) - M44 * (M51 * M65 - M55 * M61) + M45 * (M51 * M64 - M54 * M61)) + M34 * (M41 * (M52 * M65 - M55 * M62) - M42 * (M51 * M65 - M55 * M61) + M45 * (M51 * M62 - M52 * M61)) - M35 * (M41 * (M52 * M64 - M54 * M62) - M42 * (M51 * M64 - M54 * M61) + M44 * (M51 * M62 - M52 * M61)))) -
                    M14 * (M21 * (M32 * (M43 * (M55 * M66 - M56 * M65) - M45 * (M53 * M66 - M56 * M63) + M46 * (M53 * M65 - M55 * M63)) - M33 * (M42 * (M55 * M66 - M56 * M65) - M45 * (M52 * M66 - M56 * M62) + M46 * (M52 * M65 - M55 * M62)) + M35 * (M42 * (M53 * M66 - M56 * M63) - M43 * (M52 * M66 - M56 * M62) + M46 * (M52 * M63 - M53 * M62)) - M36 * (M42 * (M53 * M65 - M55 * M63) - M43 * (M52 * M65 - M55 * M62) + M45 * (M52 * M63 - M53 * M62))) - M22 * (M31 * (M43 * (M55 * M66 - M56 * M65) - M45 * (M53 * M66 - M56 * M63) + M46 * (M53 * M65 - M55 * M63)) - M33 * (M41 * (M55 * M66 - M56 * M65) - M45 * (M51 * M66 - M56 * M61) + M46 * (M51 * M65 - M55 * M61)) + M35 * (M41 * (M53 * M66 - M56 * M63) - M43 * (M51 * M66 - M56 * M61) + M46 * (M51 * M63 - M53 * M61)) - M36 * (M41 * (M53 * M65 - M55 * M63) - M43 * (M51 * M65 - M55 * M61) + M45 * (M51 * M63 - M53 * M61))) + M23 * (M31 * (M42 * (M55 * M66 - M56 * M65) - M45 * (M52 * M66 - M56 * M62) + M46 * (M52 * M65 - M55 * M62)) - M32 * (M41 * (M55 * M66 - M56 * M65) - M45 * (M51 * M66 - M56 * M61) + M46 * (M51 * M65 - M55 * M61)) + M35 * (M41 * (M52 * M66 - M56 * M62) - M42 * (M51 * M66 - M56 * M61) + M46 * (M51 * M62 - M52 * M61)) - M36 * (M41 * (M52 * M65 - M55 * M62) - M42 * (M51 * M65 - M55 * M61) + M45 * (M51 * M62 - M52 * M61))) - M25 * (M31 * (M42 * (M53 * M66 - M56 * M63) - M43 * (M52 * M66 - M56 * M62) + M46 * (M52 * M63 - M53 * M62)) - M32 * (M41 * (M53 * M66 - M56 * M63) - M43 * (M51 * M66 - M56 * M61) + M46 * (M51 * M63 - M53 * M61)) + M33 * (M41 * (M52 * M66 - M56 * M62) - M42 * (M51 * M66 - M56 * M61) + M46 * (M51 * M62 - M52 * M61)) - M36 * (M41 * (M52 * M63 - M53 * M62) - M42 * (M51 * M63 - M53 * M61) + M43 * (M51 * M62 - M52 * M61))) + M26 * (M31 * (M42 * (M53 * M65 - M55 * M63) - M43 * (M52 * M65 - M55 * M62) + M45 * (M52 * M63 - M53 * M62)) - M32 * (M41 * (M53 * M65 - M55 * M63) - M43 * (M51 * M65 - M55 * M61) + M45 * (M51 * M63 - M53 * M61)) + M33 * (M41 * (M52 * M65 - M55 * M62) - M42 * (M51 * M65 - M55 * M61) + M45 * (M51 * M62 - M52 * M61)) - M35 * (M41 * (M52 * M63 - M53 * M62) - M42 * (M51 * M63 - M53 * M61) + M43 * (M51 * M62 - M52 * M61)))) +
                    M15 * (M21 * (M32 * (M43 * (M54 * M66 - M56 * M64) - M44 * (M53 * M66 - M56 * M63) + M46 * (M53 * M64 - M54 * M63)) - M33 * (M42 * (M54 * M66 - M56 * M64) - M44 * (M52 * M66 - M56 * M62) + M46 * (M52 * M64 - M54 * M62)) + M34 * (M42 * (M53 * M66 - M56 * M63) - M43 * (M52 * M66 - M56 * M62) + M46 * (M52 * M63 - M53 * M62)) - M36 * (M42 * (M53 * M64 - M54 * M63) - M43 * (M52 * M64 - M54 * M62) + M44 * (M52 * M63 - M53 * M62))) - M22 * (M31 * (M43 * (M54 * M66 - M56 * M64) - M44 * (M53 * M66 - M56 * M63) + M46 * (M53 * M64 - M54 * M63)) - M33 * (M41 * (M54 * M66 - M56 * M64) - M44 * (M51 * M66 - M56 * M61) + M46 * (M51 * M64 - M54 * M61)) + M34 * (M41 * (M53 * M66 - M56 * M63) - M43 * (M51 * M66 - M56 * M61) + M46 * (M51 * M63 - M53 * M61)) - M36 * (M41 * (M53 * M64 - M54 * M63) - M43 * (M51 * M64 - M54 * M61) + M44 * (M51 * M63 - M53 * M61))) + M23 * (M31 * (M42 * (M54 * M66 - M56 * M64) - M44 * (M52 * M66 - M56 * M62) + M46 * (M52 * M64 - M54 * M62)) - M32 * (M41 * (M54 * M66 - M56 * M64) - M44 * (M51 * M66 - M56 * M61) + M46 * (M51 * M64 - M54 * M61)) + M34 * (M41 * (M52 * M66 - M56 * M62) - M42 * (M51 * M66 - M56 * M61) + M46 * (M51 * M62 - M52 * M61)) - M36 * (M41 * (M52 * M64 - M54 * M62) - M42 * (M51 * M64 - M54 * M61) + M44 * (M51 * M62 - M52 * M61))) - M24 * (M31 * (M42 * (M53 * M66 - M56 * M63) - M43 * (M52 * M66 - M56 * M62) + M46 * (M52 * M63 - M53 * M62)) - M32 * (M41 * (M53 * M66 - M56 * M63) - M43 * (M51 * M66 - M56 * M61) + M46 * (M51 * M63 - M53 * M61)) + M33 * (M41 * (M52 * M66 - M56 * M62) - M42 * (M51 * M66 - M56 * M61) + M46 * (M51 * M62 - M52 * M61)) - M36 * (M41 * (M52 * M63 - M53 * M62) - M42 * (M51 * M63 - M53 * M61) + M43 * (M51 * M62 - M52 * M61))) + M26 * (M31 * (M42 * (M53 * M64 - M54 * M63) - M43 * (M52 * M64 - M54 * M62) + M44 * (M52 * M63 - M53 * M62)) - M32 * (M41 * (M53 * M64 - M54 * M63) - M43 * (M51 * M64 - M54 * M61) + M44 * (M51 * M63 - M53 * M61)) + M33 * (M41 * (M52 * M64 - M54 * M62) - M42 * (M51 * M64 - M54 * M61) + M44 * (M51 * M62 - M52 * M61)) - M34 * (M41 * (M52 * M63 - M53 * M62) - M42 * (M51 * M63 - M53 * M61) + M43 * (M51 * M62 - M52 * M61)))) -
                    M16 * (M21 * (M32 * (M43 * (M54 * M65 - M55 * M64) - M44 * (M53 * M65 - M55 * M63) + M45 * (M53 * M64 - M54 * M63)) - M33 * (M42 * (M54 * M65 - M55 * M64) - M44 * (M52 * M65 - M55 * M62) + M45 * (M52 * M64 - M54 * M62)) + M34 * (M42 * (M53 * M65 - M55 * M63) - M43 * (M52 * M65 - M55 * M62) + M45 * (M52 * M63 - M53 * M62)) - M35 * (M42 * (M53 * M64 - M54 * M63) - M43 * (M52 * M64 - M54 * M62) + M44 * (M52 * M63 - M53 * M62))) - M22 * (M31 * (M43 * (M54 * M65 - M55 * M64) - M44 * (M53 * M65 - M55 * M63) + M45 * (M53 * M64 - M54 * M63)) - M33 * (M41 * (M54 * M65 - M55 * M64) - M44 * (M51 * M65 - M55 * M61) + M45 * (M51 * M64 - M54 * M61)) + M34 * (M41 * (M53 * M65 - M55 * M63) - M43 * (M51 * M65 - M55 * M61) + M45 * (M51 * M63 - M53 * M61)) - M35 * (M41 * (M53 * M64 - M54 * M63) - M43 * (M51 * M64 - M54 * M61) + M44 * (M51 * M63 - M53 * M61))) + M23 * (M31 * (M42 * (M54 * M65 - M55 * M64) - M44 * (M52 * M65 - M55 * M62) + M45 * (M52 * M64 - M54 * M62)) - M32 * (M41 * (M54 * M65 - M55 * M64) - M44 * (M51 * M65 - M55 * M61) + M45 * (M51 * M64 - M54 * M61)) + M34 * (M41 * (M52 * M65 - M55 * M62) - M42 * (M51 * M65 - M55 * M61) + M45 * (M51 * M62 - M52 * M61)) - M35 * (M41 * (M52 * M64 - M54 * M62) - M42 * (M51 * M64 - M54 * M61) + M44 * (M51 * M62 - M52 * M61))) - M24 * (M31 * (M42 * (M53 * M65 - M55 * M63) - M43 * (M52 * M65 - M55 * M62) + M45 * (M52 * M63 - M53 * M62)) - M32 * (M41 * (M53 * M65 - M55 * M63) - M43 * (M51 * M65 - M55 * M61) + M45 * (M51 * M63 - M53 * M61)) + M33 * (M41 * (M52 * M65 - M55 * M62) - M42 * (M51 * M65 - M55 * M61) + M45 * (M51 * M62 - M52 * M61)) - M35 * (M41 * (M52 * M63 - M53 * M62) - M42 * (M51 * M63 - M53 * M61) + M43 * (M51 * M62 - M52 * M61))) + M25 * (M31 * (M42 * (M53 * M64 - M54 * M63) - M43 * (M52 * M64 - M54 * M62) + M44 * (M52 * M63 - M53 * M62)) - M32 * (M41 * (M53 * M64 - M54 * M63) - M43 * (M51 * M64 - M54 * M61) + M44 * (M51 * M63 - M53 * M61)) + M33 * (M41 * (M52 * M64 - M54 * M62) - M42 * (M51 * M64 - M54 * M61) + M44 * (M51 * M62 - M52 * M61)) - M34 * (M41 * (M52 * M63 - M53 * M62) - M42 * (M51 * M63 - M53 * M61) + M43 * (M51 * M62 - M52 * M61))));
            }
        }

        public Vector6 Diagonal => new Vector6(M11, M22, M33, M44, M55, M66);

        public Matrix6x6 Inverted => Adjugate / Determinant;

        public Matrix6x6 Lower
        {
            get
            {
                return new Matrix6x6
                (
                    M11, 0, 0, 0, 0, 0,
                    M21, M22, 0, 0, 0, 0,
                    M31, M32, M33, 0, 0, 0,
                    M41, M42, M43, M44, 0, 0,
                    M51, M52, M53, M54, M55, 0,
                    M61, M62, M63, M64, M65, M66
                );
            }
        }

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M13 { get; set; }

        public double M14 { get; set; }

        public double M15 { get; set; }

        public double M16 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double M23 { get; set; }

        public double M24 { get; set; }

        public double M25 { get; set; }

        public double M26 { get; set; }

        public double M31 { get; set; }

        public double M32 { get; set; }

        public double M33 { get; set; }

        public double M34 { get; set; }

        public double M35 { get; set; }

        public double M36 { get; set; }

        public double M41 { get; set; }

        public double M42 { get; set; }

        public double M43 { get; set; }

        public double M44 { get; set; }

        public double M45 { get; set; }

        public double M46 { get; set; }

        public double M51 { get; set; }

        public double M52 { get; set; }

        public double M53 { get; set; }

        public double M54 { get; set; }

        public double M55 { get; set; }

        public double M56 { get; set; }

        public double M61 { get; set; }

        public double M62 { get; set; }

        public double M63 { get; set; }

        public double M64 { get; set; }

        public double M65 { get; set; }

        public double M66 { get; set; }

        public double Minor11 => Submatrix11.Determinant;

        public double Minor12 => Submatrix12.Determinant;

        public double Minor13 => Submatrix13.Determinant;

        public double Minor14 => Submatrix14.Determinant;

        public double Minor15 => Submatrix15.Determinant;

        public double Minor16 => Submatrix16.Determinant;

        public double Minor21 => Submatrix21.Determinant;

        public double Minor22 => Submatrix22.Determinant;

        public double Minor23 => Submatrix23.Determinant;

        public double Minor24 => Submatrix24.Determinant;

        public double Minor25 => Submatrix25.Determinant;

        public double Minor26 => Submatrix26.Determinant;

        public double Minor31 => Submatrix31.Determinant;

        public double Minor32 => Submatrix32.Determinant;

        public double Minor33 => Submatrix33.Determinant;

        public double Minor34 => Submatrix34.Determinant;

        public double Minor35 => Submatrix35.Determinant;

        public double Minor36 => Submatrix36.Determinant;

        public double Minor41 => Submatrix41.Determinant;

        public double Minor42 => Submatrix42.Determinant;

        public double Minor43 => Submatrix43.Determinant;

        public double Minor44 => Submatrix44.Determinant;

        public double Minor45 => Submatrix45.Determinant;

        public double Minor46 => Submatrix46.Determinant;

        public double Minor51 => Submatrix51.Determinant;

        public double Minor52 => Submatrix52.Determinant;

        public double Minor53 => Submatrix53.Determinant;

        public double Minor54 => Submatrix54.Determinant;

        public double Minor55 => Submatrix55.Determinant;

        public double Minor56 => Submatrix56.Determinant;

        public double Minor61 => Submatrix61.Determinant;

        public double Minor62 => Submatrix62.Determinant;

        public double Minor63 => Submatrix63.Determinant;

        public double Minor64 => Submatrix64.Determinant;

        public double Minor65 => Submatrix65.Determinant;

        public double Minor66 => Submatrix66.Determinant;

        public Matrix6x6 Negated
        {
            get
            {
                return new Matrix6x6
                (
                    -M11, -M12, -M13, -M14, -M15, -M16,
                    -M21, -M22, -M23, -M24, -M25, -M26,
                    -M31, -M32, -M33, -M34, -M35, -M36,
                    -M41, -M42, -M43, -M44, -M45, -M46,
                    -M51, -M52, -M53, -M54, -M55, -M56,
                    -M61, -M62, -M63, -M64, -M65, -M66
                );
            }
        }

        public Vector6 Row1 => new Vector6(M11, M12, M13, M14, M15, M16);

        public Vector6 Row2 => new Vector6(M21, M22, M23, M24, M25, M26);

        public Vector6 Row3 => new Vector6(M31, M32, M33, M34, M35, M36);

        public Vector6 Row4 => new Vector6(M41, M42, M43, M44, M45, M46);

        public Vector6 Row5 => new Vector6(M51, M52, M53, M54, M55, M56);

        public Vector6 Row6 => new Vector6(M61, M62, M63, M64, M65, M66);

        public Matrix6x6 Squared => this * this;

        public Matrix5x5 Submatrix11 => new Matrix5x5(M22, M23, M24, M25, M26, M32, M33, M34, M35, M36, M42, M43, M44, M45, M46, M52, M53, M54, M55, M56, M62, M63, M64, M65, M66);

        public Matrix5x5 Submatrix12 => new Matrix5x5(M21, M23, M24, M25, M26, M31, M33, M34, M35, M36, M41, M43, M44, M45, M46, M51, M53, M54, M55, M56, M61, M63, M64, M65, M66);

        public Matrix5x5 Submatrix13 => new Matrix5x5(M21, M22, M24, M25, M26, M31, M32, M34, M35, M36, M41, M42, M44, M45, M46, M51, M52, M54, M55, M56, M61, M62, M64, M65, M66);

        public Matrix5x5 Submatrix14 => new Matrix5x5(M21, M22, M23, M25, M26, M31, M32, M33, M35, M36, M41, M42, M43, M45, M46, M51, M52, M53, M55, M56, M61, M62, M63, M65, M66);

        public Matrix5x5 Submatrix15 => new Matrix5x5(M21, M22, M23, M24, M26, M31, M32, M33, M34, M36, M41, M42, M43, M44, M46, M51, M52, M53, M54, M56, M61, M62, M63, M64, M66);

        public Matrix5x5 Submatrix16 => new Matrix5x5(M21, M22, M23, M24, M25, M31, M32, M33, M34, M35, M41, M42, M43, M44, M45, M51, M52, M53, M54, M55, M61, M62, M63, M64, M65);

        public Matrix5x5 Submatrix21 => new Matrix5x5(M12, M13, M14, M15, M16, M32, M33, M34, M35, M36, M42, M43, M44, M45, M46, M52, M53, M54, M55, M56, M62, M63, M64, M65, M66);

        public Matrix5x5 Submatrix22 => new Matrix5x5(M11, M13, M14, M15, M16, M31, M33, M34, M35, M36, M41, M43, M44, M45, M46, M51, M53, M54, M55, M56, M61, M63, M64, M65, M66);

        public Matrix5x5 Submatrix23 => new Matrix5x5(M11, M12, M14, M15, M16, M31, M32, M34, M35, M36, M41, M42, M44, M45, M46, M51, M52, M54, M55, M56, M61, M62, M64, M65, M66);

        public Matrix5x5 Submatrix24 => new Matrix5x5(M11, M12, M13, M15, M16, M31, M32, M33, M35, M36, M41, M42, M43, M45, M46, M51, M52, M53, M55, M56, M61, M62, M63, M65, M66);

        public Matrix5x5 Submatrix25 => new Matrix5x5(M11, M12, M13, M14, M16, M31, M32, M33, M34, M36, M41, M42, M43, M44, M46, M51, M52, M53, M54, M56, M61, M62, M63, M64, M66);

        public Matrix5x5 Submatrix26 => new Matrix5x5(M11, M12, M13, M14, M15, M31, M32, M33, M34, M35, M41, M42, M43, M44, M45, M51, M52, M53, M54, M55, M61, M62, M63, M64, M65);

        public Matrix5x5 Submatrix31 => new Matrix5x5(M12, M13, M14, M15, M16, M22, M23, M24, M25, M26, M42, M43, M44, M45, M46, M52, M53, M54, M55, M56, M62, M63, M64, M65, M66);

        public Matrix5x5 Submatrix32 => new Matrix5x5(M11, M13, M14, M15, M16, M21, M23, M24, M25, M26, M41, M43, M44, M45, M46, M51, M53, M54, M55, M56, M61, M63, M64, M65, M66);

        public Matrix5x5 Submatrix33 => new Matrix5x5(M11, M12, M14, M15, M16, M21, M22, M24, M25, M26, M41, M42, M44, M45, M46, M51, M52, M54, M55, M56, M61, M62, M64, M65, M66);

        public Matrix5x5 Submatrix34 => new Matrix5x5(M11, M12, M13, M15, M16, M21, M22, M23, M25, M26, M41, M42, M43, M45, M46, M51, M52, M53, M55, M56, M61, M62, M63, M65, M66);

        public Matrix5x5 Submatrix35 => new Matrix5x5(M11, M12, M13, M14, M16, M21, M22, M23, M24, M26, M41, M42, M43, M44, M46, M51, M52, M53, M54, M56, M61, M62, M63, M64, M66);

        public Matrix5x5 Submatrix36 => new Matrix5x5(M11, M12, M13, M14, M15, M21, M22, M23, M24, M25, M41, M42, M43, M44, M45, M51, M52, M53, M54, M55, M61, M62, M63, M64, M65);

        public Matrix5x5 Submatrix41 => new Matrix5x5(M12, M13, M14, M15, M16, M22, M23, M24, M25, M26, M32, M33, M34, M35, M36, M52, M53, M54, M55, M56, M62, M63, M64, M65, M66);

        public Matrix5x5 Submatrix42 => new Matrix5x5(M11, M13, M14, M15, M16, M21, M23, M24, M25, M26, M31, M33, M34, M35, M36, M51, M53, M54, M55, M56, M61, M63, M64, M65, M66);

        public Matrix5x5 Submatrix43 => new Matrix5x5(M11, M12, M14, M15, M16, M21, M22, M24, M25, M26, M31, M32, M34, M35, M36, M51, M52, M54, M55, M56, M61, M62, M64, M65, M66);

        public Matrix5x5 Submatrix44 => new Matrix5x5(M11, M12, M13, M15, M16, M21, M22, M23, M25, M26, M31, M32, M33, M35, M36, M51, M52, M53, M55, M56, M61, M62, M63, M65, M66);

        public Matrix5x5 Submatrix45 => new Matrix5x5(M11, M12, M13, M14, M16, M21, M22, M23, M24, M26, M31, M32, M33, M34, M36, M51, M52, M53, M54, M56, M61, M62, M63, M64, M66);

        public Matrix5x5 Submatrix46 => new Matrix5x5(M11, M12, M13, M14, M15, M21, M22, M23, M24, M25, M31, M32, M33, M34, M35, M51, M52, M53, M54, M55, M61, M62, M63, M64, M65);

        public Matrix5x5 Submatrix51 => new Matrix5x5(M12, M13, M14, M15, M16, M22, M23, M24, M25, M26, M32, M33, M34, M35, M36, M42, M43, M44, M45, M46, M62, M63, M64, M65, M66);

        public Matrix5x5 Submatrix52 => new Matrix5x5(M11, M13, M14, M15, M16, M21, M23, M24, M25, M26, M31, M33, M34, M35, M36, M41, M43, M44, M45, M46, M61, M63, M64, M65, M66);

        public Matrix5x5 Submatrix53 => new Matrix5x5(M11, M12, M14, M15, M16, M21, M22, M24, M25, M26, M31, M32, M34, M35, M36, M41, M42, M44, M45, M46, M61, M62, M64, M65, M66);

        public Matrix5x5 Submatrix54 => new Matrix5x5(M11, M12, M13, M15, M16, M21, M22, M23, M25, M26, M31, M32, M33, M35, M36, M41, M42, M43, M45, M46, M61, M62, M63, M65, M66);

        public Matrix5x5 Submatrix55 => new Matrix5x5(M11, M12, M13, M14, M16, M21, M22, M23, M24, M26, M31, M32, M33, M34, M36, M41, M42, M43, M44, M46, M61, M62, M63, M64, M66);

        public Matrix5x5 Submatrix56 => new Matrix5x5(M11, M12, M13, M14, M15, M21, M22, M23, M24, M25, M31, M32, M33, M34, M35, M41, M42, M43, M44, M45, M61, M62, M63, M64, M65);

        public Matrix5x5 Submatrix61 => new Matrix5x5(M12, M13, M14, M15, M16, M22, M23, M24, M25, M26, M32, M33, M34, M35, M36, M42, M43, M44, M45, M46, M52, M53, M54, M55, M56);

        public Matrix5x5 Submatrix62 => new Matrix5x5(M11, M13, M14, M15, M16, M21, M23, M24, M25, M26, M31, M33, M34, M35, M36, M41, M43, M44, M45, M46, M51, M53, M54, M55, M56);

        public Matrix5x5 Submatrix63 => new Matrix5x5(M11, M12, M14, M15, M16, M21, M22, M24, M25, M26, M31, M32, M34, M35, M36, M41, M42, M44, M45, M46, M51, M52, M54, M55, M56);

        public Matrix5x5 Submatrix64 => new Matrix5x5(M11, M12, M13, M15, M16, M21, M22, M23, M25, M26, M31, M32, M33, M35, M36, M41, M42, M43, M45, M46, M51, M52, M53, M55, M56);

        public Matrix5x5 Submatrix65 => new Matrix5x5(M11, M12, M13, M14, M16, M21, M22, M23, M24, M26, M31, M32, M33, M34, M36, M41, M42, M43, M44, M46, M51, M52, M53, M54, M56);

        public Matrix5x5 Submatrix66 => new Matrix5x5(M11, M12, M13, M14, M15, M21, M22, M23, M24, M25, M31, M32, M33, M34, M35, M41, M42, M43, M44, M45, M51, M52, M53, M54, M55);

        public double Trace => M11 + M22 + M33 + M44 + M55 + M66;

        public Matrix6x6 Transposed
        {
            get
            {
                return new Matrix6x6
                (
                    M11, M21, M31, M41, M51, M61,
                    M12, M22, M32, M42, M52, M62,
                    M13, M23, M33, M43, M53, M63,
                    M14, M24, M34, M44, M54, M64,
                    M15, M25, M35, M45, M55, M65,
                    M16, M26, M36, M46, M56, M66
                );
            }
        }

        public Matrix6x6 Upper
        {
            get
            {
                return new Matrix6x6
                (
                    M11, M12, M13, M14, M15, M16,
                    0, M22, M23, M24, M25, M26,
                    0, 0, M33, M34, M35, M36,
                    0, 0, 0, M44, M45, M46,
                    0, 0, 0, 0, M55, M56,
                    0, 0, 0, 0, 0, M66
                );
            }
        }

        #endregion
    }
}
