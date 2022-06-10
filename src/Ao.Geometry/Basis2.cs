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
	public struct Basis2 : IEquatable<Basis2>
	{
		#region Constants

		public static readonly Basis2 Cartesian = new Basis2(Vector2.Unit1, Vector2.Unit2);

		#endregion

		#region Construction

		public Basis2(Vector2 base1, Vector2 base2)
		{
			Base1 = base1;
			Base2 = base2;
		}

		#endregion

		#region Methods

		public bool Equals(Basis2 x) => this == x;

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Basis2)) return false;

			var y = (Basis2)x;

			return this == y;
		}

		public override int GetHashCode() =>
			Base1.GetHashCode() ^
			Base2.GetHashCode();

		#endregion

		#region Operators

		public static bool operator ==(Basis2 a, Basis2 b) => a.Base1 == b.Base1 && a.Base2 == b.Base2;

		public static bool operator !=(Basis2 a, Basis2 b) => a.Base1 != b.Base1 || a.Base2 != b.Base2;

		#endregion

		#region Properties

		public Vector2 Base1 { get; set; }

		public Vector2 Base2 { get; set; }

		public Basis2 Normalized => new Basis2(Base1.Normalized, Base2.Normalized);

		#endregion
	}
}
