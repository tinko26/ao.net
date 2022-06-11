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
    public struct Affinity3
    {
        #region Constants

        public static readonly Affinity3 Identity = new Affinity3(Matrix3x3.Identity);

        public static readonly Affinity3 ProjectX = new Affinity3(new Matrix3x3(1, 0, 0, 0, 0, 0, 0, 0, 0));

        public static readonly Affinity3 ProjectXY = new Affinity3(new Matrix3x3(1, 0, 0, 0, 1, 0, 0, 0, 0));

        public static readonly Affinity3 ProjectXZ = new Affinity3(new Matrix3x3(1, 0, 0, 0, 0, 0, 0, 0, 1));

        public static readonly Affinity3 ProjectY = new Affinity3(new Matrix3x3(0, 0, 0, 0, 1, 0, 0, 0, 0));

        public static readonly Affinity3 ProjectYZ = new Affinity3(new Matrix3x3(0, 0, 0, 0, 1, 0, 0, 0, 1));

        public static readonly Affinity3 ProjectZ = new Affinity3(new Matrix3x3(0, 0, 0, 0, 0, 0, 0, 0, 1));

        public static readonly Affinity3 ReflectXY = new Affinity3(new Matrix3x3(1, 0, 0, 0, 1, 0, 0, 0, -1));

        public static readonly Affinity3 ReflectXZ = new Affinity3(new Matrix3x3(1, 0, 0, 0, -1, 0, 0, 0, 1));

        public static readonly Affinity3 ReflectYZ = new Affinity3(new Matrix3x3(-1, 0, 0, 0, 1, 0, 0, 0, 1));

        #endregion

        #region Construction

        public Affinity3(Matrix3x3 transformation)
        {
            Transformation = transformation;

            Translation = Vector3.Zero;
        }

        public Affinity3(Matrix3x3 transformation, Vector3 translation)
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

        public static Affinity3 FromBasis(Basis3 B) => ToBasis(B).Inverted;

        public static Affinity3 LookAt(Point3 Eye, Point3 Center, Vector3 Up)
        {
            var F = (Center - Eye).Normalized;

            var S = (F % Up).Normalized;

            var U = S % F;

            var E = Eye - Point3.Origin;

            var Transformation = Matrix3x3.FromRows(S, U, -F);

            var Translation = new Vector3(-E * S, -E * U, E * F);

            return new Affinity3(Transformation, Translation);
        }

        public static Affinity3 Reflect(Vector3 Normal) => new Affinity3(Matrix3x3.Householder(Normal.Normalized));

        public static Affinity3 RollPitchYaw(double Roll, double Pitch, double Yaw) =>
            RotateZ(Yaw) *
            RotateY(Pitch) *
            RotateX(Roll);

        public static Affinity3 RollPitchYaw(double Roll, double Pitch, double Yaw, Basis3 B) =>
            Rotate(Yaw, B.Base3) *
            Rotate(Pitch, B.Base2) *
            Rotate(Roll, B.Base1);

        public static Affinity3 Rotate(double Angle, Vector3 Axis)
        {
            var N = Axis.Normalized;

            var S = Math.Sin(Angle);
            var C = Math.Cos(Angle);

            var CI = 1.0 - C;

            var N11 = N.M1 * N.M1;
            var N12 = N.M1 * N.M2;
            var N13 = N.M1 * N.M3;
            var N22 = N.M2 * N.M2;
            var N23 = N.M2 * N.M3;
            var N33 = N.M3 * N.M3;

            var M11 = C + N11 * CI;
            var M22 = C + N22 * CI;
            var M33 = C + N33 * CI;

            var M12 = N12 * CI - N.M3 * S;
            var M13 = N13 * CI + N.M2 * S;

            var M21 = N12 * CI + N.M3 * S;
            var M23 = N23 * CI - N.M1 * S;

            var M31 = N13 * CI - N.M2 * S;
            var M32 = N23 * CI + N.M1 * S;

            var Transformation = new Matrix3x3
            (
                M11, M12, M13,
                M21, M22, M23,
                M31, M32, M33
            );

            return new Affinity3(Transformation);
        }

        public static Affinity3 RotateX(double Angle)
        {
            var C = Math.Cos(Angle);
            var S = Math.Sin(Angle);

            return new Affinity3(new Matrix3x3(1, 0, 0, 0, C, -S, 0, S, C));
        }

        public static Affinity3 RotateY(double Angle)
        {
            var C = Math.Cos(Angle);
            var S = Math.Sin(Angle);

            return new Affinity3(new Matrix3x3(C, 0, S, 0, 1, 0, -S, 0, C));
        }

        public static Affinity3 RotateZ(double Angle)
        {
            var C = Math.Cos(Angle);
            var S = Math.Sin(Angle);

            return new Affinity3(new Matrix3x3(C, -S, 0, S, C, 0, 0, 0, 1));
        }

        public static Affinity3 Scale(double S) => Scale(S, S, S);

        public static Affinity3 Scale(double SX, double SY, double SZ) => new Affinity3(new Matrix3x3(SX, 0, 0, 0, SY, 0, 0, 0, SZ));

        public static Affinity3 Shear(double S) => Shear(S, S, S, S, S, S);

        public static Affinity3 Shear(double S1, double S2, double S3, double S4, double S5, double S6) => new Affinity3(new Matrix3x3(1, S1, S2, S3, 1, S4, S5, S6, 1));

        public static Affinity3 ToBasis(Basis3 B) => new Affinity3(Matrix3x3.FromRows(B.Base1, B.Base2, B.Base3));

        public static Affinity3 Translate(Vector3 T) => new Affinity3(Matrix3x3.Identity, T);

        public static Affinity3 TranslateX(double TX) => new Affinity3(Matrix3x3.Identity, new Vector3(TX, 0, 0));

        public static Affinity3 TranslateY(double TY) => new Affinity3(Matrix3x3.Identity, new Vector3(0, TY, 0));

        public static Affinity3 TranslateZ(double TZ) => new Affinity3(Matrix3x3.Identity, new Vector3(0, 0, TZ));

        #endregion

        #region Operators

        public static Affinity3 operator *(Affinity3 a, Affinity3 b) => new Affinity3
        (
            a.Transformation * b.Transformation,
            a.Transformation * b.Translation + a.Translation
        );

        public static Point3 operator *(Affinity3 a, Point3 b) => Point3.Origin + a.Transformation * (b - Point3.Origin) + a.Translation;

        public static Vector3 operator *(Affinity3 a, Vector3 b) => a.Transformation * b;

        public static Affinity3 operator !(Affinity3 a) => a.Inverted;

        #endregion

        #region Properties

        public Matrix4x4 AugmentedMatrix
        {
            get
            {
                return new Matrix4x4
                (
                    Transformation.M11, Transformation.M12, Transformation.M13, Translation.M1,
                    Transformation.M21, Transformation.M22, Transformation.M23, Translation.M2,
                    Transformation.M31, Transformation.M32, Transformation.M33, Translation.M3,
                    0, 0, 0, 1
                );
            }
        }

        public Affinity3 Inverted
        {
            get
            {
                var I = Transformation.Inverted;

                return new Affinity3(I, -(I * Translation));
            }
        }

        public Matrix3x3 Transformation { get; set; }

        public Vector3 Translation { get; set; }

        #endregion
    }
}
