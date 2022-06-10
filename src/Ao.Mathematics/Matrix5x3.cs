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
	public struct Matrix5x3 : IEquatable<Matrix5x3>
	{
		#region Constants

		public static readonly Matrix5x3 Zero = new Matrix5x3();

		#endregion

		#region Construction

		public Matrix5x3
		(
			double m11, double m12, double m13,
			double m21, double m22, double m23,
			double m31, double m32, double m33,
			double m41, double m42, double m43,
			double m51, double m52, double m53
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
			M51 = m51;
			M52 = m52;
			M53 = m53;
		}

		#endregion

		#region Methods

		public bool Equals(Matrix5x3 x) => this == x;

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Matrix5x3)) return false;

			var y = (Matrix5x3)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^ 
			M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode() ^ 
			M31.GetHashCode() ^ M32.GetHashCode() ^ M33.GetHashCode() ^ 
			M41.GetHashCode() ^ M42.GetHashCode() ^ M43.GetHashCode() ^ 
			M51.GetHashCode() ^ M52.GetHashCode() ^ M53.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix5x3 FromColumnAndRow(Vector5 column, Vector3 row)
        {
            return new Matrix5x3
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
                column.M4 * row.M3,

                column.M5 * row.M1,
                column.M5 * row.M2,
                column.M5 * row.M3
            );
        }

        public static Matrix5x3 FromColumns(Vector5 column1, Vector5 column2, Vector5 column3)
        {
            return new Matrix5x3
            (
                column1.M1, column2.M1, column3.M1,
                column1.M2, column2.M2, column3.M2,
                column1.M3, column2.M3, column3.M3,
                column1.M4, column2.M4, column3.M4,
                column1.M5, column2.M5, column3.M5
            );
        }

        public static Matrix5x3 FromRows(Vector3 row1, Vector3 row2, Vector3 row3, Vector3 row4, Vector3 row5)
        {
            return new Matrix5x3
            (
                row1.M1, row1.M2, row1.M3,
                row2.M1, row2.M2, row2.M3,
                row3.M1, row3.M2, row3.M3,
                row4.M1, row4.M2, row4.M3,
                row5.M1, row5.M2, row5.M3
            );
        }

        #endregion

        #region Operators

        public static Matrix5x3 operator +(Matrix5x3 a) => a;

        public static Matrix5x3 operator +(Matrix5x3 a, Matrix5x3 b)
        {
            return new Matrix5x3
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23,
                a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33,
                a.M41 + b.M41, a.M42 + b.M42, a.M43 + b.M43,
                a.M51 + b.M51, a.M52 + b.M52, a.M53 + b.M53
            );
        }

        public static Matrix5x3 operator -(Matrix5x3 a) => a.Negated;

        public static Matrix5x3 operator -(Matrix5x3 a, Matrix5x3 b)
        {
            return new Matrix5x3
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23,
                a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33,
                a.M41 - b.M41, a.M42 - b.M42, a.M43 - b.M43,
                a.M51 - b.M51, a.M52 - b.M52, a.M53 - b.M53
            );
        }

        public static Matrix5x3 operator *(Matrix5x3 a, double b)
        {
            return new Matrix5x3
            (
                a.M11 * b, a.M12 * b, a.M13 * b,
                a.M21 * b, a.M22 * b, a.M23 * b,
                a.M31 * b, a.M32 * b, a.M33 * b,
                a.M41 * b, a.M42 * b, a.M43 * b,
                a.M51 * b, a.M52 * b, a.M53 * b
            );
        }

        public static Matrix5x3 operator *(double a, Matrix5x3 b)
        {
            return new Matrix5x3
            (
                a * b.M11, a * b.M12, a * b.M13,
                a * b.M21, a * b.M22, a * b.M23,
                a * b.M31, a * b.M32, a * b.M33,
                a * b.M41, a * b.M42, a * b.M43,
                a * b.M51, a * b.M52, a * b.M53
            );
        }

        public static Matrix5x3 operator /(Matrix5x3 a, double b)
        {
            return new Matrix5x3
            (
                a.M11 / b, a.M12 / b, a.M13 / b,
                a.M21 / b, a.M22 / b, a.M23 / b,
                a.M31 / b, a.M32 / b, a.M33 / b,
                a.M41 / b, a.M42 / b, a.M43 / b,
                a.M51 / b, a.M52 / b, a.M53 / b
            );
        }

        public static Matrix3x5 operator ~(Matrix5x3 a) => a.Transposed;

        #endregion

        #region Operators

        public static Matrix5x2 operator *(Matrix5x3 a, Matrix3x2 b)
        {
            return new Matrix5x2
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,

                a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31,
                a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32
            );
        }

        public static Matrix5x3 operator *(Matrix5x3 a, Matrix3x3 b)
        {
            return new Matrix5x3
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
                a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33
            );
        }

        public static Matrix5x4 operator *(Matrix5x3 a, Matrix3x4 b)
        {
            return new Matrix5x4
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
                a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33,
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34
            );
        }

        public static Matrix5x5 operator *(Matrix5x3 a, Matrix3x5 b)
        {
            return new Matrix5x5
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
                a.M41 * b.M15 + a.M42 * b.M25 + a.M43 * b.M35,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33,
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34,
                a.M51 * b.M15 + a.M52 * b.M25 + a.M53 * b.M35
            );
        }

        public static Matrix5x6 operator *(Matrix5x3 a, Matrix3x6 b)
        {
            return new Matrix5x6
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
                a.M41 * b.M16 + a.M42 * b.M26 + a.M43 * b.M36,

                a.M51 * b.M11 + a.M52 * b.M21 + a.M53 * b.M31,
                a.M51 * b.M12 + a.M52 * b.M22 + a.M53 * b.M32,
                a.M51 * b.M13 + a.M52 * b.M23 + a.M53 * b.M33,
                a.M51 * b.M14 + a.M52 * b.M24 + a.M53 * b.M34,
                a.M51 * b.M15 + a.M52 * b.M25 + a.M53 * b.M35,
                a.M51 * b.M16 + a.M52 * b.M26 + a.M53 * b.M36
            );
        }

        #endregion

        #region Operators

        public static Vector5 operator *(Matrix5x3 a, Vector3 b)
        {
            return new Vector5
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3,
                a.M31 * b.M1 + a.M32 * b.M2 + a.M33 * b.M3,
                a.M41 * b.M1 + a.M42 * b.M2 + a.M43 * b.M3,
                a.M51 * b.M1 + a.M52 * b.M2 + a.M53 * b.M3
            );
        }

        public static Vector3 operator *(Vector5 a, Matrix5x3 b)
        {
            return new Vector3
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31 + a.M4 * b.M41 + a.M5 * b.M51,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32 + a.M4 * b.M42 + a.M5 * b.M52,
                a.M1 * b.M13 + a.M2 * b.M23 + a.M3 * b.M33 + a.M4 * b.M43 + a.M5 * b.M53
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix5x3 a, Matrix5x3 b) =>
			a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 && 
			a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 && 
			a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33 && 
			a.M41 == b.M41 && a.M42 == b.M42 && a.M43 == b.M43 && 
			a.M51 == b.M51 && a.M52 == b.M52 && a.M53 == b.M53;

		public static bool operator !=(Matrix5x3 a, Matrix5x3 b) =>
			a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 || 
			a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 || 
			a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33 || 
			a.M41 != b.M41 || a.M42 != b.M42 || a.M43 != b.M43 || 
			a.M51 != b.M51 || a.M52 != b.M52 || a.M53 != b.M53;

        #endregion

        #region Properties

        public Vector5 Column1 => new Vector5(M11, M21, M31, M41, M51);

        public Vector5 Column2 => new Vector5(M12, M22, M32, M42, M52);

        public Vector5 Column3 => new Vector5(M13, M23, M33, M43, M53);

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

        public double M51 { get; set; }

        public double M52 { get; set; }

        public double M53 { get; set; }

        public Matrix5x3 Negated
        {
            get
            {
                return new Matrix5x3
                (
                    -M11, -M12, -M13,
                    -M21, -M22, -M23,
                    -M31, -M32, -M33,
                    -M41, -M42, -M43,
                    -M51, -M52, -M53
                );
            }
        }

        public Vector3 Row1 => new Vector3(M11, M12, M13);

        public Vector3 Row2 => new Vector3(M21, M22, M23);

        public Vector3 Row3 => new Vector3(M31, M32, M33);

        public Vector3 Row4 => new Vector3(M41, M42, M43);

        public Vector3 Row5 => new Vector3(M51, M52, M53);

        public Matrix3x5 Transposed
        {
            get
            {
                return new Matrix3x5
                (
                    M11, M21, M31, M41, M51,
                    M12, M22, M32, M42, M52,
                    M13, M23, M33, M43, M53
                );
            }
        }

        #endregion
    }
}
