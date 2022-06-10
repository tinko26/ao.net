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
	public struct Matrix6x2 : IEquatable<Matrix6x2>
	{
		#region Constants

		public static readonly Matrix6x2 Zero = new Matrix6x2();

		#endregion

		#region Construction

		public Matrix6x2
		(
			double m11, double m12,
			double m21, double m22,
			double m31, double m32,
			double m41, double m42,
			double m51, double m52,
			double m61, double m62
		)
		{
			M11 = m11;
			M12 = m12;
			M21 = m21;
			M22 = m22;
			M31 = m31;
			M32 = m32;
			M41 = m41;
			M42 = m42;
			M51 = m51;
			M52 = m52;
			M61 = m61;
			M62 = m62;
		}

		#endregion

		#region Methods

		public bool Equals(Matrix6x2 x) => this == x;

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Matrix6x2)) return false;

			var y = (Matrix6x2)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M11.GetHashCode() ^ M12.GetHashCode() ^ 
			M21.GetHashCode() ^ M22.GetHashCode() ^ 
			M31.GetHashCode() ^ M32.GetHashCode() ^ 
			M41.GetHashCode() ^ M42.GetHashCode() ^ 
			M51.GetHashCode() ^ M52.GetHashCode() ^ 
			M61.GetHashCode() ^ M62.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix6x2 FromColumnAndRow(Vector6 column, Vector2 row)
        {
            return new Matrix6x2
            (
                column.M1 * row.M1,
                column.M1 * row.M2,

                column.M2 * row.M1,
                column.M2 * row.M2,

                column.M3 * row.M1,
                column.M3 * row.M2,

                column.M4 * row.M1,
                column.M4 * row.M2,

                column.M5 * row.M1,
                column.M5 * row.M2,

                column.M6 * row.M1,
                column.M6 * row.M2
            );
        }

        public static Matrix6x2 FromColumns(Vector6 column1, Vector6 column2)
        {
            return new Matrix6x2
            (
                column1.M1, column2.M1,
                column1.M2, column2.M2,
                column1.M3, column2.M3,
                column1.M4, column2.M4,
                column1.M5, column2.M5,
                column1.M6, column2.M6
            );
        }

        public static Matrix6x2 FromRows(Vector2 row1, Vector2 row2, Vector2 row3, Vector2 row4, Vector2 row5, Vector2 row6)
        {
            return new Matrix6x2
            (
                row1.M1, row1.M2,
                row2.M1, row2.M2,
                row3.M1, row3.M2,
                row4.M1, row4.M2,
                row5.M1, row5.M2,
                row6.M1, row6.M2
            );
        }

        #endregion

        #region Operators

        public static Matrix6x2 operator +(Matrix6x2 a) => a;

        public static Matrix6x2 operator +(Matrix6x2 a, Matrix6x2 b)
        {
            return new Matrix6x2
            (
                a.M11 + b.M11, a.M12 + b.M12,
                a.M21 + b.M21, a.M22 + b.M22,
                a.M31 + b.M31, a.M32 + b.M32,
                a.M41 + b.M41, a.M42 + b.M42,
                a.M51 + b.M51, a.M52 + b.M52,
                a.M61 + b.M61, a.M62 + b.M62
            );
        }

        public static Matrix6x2 operator -(Matrix6x2 a) => a.Negated;

        public static Matrix6x2 operator -(Matrix6x2 a, Matrix6x2 b)
        {
            return new Matrix6x2
            (
                a.M11 - b.M11, a.M12 - b.M12,
                a.M21 - b.M21, a.M22 - b.M22,
                a.M31 - b.M31, a.M32 - b.M32,
                a.M41 - b.M41, a.M42 - b.M42,
                a.M51 - b.M51, a.M52 - b.M52,
                a.M61 - b.M61, a.M62 - b.M62
            );
        }

        public static Matrix6x2 operator *(Matrix6x2 a, double b)
        {
            return new Matrix6x2
            (
                a.M11 * b, a.M12 * b,
                a.M21 * b, a.M22 * b,
                a.M31 * b, a.M32 * b,
                a.M41 * b, a.M42 * b,
                a.M51 * b, a.M52 * b,
                a.M61 * b, a.M62 * b
            );
        }

        public static Matrix6x2 operator *(double a, Matrix6x2 b)
        {
            return new Matrix6x2
            (
                a * b.M11, a * b.M12,
                a * b.M21, a * b.M22,
                a * b.M31, a * b.M32,
                a * b.M41, a * b.M42,
                a * b.M51, a * b.M52,
                a * b.M61, a * b.M62
            );
        }

        public static Matrix6x2 operator /(Matrix6x2 a, double b)
        {
            return new Matrix6x2
            (
                a.M11 / b, a.M12 / b,
                a.M21 / b, a.M22 / b,
                a.M31 / b, a.M32 / b,
                a.M41 / b, a.M42 / b,
                a.M51 / b, a.M52 / b,
                a.M61 / b, a.M62 / b
            );
        }

        public static Matrix2x6 operator ~(Matrix6x2 a) => a.Transposed;

        #endregion

        #region Operators

        public static Matrix6x2 operator *(Matrix6x2 a, Matrix2x2 b)
        {
            return new Matrix6x2
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,

                a.M31 * b.M11 + a.M32 * b.M21,
                a.M31 * b.M12 + a.M32 * b.M22,

                a.M41 * b.M11 + a.M42 * b.M21,
                a.M41 * b.M12 + a.M42 * b.M22,

                a.M51 * b.M11 + a.M52 * b.M21,
                a.M51 * b.M12 + a.M52 * b.M22,

                a.M61 * b.M11 + a.M62 * b.M21,
                a.M61 * b.M12 + a.M62 * b.M22
            );
        }

        public static Matrix6x3 operator *(Matrix6x2 a, Matrix2x3 b)
        {
            return new Matrix6x3
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,
                a.M11 * b.M13 + a.M12 * b.M23,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,
                a.M21 * b.M13 + a.M22 * b.M23,

                a.M31 * b.M11 + a.M32 * b.M21,
                a.M31 * b.M12 + a.M32 * b.M22,
                a.M31 * b.M13 + a.M32 * b.M23,

                a.M41 * b.M11 + a.M42 * b.M21,
                a.M41 * b.M12 + a.M42 * b.M22,
                a.M41 * b.M13 + a.M42 * b.M23,

                a.M51 * b.M11 + a.M52 * b.M21,
                a.M51 * b.M12 + a.M52 * b.M22,
                a.M51 * b.M13 + a.M52 * b.M23,

                a.M61 * b.M11 + a.M62 * b.M21,
                a.M61 * b.M12 + a.M62 * b.M22,
                a.M61 * b.M13 + a.M62 * b.M23
            );
        }

        public static Matrix6x4 operator *(Matrix6x2 a, Matrix2x4 b)
        {
            return new Matrix6x4
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,
                a.M11 * b.M13 + a.M12 * b.M23,
                a.M11 * b.M14 + a.M12 * b.M24,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,
                a.M21 * b.M13 + a.M22 * b.M23,
                a.M21 * b.M14 + a.M22 * b.M24,

                a.M31 * b.M11 + a.M32 * b.M21,
                a.M31 * b.M12 + a.M32 * b.M22,
                a.M31 * b.M13 + a.M32 * b.M23,
                a.M31 * b.M14 + a.M32 * b.M24,

                a.M41 * b.M11 + a.M42 * b.M21,
                a.M41 * b.M12 + a.M42 * b.M22,
                a.M41 * b.M13 + a.M42 * b.M23,
                a.M41 * b.M14 + a.M42 * b.M24,

                a.M51 * b.M11 + a.M52 * b.M21,
                a.M51 * b.M12 + a.M52 * b.M22,
                a.M51 * b.M13 + a.M52 * b.M23,
                a.M51 * b.M14 + a.M52 * b.M24,

                a.M61 * b.M11 + a.M62 * b.M21,
                a.M61 * b.M12 + a.M62 * b.M22,
                a.M61 * b.M13 + a.M62 * b.M23,
                a.M61 * b.M14 + a.M62 * b.M24
            );
        }

        public static Matrix6x5 operator *(Matrix6x2 a, Matrix2x5 b)
        {
            return new Matrix6x5
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,
                a.M11 * b.M13 + a.M12 * b.M23,
                a.M11 * b.M14 + a.M12 * b.M24,
                a.M11 * b.M15 + a.M12 * b.M25,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,
                a.M21 * b.M13 + a.M22 * b.M23,
                a.M21 * b.M14 + a.M22 * b.M24,
                a.M21 * b.M15 + a.M22 * b.M25,

                a.M31 * b.M11 + a.M32 * b.M21,
                a.M31 * b.M12 + a.M32 * b.M22,
                a.M31 * b.M13 + a.M32 * b.M23,
                a.M31 * b.M14 + a.M32 * b.M24,
                a.M31 * b.M15 + a.M32 * b.M25,

                a.M41 * b.M11 + a.M42 * b.M21,
                a.M41 * b.M12 + a.M42 * b.M22,
                a.M41 * b.M13 + a.M42 * b.M23,
                a.M41 * b.M14 + a.M42 * b.M24,
                a.M41 * b.M15 + a.M42 * b.M25,

                a.M51 * b.M11 + a.M52 * b.M21,
                a.M51 * b.M12 + a.M52 * b.M22,
                a.M51 * b.M13 + a.M52 * b.M23,
                a.M51 * b.M14 + a.M52 * b.M24,
                a.M51 * b.M15 + a.M52 * b.M25,

                a.M61 * b.M11 + a.M62 * b.M21,
                a.M61 * b.M12 + a.M62 * b.M22,
                a.M61 * b.M13 + a.M62 * b.M23,
                a.M61 * b.M14 + a.M62 * b.M24,
                a.M61 * b.M15 + a.M62 * b.M25
            );
        }

        public static Matrix6x6 operator *(Matrix6x2 a, Matrix2x6 b)
        {
            return new Matrix6x6
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,
                a.M11 * b.M13 + a.M12 * b.M23,
                a.M11 * b.M14 + a.M12 * b.M24,
                a.M11 * b.M15 + a.M12 * b.M25,
                a.M11 * b.M16 + a.M12 * b.M26,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,
                a.M21 * b.M13 + a.M22 * b.M23,
                a.M21 * b.M14 + a.M22 * b.M24,
                a.M21 * b.M15 + a.M22 * b.M25,
                a.M21 * b.M16 + a.M22 * b.M26,

                a.M31 * b.M11 + a.M32 * b.M21,
                a.M31 * b.M12 + a.M32 * b.M22,
                a.M31 * b.M13 + a.M32 * b.M23,
                a.M31 * b.M14 + a.M32 * b.M24,
                a.M31 * b.M15 + a.M32 * b.M25,
                a.M31 * b.M16 + a.M32 * b.M26,

                a.M41 * b.M11 + a.M42 * b.M21,
                a.M41 * b.M12 + a.M42 * b.M22,
                a.M41 * b.M13 + a.M42 * b.M23,
                a.M41 * b.M14 + a.M42 * b.M24,
                a.M41 * b.M15 + a.M42 * b.M25,
                a.M41 * b.M16 + a.M42 * b.M26,

                a.M51 * b.M11 + a.M52 * b.M21,
                a.M51 * b.M12 + a.M52 * b.M22,
                a.M51 * b.M13 + a.M52 * b.M23,
                a.M51 * b.M14 + a.M52 * b.M24,
                a.M51 * b.M15 + a.M52 * b.M25,
                a.M51 * b.M16 + a.M52 * b.M26,

                a.M61 * b.M11 + a.M62 * b.M21,
                a.M61 * b.M12 + a.M62 * b.M22,
                a.M61 * b.M13 + a.M62 * b.M23,
                a.M61 * b.M14 + a.M62 * b.M24,
                a.M61 * b.M15 + a.M62 * b.M25,
                a.M61 * b.M16 + a.M62 * b.M26
            );
        }

        #endregion

        #region Operators

        public static Vector6 operator *(Matrix6x2 a, Vector2 b)
        {
            return new Vector6
            (
                a.M11 * b.M1 + a.M12 * b.M2,
                a.M21 * b.M1 + a.M22 * b.M2,
                a.M31 * b.M1 + a.M32 * b.M2,
                a.M41 * b.M1 + a.M42 * b.M2,
                a.M51 * b.M1 + a.M52 * b.M2,
                a.M61 * b.M1 + a.M62 * b.M2
            );
        }

        public static Vector2 operator *(Vector6 a, Matrix6x2 b)
        {
            return new Vector2
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31 + a.M4 * b.M41 + a.M5 * b.M51 + a.M6 * b.M61,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32 + a.M4 * b.M42 + a.M5 * b.M52 + a.M6 * b.M62
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix6x2 a, Matrix6x2 b) =>
			a.M11 == b.M11 && a.M12 == b.M12 && 
			a.M21 == b.M21 && a.M22 == b.M22 && 
			a.M31 == b.M31 && a.M32 == b.M32 && 
			a.M41 == b.M41 && a.M42 == b.M42 && 
			a.M51 == b.M51 && a.M52 == b.M52 && 
			a.M61 == b.M61 && a.M62 == b.M62;

		public static bool operator !=(Matrix6x2 a, Matrix6x2 b) =>
			a.M11 != b.M11 || a.M12 != b.M12 || 
			a.M21 != b.M21 || a.M22 != b.M22 || 
			a.M31 != b.M31 || a.M32 != b.M32 || 
			a.M41 != b.M41 || a.M42 != b.M42 || 
			a.M51 != b.M51 || a.M52 != b.M52 || 
			a.M61 != b.M61 || a.M62 != b.M62;

        #endregion

        #region Properties

        public Vector6 Column1 => new Vector6(M11, M21, M31, M41, M51, M61);

        public Vector6 Column2 => new Vector6(M12, M22, M32, M42, M52, M62);

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double M31 { get; set; }

        public double M32 { get; set; }

        public double M41 { get; set; }

        public double M42 { get; set; }

        public double M51 { get; set; }

        public double M52 { get; set; }

        public double M61 { get; set; }

        public double M62 { get; set; }

        public Matrix6x2 Negated
        {
            get
            {
                return new Matrix6x2
                (
                    -M11, -M12,
                    -M21, -M22,
                    -M31, -M32,
                    -M41, -M42,
                    -M51, -M52,
                    -M61, -M62
                );
            }
        }

        public Vector2 Row1 => new Vector2(M11, M12);

        public Vector2 Row2 => new Vector2(M21, M22);

        public Vector2 Row3 => new Vector2(M31, M32);

        public Vector2 Row4 => new Vector2(M41, M42);

        public Vector2 Row5 => new Vector2(M51, M52);

        public Vector2 Row6 => new Vector2(M61, M62);

        public Matrix2x6 Transposed
        {
            get
            {
                return new Matrix2x6
                (
                    M11, M21, M31, M41, M51, M61,
                    M12, M22, M32, M42, M52, M62
                );
            }
        }

        #endregion
    }
}
