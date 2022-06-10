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
    public struct VolumetricFuelEconomy :
        IComparable<VolumetricFuelEconomy>,
        IEquatable<VolumetricFuelEconomy>
    {
        #region Constants

        public static readonly VolumetricFuelEconomy Max = new VolumetricFuelEconomy(double.MaxValue);

        public static readonly VolumetricFuelEconomy Min = new VolumetricFuelEconomy(double.MinValue);

        public static readonly VolumetricFuelEconomy NegativeInfinity = new VolumetricFuelEconomy(double.NegativeInfinity);

        public static readonly VolumetricFuelEconomy PositiveInfinity = new VolumetricFuelEconomy(double.PositiveInfinity);

        public static readonly VolumetricFuelEconomy Unit = new VolumetricFuelEconomy(1);

        public static readonly VolumetricFuelEconomy Zero = new VolumetricFuelEconomy();

        #endregion

        #region Construction

        public VolumetricFuelEconomy(double metersPerCubicMeter)
        {
            MetersPerCubicMeter = metersPerCubicMeter;
        }

        #endregion

        #region Methods

        public int CompareTo(VolumetricFuelEconomy x)
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

        public bool Equals(VolumetricFuelEconomy x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is VolumetricFuelEconomy)) return false;

            var y = (VolumetricFuelEconomy)x;

            return this == y;
        }

        public override int GetHashCode() => MetersPerCubicMeter.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(VolumetricFuelEconomy x, VolumetricFuelEconomy y) => x.MetersPerCubicMeter == y.MetersPerCubicMeter;

        public static bool operator !=(VolumetricFuelEconomy x, VolumetricFuelEconomy y) => x.MetersPerCubicMeter != y.MetersPerCubicMeter;

        public static bool operator <(VolumetricFuelEconomy x, VolumetricFuelEconomy y) => x.MetersPerCubicMeter < y.MetersPerCubicMeter;

        public static bool operator <=(VolumetricFuelEconomy x, VolumetricFuelEconomy y) => x.MetersPerCubicMeter <= y.MetersPerCubicMeter;

        public static bool operator >(VolumetricFuelEconomy x, VolumetricFuelEconomy y) => x.MetersPerCubicMeter > y.MetersPerCubicMeter;

        public static bool operator >=(VolumetricFuelEconomy x, VolumetricFuelEconomy y) => x.MetersPerCubicMeter >= y.MetersPerCubicMeter;

        #endregion

        #region Operators

        public static VolumetricFuelEconomy operator +(VolumetricFuelEconomy x) => x;

        public static VolumetricFuelEconomy operator +(VolumetricFuelEconomy x, VolumetricFuelEconomy y) => new VolumetricFuelEconomy(x.MetersPerCubicMeter + y.MetersPerCubicMeter);

        public static VolumetricFuelEconomy operator -(VolumetricFuelEconomy x) => new VolumetricFuelEconomy(-x.MetersPerCubicMeter);

        public static VolumetricFuelEconomy operator -(VolumetricFuelEconomy x, VolumetricFuelEconomy y) => new VolumetricFuelEconomy(x.MetersPerCubicMeter - y.MetersPerCubicMeter);

        public static VolumetricFuelEconomy operator *(double x, VolumetricFuelEconomy y) => new VolumetricFuelEconomy(x * y.MetersPerCubicMeter);

        public static VolumetricFuelEconomy operator *(VolumetricFuelEconomy x, double y) => new VolumetricFuelEconomy(x.MetersPerCubicMeter * y);

        public static VolumetricFuelEconomy operator /(VolumetricFuelEconomy x, double y) => new VolumetricFuelEconomy(x.MetersPerCubicMeter / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(VolumetricFuelEconomy x, VolumetricFuelEconomy y) => x.MetersPerCubicMeter / y.MetersPerCubicMeter;

        #endregion

        #region Properties

        #region MetersPerCubicDecimeter

        public double MetersPerCubicDecimeter
        {
            get => MetersPerCubicMeter * 1e-3;
            set => MetersPerCubicMeter = value * 1e+3;
        }

        public double KilometersPerCubicDecimeter
        {
            get => MetersPerCubicMeter * 1e-6;
            set => MetersPerCubicMeter = value * 1e+6;
        }

        #endregion

        #region MetersPerCubicMeter

        public double MetersPerCubicMeter { get; set; }

        public double KilometersPerCubicMeter
        {
            get => MetersPerCubicMeter * 1e-3;
            set => MetersPerCubicMeter = value * 1e+3;
        }

        #endregion

        #region MetersPerLiter

        public double MetersPerLiter
        {
            get => MetersPerCubicMeter * 1e-3;
            set => MetersPerCubicMeter = value * 1e+3;
        }

        public double KilometersPerLiter
        {
            get => MetersPerCubicMeter * 1e-6;
            set => MetersPerCubicMeter = value * 1e+6;
        }

        #endregion

        #endregion
    }
}
