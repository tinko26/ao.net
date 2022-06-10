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
	public struct General3
	{
        #region Construction

        public General3(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        #endregion

        #region Methods

        public double Distance(Point3 P) => Math.Abs(A * P.X + B * P.Y + C * P.Z + D) / Math.Sqrt(A * A + B * B + C * C);

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            A.GetHashCode() ^
            B.GetHashCode() ^
            C.GetHashCode() ^
            D.GetHashCode();

        #endregion

        #region Methods (Static)

        public static General3 FromHesse(Hesse3 H)
		{
            var N = H.Normal;

            return new General3(N.M1, N.M2, N.M3, -H.D);
        }

        public static General3 FromIntercepts(double InterceptX, double InterceptY, double InterceptZ)
        {
            var a = InterceptY * InterceptZ;

            var b = InterceptX * InterceptZ;

            var c = InterceptX * InterceptY;

            var d = -InterceptX * InterceptY * InterceptZ;

            return new General3(a, b, c, d);
        }

        public static General3 FromPlane(Plane3 P)
		{
            var n = P.Normal;

            return new General3(n.M1, n.M2, n.M3, -(n * (P.Base - Point3.Origin)));
        }

        public static General3 FromPointNormal(Point3 P, Vector3 N)
        {
            var a = N.M1;
            var b = N.M2;
            var c = N.M3;

            var d = -N * (P - Point3.Origin);

            return new General3(a, b, c, d);
        }

        public static General3 FromThreePoints(Point3 P1, Point3 P2, Point3 P3) => FromPlane(new Plane3(P1, P2 - P1, P3 - P1));

        #endregion

        #region Properties

        public double A { get; set; }

        public double B { get; set; }

        public Point3 Base
        {
            get
            {
                var a = Math.Abs(A);

                var b = Math.Abs(B);

                var c = Math.Abs(C);

                if (a > b || a > c)
                {
                    return IntersectionX;
                }

                else if (b > c)
                {
                    return IntersectionY;
                }

                else
                {
                    return IntersectionZ;
                }
            }
        }

        public double C { get; set; }

        public double D { get; set; }

        public Vector3 Direction1 => Normal.Orthogonal;

        public Vector3 Direction2 => Normal % Direction1;

        public double InterceptX => -D / A;

        public double InterceptY => -D / B;

        public double InterceptZ => -D / C;

        public Point3 IntersectionX => new Point3(InterceptX, 0, 0);

        public Line3 IntersectionXY
        {
            get
            {
                Line3 i;

                var a = Math.Abs(A);

                var b = Math.Abs(B);

                if (a > b)
                {
                    i = new Line3
                    {
                        Base = IntersectionX,

                        Direction = new Vector3(B, -A, 0)
                    };
                }

                else
                {
                    i = new Line3
                    {
                        Base = IntersectionY,

                        Direction = new Vector3(B, -A, 0)
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

                var a = Math.Abs(A);

                var c = Math.Abs(C);

                if (a > c)
                {
                    i = new Line3
                    {
                        Base = IntersectionX,

                        Direction = new Vector3(C, 0, -A)
                    };
                }

                else
                {
                    i = new Line3
                    {
                        Base = IntersectionZ,

                        Direction = new Vector3(C, 0, -A)
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

                var b = Math.Abs(B);

                var c = Math.Abs(C);

                if (b > c)
                {
                    i = new Line3
                    {
                        Base = IntersectionY,

                        Direction = new Vector3(0, C, -B)
                    };
                }

                else
                {
                    i = new Line3
                    {
                        Base = IntersectionZ,

                        Direction = new Vector3(0, C, -B)
                    };
                }

                return i;
            }
        }

        public Point3 IntersectionZ => new Point3(0, 0, InterceptZ);

        public Vector3 Normal => new Vector3(A, B, C);

        public Vector3 NormalAwayFromOrigin => D < 0 ? Normal : -Normal;

        public Vector3 NormalTowardsOrigin => D < 0 ? -Normal : Normal;

        public Point3 Perpendicular
        {
            get
            {
                var t = -D / (A * A + B * B + C * C);

                var x = A * t;

                var y = B * t;

                var z = C * t;

                return new Point3(x, y, z);
            }
        }

        #endregion
    }
}
