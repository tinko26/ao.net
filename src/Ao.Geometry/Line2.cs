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
    public struct Line2
    {
        #region Construction

        public Line2(Point2 @base, Vector2 direction)
        {
            Base = @base;

            Direction = direction;
        }

        public Line2(Vector2 direction)
        {
            Base = Point2.Origin;

            Direction = direction;
        }

        #endregion

        #region Methods

        public double Distance(Point2 P) => Math.Abs(Direction % (P - Base) / Direction.Length);

        public Point2 Intersection(General2 G) => G.Intersection(this);

        public Point2 Intersection(Hesse2 H) => H.Intersection(this);

        public Point2 Intersection(Line2 L)
        {
            var d = L.Direction;

            var M = new Matrix2x2(Direction.X, -d.X, Direction.Y, -d.Y);

            var n = L.Base - Base;

            var x = M.Inverted * n;

            return Position(x.M1);
        }

        public bool Intersects(General2 G) => G.Intersects(this);

        public bool Intersects(Hesse2 H) => H.Intersects(this);

        public bool Intersects(Line2 L)
        {
            var d = L.Direction;

            var M = new Matrix2x2(Direction.X, -d.X, Direction.Y, -d.Y);

            return M.Determinant != 0;
        }

        public Point2 Position(double t) => Base + t * Direction;

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            Base.GetHashCode() ^
            Direction.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Line2 FromGeneral(General2 G) => new Line2(G.Base, G.Direction);

        public static Line2 FromHesse(Hesse2 H) => new Line2(H.Base, H.Direction);

        public static Line2 FromIntercepts(double InterceptX, double InterceptY)
        {
            var b = new Point2(InterceptX, 0);

            var d = new Vector2(-InterceptX, InterceptY);

            return new Line2(b, d);
        }

        public static Line2 FromPointNormal(Point2 P, Vector2 N) => new Line2(P, N.OrthogonalCW);

        public static Line2 FromPointSlope(Point2 P, double Slope) => new Line2(P, new Vector2(1, Slope));

        public static Line2 FromSlopeIntercept(double Slope, double InterceptY)
        {
            var b = new Point2(0, InterceptY);

            var d = new Vector2(1, Slope);

            return new Line2(b, d);
        }

        public static Line2 FromTwoPoints(Point2 P1, Point2 P2) => new Line2(P1, P2 - P1);

        #endregion

        #region Properties

        public Point2 Base { get; set; }

        public Vector2 Direction { get; set; }

        public double InterceptX => Base.X - Base.Y / Slope;

        public double InterceptY => Base.Y - Slope * Base.X;

        public Point2 IntersectionX => new Point2(InterceptX, 0);

        public Point2 IntersectionY => new Point2(0, InterceptY);

        public Vector2 Normal => Direction.OrthogonalCW;

        public Vector2 NormalAwayFromOrigin
        {
            get
            {
                var n = Normal;

                return (n * (Base - Point2.Origin)) > 0 ? n : -n;
            }
        }

        public Vector2 NormalTowardsOrigin
        {
            get
            {
                var n = Normal;

                return (n * (Base - Point2.Origin)) > 0 ? -n : n;
            }
        }

        public Point2 Perpendicular
        {
            get
            {
                var s = (Base.X * Direction.Y - Base.Y * Direction.X) / (Direction.LengthSqr);

                var x = s * Direction.M2;

                var y = -s * Direction.M1;

                return new Point2(x, y);
            }
        }

        public double Slope => Direction.Slope;

        #endregion
    }
}
