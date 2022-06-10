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

namespace Ao.Geometry
{
	public struct Line3
	{
        #region Construction

        public Line3(Point3 @base, Vector3 direction)
        {
            Base = @base;

            Direction = direction;
        }

        public Line3(Vector3 direction)
        {
            Base = Point3.Origin;

            Direction = direction;
        }

        #endregion

        #region Methods

        public double Distance(Point3 P) => (Direction % (P - Base)).Length / Direction.Length;

        public double DistanceSqr(Point3 P) => (Direction % (P - Base)).LengthSqr / Direction.LengthSqr;

        public Point3 Position(double t) => Base + t * Direction;

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            Base.GetHashCode() ^
            Direction.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Line3 FromTwoPoints(Point3 P1, Point3 P2) => new Line3(P1, P2 - P1);

        #endregion

        #region Properties

        public Point3 Base { get; set; }

        public Vector3 Direction { get; set; }

        #endregion
    }
}
