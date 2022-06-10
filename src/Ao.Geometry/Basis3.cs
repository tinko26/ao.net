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
	public struct Basis3 : IEquatable<Basis3>
	{
		#region Constants

		public static readonly Basis3 Cartesian = new Basis3(Vector3.Unit1, Vector3.Unit2, Vector3.Unit3);

		#endregion

		#region Construction

		public Basis3(Vector3 base1, Vector3 base2, Vector3 base3)
		{
			Base1 = base1;
			Base2 = base2;
			Base3 = base3;
		}

		#endregion

		#region Methods

		public bool Equals(Basis3 x) => this == x;

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is Basis3)) return false;

			var y = (Basis3)x;

			return this == y;
		}

		public override int GetHashCode() =>
			Base1.GetHashCode() ^
			Base2.GetHashCode() ^
			Base3.GetHashCode();

		#endregion

		#region Operators

		public static bool operator ==(Basis3 a, Basis3 b) => a.Base1 == b.Base1 && a.Base2 == b.Base2 && a.Base3 == b.Base3;

		public static bool operator !=(Basis3 a, Basis3 b) => a.Base1 != b.Base1 || a.Base2 != b.Base2 || a.Base3 != b.Base3;

		#endregion

		#region Properties

		public Vector3 Base1 { get; set; }

		public Vector3 Base2 { get; set; }

		public Vector3 Base3 { get; set; }

		public Basis3 Normalized => new Basis3(Base1.Normalized, Base2.Normalized, Base3.Normalized);

		#endregion
	}
}
