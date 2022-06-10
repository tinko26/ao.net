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
	public struct Matrix5x6 : IEquatable<Matrix5x6>
	{
		#region Constants

		public static readonly Matrix5x6 Zero = new Matrix5x6();

		#endregion

		#region Construction

		public Matrix5x6
		(
			double m11, double m12, double m13, double m14, double m15, double m16,
			double m21, double m22, double m23, double m24, double m25, double m26,
			double m31, double m32, double m33, double m34, double m35, double m36,
			double m41, double m42, double m43, double m44, double m45, double m46,
			double m51, double m52, double m53, double m54, double m55, double m56
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
		}

		#endregion

		#region Methods

		public bool Equals(Matrix5x6 x) => this == x;

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Matrix5x6)) return false;

			var y = (Matrix5x6)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^ M14.GetHashCode() ^ M15.GetHashCode() ^ M16.GetHashCode() ^
			M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode() ^ M24.GetHashCode() ^ M25.GetHashCode() ^ M26.GetHashCode() ^
			M31.GetHashCode() ^ M32.GetHashCode() ^ M33.GetHashCode() ^ M34.GetHashCode() ^ M35.GetHashCode() ^ M36.GetHashCode() ^
			M41.GetHashCode() ^ M42.GetHashCode() ^ M43.GetHashCode() ^ M44.GetHashCode() ^ M45.GetHashCode() ^ M46.GetHashCode() ^
			M51.GetHashCode() ^ M52.GetHashCode() ^ M53.GetHashCode() ^ M54.GetHashCode() ^ M55.GetHashCode() ^ M56.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix5x6 FromColumnAndRow(Vector5 column, Vector6 row)
        {
            return new Matrix5x6
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
                column.M5 * row.M6
            );
        }

        public static Matrix5x6 FromColumns(Vector5 column1, Vector5 column2, Vector5 column3, Vector5 column4, Vector5 column5, Vector5 column6)
        {
            return new Matrix5x6
            (
                column1.M1, column2.M1, column3.M1, column4.M1, column5.M1, column6.M1,
                column1.M2, column2.M2, column3.M2, column4.M2, column5.M2, column6.M2,
                column1.M3, column2.M3, column3.M3, column4.M3, column5.M3, column6.M3,
                column1.M4, column2.M4, column3.M4, column4.M4, column5.M4, column6.M4,
                column1.M5, column2.M5, column3.M5, column4.M5, column5.M5, column6.M5
            );
        }

        public static Matrix5x6 FromRows(Vector6 row1, Vector6 row2, Vector6 row3, Vector6 row4, Vector6 row5)
        {
            return new Matrix5x6
            (
                row1.M1, row1.M2, row1.M3, row1.M4, row1.M5, row1.M6,
                row2.M1, row2.M2, row2.M3, row2.M4, row2.M5, row2.M6,
                row3.M1, row3.M2, row3.M3, row3.M4, row3.M5, row3.M6,
                row4.M1, row4.M2, row4.M3, row4.M4, row4.M5, row4.M6,
                row5.M1, row5.M2, row5.M3, row5.M4, row5.M5, row5.M6
            );
        }

        #endregion

        #region Operators

        public static Matrix5x6 operator +(Matrix5x6 a) => a;

        public static Matrix5x6 operator +(Matrix5x6 a, Matrix5x6 b)
        {
            return new Matrix5x6
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13, a.M14 + b.M14, a.M15 + b.M15, a.M16 + b.M16,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23, a.M24 + b.M24, a.M25 + b.M25, a.M26 + b.M26,
                a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33, a.M34 + b.M34, a.M35 + b.M35, a.M36 + b.M36,
                a.M41 + b.M41, a.M42 + b.M42, a.M43 + b.M43, a.M44 + b.M44, a.M45 + b.M45, a.M46 + b.M46,
                a.M51 + b.M51, a.M52 + b.M52, a.M53 + b.M53, a.M54 + b.M54, a.M55 + b.M55, a.M56 + b.M56
            );
        }

        public static Matrix5x6 operator -(Matrix5x6 a) => a.Negated;

        public static Matrix5x6 operator -(Matrix5x6 a, Matrix5x6 b)
        {
            return new Matrix5x6
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13, a.M14 - b.M14, a.M15 - b.M15, a.M16 - b.M16,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23, a.M24 - b.M24, a.M25 - b.M25, a.M26 - b.M26,
                a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33, a.M34 - b.M34, a.M35 - b.M35, a.M36 - b.M36,
                a.M41 - b.M41, a.M42 - b.M42, a.M43 - b.M43, a.M44 - b.M44, a.M45 - b.M45, a.M46 - b.M46,
                a.M51 - b.M51, a.M52 - b.M52, a.M53 - b.M53, a.M54 - b.M54, a.M55 - b.M55, a.M56 - b.M56
            );
        }

        public static Matrix5x6 operator *(Matrix5x6 a, double b)
        {
            return new Matrix5x6
            (
                a.M11 * b, a.M12 * b, a.M13 * b, a.M14 * b, a.M15 * b, a.M16 * b,
                a.M21 * b, a.M22 * b, a.M23 * b, a.M24 * b, a.M25 * b, a.M26 * b,
                a.M31 * b, a.M32 * b, a.M33 * b, a.M34 * b, a.M35 * b, a.M36 * b,
                a.M41 * b, a.M42 * b, a.M43 * b, a.M44 * b, a.M45 * b, a.M46 * b,
                a.M51 * b, a.M52 * b, a.M53 * b, a.M54 * b, a.M55 * b, a.M56 * b
            );
        }

        public static Matrix5x6 operator *(double a, Matrix5x6 b)
        {
            return new Matrix5x6
            (
                a * b.M11, a * b.M12, a * b.M13, a * b.M14, a * b.M15, a * b.M16,
                a * b.M21, a * b.M22, a * b.M23, a * b.M24, a * b.M25, a * b.M26,
                a * b.M31, a * b.M32, a * b.M33, a * b.M34, a * b.M35, a * b.M36,
                a * b.M41, a * b.M42, a * b.M43, a * b.M44, a * b.M45, a * b.M46,
                a * b.M51, a * b.M52, a * b.M53, a * b.M54, a * b.M55, a * b.M56
            );
        }

        public static Matrix5x6 operator /(Matrix5x6 a, double b)
        {
            return new Matrix5x6
            (
                a.M11 / b, a.M12 / b, a.M13 / b, a.M14 / b, a.M15 / b, a.M16 / b,
                a.M21 / b, a.M22 / b, a.M23 / b, a.M24 / b, a.M25 / b, a.M26 / b,
                a.M31 / b, a.M32 / b, a.M33 / b, a.M34 / b, a.M35 / b, a.M36 / b,
                a.M41 / b, a.M42 / b, a.M43 / b, a.M44 / b, a.M45 / b, a.M46 / b,
                a.M51 / b, a.M52 / b, a.M53 / b, a.M54 / b, a.M55 / b, a.M56 / b
            );
        }

        public static Matrix6x5 operator ~(Matrix5x6 a) => a.Transposed;

        #endregion

        #region Operators

        public static Matrix5x2 operator *(Matrix5x6 a, Matrix6x2 b)
        {
            return new Matrix5x2
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
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32 + a.M54 * b.M42 + a.M55 * b.M52 + a.M56 * b.M62
            );
        }

        public static Matrix5x3 operator *(Matrix5x6 a, Matrix6x3 b)
        {
            return new Matrix5x3
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
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33 + a.M54 * b.M43 + a.M55 * b.M53 + a.M56 * b.M63
            );
        }

        public static Matrix5x4 operator *(Matrix5x6 a, Matrix6x4 b)
        {
            return new Matrix5x4
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
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34 + a.M54 * b.M44 + a.M55 * b.M54 + a.M56 * b.M64
            );
        }

        public static Matrix5x5 operator *(Matrix5x6 a, Matrix6x5 b)
        {
            return new Matrix5x5
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
                a.M51 * b.M15 + a.M52 * b.M25 + a.M53 * b.M35 + a.M54 * b.M45 + a.M55 * b.M55 + a.M56 * b.M65
            );
        }

        public static Matrix5x6 operator *(Matrix5x6 a, Matrix6x6 b)
        {
            return new Matrix5x6
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
                a.M51 * b.M16 + a.M52 * b.M26 + a.M53 * b.M36 + a.M54 * b.M46 + a.M55 * b.M56 + a.M56 * b.M66
            );
        }

        #endregion

        #region Operators

        public static Vector5 operator *(Matrix5x6 a, Vector6 b)
        {
            return new Vector5
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3 + a.M14 * b.M4 + a.M15 * b.M5 + a.M16 * b.M6,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3 + a.M24 * b.M4 + a.M25 * b.M5 + a.M26 * b.M6,
                a.M31 * b.M1 + a.M32 * b.M2 + a.M33 * b.M3 + a.M34 * b.M4 + a.M35 * b.M5 + a.M36 * b.M6,
                a.M41 * b.M1 + a.M42 * b.M2 + a.M43 * b.M3 + a.M44 * b.M4 + a.M45 * b.M5 + a.M46 * b.M6,
                a.M51 * b.M1 + a.M52 * b.M2 + a.M53 * b.M3 + a.M54 * b.M4 + a.M55 * b.M5 + a.M56 * b.M6
            );
        }

        public static Vector6 operator *(Vector5 a, Matrix5x6 b)
        {
            return new Vector6
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31 + a.M4 * b.M41 + a.M5 * b.M51,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32 + a.M4 * b.M42 + a.M5 * b.M52,
                a.M1 * b.M13 + a.M2 * b.M23 + a.M3 * b.M33 + a.M4 * b.M43 + a.M5 * b.M53,
                a.M1 * b.M14 + a.M2 * b.M24 + a.M3 * b.M34 + a.M4 * b.M44 + a.M5 * b.M54,
                a.M1 * b.M15 + a.M2 * b.M25 + a.M3 * b.M35 + a.M4 * b.M45 + a.M5 * b.M55,
                a.M1 * b.M16 + a.M2 * b.M26 + a.M3 * b.M36 + a.M4 * b.M46 + a.M5 * b.M56
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix5x6 a, Matrix5x6 b) =>
			a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 && a.M14 == b.M14 && a.M15 == b.M15 && a.M16 == b.M16 &&
			a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 && a.M24 == b.M24 && a.M25 == b.M25 && a.M26 == b.M26 &&
			a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33 && a.M34 == b.M34 && a.M35 == b.M35 && a.M36 == b.M36 &&
			a.M41 == b.M41 && a.M42 == b.M42 && a.M43 == b.M43 && a.M44 == b.M44 && a.M45 == b.M45 && a.M46 == b.M46 &&
			a.M51 == b.M51 && a.M52 == b.M52 && a.M53 == b.M53 && a.M54 == b.M54 && a.M55 == b.M55 && a.M56 == b.M56;

		public static bool operator !=(Matrix5x6 a, Matrix5x6 b) =>
			a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 || a.M14 != b.M14 || a.M15 != b.M15 || a.M16 != b.M16 ||
			a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 || a.M24 != b.M24 || a.M25 != b.M25 || a.M26 != b.M26 ||
			a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33 || a.M34 != b.M34 || a.M35 != b.M35 || a.M36 != b.M36 ||
			a.M41 != b.M41 || a.M42 != b.M42 || a.M43 != b.M43 || a.M44 != b.M44 || a.M45 != b.M45 || a.M46 != b.M46 ||
			a.M51 != b.M51 || a.M52 != b.M52 || a.M53 != b.M53 || a.M54 != b.M54 || a.M55 != b.M55 || a.M56 != b.M56;

        #endregion

        #region Properties

        public Vector5 Column1 => new Vector5(M11, M21, M31, M41, M51);

        public Vector5 Column2 => new Vector5(M12, M22, M32, M42, M52);

        public Vector5 Column3 => new Vector5(M13, M23, M33, M43, M53);

        public Vector5 Column4 => new Vector5(M14, M24, M34, M44, M54);

        public Vector5 Column5 => new Vector5(M15, M25, M35, M45, M55);

        public Vector5 Column6 => new Vector5(M16, M26, M36, M46, M56);

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

        public Matrix5x6 Negated
        {
            get
            {
                return new Matrix5x6
                (
                    -M11, -M12, -M13, -M14, -M15, -M16,
                    -M21, -M22, -M23, -M24, -M25, -M26,
                    -M31, -M32, -M33, -M34, -M35, -M36,
                    -M41, -M42, -M43, -M44, -M45, -M46,
                    -M51, -M52, -M53, -M54, -M55, -M56
                );
            }
        }

        public Vector6 Row1 => new Vector6(M11, M12, M13, M14, M15, M16);

        public Vector6 Row2 => new Vector6(M21, M22, M23, M24, M25, M26);

        public Vector6 Row3 => new Vector6(M31, M32, M33, M34, M35, M36);

        public Vector6 Row4 => new Vector6(M41, M42, M43, M44, M45, M46);

        public Vector6 Row5 => new Vector6(M51, M52, M53, M54, M55, M56);

        public Matrix6x5 Transposed
        {
            get
            {
                return new Matrix6x5
                (
                    M11, M21, M31, M41, M51,
                    M12, M22, M32, M42, M52,
                    M13, M23, M33, M43, M53,
                    M14, M24, M34, M44, M54,
                    M15, M25, M35, M45, M55,
                    M16, M26, M36, M46, M56
                );
            }
        }

        #endregion
    }
}
