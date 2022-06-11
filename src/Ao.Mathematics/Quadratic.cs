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
    public struct Quadratic : IEquatable<Quadratic>
    {
        #region Construction

        public Quadratic(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        #endregion

        #region Methods

        public bool Equals(Quadratic x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Quadratic)) return false;

            var y = (Quadratic)x;

            return this == y;
        }

        public override int GetHashCode() =>
            A.GetHashCode() ^
            B.GetHashCode() ^
            C.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Quadratic a, Quadratic b) => a.A == b.A && a.B == b.B && a.C == b.C;

        public static bool operator !=(Quadratic a, Quadratic b) => a.A != b.A || a.B != b.B || a.C != b.C;

        #endregion

        #region Properties

        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }

        public double Discriminant => B * B - 4 * A * C;

        public double Root1 => (-B + Math.Sqrt(Discriminant)) / (2 * A);

        public double Root2 => (-B - Math.Sqrt(Discriminant)) / (2 * A);

        public int Roots => Math.Sign(Discriminant) + 1;

        #endregion
    }
}
