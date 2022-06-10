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
    public struct PowerDensity :
        IComparable<PowerDensity>,
        IEquatable<PowerDensity>
    {
        #region Constants

        public static readonly PowerDensity Max = new PowerDensity(double.MaxValue);

        public static readonly PowerDensity Min = new PowerDensity(double.MinValue);

        public static readonly PowerDensity NegativeInfinity = new PowerDensity(double.NegativeInfinity);

        public static readonly PowerDensity PositiveInfinity = new PowerDensity(double.PositiveInfinity);

        public static readonly PowerDensity Unit = new PowerDensity(1);

        public static readonly PowerDensity Zero = new PowerDensity();

        #endregion

        #region Construction

        public PowerDensity(double wattsPerCubicMeter)
        {
            WattsPerCubicMeter = wattsPerCubicMeter;
        }

        #endregion

        #region Methods

        public int CompareTo(PowerDensity x)
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

        public bool Equals(PowerDensity x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is PowerDensity)) return false;

            var y = (PowerDensity)x;

            return this == y;
        }

        public override int GetHashCode() => WattsPerCubicMeter.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(PowerDensity x, PowerDensity y) => x.WattsPerCubicMeter == y.WattsPerCubicMeter;

        public static bool operator !=(PowerDensity x, PowerDensity y) => x.WattsPerCubicMeter != y.WattsPerCubicMeter;

        public static bool operator <(PowerDensity x, PowerDensity y) => x.WattsPerCubicMeter < y.WattsPerCubicMeter;

        public static bool operator <=(PowerDensity x, PowerDensity y) => x.WattsPerCubicMeter <= y.WattsPerCubicMeter;

        public static bool operator >(PowerDensity x, PowerDensity y) => x.WattsPerCubicMeter > y.WattsPerCubicMeter;

        public static bool operator >=(PowerDensity x, PowerDensity y) => x.WattsPerCubicMeter >= y.WattsPerCubicMeter;

        #endregion

        #region Operators

        public static PowerDensity operator +(PowerDensity x) => x;

        public static PowerDensity operator +(PowerDensity x, PowerDensity y) => new PowerDensity(x.WattsPerCubicMeter + y.WattsPerCubicMeter);

        public static PowerDensity operator -(PowerDensity x) => new PowerDensity(-x.WattsPerCubicMeter);

        public static PowerDensity operator -(PowerDensity x, PowerDensity y) => new PowerDensity(x.WattsPerCubicMeter - y.WattsPerCubicMeter);

        public static PowerDensity operator *(double x, PowerDensity y) => new PowerDensity(x * y.WattsPerCubicMeter);

        public static PowerDensity operator *(PowerDensity x, double y) => new PowerDensity(x.WattsPerCubicMeter * y);

        public static PowerDensity operator /(PowerDensity x, double y) => new PowerDensity(x.WattsPerCubicMeter / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(PowerDensity x, PowerDensity y) => x.WattsPerCubicMeter / y.WattsPerCubicMeter;

        #endregion

        #region Properties

        #region WattsPerCubicMeter

        public double NanowattsPerCubicMeter
        {
            get => WattsPerCubicMeter * 1e+9;
            set => WattsPerCubicMeter = value * 1e-9;
        }

        public double MicrowattsPerCubicMeter
        {
            get => WattsPerCubicMeter * 1e+6;
            set => WattsPerCubicMeter = value * 1e-6;
        }

        public double MilliwattsPerCubicMeter
        {
            get => WattsPerCubicMeter * 1e+3;
            set => WattsPerCubicMeter = value * 1e-3;
        }

        public double WattsPerCubicMeter { get; set; }

        public double KilowattsPerCubicMeter
        {
            get => WattsPerCubicMeter * 1e-3;
            set => WattsPerCubicMeter = value * 1e+3;
        }

        public double MegawattsPerCubicMeter
        {
            get => WattsPerCubicMeter * 1e-6;
            set => WattsPerCubicMeter = value * 1e+6;
        }

        public double GigawattsPerCubicMeter
        {
            get => WattsPerCubicMeter * 1e-9;
            set => WattsPerCubicMeter = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
