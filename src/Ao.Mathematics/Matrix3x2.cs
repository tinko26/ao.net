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
	public struct Matrix3x2 : IEquatable<Matrix3x2>
	{
		#region Constants

		public static readonly Matrix3x2 Zero = new Matrix3x2();

		#endregion

		#region Construction

		public Matrix3x2
		(
			double m11, double m12,
			double m21, double m22,
			double m31, double m32
		)
		{
			M11 = m11;
			M12 = m12;
			M21 = m21;
			M22 = m22;
			M31 = m31;
			M32 = m32;
		}

		#endregion

		#region Methods

		public bool Equals(Matrix3x2 x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Matrix3x2)) return false;

			var y = (Matrix3x2)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M11.GetHashCode() ^ M12.GetHashCode() ^ 
			M21.GetHashCode() ^ M22.GetHashCode() ^ 
			M31.GetHashCode() ^ M32.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix3x2 FromColumnAndRow(Vector3 column, Vector2 row)
        {
            return new Matrix3x2
            (
                column.M1 * row.M1,
                column.M1 * row.M2,

                column.M2 * row.M1,
                column.M2 * row.M2,

                column.M3 * row.M1,
                column.M3 * row.M2
            );
        }

        public static Matrix3x2 FromColumns(Vector3 column1, Vector3 column2)
        {
            return new Matrix3x2
            (
                column1.M1, column2.M1,
                column1.M2, column2.M2,
                column1.M3, column2.M3
            );
        }

        public static Matrix3x2 FromRows(Vector2 row1, Vector2 row2, Vector2 row3)
        {
            return new Matrix3x2
            (
                row1.M1, row1.M2,
                row2.M1, row2.M2,
                row3.M1, row3.M2
            );
        }

        #endregion

        #region Operators

        public static Matrix3x2 operator +(Matrix3x2 a) => a;

        public static Matrix3x2 operator +(Matrix3x2 a, Matrix3x2 b)
        {
            return new Matrix3x2
            (
                a.M11 + b.M11, a.M12 + b.M12,
                a.M21 + b.M21, a.M22 + b.M22,
                a.M31 + b.M31, a.M32 + b.M32
            );
        }

        public static Matrix3x2 operator -(Matrix3x2 a) => a.Negated;

        public static Matrix3x2 operator -(Matrix3x2 a, Matrix3x2 b)
        {
            return new Matrix3x2
            (
                a.M11 - b.M11, a.M12 - b.M12,
                a.M21 - b.M21, a.M22 - b.M22,
                a.M31 - b.M31, a.M32 - b.M32
            );
        }

        public static Matrix3x2 operator *(Matrix3x2 a, double b)
        {
            return new Matrix3x2
            (
                a.M11 * b, a.M12 * b,
                a.M21 * b, a.M22 * b,
                a.M31 * b, a.M32 * b
            );
        }

        public static Matrix3x2 operator *(double a, Matrix3x2 b)
        {
            return new Matrix3x2
            (
                a * b.M11, a * b.M12,
                a * b.M21, a * b.M22,
                a * b.M31, a * b.M32
            );
        }

        public static Matrix3x2 operator /(Matrix3x2 a, double b)
        {
            return new Matrix3x2
            (
                a.M11 / b, a.M12 / b,
                a.M21 / b, a.M22 / b,
                a.M31 / b, a.M32 / b
            );
        }

        public static Matrix2x3 operator ~(Matrix3x2 a) => a.Transposed;

        #endregion

        #region Operators

        public static Matrix3x2 operator *(Matrix3x2 a, Matrix2x2 b)
        {
            return new Matrix3x2
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,

                a.M31 * b.M11 + a.M32 * b.M21,
                a.M31 * b.M12 + a.M32 * b.M22
            );
        }

        public static Matrix3x3 operator *(Matrix3x2 a, Matrix2x3 b)
        {
            return new Matrix3x3
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,
                a.M11 * b.M13 + a.M12 * b.M23,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,
                a.M21 * b.M13 + a.M22 * b.M23,

                a.M31 * b.M11 + a.M32 * b.M21,
                a.M31 * b.M12 + a.M32 * b.M22,
                a.M31 * b.M13 + a.M32 * b.M23
            );
        }

        public static Matrix3x4 operator *(Matrix3x2 a, Matrix2x4 b)
        {
            return new Matrix3x4
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
                a.M31 * b.M14 + a.M32 * b.M24
            );
        }

        public static Matrix3x5 operator *(Matrix3x2 a, Matrix2x5 b)
        {
            return new Matrix3x5
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
                a.M31 * b.M15 + a.M32 * b.M25
            );
        }

        public static Matrix3x6 operator *(Matrix3x2 a, Matrix2x6 b)
        {
            return new Matrix3x6
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
                a.M31 * b.M16 + a.M32 * b.M26
            );
        }

        #endregion

        #region Operators

        public static Vector3 operator *(Matrix3x2 a, Vector2 b)
        {
            return new Vector3
            (
                a.M11 * b.M1 + a.M12 * b.M2,
                a.M21 * b.M1 + a.M22 * b.M2,
                a.M31 * b.M1 + a.M32 * b.M2
            );
        }

        public static Vector2 operator *(Vector3 a, Matrix3x2 b)
        {
            return new Vector2
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix3x2 a, Matrix3x2 b) =>
			a.M11 == b.M11 && a.M12 == b.M12 && 
			a.M21 == b.M21 && a.M22 == b.M22 && 
			a.M31 == b.M31 && a.M32 == b.M32;

		public static bool operator !=(Matrix3x2 a, Matrix3x2 b) =>
			a.M11 != b.M11 || a.M12 != b.M12 || 
			a.M21 != b.M21 || a.M22 != b.M22 || 
			a.M31 != b.M31 || a.M32 != b.M32;

        #endregion

        #region Properties

        public Vector3 Column1 => new Vector3(M11, M21, M31);

        public Vector3 Column2 => new Vector3(M12, M22, M32);

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double M31 { get; set; }

        public double M32 { get; set; }

        public Matrix3x2 Negated
        {
            get
            {
                return new Matrix3x2
                (
                    -M11, -M12,
                    -M21, -M22,
                    -M31, -M32
                );
            }
        }

        public Vector2 Row1 => new Vector2(M11, M12);

        public Vector2 Row2 => new Vector2(M21, M22);

        public Vector2 Row3 => new Vector2(M31, M32);

        public Matrix2x3 Transposed
        {
            get
            {
                return new Matrix2x3
                (
                    M11, M21, M31,
                    M12, M22, M32
                );
            }
        }

        #endregion
    }
}
