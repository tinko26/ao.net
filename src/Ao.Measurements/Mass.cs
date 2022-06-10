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
    public struct Mass :
        IComparable<Mass>,
        IEquatable<Mass>
    {
        #region Constants

        public static readonly Mass Max = new Mass(double.MaxValue);

        public static readonly Mass Min = new Mass(double.MinValue);

        public static readonly Mass NegativeInfinity = new Mass(double.NegativeInfinity);

        public static readonly Mass PositiveInfinity = new Mass(double.PositiveInfinity);

        public static readonly Mass Unit = new Mass(1);

        public static readonly Mass Zero = new Mass();

        #endregion

        #region Construction

        public Mass(double kilograms) => Kilograms = kilograms;

        #endregion

        #region Methods

        public int CompareTo(Mass x)
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

        public bool Equals(Mass x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Mass)) return false;

            var y = (Mass)x;

            return this == y;
        }

        public override int GetHashCode() => Kilograms.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Mass x, Mass y) => x.Kilograms == y.Kilograms;

        public static bool operator !=(Mass x, Mass y) => x.Kilograms != y.Kilograms;

        public static bool operator <(Mass x, Mass y) => x.Kilograms < y.Kilograms;

        public static bool operator <=(Mass x, Mass y) => x.Kilograms <= y.Kilograms;

        public static bool operator >(Mass x, Mass y) => x.Kilograms > y.Kilograms;

        public static bool operator >=(Mass x, Mass y) => x.Kilograms >= y.Kilograms;

        #endregion

        #region Operators

        public static Mass operator +(Mass x) => x;

        public static Mass operator +(Mass x, Mass y) => new Mass(x.Kilograms + y.Kilograms);

        public static Mass operator -(Mass x) => new Mass(-x.Kilograms);

        public static Mass operator -(Mass x, Mass y) => new Mass(x.Kilograms - y.Kilograms);

        public static Mass operator *(double x, Mass y) => new Mass(x * y.Kilograms);

        public static Mass operator *(Mass x, double y) => new Mass(x.Kilograms * y);

        public static Mass operator /(Mass x, double y) => new Mass(x.Kilograms / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static Volume operator /(Mass x, Density y) => new Volume(x.Kilograms / y.KilogramsPerCubicMeter);

        public static double operator /(Mass x, Mass y) => x.Kilograms / y.Kilograms;

        public static Density operator /(Mass x, Volume y) => new Density(x.Kilograms / y.CubicMeters);

        #endregion

        #region Properties

        #region Kilograms

        public double Nanograms
        {
            get => Kilograms * 1e+12;
            set => Kilograms = value * 1e-12;
        }

        public double Micrograms
        {
            get => Kilograms * 1e+9;
            set => Kilograms = value * 1e-9;
        }

        public double Milligrams
        {
            get => Kilograms * 1e+6;
            set => Kilograms = value * 1e-6;
        }

        public double Grams
        {
            get => Kilograms * 1e+3;
            set => Kilograms = value * 1e-3;
        }

        public double Kilograms { get; set; }

        #endregion

        #region Tonnes

        public double Tonnes
        {
            get => Kilograms * 1e-3;
            set => Kilograms = value * 1e+3;
        }

        public double Kilotonnes
        {
            get => Kilograms * 1e-6;
            set => Kilograms = value * 1e+6;
        }

        public double Megatonnes
        {
            get => Kilograms * 1e-9;
            set => Kilograms = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
