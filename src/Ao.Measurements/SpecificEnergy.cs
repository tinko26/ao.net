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
    public struct SpecificEnergy :
        IComparable<SpecificEnergy>,
        IEquatable<SpecificEnergy>
    {
        #region Constants

        public static readonly SpecificEnergy Max = new SpecificEnergy(double.MaxValue);

        public static readonly SpecificEnergy Min = new SpecificEnergy(double.MinValue);

        public static readonly SpecificEnergy NegativeInfinity = new SpecificEnergy(double.NegativeInfinity);

        public static readonly SpecificEnergy PositiveInfinity = new SpecificEnergy(double.PositiveInfinity);

        public static readonly SpecificEnergy Unit = new SpecificEnergy(1);

        public static readonly SpecificEnergy Zero = new SpecificEnergy();

        #endregion

        #region Construction

        public SpecificEnergy(double joulesPerKilogram)
        {
            JoulesPerKilogram = joulesPerKilogram;
        }

        #endregion

        #region Methods

        public int CompareTo(SpecificEnergy x)
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

        public bool Equals(SpecificEnergy x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is SpecificEnergy)) return false;

            var y = (SpecificEnergy)x;

            return this == y;
        }

        public override int GetHashCode() => JoulesPerKilogram.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(SpecificEnergy x, SpecificEnergy y) => x.JoulesPerKilogram == y.JoulesPerKilogram;

        public static bool operator !=(SpecificEnergy x, SpecificEnergy y) => x.JoulesPerKilogram != y.JoulesPerKilogram;

        public static bool operator <(SpecificEnergy x, SpecificEnergy y) => x.JoulesPerKilogram < y.JoulesPerKilogram;

        public static bool operator <=(SpecificEnergy x, SpecificEnergy y) => x.JoulesPerKilogram <= y.JoulesPerKilogram;

        public static bool operator >(SpecificEnergy x, SpecificEnergy y) => x.JoulesPerKilogram > y.JoulesPerKilogram;

        public static bool operator >=(SpecificEnergy x, SpecificEnergy y) => x.JoulesPerKilogram >= y.JoulesPerKilogram;

        #endregion

        #region Operators

        public static SpecificEnergy operator +(SpecificEnergy x) => x;

        public static SpecificEnergy operator +(SpecificEnergy x, SpecificEnergy y) => new SpecificEnergy(x.JoulesPerKilogram + y.JoulesPerKilogram);

        public static SpecificEnergy operator -(SpecificEnergy x) => new SpecificEnergy(-x.JoulesPerKilogram);

        public static SpecificEnergy operator -(SpecificEnergy x, SpecificEnergy y) => new SpecificEnergy(x.JoulesPerKilogram - y.JoulesPerKilogram);

        public static SpecificEnergy operator *(double x, SpecificEnergy y) => new SpecificEnergy(x * y.JoulesPerKilogram);

        public static SpecificEnergy operator *(SpecificEnergy x, double y) => new SpecificEnergy(x.JoulesPerKilogram * y);

        public static SpecificEnergy operator /(SpecificEnergy x, double y) => new SpecificEnergy(x.JoulesPerKilogram / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(SpecificEnergy x, SpecificEnergy y) => x.JoulesPerKilogram / y.JoulesPerKilogram;

        #endregion

        #region Properties

        #region JoulesPerKilogram

        public double JoulesPerKilogram { get; set; }

        #endregion

        #endregion
    }
}
