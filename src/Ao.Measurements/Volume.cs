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
    public struct Volume :
        IComparable<Volume>,
        IEquatable<Volume>
    {
        #region Constants

        public static readonly Volume Max = new Volume(double.MaxValue);

        public static readonly Volume Min = new Volume(double.MinValue);

        public static readonly Volume NegativeInfinity = new Volume(double.NegativeInfinity);

        public static readonly Volume PositiveInfinity = new Volume(double.PositiveInfinity);

        public static readonly Volume Unit = new Volume(1);

        public static readonly Volume Zero = new Volume();

        #endregion

        #region Construction

        public Volume(double cubicMeters)
        {
            CubicMeters = cubicMeters;
        }

        #endregion

        #region Methods

        public int CompareTo(Volume x)
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

        public bool Equals(Volume x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Volume)) return false;

            var y = (Volume)x;

            return this == y;
        }

        public override int GetHashCode() => CubicMeters.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Volume x, Volume y) => x.CubicMeters == y.CubicMeters;

        public static bool operator !=(Volume x, Volume y) => x.CubicMeters != y.CubicMeters;

        public static bool operator <(Volume x, Volume y) => x.CubicMeters < y.CubicMeters;

        public static bool operator <=(Volume x, Volume y) => x.CubicMeters <= y.CubicMeters;

        public static bool operator >(Volume x, Volume y) => x.CubicMeters > y.CubicMeters;

        public static bool operator >=(Volume x, Volume y) => x.CubicMeters >= y.CubicMeters;

        #endregion

        #region Operators

        public static Volume operator +(Volume x) => x;

        public static Volume operator +(Volume x, Volume y) => new Volume(x.CubicMeters + y.CubicMeters);

        public static Volume operator -(Volume x) => new Volume(-x.CubicMeters);

        public static Volume operator -(Volume x, Volume y) => new Volume(x.CubicMeters - y.CubicMeters);

        public static Volume operator *(double x, Volume y) => new Volume(x * y.CubicMeters);

        public static Volume operator *(Volume x, double y) => new Volume(x.CubicMeters * y);

        public static Volume operator /(Volume x, double y) => new Volume(x.CubicMeters / y);

        #endregion

        #region Operators (*)

        public static Mass operator *(Volume x, Density y) => new Mass(x.CubicMeters * y.KilogramsPerCubicMeter);

        #endregion

        #region Operators (/)

        public static Length operator /(Volume x, Area y) => new Length(x.CubicMeters / y.SquareMeters);

        public static Area operator /(Volume x, Length y) => new Area(x.CubicMeters / y.Meters);

        public static double operator /(Volume x, Volume y) => x.CubicMeters / y.CubicMeters;

        #endregion

        #region Properties

        #region CubicMeters

        public double CubicNanometers
        {
            get => CubicMeters * 1e+27;
            set => CubicMeters = value * 1e-27;
        }

        public double CubicMicrometers
        {
            get => CubicMeters * 1e+18;
            set => CubicMeters = value * 1e-18;
        }

        public double CubicMillimeters
        {
            get => CubicMeters * 1e+9;
            set => CubicMeters = value * 1e-9;
        }

        public double CubicCentimeters
        {
            get => CubicMeters * 1e+6;
            set => CubicMeters = value * 1e-6;
        }

        public double CubicDecimeters
        {
            get => CubicMeters * 1e+3;
            set => CubicMeters = value * 1e-3;
        }

        public double CubicMeters { get; set; }

        public double CubicKilometers
        {
            get => CubicMeters * 1e-9;
            set => CubicMeters = value * 1e+9;
        }

        #endregion

        #region Liters

        public double Nanoliters
        {
            get => CubicMeters * 1e+12;
            set => CubicMeters = value * 1e-12;
        }

        public double Microliters
        {
            get => CubicMeters * 1e+9;
            set => CubicMeters = value * 1e-9;
        }

        public double Milliliters
        {
            get => CubicMeters * 1e+6;
            set => CubicMeters = value * 1e-6;
        }

        public double Centiliters
        {
            get => CubicMeters * 1e+5;
            set => CubicMeters = value * 1e-5;
        }

        public double Deciliters
        {
            get => CubicMeters * 1e+4;
            set => CubicMeters = value * 1e-4;
        }

        public double Liters
        {
            get => CubicMeters * 1e+3;
            set => CubicMeters = value * 1e-3;
        }

        #endregion

        #endregion
    }
}
