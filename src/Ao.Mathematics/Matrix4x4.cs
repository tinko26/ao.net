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
	public struct Matrix4x4 : IEquatable<Matrix4x4>
	{
		#region Constants

		public static readonly Matrix4x4 Identity = new Matrix4x4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

		public static readonly Matrix4x4 Zero = new Matrix4x4();

		#endregion

		#region Construction

		public Matrix4x4
		(
			double m11, double m12, double m13, double m14,
			double m21, double m22, double m23, double m24,
			double m31, double m32, double m33, double m34,
			double m41, double m42, double m43, double m44
		)
		{
			M11 = m11;
			M12 = m12;
			M13 = m13;
			M14 = m14;
			M21 = m21;
			M22 = m22;
			M23 = m23;
			M24 = m24;
			M31 = m31;
			M32 = m32;
			M33 = m33;
			M34 = m34;
			M41 = m41;
			M42 = m42;
			M43 = m43;
			M44 = m44;
		}

		#endregion

		#region Methods

		public bool Equals(Matrix4x4 x) => this == x;

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Matrix4x4)) return false;

			var y = (Matrix4x4)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^ M14.GetHashCode() ^ 
			M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode() ^ M24.GetHashCode() ^ 
			M31.GetHashCode() ^ M32.GetHashCode() ^ M33.GetHashCode() ^ M34.GetHashCode() ^ 
			M41.GetHashCode() ^ M42.GetHashCode() ^ M43.GetHashCode() ^ M44.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix4x4 FromColumnAndRow(Vector4 column, Vector4 row)
        {
            return new Matrix4x4
            (
                column.M1 * row.M1,
                column.M1 * row.M2,
                column.M1 * row.M3,
                column.M1 * row.M4,

                column.M2 * row.M1,
                column.M2 * row.M2,
                column.M2 * row.M3,
                column.M2 * row.M4,

                column.M3 * row.M1,
                column.M3 * row.M2,
                column.M3 * row.M3,
                column.M3 * row.M4,

                column.M4 * row.M1,
                column.M4 * row.M2,
                column.M4 * row.M3,
                column.M4 * row.M4
            );
        }

        public static Matrix4x4 FromColumns(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
        {
            return new Matrix4x4
            (
                column1.M1, column2.M1, column3.M1, column4.M1,
                column1.M2, column2.M2, column3.M2, column4.M2,
                column1.M3, column2.M3, column3.M3, column4.M3,
                column1.M4, column2.M4, column3.M4, column4.M4
            );
        }

        public static Matrix4x4 FromDiagonal(double m11, double m22, double m33, double m44)
        {
            return new Matrix4x4
            (
                m11, 0, 0, 0,
                0, m22, 0, 0,
                0, 0, m33, 0,
                0, 0, 0, m44
            );
        }

        public static Matrix4x4 FromDiagonal(Vector4 diagonal)
        {
            return new Matrix4x4
            (
                diagonal.M1, 0, 0, 0,
                0, diagonal.M2, 0, 0,
                0, 0, diagonal.M3, 0,
                0, 0, 0, diagonal.M4
            );
        }

        public static Matrix4x4 FromRows(Vector4 row1, Vector4 row2, Vector4 row3, Vector4 row4)
        {
            return new Matrix4x4
            (
                row1.M1, row1.M2, row1.M3, row1.M4,
                row2.M1, row2.M2, row2.M3, row2.M4,
                row3.M1, row3.M2, row3.M3, row3.M4,
                row4.M1, row4.M2, row4.M3, row4.M4
            );
        }

        public static Matrix4x4 Householder(Vector4 vector) => Identity - 2 * FromColumnAndRow(vector, vector);

        #endregion

        #region Operators

        public static Matrix4x4 operator +(Matrix4x4 a) => a;

        public static Matrix4x4 operator +(Matrix4x4 a, Matrix4x4 b)
        {
            return new Matrix4x4
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13, a.M14 + b.M14,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23, a.M24 + b.M24,
                a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33, a.M34 + b.M34,
                a.M41 + b.M41, a.M42 + b.M42, a.M43 + b.M43, a.M44 + b.M44
            );
        }

        public static Matrix4x4 operator -(Matrix4x4 a) => a.Negated;

        public static Matrix4x4 operator -(Matrix4x4 a, Matrix4x4 b)
        {
            return new Matrix4x4
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13, a.M14 - b.M14,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23, a.M24 - b.M24,
                a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33, a.M34 - b.M34,
                a.M41 - b.M41, a.M42 - b.M42, a.M43 - b.M43, a.M44 - b.M44
            );
        }

        public static Matrix4x4 operator *(Matrix4x4 a, double b)
        {
            return new Matrix4x4
            (
                a.M11 * b, a.M12 * b, a.M13 * b, a.M14 * b,
                a.M21 * b, a.M22 * b, a.M23 * b, a.M24 * b,
                a.M31 * b, a.M32 * b, a.M33 * b, a.M34 * b,
                a.M41 * b, a.M42 * b, a.M43 * b, a.M44 * b
            );
        }

        public static Matrix4x4 operator *(double a, Matrix4x4 b)
        {
            return new Matrix4x4
            (
                a * b.M11, a * b.M12, a * b.M13, a * b.M14,
                a * b.M21, a * b.M22, a * b.M23, a * b.M24,
                a * b.M31, a * b.M32, a * b.M33, a * b.M34,
                a * b.M41, a * b.M42, a * b.M43, a * b.M44
            );
        }

        public static Matrix4x4 operator /(Matrix4x4 a, double b)
        {
            return new Matrix4x4
            (
                a.M11 / b, a.M12 / b, a.M13 / b, a.M14 / b,
                a.M21 / b, a.M22 / b, a.M23 / b, a.M24 / b,
                a.M31 / b, a.M32 / b, a.M33 / b, a.M34 / b,
                a.M41 / b, a.M42 / b, a.M43 / b, a.M44 / b
            );
        }

        public static Matrix4x4 operator ~(Matrix4x4 a) => a.Transposed;

        public static Matrix4x4 operator !(Matrix4x4 a) => a.Inverted;

        #endregion

        #region Operators

        public static Matrix4x2 operator *(Matrix4x4 a, Matrix4x2 b)
        {
            return new Matrix4x2
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42
            );
        }

        public static Matrix4x3 operator *(Matrix4x4 a, Matrix4x3 b)
        {
            return new Matrix4x3
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43
            );
        }

        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        {
            return new Matrix4x4
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44
            );
        }

        public static Matrix4x5 operator *(Matrix4x4 a, Matrix4x5 b)
        {
            return new Matrix4x5
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44,
                a.M11 * b.M15 + a.M12 * b.M25 + a.M13 * b.M35 + a.M14 * b.M45,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44,
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35 + a.M24 * b.M45,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44,
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35 + a.M34 * b.M45,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44,
                a.M41 * b.M15 + a.M42 * b.M25 + a.M43 * b.M35 + a.M44 * b.M45
            );
        }

        public static Matrix4x6 operator *(Matrix4x4 a, Matrix4x6 b)
        {
            return new Matrix4x6
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,
                a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44,
                a.M11 * b.M15 + a.M12 * b.M25 + a.M13 * b.M35 + a.M14 * b.M45,
                a.M11 * b.M16 + a.M12 * b.M26 + a.M13 * b.M36 + a.M14 * b.M46,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,
                a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44,
                a.M21 * b.M15 + a.M22 * b.M25 + a.M23 * b.M35 + a.M24 * b.M45,
                a.M21 * b.M16 + a.M22 * b.M26 + a.M23 * b.M36 + a.M24 * b.M46,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44,
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35 + a.M34 * b.M45,
                a.M31 * b.M16 + a.M32 * b.M26 + a.M33 * b.M36 + a.M34 * b.M46,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43,
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44,
                a.M41 * b.M15 + a.M42 * b.M25 + a.M43 * b.M35 + a.M44 * b.M45,
                a.M41 * b.M16 + a.M42 * b.M26 + a.M43 * b.M36 + a.M44 * b.M46
            );
        }

        #endregion

        #region Operators

        public static Vector4 operator *(Matrix4x4 a, Vector4 b)
        {
            return new Vector4
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3 + a.M14 * b.M4,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3 + a.M24 * b.M4,
                a.M31 * b.M1 + a.M32 * b.M2 + a.M33 * b.M3 + a.M34 * b.M4,
                a.M41 * b.M1 + a.M42 * b.M2 + a.M43 * b.M3 + a.M44 * b.M4
            );
        }

        public static Vector4 operator *(Vector4 a, Matrix4x4 b)
        {
            return new Vector4
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31 + a.M4 * b.M41,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32 + a.M4 * b.M42,
                a.M1 * b.M13 + a.M2 * b.M23 + a.M3 * b.M33 + a.M4 * b.M43,
                a.M1 * b.M14 + a.M2 * b.M24 + a.M3 * b.M34 + a.M4 * b.M44
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix4x4 a, Matrix4x4 b) =>
			a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 && a.M14 == b.M14 && 
			a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 && a.M24 == b.M24 && 
			a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33 && a.M34 == b.M34 && 
			a.M41 == b.M41 && a.M42 == b.M42 && a.M43 == b.M43 && a.M44 == b.M44;

		public static bool operator !=(Matrix4x4 a, Matrix4x4 b) =>
			a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 || a.M14 != b.M14 || 
			a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 || a.M24 != b.M24 || 
			a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33 || a.M34 != b.M34 || 
			a.M41 != b.M41 || a.M42 != b.M42 || a.M43 != b.M43 || a.M44 != b.M44;

        #endregion

        #region Properties

        public Matrix4x4 Adjugate
        {
            get
            {
                var t01 = M21 * M32 - M22 * M31;
                var t02 = M21 * M33 - M23 * M31;
                var t03 = M21 * M34 - M24 * M31;
                var t04 = M21 * M42 - M22 * M41;
                var t05 = M21 * M43 - M23 * M41;
                var t06 = M21 * M44 - M24 * M41;
                var t07 = M22 * M33 - M23 * M32;
                var t08 = M22 * M34 - M24 * M32;
                var t09 = M22 * M43 - M23 * M42;
                var t10 = M22 * M44 - M24 * M42;
                var t11 = M23 * M34 - M24 * M33;
                var t12 = M23 * M44 - M24 * M43;
                var t13 = M31 * M42 - M32 * M41;
                var t14 = M31 * M43 - M33 * M41;
                var t15 = M31 * M44 - M34 * M41;
                var t16 = M32 * M43 - M33 * M42;
                var t17 = M32 * M44 - M34 * M42;
                var t18 = M33 * M44 - M34 * M43;

                var m11 = M22 * t18 - M23 * t17 + M24 * t16;
                var m12 = M13 * t17 - M14 * t16 - M12 * t18;
                var m13 = M12 * t12 - M13 * t10 + M14 * t09;
                var m14 = M13 * t08 - M14 * t07 - M12 * t11;
                var m21 = M23 * t15 - M24 * t14 - M21 * t18;
                var m22 = M11 * t18 - M13 * t15 + M14 * t14;
                var m23 = M13 * t06 - M14 * t05 - M11 * t12;
                var m24 = M11 * t11 - M13 * t03 + M14 * t02;
                var m31 = M21 * t17 - M22 * t15 + M24 * t13;
                var m32 = M12 * t15 - M14 * t13 - M11 * t17;
                var m33 = M11 * t10 - M12 * t06 + M14 * t04;
                var m34 = M12 * t03 - M14 * t01 - M11 * t08;
                var m41 = M22 * t14 - M23 * t13 - M21 * t16;
                var m42 = M11 * t16 - M12 * t14 + M13 * t13;
                var m43 = M12 * t05 - M13 * t04 - M11 * t09;
                var m44 = M11 * t07 - M12 * t02 + M13 * t01;

                return new Matrix4x4
                (
                    m11, m12, m13, m14,
                    m21, m22, m23, m24,
                    m31, m32, m33, m34,
                    m41, m42, m43, m44
                );
            }
        }

        public Matrix4x4 AdjugateFromCofactors
        {
            get
            {
                return new Matrix4x4
                (
                    Cofactor11, Cofactor21, Cofactor31, Cofactor41,
                    Cofactor12, Cofactor22, Cofactor32, Cofactor42,
                    Cofactor13, Cofactor23, Cofactor33, Cofactor43,
                    Cofactor14, Cofactor24, Cofactor34, Cofactor44
                );
            }
        }

        public Matrix4x4 Cofactor
        {
            get
            {
                return new Matrix4x4
                (
                    Cofactor11, Cofactor12, Cofactor13, Cofactor14,
                    Cofactor21, Cofactor22, Cofactor23, Cofactor24,
                    Cofactor31, Cofactor32, Cofactor33, Cofactor34,
                    Cofactor41, Cofactor42, Cofactor43, Cofactor44
                );
            }
        }

        public double Cofactor11 => +Minor11;

        public double Cofactor12 => -Minor12;

        public double Cofactor13 => +Minor13;

        public double Cofactor14 => -Minor14;

        public double Cofactor21 => -Minor21;

        public double Cofactor22 => +Minor22;

        public double Cofactor23 => -Minor23;

        public double Cofactor24 => +Minor24;

        public double Cofactor31 => +Minor31;

        public double Cofactor32 => -Minor32;

        public double Cofactor33 => +Minor33;

        public double Cofactor34 => -Minor34;

        public double Cofactor41 => -Minor41;

        public double Cofactor42 => +Minor42;

        public double Cofactor43 => -Minor43;

        public double Cofactor44 => +Minor44;

        public Vector4 Column1 => new Vector4(M11, M21, M31, M41);

        public Vector4 Column2 => new Vector4(M12, M22, M32, M42);

        public Vector4 Column3 => new Vector4(M13, M23, M33, M43);

        public Vector4 Column4 => new Vector4(M14, M24, M34, M44);

        public double Determinant
        {
            get
            {
                var t1 = M31 * M42 - M41 * M32;
                var t2 = M31 * M43 - M41 * M33;
                var t3 = M31 * M44 - M41 * M34;
                var t4 = M32 * M43 - M42 * M33;
                var t5 = M32 * M44 - M42 * M34;
                var t6 = M33 * M44 - M43 * M34;

                return
                    M11 * (M22 * t6 - M23 * t5 + M24 * t4) -
                    M12 * (M21 * t6 - M23 * t3 + M24 * t2) +
                    M13 * (M21 * t5 - M22 * t3 + M24 * t1) -
                    M14 * (M21 * t4 - M22 * t2 + M23 * t1);
            }
        }

        public Vector4 Diagonal => new Vector4(M11, M22, M33, M44);

        public Matrix4x4 Inverted => Adjugate / Determinant;

        public Matrix4x4 Lower
        {
            get
            {
                return new Matrix4x4
                (
                    M11, 0, 0, 0,
                    M21, M22, 0, 0,
                    M31, M32, M33, 0,
                    M41, M42, M43, M44
                );
            }
        }

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M13 { get; set; }

        public double M14 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double M23 { get; set; }

        public double M24 { get; set; }

        public double M31 { get; set; }

        public double M32 { get; set; }

        public double M33 { get; set; }

        public double M34 { get; set; }

        public double M41 { get; set; }

        public double M42 { get; set; }

        public double M43 { get; set; }

        public double M44 { get; set; }

        public double Minor11 => Submatrix11.Determinant;

        public double Minor12 => Submatrix12.Determinant;

        public double Minor13 => Submatrix13.Determinant;

        public double Minor14 => Submatrix14.Determinant;

        public double Minor21 => Submatrix21.Determinant;

        public double Minor22 => Submatrix22.Determinant;

        public double Minor23 => Submatrix23.Determinant;

        public double Minor24 => Submatrix24.Determinant;

        public double Minor31 => Submatrix31.Determinant;

        public double Minor32 => Submatrix32.Determinant;

        public double Minor33 => Submatrix33.Determinant;

        public double Minor34 => Submatrix34.Determinant;

        public double Minor41 => Submatrix41.Determinant;

        public double Minor42 => Submatrix42.Determinant;

        public double Minor43 => Submatrix43.Determinant;

        public double Minor44 => Submatrix44.Determinant;

        public Matrix4x4 Negated
        {
            get
            {
                return new Matrix4x4
                (
                    -M11, -M12, -M13, -M14,
                    -M21, -M22, -M23, -M24,
                    -M31, -M32, -M33, -M34,
                    -M41, -M42, -M43, -M44
                );
            }
        }

        public Vector4 Row1 => new Vector4(M11, M12, M13, M14);

        public Vector4 Row2 => new Vector4(M21, M22, M23, M24);

        public Vector4 Row3 => new Vector4(M31, M32, M33, M34);

        public Vector4 Row4 => new Vector4(M41, M42, M43, M44);

        public Matrix4x4 Squared => this * this;

        public Matrix3x3 Submatrix11 => new Matrix3x3(M22, M23, M24, M32, M33, M34, M42, M43, M44);

        public Matrix3x3 Submatrix12 => new Matrix3x3(M21, M23, M24, M31, M33, M34, M41, M43, M44);

        public Matrix3x3 Submatrix13 => new Matrix3x3(M21, M22, M24, M31, M32, M34, M41, M42, M44);

        public Matrix3x3 Submatrix14 => new Matrix3x3(M21, M22, M23, M31, M32, M33, M41, M42, M43);

        public Matrix3x3 Submatrix21 => new Matrix3x3(M12, M13, M14, M32, M33, M34, M42, M43, M44);

        public Matrix3x3 Submatrix22 => new Matrix3x3(M11, M13, M14, M31, M33, M34, M41, M43, M44);

        public Matrix3x3 Submatrix23 => new Matrix3x3(M11, M12, M14, M31, M32, M34, M41, M42, M44);

        public Matrix3x3 Submatrix24 => new Matrix3x3(M11, M12, M13, M31, M32, M33, M41, M42, M43);

        public Matrix3x3 Submatrix31 => new Matrix3x3(M12, M13, M14, M22, M23, M24, M42, M43, M44);

        public Matrix3x3 Submatrix32 => new Matrix3x3(M11, M13, M14, M21, M23, M24, M41, M43, M44);

        public Matrix3x3 Submatrix33 => new Matrix3x3(M11, M12, M14, M21, M22, M24, M41, M42, M44);

        public Matrix3x3 Submatrix34 => new Matrix3x3(M11, M12, M13, M21, M22, M23, M41, M42, M43);

        public Matrix3x3 Submatrix41 => new Matrix3x3(M12, M13, M14, M22, M23, M24, M32, M33, M34);

        public Matrix3x3 Submatrix42 => new Matrix3x3(M11, M13, M14, M21, M23, M24, M31, M33, M34);

        public Matrix3x3 Submatrix43 => new Matrix3x3(M11, M12, M14, M21, M22, M24, M31, M32, M34);

        public Matrix3x3 Submatrix44 => new Matrix3x3(M11, M12, M13, M21, M22, M23, M31, M32, M33);

        public double Trace => M11 + M22 + M33 + M44;

        public Matrix4x4 Transposed
        {
            get
            {
                return new Matrix4x4
                (
                    M11, M21, M31, M41,
                    M12, M22, M32, M42,
                    M13, M23, M33, M43,
                    M14, M24, M34, M44
                );
            }
        }

        public Matrix4x4 Upper
        {
            get
            {
                return new Matrix4x4
                (
                    M11, M12, M13, M14,
                    0, M22, M23, M24,
                    0, 0, M33, M34,
                    0, 0, 0, M44
                );
            }
        }

        #endregion
    }
}
