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

using System;

namespace Ao.Mathematics
{
	public struct Point3 : IEquatable<Point3>
	{
		#region Constants

		public static readonly Point3 Origin = new Point3();

		#endregion

		#region Construction

		public Point3(double m1, double m2, double m3)
		{
			M1 = m1;
			M2 = m2;
			M3 = m3;
		}

		#endregion

		#region Methods

		public double Distance(Point3 point) => (this - point).Length;

		public double DistanceSqr(Point3 point) => (this - point).LengthSqr;

		public bool Equals(Point3 x) => this == x;

		public Cylindrical ToCylindrical()
		{
			var r = Math.Sqrt(M1 * M1 + M2 * M2);

			var a = Math.Atan2(M2, M1);

			return new Cylindrical(r, a, M3);
		}

		public Spherical ToSpherical()
		{
			var t = M1 * M1 + M2 * M2;

			var r = Math.Sqrt(t + M3 * M3);

			var a = Math.Atan2(M2, M1);

			var i = 0.5 * Math.PI - Math.Atan2(M3, Math.Sqrt(t));

			return new Spherical(r, a, i);
		}

		public Vector3 ToVector() => new Vector3(M1, M2, M3);

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Point3)) return false;

			var y = (Point3)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M1.GetHashCode() ^
			M2.GetHashCode() ^
			M3.GetHashCode();

		#endregion

		#region Methods (Static)

		public static Point3 FromCylindrical(Cylindrical cylindrical) => cylindrical.ToPoint();

		public static Point3 FromSpherical(Spherical spherical) => spherical.ToPoint();

		public static Point3 FromVector(Vector3 vector) => vector.ToPoint();

		#endregion

		#region Operators

		public static Point3 operator +(Point3 a, Point3 b) => new Point3(a.M1 + b.M1, a.M2 + b.M2, a.M3 + b.M3);

		public static Point3 operator +(Point3 a, Vector3 b) => new Point3(a.M1 + b.M1, a.M2 + b.M2, a.M3 + b.M3);

		public static Point3 operator -(Point3 a, Vector3 b) => new Point3(a.M1 - b.M1, a.M2 - b.M2, a.M3 - b.M3);

		public static Vector3 operator -(Point3 a, Point3 b) => new Vector3(a.M1 - b.M1, a.M2 - b.M2, a.M3 - b.M3);

		public static Point3 operator *(Point3 a, double b) => new Point3(a.M1 * b, a.M2 * b, a.M3 * b);

		public static Point3 operator *(double a, Point3 b) => new Point3(a * b.M1, a * b.M2, a * b.M3);

		public static Point3 operator /(Point3 a, double b) => new Point3(a.M1 / b, a.M2 / b, a.M3 / b);

		#endregion

		#region Operators

		public static bool operator ==(Point3 a, Point3 b) => a.M1 == b.M1 && a.M2 == b.M2 && a.M3 == b.M3;

		public static bool operator !=(Point3 a, Point3 b) => a.M1 != b.M1 || a.M2 != b.M2 || a.M3 != b.M3;

		#endregion

		#region Properties

		public double M1 { get; set; }

		public double M2 { get; set; }

		public double M3 { get; set; }

		public double X
		{
			get => M1;
			set => M1 = value;
		}

		public double Y
		{
			get => M2;
			set => M2 = value;
		}

		public double Z
		{
			get => M3;
			set => M3 = value;
		}

		#endregion
	}
}
