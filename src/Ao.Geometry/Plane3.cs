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
    public struct Plane3
    {
        #region Constants

        public static readonly Plane3 X = FromPointNormal(Point3.Origin, Vector3.Unit1);

        public static readonly Plane3 Y = FromPointNormal(Point3.Origin, Vector3.Unit2);

        public static readonly Plane3 Z = FromPointNormal(Point3.Origin, Vector3.Unit3);

        #endregion

        #region Construction

        public Plane3(Point3 @base, Vector3 direction1, Vector3 direction2)
        {
            Base = @base;

            Direction1 = direction1;
            Direction2 = direction2;
        }

        public Plane3(Vector3 direction1, Vector3 direction2)
        {
            Base = Point3.Origin;

            Direction1 = direction1;
            Direction2 = direction2;
        }

        #endregion

        #region Methods

        public double Distance(Point3 P) => Math.Abs(Normal.Normalized * (Base - P));

        public Point3 Position(double u, double v) => Base + u * Direction1 + v * Direction2;

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            Base.GetHashCode() ^
            Direction1.GetHashCode() ^
            Direction2.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Plane3 FromGeneral(General3 G)
        {
            var N = G.Normal;

            var B = Point3.Origin - G.D * N;

            var D1 = N.Orthogonal;

            var D2 = N % D1;

            return new Plane3(B, D1, D2);
        }

        public static Plane3 FromHesse(Hesse3 H)
        {
            var N = H.Normal;

            var B = Point3.Origin + H.D * N;

            var D1 = N.Orthogonal;

            var D2 = N % D1;

            return new Plane3(B, D1, D2);
        }

        public static Plane3 FromIntercepts(double InterceptX, double InterceptY, double InterceptZ)
        {
            var b = new Point3(InterceptX, 0, 0);

            var d1 = new Vector3(-InterceptX, InterceptY, 0);

            var d2 = new Vector3(-InterceptX, 0, InterceptZ);

            return new Plane3(b, d1, d2);
        }

        public static Plane3 FromPointNormal(Point3 P, Vector3 N)
        {
            var d1 = N.Orthogonal;

            var d2 = N % d1;

            return new Plane3(P, d1, d2);
        }

        public static Plane3 FromThreePoints(Point3 P1, Point3 P2, Point3 P3) => new Plane3(P1, P2 - P1, P3 - P1);

        #endregion

        #region Properties

        public Point3 Base { get; set; }

        public Vector3 Direction1 { get; set; }

        public Vector3 Direction2 { get; set; }

        public double InterceptX
        {
            get
            {
                var n = Normal;

                var d = n * (Base - Point3.Origin);

                return d / n.M1;
            }
        }

        public double InterceptY
        {
            get
            {
                var n = Normal;

                var d = n * (Base - Point3.Origin);

                return d / n.M2;
            }
        }

        public double InterceptZ
        {
            get
            {
                var n = Normal;

                var d = n * (Base - Point3.Origin);

                return d / n.M3;
            }
        }

        public Point3 IntersectionX => new Point3(InterceptX, 0, 0);

        public Point3 IntersectionY => new Point3(0, InterceptY, 0);

        public Point3 IntersectionZ => new Point3(0, 0, InterceptZ);

        public Vector3 Normal => Direction1 % Direction2;

        public Vector3 NormalAwayFromOrigin
        {
            get
            {
                var n = Normal;

                return (n * (Base - Point3.Origin)) > 0 ? n : -n;
            }
        }

        public Vector3 NormalTowardsOrigin
        {
            get
            {
                var n = Normal;

                return (n * (Base - Point3.Origin)) > 0 ? -n : n;
            }
        }

        public Point3 Perpendicular
        {
            get
            {
                var n = Normal;

                var d = n * (Base - Point3.Origin);

                var t = -d / n.LengthSqr;

                var x = n.M1 * t;

                var y = n.M2 * t;

                var z = n.M3 * t;

                return new Point3(x, y, z);
            }
        }

        #endregion
    }
}
