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
    public struct Sphere3
    {
        #region Construction

        public Sphere3(Point3 center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public Sphere3(double radius)
        {
            Center = Point3.Origin;
            Radius = radius;
        }

        #endregion

        #region Methods

        public bool Contains(Point3 P) => Center.DistanceSqr(P) <= RadiusSqr;

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            Center.GetHashCode() ^
            Radius.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Sphere3 FromFourPoints(Point3 P1, Point3 P2, Point3 P3, Point3 P4)
        {
            var x1 = P1.X;
            var y1 = P1.Y;
            var z1 = P1.Z;
            var x2 = P2.X;
            var y2 = P2.Y;
            var z2 = P2.Z;
            var x3 = P3.X;
            var y3 = P3.Y;
            var z3 = P3.Z;
            var x4 = P4.X;
            var y4 = P4.Y;
            var z4 = P4.Z;

            var t1 = -(x1 * x1 + y1 * y1 + z1 * z1);
            var t2 = -(x2 * x2 + y2 * y2 + z2 * z2);
            var t3 = -(x3 * x3 + y3 * y3 + z3 * z3);
            var t4 = -(x4 * x4 + y4 * y4 + z4 * z4);

            var T = new Matrix4x4(x1, y1, z1, 1, x2, y2, z2, 1, x3, y3, z3, 1, x4, y4, z4, 1).Determinant;

            var D = new Matrix4x4(t1, y1, z1, 1, t2, y2, z2, 1, t3, y3, z3, 1, t4, y4, z4, 1).Determinant / T;
            var E = new Matrix4x4(x1, t1, z1, 1, x2, t2, z2, 1, x3, t3, z3, 1, x4, t4, z4, 1).Determinant / T;
            var F = new Matrix4x4(x1, y1, t1, 1, x2, y2, t2, 1, x3, y3, t3, 1, x4, y4, t4, 1).Determinant / T;
            var G = new Matrix4x4(x1, y1, z1, t1, x2, y2, z2, t2, x3, y3, z3, t3, x4, y4, z4, t4).Determinant / T;

            var cx = -D / 2;
            var cy = -E / 2;
            var cz = -F / 2;

            var r = 0.5 * Math.Sqrt(D * D + E * E + F * F - 4 * G);

            return new Sphere3(new Point3(cx, cy, cz), r);
        }

        #endregion

        #region Properties

        public Box3 BoundingBox
        {
            get
            {
                return new Box3
                (
                    Center.X - Radius,
                    Center.Y - Radius,
                    Center.Z - Radius,
                    Center.X + Radius,
                    Center.Y + Radius,
                    Center.Z + Radius
                );
            }
        }

        public Point3 Center { get; set; }

        public double Diameter => 2 * Radius;

        public double Radius { get; set; }

        public double RadiusSqr => Radius * Radius;

        public double SurfaceArea => 4.0 * Math.PI * RadiusSqr;

        public double Volume => 4.0 / 3.0 * Math.PI * RadiusSqr * Radius;

        #endregion
    }
}
