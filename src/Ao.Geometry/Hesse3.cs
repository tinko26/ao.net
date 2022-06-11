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
    public struct Hesse3
    {
        #region Construction

        public Hesse3(Vector3 normal)
        {
            Normal = normal;

            D = 0;
        }

        public Hesse3(Vector3 normal, double d)
        {
            Normal = normal;

            D = d;
        }

        #endregion

        #region Methods

        public double Distance(Point3 P) => Math.Abs((D - Normal * (P - Point3.Origin)) / Normal.Length);

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            Normal.GetHashCode() ^
            D.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Hesse3 FromGeneral(General3 G) => new Hesse3(G.Normal, -G.D);

        public static Hesse3 FromIntercepts(double InterceptX, double InterceptY, double InterceptZ)
        {
            var n = new Vector3
                (
                    InterceptY * InterceptZ,
                    InterceptX * InterceptZ,
                    InterceptX * InterceptY
                );

            var d = InterceptX * InterceptY * InterceptZ;

            return new Hesse3(n, d);
        }

        public static Hesse3 FromPlane(Plane3 P)
        {
            var N = P.Normal;

            return new Hesse3(N, N * (P.Base - Point3.Origin));
        }

        public static Hesse3 FromPointNormal(Point3 P, Vector3 N)
        {
            return new Hesse3(N, N * (P - Point3.Origin));
        }

        public static Hesse3 FromThreePoints(Point3 P1, Point3 P2, Point3 P3) => FromPlane(new Plane3(P1, P2 - P1, P3 - P1));

        #endregion

        #region Properties

        public Point3 Base
        {
            get
            {
                var n1 = Math.Abs(Normal.M1);

                var n2 = Math.Abs(Normal.M2);

                var n3 = Math.Abs(Normal.M3);

                if (n1 > n2 || n1 > n3)
                {
                    return IntersectionX;
                }

                else if (n2 > n3)
                {
                    return IntersectionY;
                }

                else
                {
                    return IntersectionZ;
                }
            }
        }

        public double D { get; set; }

        public Vector3 Direction1 => Normal.Orthogonal;

        public Vector3 Direction2 => Normal % Direction1;

        public double InterceptX => D / Normal.M1;

        public double InterceptY => D / Normal.M2;

        public double InterceptZ => D / Normal.M3;

        public Point3 IntersectionX => new Point3(InterceptX, 0, 0);

        public Line3 IntersectionXY
        {
            get
            {
                Line3 i;

                var n1 = Math.Abs(Normal.M1);

                var n2 = Math.Abs(Normal.M2);

                if (n1 > n2)
                {
                    i = new Line3
                    {
                        Base = IntersectionX,

                        Direction = new Vector3(Normal.M2, -Normal.M1, 0)
                    };
                }

                else
                {
                    i = new Line3
                    {
                        Base = IntersectionY,

                        Direction = new Vector3(Normal.M2, -Normal.M1, 0)
                    };
                }

                return i;
            }
        }

        public Line3 IntersectionXZ
        {
            get
            {
                Line3 i;

                var n1 = Math.Abs(Normal.M1);

                var n3 = Math.Abs(Normal.M3);

                if (n1 > n3)
                {
                    i = new Line3
                    {
                        Base = IntersectionX,

                        Direction = new Vector3(Normal.M3, 0, -Normal.M1)
                    };
                }

                else
                {
                    i = new Line3
                    {
                        Base = IntersectionZ,

                        Direction = new Vector3(Normal.M3, 0, -Normal.M1)
                    };
                }

                return i;
            }
        }

        public Point3 IntersectionY => new Point3(0, InterceptY, 0);

        public Line3 IntersectionYZ
        {
            get
            {
                Line3 i;

                var n2 = Math.Abs(Normal.M2);

                var n3 = Math.Abs(Normal.M3);

                if (n2 > n3)
                {
                    i = new Line3
                    {
                        Base = IntersectionY,

                        Direction = new Vector3(0, Normal.M3, -Normal.M2)
                    };
                }

                else
                {
                    i = new Line3
                    {
                        Base = IntersectionZ,

                        Direction = new Vector3(0, Normal.M3, -Normal.M2)
                    };
                }

                return i;
            }
        }

        public Point3 IntersectionZ => new Point3(0, 0, InterceptZ);

        public Vector3 Normal { get; set; }

        public Vector3 NormalAwayFromOrigin => D > 0 ? Normal : -Normal;

        public Hesse3 Normalized
        {
            get
            {
                var l = Normal.Length;

                return new Hesse3(Normal / l, D / l);
            }
        }

        public Vector3 NormalTowardsOrigin => D > 0 ? -Normal : Normal;

        public Point3 Perpendicular
        {
            get
            {
                var t = -D / Normal.LengthSqr;

                var x = Normal.M1 * t;

                var y = Normal.M2 * t;

                var z = Normal.M3 * t;

                return new Point3(x, y, z);
            }
        }

        #endregion
    }
}
