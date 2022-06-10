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
    public struct MassFuelEconomy :
        IComparable<MassFuelEconomy>,
        IEquatable<MassFuelEconomy>
    {
        #region Constants

        public static readonly MassFuelEconomy Max = new MassFuelEconomy(double.MaxValue);

        public static readonly MassFuelEconomy Min = new MassFuelEconomy(double.MinValue);

        public static readonly MassFuelEconomy NegativeInfinity = new MassFuelEconomy(double.NegativeInfinity);

        public static readonly MassFuelEconomy PositiveInfinity = new MassFuelEconomy(double.PositiveInfinity);

        public static readonly MassFuelEconomy Unit = new MassFuelEconomy(1);

        public static readonly MassFuelEconomy Zero = new MassFuelEconomy();

        #endregion

        #region Construction

        public MassFuelEconomy(double metersPerKilogram)
        {
            MetersPerKilogram = metersPerKilogram;
        }

        #endregion

        #region Methods

        public int CompareTo(MassFuelEconomy x)
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

        public bool Equals(MassFuelEconomy x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is MassFuelEconomy)) return false;

            var y = (MassFuelEconomy)x;

            return this == y;
        }

        public override int GetHashCode() => MetersPerKilogram.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(MassFuelEconomy x, MassFuelEconomy y) => x.MetersPerKilogram == y.MetersPerKilogram;

        public static bool operator !=(MassFuelEconomy x, MassFuelEconomy y) => x.MetersPerKilogram != y.MetersPerKilogram;

        public static bool operator <(MassFuelEconomy x, MassFuelEconomy y) => x.MetersPerKilogram < y.MetersPerKilogram;

        public static bool operator <=(MassFuelEconomy x, MassFuelEconomy y) => x.MetersPerKilogram <= y.MetersPerKilogram;

        public static bool operator >(MassFuelEconomy x, MassFuelEconomy y) => x.MetersPerKilogram > y.MetersPerKilogram;

        public static bool operator >=(MassFuelEconomy x, MassFuelEconomy y) => x.MetersPerKilogram >= y.MetersPerKilogram;

        #endregion

        #region Operators

        public static MassFuelEconomy operator +(MassFuelEconomy x) => x;

        public static MassFuelEconomy operator +(MassFuelEconomy x, MassFuelEconomy y) => new MassFuelEconomy(x.MetersPerKilogram + y.MetersPerKilogram);

        public static MassFuelEconomy operator -(MassFuelEconomy x) => new MassFuelEconomy(-x.MetersPerKilogram);

        public static MassFuelEconomy operator -(MassFuelEconomy x, MassFuelEconomy y) => new MassFuelEconomy(x.MetersPerKilogram - y.MetersPerKilogram);

        public static MassFuelEconomy operator *(double x, MassFuelEconomy y) => new MassFuelEconomy(x * y.MetersPerKilogram);

        public static MassFuelEconomy operator *(MassFuelEconomy x, double y) => new MassFuelEconomy(x.MetersPerKilogram * y);

        public static MassFuelEconomy operator /(MassFuelEconomy x, double y) => new MassFuelEconomy(x.MetersPerKilogram / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(MassFuelEconomy x, MassFuelEconomy y) => x.MetersPerKilogram / y.MetersPerKilogram;

        #endregion

        #region Properties

        #region MetersPerKilogram

        public double MetersPerKilogram { get; set; }

        public double KilometersPerKilogram
        {
            get => MetersPerKilogram * 1e-3;
            set => MetersPerKilogram = value * 1e+3;
        }

        #endregion

        #endregion
    }
}
