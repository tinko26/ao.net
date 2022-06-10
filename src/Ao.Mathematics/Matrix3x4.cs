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
	public struct Matrix3x4 : IEquatable<Matrix3x4>
	{
		#region Constants

		public static readonly Matrix3x4 Zero = new Matrix3x4();

		#endregion

		#region Construction

		public Matrix3x4
		(
			double m11, double m12, double m13, double m14,
			double m21, double m22, double m23, double m24,
			double m31, double m32, double m33, double m34
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
		}

		#endregion

		#region Methods

		public bool Equals(Matrix3x4 x) => this == x;

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Matrix3x4)) return false;

			var y = (Matrix3x4)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^ M14.GetHashCode() ^ 
			M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode() ^ M24.GetHashCode() ^ 
			M31.GetHashCode() ^ M32.GetHashCode() ^ M33.GetHashCode() ^ M34.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix3x4 FromColumnAndRow(Vector3 column, Vector4 row)
        {
            return new Matrix3x4
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
                column.M3 * row.M4
            );
        }

        public static Matrix3x4 FromColumns(Vector3 column1, Vector3 column2, Vector3 column3, Vector3 column4)
        {
            return new Matrix3x4
            (
                column1.M1, column2.M1, column3.M1, column4.M1,
                column1.M2, column2.M2, column3.M2, column4.M2,
                column1.M3, column2.M3, column3.M3, column4.M3
            );
        }

        public static Matrix3x4 FromRows(Vector4 row1, Vector4 row2, Vector4 row3)
        {
            return new Matrix3x4
            (
                row1.M1, row1.M2, row1.M3, row1.M4,
                row2.M1, row2.M2, row2.M3, row2.M4,
                row3.M1, row3.M2, row3.M3, row3.M4
            );
        }

        #endregion

        #region Operators

        public static Matrix3x4 operator +(Matrix3x4 a) => a;

        public static Matrix3x4 operator +(Matrix3x4 a, Matrix3x4 b)
        {
            return new Matrix3x4
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13, a.M14 + b.M14,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23, a.M24 + b.M24,
                a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33, a.M34 + b.M34
            );
        }

        public static Matrix3x4 operator -(Matrix3x4 a) => a.Negated;

        public static Matrix3x4 operator -(Matrix3x4 a, Matrix3x4 b)
        {
            return new Matrix3x4
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13, a.M14 - b.M14,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23, a.M24 - b.M24,
                a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33, a.M34 - b.M34
            );
        }

        public static Matrix3x4 operator *(Matrix3x4 a, double b)
        {
            return new Matrix3x4
            (
                a.M11 * b, a.M12 * b, a.M13 * b, a.M14 * b,
                a.M21 * b, a.M22 * b, a.M23 * b, a.M24 * b,
                a.M31 * b, a.M32 * b, a.M33 * b, a.M34 * b
            );
        }

        public static Matrix3x4 operator *(double a, Matrix3x4 b)
        {
            return new Matrix3x4
            (
                a * b.M11, a * b.M12, a * b.M13, a * b.M14,
                a * b.M21, a * b.M22, a * b.M23, a * b.M24,
                a * b.M31, a * b.M32, a * b.M33, a * b.M34
            );
        }

        public static Matrix3x4 operator /(Matrix3x4 a, double b)
        {
            return new Matrix3x4
            (
                a.M11 / b, a.M12 / b, a.M13 / b, a.M14 / b,
                a.M21 / b, a.M22 / b, a.M23 / b, a.M24 / b,
                a.M31 / b, a.M32 / b, a.M33 / b, a.M34 / b
            );
        }

        public static Matrix4x3 operator ~(Matrix3x4 a) => a.Transposed;

        #endregion

        #region Operators

        public static Matrix3x2 operator *(Matrix3x4 a, Matrix4x2 b)
        {
            return new Matrix3x2
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42
            );
        }

        public static Matrix3x3 operator *(Matrix3x4 a, Matrix4x3 b)
        {
            return new Matrix3x3
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43
            );
        }

        public static Matrix3x4 operator *(Matrix3x4 a, Matrix4x4 b)
        {
            return new Matrix3x4
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
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44
            );
        }

        public static Matrix3x5 operator *(Matrix3x4 a, Matrix4x5 b)
        {
            return new Matrix3x5
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
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35 + a.M34 * b.M45
            );
        }

        public static Matrix3x6 operator *(Matrix3x4 a, Matrix4x6 b)
        {
            return new Matrix3x6
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
                a.M31 * b.M16 + a.M32 * b.M26 + a.M33 * b.M36 + a.M34 * b.M46
            );
        }

        #endregion

        #region Operators

        public static Vector3 operator *(Matrix3x4 a, Vector4 b)
        {
            return new Vector3
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3 + a.M14 * b.M4,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3 + a.M24 * b.M4,
                a.M31 * b.M1 + a.M32 * b.M2 + a.M33 * b.M3 + a.M34 * b.M4
            );
        }

        public static Vector4 operator *(Vector3 a, Matrix3x4 b)
        {
            return new Vector4
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32,
                a.M1 * b.M13 + a.M2 * b.M23 + a.M3 * b.M33,
                a.M1 * b.M14 + a.M2 * b.M24 + a.M3 * b.M34
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix3x4 a, Matrix3x4 b) =>
			a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 && a.M14 == b.M14 && 
			a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 && a.M24 == b.M24 && 
			a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33 && a.M34 == b.M34;

		public static bool operator !=(Matrix3x4 a, Matrix3x4 b) =>
			a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 || a.M14 != b.M14 || 
			a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 || a.M24 != b.M24 || 
			a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33 || a.M34 != b.M34;

        #endregion

        #region Properties

        public Vector3 Column1 => new Vector3(M11, M21, M31);

        public Vector3 Column2 => new Vector3(M12, M22, M32);

        public Vector3 Column3 => new Vector3(M13, M23, M33);

        public Vector3 Column4 => new Vector3(M14, M24, M34);

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

        public Matrix3x4 Negated
        {
            get
            {
                return new Matrix3x4
                (
                    -M11, -M12, -M13, -M14,
                    -M21, -M22, -M23, -M24,
                    -M31, -M32, -M33, -M34
                );
            }
        }

        public Vector4 Row1 => new Vector4(M11, M12, M13, M14);

        public Vector4 Row2 => new Vector4(M21, M22, M23, M24);

        public Vector4 Row3 => new Vector4(M31, M32, M33, M34);

        public Matrix4x3 Transposed
        {
            get
            {
                return new Matrix4x3
                (
                    M11, M21, M31,
                    M12, M22, M32,
                    M13, M23, M33,
                    M14, M24, M34
                );
            }
        }

        #endregion
    }
}
