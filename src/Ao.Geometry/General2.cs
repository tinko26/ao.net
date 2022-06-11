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
    public struct General2
    {
        #region Construction

        public General2(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        #endregion

        #region Methods

        public double Distance(Point2 P) => Math.Abs(A * P.X + B * P.Y + C) / Math.Sqrt(A * A + B * B);

        public Point2 Intersection(General2 G)
        {
            var M = new Matrix2x2(A, B, G.A, G.B);

            var n = new Vector2(-C, -G.C);

            return Point2.Origin + M.Inverted * n;
        }

        public Point2 Intersection(Hesse2 H)
        {
            var n = H.Normal;

            var M = new Matrix2x2(A, B, n.X, n.Y);

            var t = new Vector2(-C, H.D);

            return Point2.Origin + M.Inverted * t;
        }

        public Point2 Intersection(Line2 L)
        {
            var b = L.Base;

            var d = L.Direction;

            var t = -(A * b.X + B * b.Y + C) / (A * d.X + B * d.Y);

            return L.Position(t);
        }

        public bool Intersects(General2 G)
        {
            var M = new Matrix2x2(A, B, G.A, G.B);

            return M.Determinant != 0;
        }

        public bool Intersects(Hesse2 H)
        {
            var n = H.Normal;

            var M = new Matrix2x2(A, B, n.X, n.Y);

            return M.Determinant != 0;
        }

        public bool Intersects(Line2 L)
        {
            var d = L.Direction;

            return A * d.X + B * d.Y != 0;
        }

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            A.GetHashCode() ^
            B.GetHashCode() ^
            C.GetHashCode();

        #endregion

        #region Methods (Static)

        public static General2 FromHesse(Hesse2 H)
        {
            var N = H.Normal;

            return new General2(N.M1, N.M2, -H.D);
        }

        public static General2 FromIntercepts(double InterceptX, double InterceptY)
        {
            var a = InterceptY;

            var b = InterceptX;

            var c = -InterceptX * InterceptY;

            return new General2(a, b, c);
        }

        public static General2 FromLine(Line2 L)
        {
            var n = L.Normal;

            var a = n.M1;

            var b = n.M2;

            var c = -n * (L.Base - Point2.Origin);

            return new General2(a, b, c);
        }

        public static General2 FromPointNormal(Point2 P, Vector2 N)
        {
            var a = N.M1;

            var b = N.M2;

            var c = -(a * P.X + b * P.Y);

            return new General2(a, b, c);
        }

        public static General2 FromPointSlope(Point2 P, double Slope)
        {
            var a = Slope;

            var b = -1;

            var c = P.Y - Slope * P.X;

            return new General2(a, b, c);
        }

        public static General2 FromSlopeIntercept(double Slope, double InterceptY)
        {
            var a = Slope;

            var b = -1;

            var c = InterceptY;

            return new General2(a, b, c);
        }

        public static General2 FromTwoPoints(Point2 P1, Point2 P2) => FromLine(new Line2(P1, P2 - P1));

        #endregion

        #region Properties

        public double A { get; set; }

        public double B { get; set; }

        public Point2 Base
        {
            get
            {
                var a = Math.Abs(A);

                var b = Math.Abs(B);

                if (a > b)
                {
                    return IntersectionX;
                }

                else
                {
                    return IntersectionY;
                }
            }
        }

        public double C { get; set; }

        public Vector2 Direction => new Vector2(B, -A);

        public double InterceptX => -C / A;

        public double InterceptY => -C / B;

        public Point2 IntersectionX => new Point2(InterceptX, 0);

        public Point2 IntersectionY => new Point2(0, InterceptY);

        public Vector2 Normal => new Vector2(A, B);

        public Vector2 NormalAwayFromOrigin => C < 0 ? Normal : -Normal;

        public Vector2 NormalTowardsOrigin => C < 0 ? -Normal : Normal;

        public Point2 Perpendicular
        {
            get
            {
                var t = -C / (A * A + B * B);

                var x = A * t;

                var y = B * t;

                return new Point2(x, y);
            }
        }

        public double Slope => -A / B;

        #endregion
    }
}
