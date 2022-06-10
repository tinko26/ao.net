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
    public struct Pressure :
        IComparable<Pressure>,
        IEquatable<Pressure>
    {
        #region Constants

        public static readonly Pressure Max = new Pressure(double.MaxValue);

        public static readonly Pressure Min = new Pressure(double.MinValue);

        public static readonly Pressure NegativeInfinity = new Pressure(double.NegativeInfinity);

        public static readonly Pressure PositiveInfinity = new Pressure(double.PositiveInfinity);

        public static readonly Pressure Unit = new Pressure(1);

        public static readonly Pressure Zero = new Pressure();

        #endregion

        #region Construction

        public Pressure(double pascals)
        {
            Pascals = pascals;
        }

        #endregion

        #region Methods

        public int CompareTo(Pressure x)
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

        public bool Equals(Pressure x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Pressure)) return false;

            var y = (Pressure)x;

            return this == y;
        }

        public override int GetHashCode() => Pascals.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Pressure x, Pressure y) => x.Pascals == y.Pascals;

        public static bool operator !=(Pressure x, Pressure y) => x.Pascals != y.Pascals;

        public static bool operator <(Pressure x, Pressure y) => x.Pascals < y.Pascals;

        public static bool operator <=(Pressure x, Pressure y) => x.Pascals <= y.Pascals;

        public static bool operator >(Pressure x, Pressure y) => x.Pascals > y.Pascals;

        public static bool operator >=(Pressure x, Pressure y) => x.Pascals >= y.Pascals;

        #endregion

        #region Operators

        public static Pressure operator +(Pressure x) => x;

        public static Pressure operator +(Pressure x, Pressure y) => new Pressure(x.Pascals + y.Pascals);

        public static Pressure operator -(Pressure x) => new Pressure(-x.Pascals);

        public static Pressure operator -(Pressure x, Pressure y) => new Pressure(x.Pascals - y.Pascals);

        public static Pressure operator *(double x, Pressure y) => new Pressure(x * y.Pascals);

        public static Pressure operator *(Pressure x, double y) => new Pressure(x.Pascals * y);

        public static Pressure operator /(Pressure x, double y) => new Pressure(x.Pascals / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(Pressure x, Pressure y) => x.Pascals / y.Pascals;

        #endregion

        #region Properties

        #region Pascals

        public double Nanopascals
        {
            get => Pascals * 1e+9;
            set => Pascals = value * 1e-9;
        }

        public double Micropascals
        {
            get => Pascals * 1e+6;
            set => Pascals = value * 1e-6;
        }

        public double Millipascals
        {
            get => Pascals * 1e+3;
            set => Pascals = value * 1e-3;
        }

        public double Pascals { get; set; }

        public double Kilopascals
        {
            get => Pascals * 1e-3;
            set => Pascals = value * 1e+3;
        }

        public double Megapascals
        {
            get => Pascals * 1e-6;
            set => Pascals = value * 1e+6;
        }

        public double Gigapascals
        {
            get => Pascals * 1e-9;
            set => Pascals = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
