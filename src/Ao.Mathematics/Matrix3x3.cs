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
    public struct Matrix3x3 : IEquatable<Matrix3x3>
    {
        #region Constants

        public static readonly Matrix3x3 Identity = new Matrix3x3(1, 0, 0, 0, 1, 0, 0, 0, 1);

        public static readonly Matrix3x3 Zero = new Matrix3x3();

        #endregion

        #region Construction

        public Matrix3x3
        (
            double m11, double m12, double m13,
            double m21, double m22, double m23,
            double m31, double m32, double m33
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
        }

        #endregion

        #region Methods

        public bool Equals(Matrix3x3 x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Matrix3x3)) return false;

            var y = (Matrix3x3)x;

            return this == y;
        }

        public override int GetHashCode() =>
            M11.GetHashCode() ^ M12.GetHashCode() ^ M13.GetHashCode() ^
            M21.GetHashCode() ^ M22.GetHashCode() ^ M23.GetHashCode() ^
            M31.GetHashCode() ^ M32.GetHashCode() ^ M33.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Matrix3x3 FromColumnAndRow(Vector3 column, Vector3 row)
        {
            return new Matrix3x3
            (
                column.M1 * row.M1,
                column.M1 * row.M2,
                column.M1 * row.M3,

                column.M2 * row.M1,
                column.M2 * row.M2,
                column.M2 * row.M3,

                column.M3 * row.M1,
                column.M3 * row.M2,
                column.M3 * row.M3
            );
        }

        public static Matrix3x3 FromColumns(Vector3 column1, Vector3 column2, Vector3 column3)
        {
            return new Matrix3x3
            (
                column1.M1, column2.M1, column3.M1,
                column1.M2, column2.M2, column3.M2,
                column1.M3, column2.M3, column3.M3
            );
        }

        public static Matrix3x3 FromDiagonal(double m11, double m22, double m33)
        {
            return new Matrix3x3
            (
                m11, 0, 0,
                0, m22, 0,
                0, 0, m33
            );
        }

        public static Matrix3x3 FromDiagonal(Vector3 diagonal)
        {
            return new Matrix3x3
            (
                diagonal.M1, 0, 0,
                0, diagonal.M2, 0,
                0, 0, diagonal.M3
            );
        }

        public static Matrix3x3 FromRows(Vector3 row1, Vector3 row2, Vector3 row3)
        {
            return new Matrix3x3
            (
                row1.M1, row1.M2, row1.M3,
                row2.M1, row2.M2, row2.M3,
                row3.M1, row3.M2, row3.M3
            );
        }

        public static Matrix3x3 Householder(Vector3 vector) => Identity - 2 * FromColumnAndRow(vector, vector);

        #endregion

        #region Operators

        public static Matrix3x3 operator +(Matrix3x3 a) => a;

        public static Matrix3x3 operator +(Matrix3x3 a, Matrix3x3 b)
        {
            return new Matrix3x3
            (
                a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13,
                a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23,
                a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33
            );
        }

        public static Matrix3x3 operator -(Matrix3x3 a) => a.Negated;

        public static Matrix3x3 operator -(Matrix3x3 a, Matrix3x3 b)
        {
            return new Matrix3x3
            (
                a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13,
                a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23,
                a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33
            );
        }

        public static Matrix3x3 operator *(Matrix3x3 a, double b)
        {
            return new Matrix3x3
            (
                a.M11 * b, a.M12 * b, a.M13 * b,
                a.M21 * b, a.M22 * b, a.M23 * b,
                a.M31 * b, a.M32 * b, a.M33 * b
            );
        }

        public static Matrix3x3 operator *(double a, Matrix3x3 b)
        {
            return new Matrix3x3
            (
                a * b.M11, a * b.M12, a * b.M13,
                a * b.M21, a * b.M22, a * b.M23,
                a * b.M31, a * b.M32, a * b.M33
            );
        }

        public static Matrix3x3 operator /(Matrix3x3 a, double b)
        {
            return new Matrix3x3
            (
                a.M11 / b, a.M12 / b, a.M13 / b,
                a.M21 / b, a.M22 / b, a.M23 / b,
                a.M31 / b, a.M32 / b, a.M33 / b
            );
        }

        public static Matrix3x3 operator ~(Matrix3x3 a) => a.Transposed;

        public static Matrix3x3 operator !(Matrix3x3 a) => a.Inverted;

        #endregion

        #region Operators

        public static Matrix3x2 operator *(Matrix3x3 a, Matrix3x2 b)
        {
            return new Matrix3x2
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32
            );
        }

        public static Matrix3x3 operator *(Matrix3x3 a, Matrix3x3 b)
        {
            return new Matrix3x3
            (
                a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
                a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,

                a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
                a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,

                a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
                a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,
                a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33
            );
        }

        public static Matrix3x4 operator *(Matrix3x3 a, Matrix3x4 b)
        {
            return new Matrix3x4
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
                a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34
            );
        }

        public static Matrix3x5 operator *(Matrix3x3 a, Matrix3x5 b)
        {
            return new Matrix3x5
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
                a.M31 * b.M15 + a.M32 * b.M25 + a.M33 * b.M35
            );
        }

        public static Matrix3x6 operator *(Matrix3x3 a, Matrix3x6 b)
        {
            return new Matrix3x6
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
                a.M31 * b.M16 + a.M32 * b.M26 + a.M33 * b.M36
            );
        }

        #endregion

        #region Operators

        public static Vector3 operator *(Matrix3x3 a, Vector3 b)
        {
            return new Vector3
            (
                a.M11 * b.M1 + a.M12 * b.M2 + a.M13 * b.M3,
                a.M21 * b.M1 + a.M22 * b.M2 + a.M23 * b.M3,
                a.M31 * b.M1 + a.M32 * b.M2 + a.M33 * b.M3
            );
        }

        public static Vector3 operator *(Vector3 a, Matrix3x3 b)
        {
            return new Vector3
            (
                a.M1 * b.M11 + a.M2 * b.M21 + a.M3 * b.M31,
                a.M1 * b.M12 + a.M2 * b.M22 + a.M3 * b.M32,
                a.M1 * b.M13 + a.M2 * b.M23 + a.M3 * b.M33
            );
        }

        #endregion

        #region Operators

        public static bool operator ==(Matrix3x3 a, Matrix3x3 b) =>
            a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 &&
            a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 &&
            a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33;

        public static bool operator !=(Matrix3x3 a, Matrix3x3 b) =>
            a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 ||
            a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 ||
            a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33;

        #endregion

        #region Properties

        public Matrix3x3 Adjugate
        {
            get
            {
                var m11 = M22 * M33 - M23 * M32;
                var m12 = M13 * M32 - M12 * M33;
                var m13 = M12 * M23 - M13 * M22;

                var m21 = M23 * M31 - M21 * M33;
                var m22 = M11 * M33 - M13 * M31;
                var m23 = M13 * M21 - M11 * M23;

                var m31 = M21 * M32 - M22 * M31;
                var m32 = M12 * M31 - M11 * M32;
                var m33 = M11 * M22 - M12 * M21;

                return new Matrix3x3
                (
                    m11, m12, m13,
                    m21, m22, m23,
                    m31, m32, m33
                );
            }
        }

        public Matrix3x3 AdjugateFromCofactors
        {
            get
            {
                return new Matrix3x3
                (
                    Cofactor11, Cofactor21, Cofactor31,
                    Cofactor12, Cofactor22, Cofactor32,
                    Cofactor13, Cofactor23, Cofactor33
                );
            }
        }

        public Matrix3x3 Cofactor
        {
            get
            {
                return new Matrix3x3
                (
                    Cofactor11, Cofactor12, Cofactor13,
                    Cofactor21, Cofactor22, Cofactor23,
                    Cofactor31, Cofactor32, Cofactor33
                );
            }
        }

        public double Cofactor11 => +Minor11;

        public double Cofactor12 => -Minor12;

        public double Cofactor13 => +Minor13;

        public double Cofactor21 => -Minor21;

        public double Cofactor22 => +Minor22;

        public double Cofactor23 => -Minor23;

        public double Cofactor31 => +Minor31;

        public double Cofactor32 => -Minor32;

        public double Cofactor33 => +Minor33;

        public Vector3 Column1 => new Vector3(M11, M21, M31);

        public Vector3 Column2 => new Vector3(M12, M22, M32);

        public Vector3 Column3 => new Vector3(M13, M23, M33);

        public double Determinant
        {
            get
            {
                return
                    M11 * (M22 * M33 - M23 * M32) -
                    M12 * (M21 * M33 - M23 * M31) +
                    M13 * (M21 * M32 - M22 * M31);
            }
        }

        public Vector3 Diagonal => new Vector3(M11, M22, M33);

        public Matrix3x3 Inverted => Adjugate / Determinant;

        public Matrix3x3 Lower
        {
            get
            {
                return new Matrix3x3
                (
                    M11, 0, 0,
                    M21, M22, 0,
                    M31, M32, M33
                );
            }
        }

        public double M11 { get; set; }

        public double M12 { get; set; }

        public double M13 { get; set; }

        public double M21 { get; set; }

        public double M22 { get; set; }

        public double M23 { get; set; }

        public double M31 { get; set; }

        public double M32 { get; set; }

        public double M33 { get; set; }

        public double Minor11 => Submatrix11.Determinant;

        public double Minor12 => Submatrix12.Determinant;

        public double Minor13 => Submatrix13.Determinant;

        public double Minor21 => Submatrix21.Determinant;

        public double Minor22 => Submatrix22.Determinant;

        public double Minor23 => Submatrix23.Determinant;

        public double Minor31 => Submatrix31.Determinant;

        public double Minor32 => Submatrix32.Determinant;

        public double Minor33 => Submatrix33.Determinant;

        public Matrix3x3 Negated
        {
            get
            {
                return new Matrix3x3
                (
                    -M11, -M12, -M13,
                    -M21, -M22, -M23,
                    -M31, -M32, -M33
                );
            }
        }

        public Vector3 Row1 => new Vector3(M11, M12, M13);

        public Vector3 Row2 => new Vector3(M21, M22, M23);

        public Vector3 Row3 => new Vector3(M31, M32, M33);

        public Matrix3x3 Squared => this * this;

        public Matrix2x2 Submatrix11 => new Matrix2x2(M22, M23, M32, M33);

        public Matrix2x2 Submatrix12 => new Matrix2x2(M21, M23, M31, M33);

        public Matrix2x2 Submatrix13 => new Matrix2x2(M21, M22, M31, M32);

        public Matrix2x2 Submatrix21 => new Matrix2x2(M12, M13, M32, M33);

        public Matrix2x2 Submatrix22 => new Matrix2x2(M11, M13, M31, M33);

        public Matrix2x2 Submatrix23 => new Matrix2x2(M11, M12, M31, M32);

        public Matrix2x2 Submatrix31 => new Matrix2x2(M12, M13, M22, M23);

        public Matrix2x2 Submatrix32 => new Matrix2x2(M11, M13, M21, M23);

        public Matrix2x2 Submatrix33 => new Matrix2x2(M11, M12, M21, M22);

        public double Trace => M11 + M22 + M33;

        public Matrix3x3 Transposed
        {
            get
            {
                return new Matrix3x3
                (
                    M11, M21, M31,
                    M12, M22, M32,
                    M13, M23, M33
                );
            }
        }

        public Matrix3x3 Upper
        {
            get
            {
                return new Matrix3x3
                (
                    M11, M12, M13,
                    0, M22, M23,
                    0, 0, M33
                );
            }
        }

        #endregion
    }
}
