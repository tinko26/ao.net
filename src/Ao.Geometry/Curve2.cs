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
	public class Curve2
	{
		#region Methods

		public double Curvature(double t)
		{
			var d1 = Derivative1(t);
			var d2 = Derivative2(t);

			var t1 = Vector2.Determinant(d1, d2);

			var t2 = Math.Pow(d1.Length, 3);

			return t1 / t2;
		}

		public Point2 CurvatureCenter(double t)
		{
			var p = Position(t);

			var d1 = Derivative1(t);
			var d2 = Derivative2(t);

			var t1 = Vector2.Determinant(d1, d2);

			var t2 = Math.Pow(d1.Length, 3);

			return p + t2 / t1 * d1.OrthogonalCCW.Normalized;
		}

		public double CurvatureRadius(double t)
		{
			var d1 = Derivative1(t);
			var d2 = Derivative2(t);

			var t1 = Vector2.Determinant(d1, d2);

			var t2 = Math.Pow(d1.Length, 3);

			return t2 / t1;
		}

		public Vector2 Normal(double t) => Derivative1(t).OrthogonalCCW;

		public Vector2 Tangent(double t) => Derivative1(t);

		public Vector2 UnitNormal(double t) => Normal(t).Normalized;

		public Vector2 UnitTangent(double t) => Tangent(t).Normalized;

		#endregion

		#region Properties

		public Func<double, Vector2> Derivative1 { get; set; }

		public Func<double, Vector2> Derivative2 { get; set; }

		public Func<double, Point2> Position { get; set; }

		#endregion
	}
}
