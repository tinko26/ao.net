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
    public struct Circle2
    {
        #region Construction

        public Circle2(Point2 center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public Circle2(double radius)
        {
            Center = Point2.Origin;
            Radius = radius;
        }

        #endregion

        #region Methods

        public bool Contains(Point2 P) => Center.DistanceSqr(P) <= RadiusSqr;

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            Center.GetHashCode() ^
            Radius.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Circle2 FromThreePoints(Point2 P1, Point2 P2, Point2 P3)
        {
            var x1 = P1.X;
            var y1 = P1.Y;
            var x2 = P2.X;
            var y2 = P2.Y;
            var x3 = P3.X;
            var y3 = P3.Y;

            var l1 = x1 * x1 + y1 * y1;
            var l2 = x2 * x2 + y2 * y2;
            var l3 = x3 * x3 + y3 * y3;

            var a = 2 * (x1 * (y2 - y3) - y1 * (x2 - x3) + x2 * y3 - x3 * y2);
            var b = l1 * (y3 - y2) + l2 * (y1 - y3) + l3 * (y2 - y1);
            var c = l1 * (x2 - x3) + l2 * (x3 - x1) + l3 * (x1 - x2);
            var d = l1 * (x3 * y2 - x2 * y3) + l2 * (x1 * y3 - x3 * y1) + l3 * (x2 * y1 - x1 * y2);

            var cx = -b / a;
            var cy = -c / a;

            var r = Math.Sqrt((b * b + c * c - 2 * a * d) / (a * a));

            return new Circle2(new Point2(cx, cy), r);
        }

        #endregion

        #region Properties

        public double Area => Math.PI * RadiusSqr;

        public Box2 BoundingBox
        {
            get
            {
                return new Box2
                (
                    Center.X - Radius,
                    Center.Y - Radius,
                    Center.X + Radius,
                    Center.Y + Radius
                );
            }
        }

        public Point2 Center { get; set; }

        public double Diameter => 2 * Radius;

        public double Perimeter => 2 * Math.PI * Radius;

        public double Radius { get; set; }

        public double RadiusSqr => Radius * Radius;

        #endregion
    }
}
