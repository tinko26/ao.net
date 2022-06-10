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
	public struct Complex : IEquatable<Complex>
	{
		#region Constants

		public static readonly Complex I = new Complex(0, 1);

		#endregion

		#region Construction

		public Complex(double real)
		{
			Real = real;

			Imaginary = 0;
		}

		public Complex(double real, double imaginary)
		{
			Real = real;

			Imaginary = imaginary;
		}

		#endregion

		#region Methods

		public bool Equals(Complex x) => this == x;

		public Point2 ToPoint() => new Point2(Real, Imaginary);

		public Polar ToPolar() => new Polar(Modulus, Argument);

		public Vector2 ToVector() => new Vector2(Real, Imaginary);

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Complex)) return false;

			var y = (Complex)x;

			return this == y;
		}

		public override int GetHashCode() => 
			Real.GetHashCode() ^ 
			Imaginary.GetHashCode();

		#endregion

		#region Methods (Static)

		public static Complex FromImaginary(double imaginary) => new Complex(0, imaginary);

		public static Complex FromPoint(Point2 point) => point.ToComplex();

		public static Complex FromPolar(Polar polar) => polar.ToComplex();

		public static Complex FromReal(double real) => new Complex(real);

		public static Complex FromVector(Vector2 vector) => vector.ToComplex();

		public static Complex Rotation(double angle) => new Complex(Math.Cos(angle), Math.Sin(angle));

		#endregion

		#region Operators

		public static Complex operator +(Complex a) => a;

		public static Complex operator +(Complex a, Complex b) => new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);

		public static Complex operator +(Complex a, double b) => new Complex(a.Real + b, a.Imaginary);

		public static Complex operator +(double a, Complex b) => new Complex(a + b.Real, b.Imaginary);

		public static Complex operator -(Complex a) => new Complex(-a.Real, -a.Imaginary);

		public static Complex operator -(Complex a, Complex b) => new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);

		public static Complex operator -(Complex a, double b) => new Complex(a.Real - b, a.Imaginary);

		public static Complex operator -(double a, Complex b) => new Complex(a - b.Real, -b.Imaginary);

		public static Complex operator *(Complex a, Complex b)
		{
			return new Complex
			(
				a.Real * b.Real - a.Imaginary * b.Imaginary,
				a.Imaginary * b.Real + a.Real * b.Imaginary
			);
		}

		public static Complex operator *(Complex a, double b) => new Complex(a.Real * b, a.Imaginary * b);

		public static Complex operator *(double a, Complex b) => new Complex(a * b.Real, a * b.Imaginary);

		public static Complex operator /(Complex a, Complex b)
		{
			double d = b.Real * b.Real + b.Imaginary * b.Imaginary;

			return new Complex
			(
				(a.Real * b.Real + a.Imaginary * b.Imaginary) / d,
				(a.Imaginary * b.Real - a.Real * b.Imaginary) / d
			);
		}

		public static Complex operator /(Complex a, double b) => new Complex(a.Real / b, a.Imaginary / b);

		public static Complex operator /(double a, Complex b)
		{
			double d = b.Real * b.Real + b.Imaginary * b.Imaginary;

			return new Complex(a * b.Real / d, -a * b.Imaginary / d);
		}

		#endregion

		#region Operators

		public static bool operator ==(Complex a, Complex b) => a.Real == b.Real && a.Imaginary == b.Imaginary;

		public static bool operator ==(Complex a, double b) => a.Real == b && a.Imaginary == 0;

		public static bool operator ==(double a, Complex b) => a == b.Real && 0 == b.Imaginary;

		public static bool operator !=(Complex a, Complex b) => a.Real != b.Real || a.Imaginary != b.Imaginary;

		public static bool operator !=(Complex a, double b) => a.Real != b || a.Imaginary != 0;

		public static bool operator !=(double a, Complex b) => a != b.Real || 0 != b.Imaginary;

		#endregion

		#region Properties

		public double Argument => Math.Atan2(Imaginary, Real);

		public Complex Conjugate => new Complex(Real, -Imaginary);

		public double Imaginary { get; set; }

		public double Modulus => Math.Sqrt(ModulusSqr);

		public double ModulusSqr => Real * Real + Imaginary * Imaginary;

		public double Real { get; set; }

		#endregion
	}
}
