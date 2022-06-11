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

using Ao.Mathematics;
using System;

namespace Ao.Geometry
{
    public struct Affinity2
    {
        #region Constants

        public static readonly Affinity2 Identity = new Affinity2(Matrix2x2.Identity);

        public static readonly Affinity2 ProjectX = new Affinity2(new Matrix2x2(1, 0, 0, 0));

        public static readonly Affinity2 ProjectY = new Affinity2(new Matrix2x2(0, 0, 0, 1));

        public static readonly Affinity2 ReflectX = new Affinity2(new Matrix2x2(1, 0, 0, -1));

        public static readonly Affinity2 ReflectY = new Affinity2(new Matrix2x2(-1, 0, 0, 1));

        #endregion

        #region Construction

        public Affinity2(Matrix2x2 transformation)
        {
            Transformation = transformation;

            Translation = Vector2.Zero;
        }

        public Affinity2(Matrix2x2 transformation, Vector2 translation)
        {
            Transformation = transformation;

            Translation = translation;
        }

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            Transformation.GetHashCode() ^
            Translation.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Affinity2 FromBasis(Basis2 B) => ToBasis(B).Inverted;

        public static Affinity2 Reflect(Vector2 Normal) => new Affinity2(Matrix2x2.Householder(Normal.Normalized));

        public static Affinity2 Rotate(double Angle)
        {
            var C = Math.Cos(Angle);
            var S = Math.Sin(Angle);

            return new Affinity2(new Matrix2x2(C, -S, S, C));
        }

        public static Affinity2 Scale(double S) => Scale(S, S);

        public static Affinity2 Scale(double SX, double SY) => new Affinity2(new Matrix2x2(SX, 0, 0, SY));

        public static Affinity2 Shear(double S) => Shear(S, S);

        public static Affinity2 Shear(double S1, double S3) => new Affinity2(new Matrix2x2(1, S1, S3, 1));

        public static Affinity2 ToBasis(Basis2 B) => new Affinity2(Matrix2x2.FromRows(B.Base1, B.Base2));

        public static Affinity2 Translate(Vector2 T) => new Affinity2(Matrix2x2.Identity, T);

        public static Affinity2 TranslateX(double TX) => new Affinity2(Matrix2x2.Identity, new Vector2(TX, 0));

        public static Affinity2 TranslateY(double TY) => new Affinity2(Matrix2x2.Identity, new Vector2(0, TY));

        #endregion

        #region Operators

        public static Affinity2 operator *(Affinity2 a, Affinity2 b) => new Affinity2
        (
            a.Transformation * b.Transformation,
            a.Transformation * b.Translation + a.Translation
        );

        public static Point2 operator *(Affinity2 a, Point2 b) => Point2.Origin + a.Transformation * (b - Point2.Origin) + a.Translation;

        public static Vector2 operator *(Affinity2 a, Vector2 b) => a.Transformation * b;

        public static Affinity2 operator !(Affinity2 a) => a.Inverted;

        #endregion

        #region Properties

        public Matrix3x3 AugmentedMatrix
        {
            get
            {
                return new Matrix3x3
                (
                    Transformation.M11, Transformation.M12, Translation.M1,
                    Transformation.M21, Transformation.M22, Translation.M2,
                    0, 0, 1
                );
            }
        }

        public Affinity2 Inverted
        {
            get
            {
                var I = Transformation.Inverted;

                return new Affinity2(I, -(I * Translation));
            }
        }

        public Matrix2x2 Transformation { get; set; }

        public Vector2 Translation { get; set; }

        #endregion
    }
}
