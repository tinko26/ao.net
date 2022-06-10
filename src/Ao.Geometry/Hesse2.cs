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
	public struct Hesse2
	{
        #region Construction

        public Hesse2(Vector2 normal)
        {
            Normal = normal;

            D = 0;
        }

        public Hesse2(Vector2 normal, double d)
        {
            Normal = normal;

            D = d;
        }

        #endregion

        #region Methods

        public double Distance(Point2 P) => Math.Abs((D - Normal * (P - Point2.Origin)) / Normal.Length);

        public Point2 Intersection(General2 G) => G.Intersection(this);

        public Point2 Intersection(Hesse2 H)
        {
            var n = H.Normal;

            var M = new Matrix2x2(Normal.X, Normal.Y, n.X, n.Y);

            var t = new Vector2(D, H.D);

            return Point2.Origin + M.Inverted * t;
        }

        public Point2 Intersection(Line2 L)
        {
            var b = L.Base;

            var d = L.Direction;

            var t = -(Normal.X * b.X + Normal.Y * b.Y - D) / (Normal.X * d.X + Normal.Y * d.Y);

            return L.Position(t);
        }

        public bool Intersects(General2 G) => G.Intersects(this);

        public bool Intersects(Hesse2 H)
        {
            var n = H.Normal;

            var M = new Matrix2x2(Normal.X, Normal.Y, n.X, n.Y);

            return M.Determinant != 0;
        }

        public bool Intersects(Line2 L)
        {
            var d = L.Direction;

            return Normal.X * d.X + Normal.Y * d.Y != 0;
        }

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            Normal.GetHashCode() ^
            D.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Hesse2 FromGeneral(General2 G) => new Hesse2(G.Normal, -G.C);

        public static Hesse2 FromIntercepts(double InterceptX, double InterceptY)
        {
            var n = new Vector2(InterceptY, InterceptX);

            var d = InterceptX * InterceptY;

            return new Hesse2(n, d);
        }

        public static Hesse2 FromLine(Line2 L)
        {
            var N = L.Normal;

            var D = N * (L.Base - Point2.Origin);

            return new Hesse2(N, D);
        }

        public static Hesse2 FromPointNormal(Point2 P, Vector2 N)
        {
            var d = N * (P - Point2.Origin);

            return new Hesse2(N, d);
        }

        public static Hesse2 FromPointSlope(Point2 P, double Slope)
        {
            var n = new Vector2(Slope, -1);

            var d = Slope * P.X - P.Y;

            return new Hesse2(n, d);
        }

        public static Hesse2 FromSlopeIntercept(double Slope, double InterceptY)
        {
            var n = new Vector2(Slope, -1);

            var d = -InterceptY;

            return new Hesse2(n, d);
        }

        public static Hesse2 FromTwoPoints(Point2 P1, Point2 P2) => FromLine(new Line2(P1, P2 - P1));

        #endregion

        #region Properties

        public Point2 Base
        {
            get
            {
                var n1 = Math.Abs(Normal.M1);

                var n2 = Math.Abs(Normal.M2);

                if (n1 > n2)
                {
                    return IntersectionX;
                }

                else
                {
                    return IntersectionY;
                }
            }
        }

        public double D { get; set; }

        public Vector2 Direction => new Vector2(Normal.M2, -Normal.M1);

        public double InterceptX => D / Normal.M1;

        public double InterceptY => D / Normal.M2;

        public Point2 IntersectionX => new Point2(InterceptX, 0);

        public Point2 IntersectionY => new Point2(0, InterceptY);

        public Vector2 Normal { get; set; }

        public Vector2 NormalAwayFromOrigin => D > 0 ? Normal : -Normal;

        public Hesse2 Normalized
        {
            get
            {
                var l = Normal.Length;

                return new Hesse2(Normal / l, D / l);
            }
        }

        public Vector2 NormalTowardsOrigin => D > 0 ? -Normal : Normal;

        public Point2 Perpendicular
        {
            get
            {
                var t = -D / Normal.LengthSqr;

                var x = Normal.M1 * t;

                var y = Normal.M2 * t;

                return new Point2(x, y);
            }
        }

        public double Slope => -Normal.M1 / Normal.M2;

        #endregion
    }
}
