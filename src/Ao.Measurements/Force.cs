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

namespace Ao.Measurements
{
    public struct Force :
        IComparable<Force>,
        IEquatable<Force>
    {
        #region Constants

        public static readonly Force Max = new Force(double.MaxValue);

        public static readonly Force Min = new Force(double.MinValue);

        public static readonly Force NegativeInfinity = new Force(double.NegativeInfinity);

        public static readonly Force PositiveInfinity = new Force(double.PositiveInfinity);

        public static readonly Force Unit = new Force(1);

        public static readonly Force Zero = new Force();

        #endregion

        #region Construction

        public Force(double newtons)
        {
            Newtons = newtons;
        }

        #endregion

        #region Methods

        public int CompareTo(Force x)
        {
            if (this < x)
            {
                return -1;
            }

            else if (this > x)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }

        public bool Equals(Force x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Force)) return false;

            var y = (Force)x;

            return this == y;
        }

        public override int GetHashCode() => Newtons.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Force x, Force y) => x.Newtons == y.Newtons;

        public static bool operator !=(Force x, Force y) => x.Newtons != y.Newtons;

        public static bool operator <(Force x, Force y) => x.Newtons < y.Newtons;

        public static bool operator <=(Force x, Force y) => x.Newtons <= y.Newtons;

        public static bool operator >(Force x, Force y) => x.Newtons > y.Newtons;

        public static bool operator >=(Force x, Force y) => x.Newtons >= y.Newtons;

        #endregion

        #region Operators

        public static Force operator +(Force x) => x;

        public static Force operator +(Force x, Force y) => new Force(x.Newtons + y.Newtons);

        public static Force operator -(Force x) => new Force(-x.Newtons);

        public static Force operator -(Force x, Force y) => new Force(x.Newtons - y.Newtons);

        public static Force operator *(double x, Force y) => new Force(x * y.Newtons);

        public static Force operator *(Force x, double y) => new Force(x.Newtons * y);

        public static Force operator /(Force x, double y) => new Force(x.Newtons / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(Force x, Force y) => x.Newtons / y.Newtons;

        #endregion

        #region Properties

        #region Newtons

        public double Nanonewtons
        {
            get => Newtons * 1e+9;
            set => Newtons = value * 1e-9;
        }

        public double Micronewtons
        {
            get => Newtons * 1e+6;
            set => Newtons = value * 1e-6;
        }

        public double Millinewtons
        {
            get => Newtons * 1e+3;
            set => Newtons = value * 1e-3;
        }

        public double Newtons { get; set; }

        public double Kilonewtons
        {
            get => Newtons * 1e-3;
            set => Newtons = value * 1e+3;
        }

        public double Meganewtons
        {
            get => Newtons * 1e-6;
            set => Newtons = value * 1e+6;
        }

        #endregion

        #endregion
    }
}
