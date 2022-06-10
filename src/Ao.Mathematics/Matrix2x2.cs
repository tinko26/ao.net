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
	public struct Matrix2x2 : IEquatable<Matrix2x2>
	{
		#region Constants

		public static readonly Matrix2x2 Identity = new Matrix2x2(1, 0, 0, 1);

		public static readonly Matrix2x2 Zero = new Matrix2x2();

		#endregion

		#region Construction

		public Matrix2x2
		(
			double m11, double m12,
			double m21, double m22
		)
		{
			M11 = m11;
			M12 = m12;
			M21 = m21;
			M22 = m22;
		}

		#endregion

		#region Methods

		public bool Equals(Matrix2x2 x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Matrix2x2)) return false;

			var y = (Matrix2x2)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M11.GetHashCode() ^ M12.GetHashCode() ^ 
			M21.GetHashCode() ^ M22.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix2x2 FromColumnAndRow(Vector2 column, Vector2 row)
        {
            return new Matrix2x2
            (
                column.M1 * row.M1,
                column.M1 * row.M2,

                column.M2 * row.M1,
                column.M2 * row.M2
            );
        }

        public static Matrix2x2 FromColumns(Vector2 column1, Vector2 column2)
        {
            return new Matrix2x2
            (
                column1.M1, column2.M1,
                column1.M2, column2.M2
            );
        }

        public static Matrix2x2 FromDiagonal(double m11, double m22)
        {
            return new Matrix2x2
            (
                m11, 0,
                0, m22
            );
        }

        public static Matrix2x2 FromDiagonal(Vector2 diagonal)
        {
            return new Matrix2x2
            (
                diagonal.M1, 0,
                0, diagonal.M2
            );
        }

        public static Matrix2x2 FromRows(Vector2 row1, Vector2 row2)
        {
            return new Matrix2x2
            (
                row1.M1, row1.M2,
                row2.M1, row2.M2
            );
        }

        public static Matrix2x2 Householder(Vector2 vector) => Identity - 2 * FromColumnAndRow(vector, vector);

        #endregion

        #region Operators

        public static Matrix2x2 operator +(Matrix2x2 a) => a;

        public static Matrix2x2 operator +(Matrix2x2 a, Matrix2x2 b)
        {
            return new Matrix2x2
            (
                a.M11 + b.M11, a.M12 + b.M12,
                a.M21 + b.M21, a.M22 + b.M22
            );
        }

        public static Matrix2x2 operator -(Matrix2x2 a) => a.Negated;

        public static Matrix2x2 operator -(Matrix2x2 a, Matrix2x2 b)
        {
            return new Matrix2x2
            (
                a.M11 - b.M11, a.M12 - b.M12,
                a.M21 - b.M21, a.M22 - b.M22
            );
        }

        public static Matrix2x2 operator *(Matrix2x2 a, Matrix2x2 b)
        {
            return new Matrix2x2
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22
            );
        }

        public static Matrix2x2 operator *(Matrix2x2 a, double b)
        {
            return new Matrix2x2
            (
                a.M11 * b, a.M12 * b,
                a.M21 * b, a.M22 * b
            );
        }

        public static Matrix2x2 operator *(double a, Matrix2x2 b)
        {
            return new Matrix2x2
            (
                a * b.M11, a * b.M12,
                a * b.M21, a * b.M22
            );
        }

        public static Matrix2x2 operator /(Matrix2x2 a, double b)
        {
            return new Matrix2x2
            (
                a.M11 / b, a.M12 / b,
                a.M21 / b, a.M22 / b
            );
        }

        public static Matrix2x2 operator ~(Matrix2x2 a) => a.Transposed;

        public static Matrix2x2 operator !(Matrix2x2 a) => a.Inverted;

        #endregion

        #region Operators

        public static Matrix2x3 operator *(Matrix2x2 a, Matrix2x3 b)
        {
            return new Matrix2x3
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,
                a.M11 * b.M13 + a.M12 * b.M23,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,
                a.M21 * b.M13 + a.M22 * b.M23
            );
        }

        public static Matrix2x4 operator *(Matrix2x2 a, Matrix2x4 b)
        {
            return new Matrix2x4
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,
                a.M11 * b.M13 + a.M12 * b.M23,
                a.M11 * b.M14 + a.M12 * b.M24,

                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,
                a.M21 * b.M13 + a.M22 * b.M23,
                a.M21 * b.M14 + a.M22 * b.M24
            );
        }

        public static Matrix2x5 operator *(Matrix2x2 a, Matrix2x5 b)
        {
            return new Matrix2x5
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
                a.M21 * b.M15 + a.M22 * b.M25
            );
        }

        public static Matrix2x6 operator *(Matrix2x2 a, Matrix2x6 b)
        {
            return new Matrix2x6
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
                a.M21 * b.M16 + a.M22 * b.M26
            );
        }

        #endregion

        #region Operators

        public static Vector2 operator *(Matrix2x2 a, Vector2 b)
        {
            return new Vector2
            (
                a.M11 * b.M1 + a.M12 * b.M2,
                a.M21 * b.M1 + a.M22 * b.M2
            );
        }

        public static Vector2 operator *(Vector2 a, Matrix2x2 b)
        {
            return new Vector2
            (
                a.M1 * b.M11 + a.M2 * b.M21,
                a.M1 * b.M12 + a.M2 * b.M22
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix2x2 a, Matrix2x2 b) =>
			a.M11 == b.M11 && a.M12 == b.M12 && 
			a.M21 == b.M21 && a.M22 == b.M22;

		public static bool operator !=(Matrix2x2 a, Matrix2x2 b) =>
			a.M11 != b.M11 || a.M12 != b.M12 || 
			a.M21 != b.M21 || a.M22 != b.M22;

        #endregion

        #region Properties

        public Matrix2x2 Adjugate
        {
            get
            {
                return new Matrix2x2
                (
                    M22, -M12,
                    -M21, M11
                );
            }
        }

        public Matrix2x2 AdjugateFromCofactors
        {
            get
            {
                return new Matrix2x2
                (
                    Cofactor11, Cofactor21,
                    Cofactor12, Cofactor22
                );
            }
        }

        public Matrix2x2 Cofactor
        {
            get
            {
                return new Matrix2x2
                (
                    Cofactor11, Cofactor12,
                    Cofactor21, Cofactor22
                );
            }
        }

        public double Cofactor11 => +Minor11;

        public double Cofactor12 => -Minor12;

        public double Cofactor21 => -Minor21;

        public double Cofactor22 => +Minor22;

        public Vector2 Column1 => new Vector2(M11, M21);

        public Vector2 Column2 => new Vector2(M12, M22);

        public double Determinant => M11 * M22 - M12 * M21;

        public Vector2 Diagonal => new Vector2(M11, M22);

        public Matrix2x2 Inverted => Adjugate / Determinant;

        public Matrix2x2 Lower
        {
            get
            {
                return new Matrix2x2
                (
                    M11, 0,
                    M21, M22
                );
            }
        }

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double Minor11 => Submatrix11;

        public double Minor12 => Submatrix12;

        public double Minor21 => Submatrix21;

        public double Minor22 => Submatrix22;

        public Matrix2x2 Negated
        {
            get
            {
                return new Matrix2x2
                (
                    -M11, -M12,
                    -M21, -M22
                );
            }
        }

        public Vector2 Row1 => new Vector2(M11, M12);

        public Vector2 Row2 => new Vector2(M21, M22);

        public Matrix2x2 Squared => this * this;

        public double Submatrix11 => M22;

        public double Submatrix12 => M21;

        public double Submatrix21 => M12;

        public double Submatrix22 => M11;

        public double Trace => M11 + M22;

        public Matrix2x2 Transposed
        {
            get
            {
                return new Matrix2x2
                (
                    M11, M21,
                    M12, M22
                );
            }
        }

        public Matrix2x2 Upper
        {
            get
            {
                return new Matrix2x2
                (
                    M11, M12,
                    0, M22
                );
            }
        }

        #endregion
    }
}
