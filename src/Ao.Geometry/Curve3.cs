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
	public class Curve3
	{
		#region Methods

		public Vector3 Binormal(double t) => Vector3.Cross(Derivative1(t), Derivative2(t));

		public double Curvature(double t)
		{
			var d1 = Derivative1(t);
			var d2 = Derivative2(t);

			var t1 = Vector3.Cross(d1, d2).Length;

			var t2 = Math.Pow(d1.Length, 3);

			return t1 / t2;
		}

		public Point3 CurvatureCenter(double t)
		{
			var p = Position(t);

			var d1 = Derivative1(t);
			var d2 = Derivative2(t);

			var b = Vector3.Cross(d1, d2);

			var t1 = Math.Pow(d1.Length, 3);

			var t2 = b.Length;

			var n = Vector3.Cross(b, d1);

			var t3 = n.Length;

			return p + t1 / (t2 * t3) * n;
		}

		public double CurvatureRadius(double t)
		{
			var d1 = Derivative1(t);
			var d2 = Derivative2(t);

			var t1 = Vector3.Cross(d1, d2).Length;

			var t2 = Math.Pow(d1.Length, 3);

			return t2 / t1;
		}

		public Vector3 Normal(double t)
		{
			var d1 = Derivative1(t);
			var d2 = Derivative2(t);

			return Vector3.Cross(Vector3.Cross(d1, d2), d1);
		}

		public Plane3 NormalPlane(double t) => Plane3.FromPointNormal(Position(t), Tangent(t));

		public Plane3 OsculatingPlane(double t) => Plane3.FromPointNormal(Position(t), Binormal(t));

		public Plane3 RectifyingPlane(double t) => Plane3.FromPointNormal(Position(t), Normal(t));

		public Vector3 Tangent(double t) => Derivative1(t);

		public double Torsion(double t)
		{
			var d1 = Derivative1(t);
			var d2 = Derivative2(t);
			var d3 = Derivative3(t);

			var t1 = Vector3.Determinant(d1, d2, d3);

			var t2 = Vector3.Cross(d1, d2);

			return t1 / (t2 * t2);
		}

		public Vector3 UnitBinormal(double t) => Binormal(t).Normalized;

		public Vector3 UnitNormal(double t) => Normal(t).Normalized;

		public Vector3 UnitTangent(double t) => Tangent(t).Normalized;

		#endregion

		#region Properties

		public Func<double, Vector3> Derivative1 { get; set; }

		public Func<double, Vector3> Derivative2 { get; set; }

		public Func<double, Vector3> Derivative3 { get; set; }

		public Func<double, Point3> Position { get; set; }

		#endregion
	}
}
