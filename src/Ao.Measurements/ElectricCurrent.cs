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
    public struct ElectricCurrent :
        IComparable<ElectricCurrent>,
        IEquatable<ElectricCurrent>
    {
        #region Constants

        public static readonly ElectricCurrent Max = new ElectricCurrent(double.MaxValue);

        public static readonly ElectricCurrent Min = new ElectricCurrent(double.MinValue);

        public static readonly ElectricCurrent NegativeInfinity = new ElectricCurrent(double.NegativeInfinity);

        public static readonly ElectricCurrent PositiveInfinity = new ElectricCurrent(double.PositiveInfinity);

        public static readonly ElectricCurrent Unit = new ElectricCurrent(1);

        public static readonly ElectricCurrent Zero = new ElectricCurrent();

        #endregion

        #region Construction

        public ElectricCurrent(double amperes)
        {
            Amperes = amperes;
        }

        #endregion

        #region Methods

        public int CompareTo(ElectricCurrent x)
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

        public bool Equals(ElectricCurrent x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is ElectricCurrent)) return false;

            var y = (ElectricCurrent)x;

            return this == y;
        }

        public override int GetHashCode() => Amperes.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(ElectricCurrent x, ElectricCurrent y) => x.Amperes == y.Amperes;

        public static bool operator !=(ElectricCurrent x, ElectricCurrent y) => x.Amperes != y.Amperes;

        public static bool operator <(ElectricCurrent x, ElectricCurrent y) => x.Amperes < y.Amperes;

        public static bool operator <=(ElectricCurrent x, ElectricCurrent y) => x.Amperes <= y.Amperes;

        public static bool operator >(ElectricCurrent x, ElectricCurrent y) => x.Amperes > y.Amperes;

        public static bool operator >=(ElectricCurrent x, ElectricCurrent y) => x.Amperes >= y.Amperes;

        #endregion

        #region Operators

        public static ElectricCurrent operator +(ElectricCurrent x) => x;

        public static ElectricCurrent operator +(ElectricCurrent x, ElectricCurrent y) => new ElectricCurrent(x.Amperes + y.Amperes);

        public static ElectricCurrent operator -(ElectricCurrent x) => new ElectricCurrent(-x.Amperes);

        public static ElectricCurrent operator -(ElectricCurrent x, ElectricCurrent y) => new ElectricCurrent(x.Amperes - y.Amperes);

        public static ElectricCurrent operator *(double x, ElectricCurrent y) => new ElectricCurrent(x * y.Amperes);

        public static ElectricCurrent operator *(ElectricCurrent x, double y) => new ElectricCurrent(x.Amperes * y);

        public static ElectricCurrent operator /(ElectricCurrent x, double y) => new ElectricCurrent(x.Amperes / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(ElectricCurrent x, ElectricCurrent y) => x.Amperes / y.Amperes;

        #endregion

        #region Properties

        #region Amperes

        public double Nanoamperes
        {
            get => Amperes * 1e+9;
            set => Amperes = value * 1e-9;
        }

        public double Microamperes
        {
            get => Amperes * 1e+6;
            set => Amperes = value * 1e-6;
        }

        public double Milliamperes
        {
            get => Amperes * 1e+3;
            set => Amperes = value * 1e-3;
        }

        public double Amperes { get; set; }

        public double Kiloamperes
        {
            get => Amperes * 1e-3;
            set => Amperes = value * 1e+3;
        }

        public double Megaamperes
        {
            get => Amperes * 1e-6;
            set => Amperes = value * 1e+6;
        }

        public double Gigaamperes
        {
            get => Amperes * 1e-9;
            set => Amperes = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
