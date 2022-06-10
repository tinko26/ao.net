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
	public struct Vector5 : IEquatable<Vector5>
	{
		#region Constants

		public static readonly Vector5 Unit1 = new Vector5(1, 0, 0, 0, 0);

		public static readonly Vector5 Unit2 = new Vector5(0, 1, 0, 0, 0);

		public static readonly Vector5 Unit3 = new Vector5(0, 0, 1, 0, 0);

		public static readonly Vector5 Unit4 = new Vector5(0, 0, 0, 1, 0);

		public static readonly Vector5 Unit5 = new Vector5(0, 0, 0, 0, 1);

		public static readonly Vector5 Zero = new Vector5();

		#endregion

		#region Construction

		public Vector5(double m1, double m2, double m3, double m4, double m5)
		{
			M1 = m1;
			M2 = m2;
			M3 = m3;
			M4 = m4;
			M5 = m5;
		}

		#endregion

		#region Methods

		public bool Equals(Vector5 x) => this == x;

		public double Norm(double p)
		{
			var s1 = Math.Pow(Math.Abs(M1), p);
			var s2 = Math.Pow(Math.Abs(M2), p);
			var s3 = Math.Pow(Math.Abs(M3), p);
			var s4 = Math.Pow(Math.Abs(M4), p);
			var s5 = Math.Pow(Math.Abs(M5), p);

			var s = s1 + s2 + s3 + s4 + s5;

			return Math.Pow(s, 1 / p);
		}

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Vector5)) return false;

			var y = (Vector5)x;

			return this == y;
		}

		public override int GetHashCode() =>
			M1.GetHashCode() ^
			M2.GetHashCode() ^
			M3.GetHashCode() ^
			M4.GetHashCode() ^
			M5.GetHashCode();

		#endregion

		#region Methods (Static)

		public static double Angle(Vector5 a, Vector5 b)
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

		public static Vector5 Project(Vector5 a, Vector5 b) => a * b / b.LengthSqr * b;

		#endregion

		#region Operators

		public static Vector5 operator +(Vector5 a) => a;

		public static Vector5 operator +(Vector5 a, Vector5 b) => new Vector5(a.M1 + b.M1, a.M2 + b.M2, a.M3 + b.M3, a.M4 + b.M4, a.M5 + b.M5);

		public static Vector5 operator -(Vector5 a) => new Vector5(-a.M1, -a.M2, -a.M3, -a.M4, -a.M5);

		public static Vector5 operator -(Vector5 a, Vector5 b) => new Vector5(a.M1 - b.M1, a.M2 - b.M2, a.M3 - b.M3, a.M4 - b.M4, a.M5 - b.M5);

		public static double operator *(Vector5 a, Vector5 b) => a.M1 * b.M1 + a.M2 * b.M2 + a.M3 * b.M3 + a.M4 * b.M4 + a.M5 * b.M5;

		public static Vector5 operator *(Vector5 a, double b) => new Vector5(a.M1 * b, a.M2 * b, a.M3 * b, a.M4 * b, a.M5 * b);

		public static Vector5 operator *(double a, Vector5 b) => new Vector5(a * b.M1, a * b.M2, a * b.M3, a * b.M4, a * b.M5);

		public static Vector5 operator /(Vector5 a, double b) => new Vector5(a.M1 / b, a.M2 / b, a.M3 / b, a.M4 / b, a.M5 / b);

		#endregion

		#region Operators

		public static bool operator ==(Vector5 a, Vector5 b) => a.M1 == b.M1 && a.M2 == b.M2 && a.M3 == b.M3 && a.M4 == b.M4 && a.M5 == b.M5;

		public static bool operator !=(Vector5 a, Vector5 b) => a.M1 != b.M1 || a.M2 != b.M2 || a.M3 != b.M3 || a.M4 != b.M4 || a.M5 != b.M5;

		#endregion

		#region Properties

		public double Chebyshev =>
			Math.Max
			(
				Math.Max
				(
					Math.Max
					(
						Math.Abs(M1),
						Math.Abs(M2)
					),
					Math.Max
					(
						Math.Abs(M3),
						Math.Abs(M4)
					)
				),
				Math.Abs(M5)
			);

		public double Length => Math.Sqrt(LengthSqr);

		public double LengthSqr =>
			M1 * M1 +
			M2 * M2 +
			M3 * M3 +
			M4 * M4 +
			M5 * M5;

		public double M1 { get; set; }

		public double M2 { get; set; }

		public double M3 { get; set; }

		public double M4 { get; set; }

		public double M5 { get; set; }

		public double Manhattan =>
			Math.Abs(M1) +
			Math.Abs(M2) +
			Math.Abs(M3) +
			Math.Abs(M4) +
			Math.Abs(M5);

		public Vector5 Negated => -this;

		public Vector5 Normalized => this / Length;

		public Vector5 TowardsNegative1 => M1 < 0 ? this : -this;

		public Vector5 TowardsNegative2 => M2 < 0 ? this : -this;

		public Vector5 TowardsNegative3 => M3 < 0 ? this : -this;

		public Vector5 TowardsNegative4 => M4 < 0 ? this : -this;

		public Vector5 TowardsNegative5 => M5 < 0 ? this : -this;

		public Vector5 TowardsPositive1 => M1 > 0 ? this : -this;

		public Vector5 TowardsPositive2 => M2 > 0 ? this : -this;

		public Vector5 TowardsPositive3 => M3 > 0 ? this : -this;

		public Vector5 TowardsPositive4 => M4 > 0 ? this : -this;

		public Vector5 TowardsPositive5 => M5 > 0 ? this : -this;

		#endregion
	}
}
