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
	public struct Vector3 : IEquatable<Vector3>
	{
		#region Constants

		public static readonly Vector3 Unit1 = new Vector3(1, 0, 0);

		public static readonly Vector3 Unit2 = new Vector3(0, 1, 0);

		public static readonly Vector3 Unit3 = new Vector3(0, 0, 1);

		public static readonly Vector3 Zero = new Vector3();

		#endregion

		#region Construction

		public Vector3(double m1, double m2, double m3)
		{
			M1 = m1;
			M2 = m2;
			M3 = m3;
		}

		#endregion

		#region Methods

		public bool Equals(Vector3 x) => this == x;

		public double Norm(double p)
		{
			var s1 = Math.Pow(Math.Abs(M1), p);
			var s2 = Math.Pow(Math.Abs(M2), p);
			var s3 = Math.Pow(Math.Abs(M3), p);

			var s = s1 + s2 + s3;

			return Math.Pow(s, 1 / p);
		}

		public Point2 ToAffinePoint() => new Point2(M1 / M3, M2 / M3);

		public Vector2 ToAffineVector() => new Vector2(M1, M2);

		public Cylindrical ToCylindrical()
		{
			var r = Math.Sqrt(M1 * M1 + M2 * M2);

			var a = Math.Atan2(M2, M1);

			return new Cylindrical(r, a, M3);
		}

		public Point3 ToPoint() => new Point3(M1, M2, M3);

		public Spherical ToSpherical()
		{
			var t = M1 * M1 + M2 * M2;

			var r = Math.Sqrt(t + M3 * M3);

			var a = Math.Atan2(M2, M1);

			var i = 0.5 * Math.PI - Math.Atan2(Z, Math.Sqrt(t));

			return new Spherical(r, a, i);
		}

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Vector3)) return false;

			var y = (Vector3)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M1.GetHashCode() ^
			M2.GetHashCode() ^
			M3.GetHashCode();

		#endregion

		#region Methods (Static)

		public static double Angle(Vector3 a, Vector3 b)
		{
			var t = a * b / Math.Sqrt(a.LengthSqr * b.LengthSqr);

			if (t <= -1)
			{
				return Math.PI;
			}

			else if (t >= +1)
			{
				return 0;
			}

			else
			{
				return Math.Acos(t);
			}
		}

		public static double Area(Vector3 a, Vector3 b) => (a % b).Length;

		public static Vector3 Cross(Vector3 a, Vector3 b) => a % b;

		public static double Determinant(Vector3 a, Vector3 b, Vector3 c) => a % b * c;

		public static Vector3 FromAffinePoint(Point2 point) => new Vector3(point.X, point.Y, 1);

		public static Vector3 FromAffineVector(Vector2 vector) => new Vector3(vector.M1, vector.M2, 0);

		public static Vector3 FromCylindrical(Cylindrical cylindrical) => cylindrical.ToVector();

		public static Vector3 FromPoint(Point3 point) => point.ToVector();

		public static Vector3 FromSpherical(Spherical spherical) => spherical.ToVector();

		public static Vector3 Project(Vector3 a, Vector3 b) => a * b / b.LengthSqr * b;

		public static double Triple(Vector3 a, Vector3 b, Vector3 c) => a % b * c;

		public static double Volume(Vector3 a, Vector3 b, Vector3 c) => Math.Abs(a % b * c);

		#endregion

		#region Operators

		public static Vector3 operator +(Vector3 a) => a;

		public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.M1 + b.M1, a.M2 + b.M2, a.M3 + b.M3);

		public static Vector3 operator -(Vector3 a) => new Vector3(-a.M1, -a.M2, -a.M3);

		public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.M1 - b.M1, a.M2 - b.M2, a.M3 - b.M3);

		public static double operator *(Vector3 a, Vector3 b) => a.M1 * b.M1 + a.M2 * b.M2 + a.M3 * b.M3;

		public static Vector3 operator *(Vector3 a, double b) => new Vector3(a.M1 * b, a.M2 * b, a.M3 * b);

		public static Vector3 operator *(double a, Vector3 b) => new Vector3(a * b.M1, a * b.M2, a * b.M3);

		public static Vector3 operator /(Vector3 a, double b) => new Vector3(a.M1 / b, a.M2 / b, a.M3 / b);

		public static Vector3 operator %(Vector3 a, Vector3 b)
		{
			return new Vector3
			(
				a.M2 * b.M3 - b.M2 * a.M3,
				a.M3 * b.M1 - b.M3 * a.M1,
				a.M1 * b.M2 - b.M1 * a.M2
			);
		}

		#endregion

		#region Operators

		public static bool operator ==(Vector3 a, Vector3 b) => a.M1 == b.M1 && a.M2 == b.M2 && a.M3 == b.M3;

		public static bool operator !=(Vector3 a, Vector3 b) => a.M1 != b.M1 || a.M2 != b.M2 || a.M3 != b.M3;

		#endregion

		#region Properties

		public double Chebyshev =>
			Math.Max
			(
				Math.Max
				(
					Math.Abs(M1),
					Math.Abs(M2)
				),
				Math.Abs(M3)
			);

		public double Length => Math.Sqrt(LengthSqr);

		public double LengthSqr =>
			M1 * M1 +
			M2 * M2 +
			M3 * M3;

		public double M1 { get; set; }

		public double M2 { get; set; }

		public double M3 { get; set; }

		public double Manhattan =>
			Math.Abs(M1) +
			Math.Abs(M2) +
			Math.Abs(M3);

		public Vector3 Negated => -this;

		public Vector3 Normalized => this / Length;

		public Vector3 Orthogonal
		{
			get
			{
				var m1 = Math.Abs(M1);
				var m2 = Math.Abs(M2);
				var m3 = Math.Abs(M3);

				if (m1 < m2 && m1 < m3)
				{
					return Orthogonal1;
				}

				else if (m2 < m1 && m2 < m3)
				{
					return Orthogonal2;
				}

				else
				{
					return Orthogonal3;
				}
			}
		}

		public Vector3 Orthogonal1 => new Vector3(0, M3, -M2);

		public Vector3 Orthogonal2 => new Vector3(-M3, 0, M1);

		public Vector3 Orthogonal3 => new Vector3(M2, -M1, 0);

		public Vector3 TowardsNegative1 => M1 < 0 ? this : -this;

		public Vector3 TowardsNegative2 => M2 < 0 ? this : -this;

		public Vector3 TowardsNegative3 => M3 < 0 ? this : -this;

		public Vector3 TowardsPositive1 => M1 > 0 ? this : -this;

		public Vector3 TowardsPositive2 => M2 > 0 ? this : -this;

		public Vector3 TowardsPositive3 => M3 > 0 ? this : -this;

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
