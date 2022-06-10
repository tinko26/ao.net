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
    public struct EnergyDensity :
        IComparable<EnergyDensity>,
        IEquatable<EnergyDensity>
    {
        #region Constants

        public static readonly EnergyDensity Max = new EnergyDensity(double.MaxValue);

        public static readonly EnergyDensity Min = new EnergyDensity(double.MinValue);

        public static readonly EnergyDensity NegativeInfinity = new EnergyDensity(double.NegativeInfinity);

        public static readonly EnergyDensity PositiveInfinity = new EnergyDensity(double.PositiveInfinity);

        public static readonly EnergyDensity Unit = new EnergyDensity(1);

        public static readonly EnergyDensity Zero = new EnergyDensity();

        #endregion

        #region Construction

        public EnergyDensity(double joulesPerCubicMeter)
        {
            JoulesPerCubicMeter = joulesPerCubicMeter;
        }

        #endregion

        #region Methods

        public int CompareTo(EnergyDensity x)
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

        public bool Equals(EnergyDensity x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is EnergyDensity)) return false;

            var y = (EnergyDensity)x;

            return this == y;
        }

        public override int GetHashCode() => JoulesPerCubicMeter.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(EnergyDensity x, EnergyDensity y) => x.JoulesPerCubicMeter == y.JoulesPerCubicMeter;

        public static bool operator !=(EnergyDensity x, EnergyDensity y) => x.JoulesPerCubicMeter != y.JoulesPerCubicMeter;

        public static bool operator <(EnergyDensity x, EnergyDensity y) => x.JoulesPerCubicMeter < y.JoulesPerCubicMeter;

        public static bool operator <=(EnergyDensity x, EnergyDensity y) => x.JoulesPerCubicMeter <= y.JoulesPerCubicMeter;

        public static bool operator >(EnergyDensity x, EnergyDensity y) => x.JoulesPerCubicMeter > y.JoulesPerCubicMeter;

        public static bool operator >=(EnergyDensity x, EnergyDensity y) => x.JoulesPerCubicMeter >= y.JoulesPerCubicMeter;

        #endregion

        #region Operators

        public static EnergyDensity operator +(EnergyDensity x) => x;

        public static EnergyDensity operator +(EnergyDensity x, EnergyDensity y) => new EnergyDensity(x.JoulesPerCubicMeter + y.JoulesPerCubicMeter);

        public static EnergyDensity operator -(EnergyDensity x) => new EnergyDensity(-x.JoulesPerCubicMeter);

        public static EnergyDensity operator -(EnergyDensity x, EnergyDensity y) => new EnergyDensity(x.JoulesPerCubicMeter - y.JoulesPerCubicMeter);

        public static EnergyDensity operator *(double x, EnergyDensity y) => new EnergyDensity(x * y.JoulesPerCubicMeter);

        public static EnergyDensity operator *(EnergyDensity x, double y) => new EnergyDensity(x.JoulesPerCubicMeter * y);

        public static EnergyDensity operator /(EnergyDensity x, double y) => new EnergyDensity(x.JoulesPerCubicMeter / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(EnergyDensity x, EnergyDensity y) => x.JoulesPerCubicMeter / y.JoulesPerCubicMeter;

        #endregion

        #region Properties

        #region JoulesPerCubicDecimeter

        public double JoulesPerCubicDecimeter
        {
            get => JoulesPerCubicMeter * 1e-3;
            set => JoulesPerCubicMeter = value * 1e+3;
        }

        public double KilojoulesPerCubicDecimeter
        {
            get => JoulesPerCubicMeter * 1e-6;
            set => JoulesPerCubicMeter = value * 1e+6;
        }

        public double MegajoulesPerCubicDecimeter
        {
            get => JoulesPerCubicMeter * 1e-9;
            set => JoulesPerCubicMeter = value * 1e+9;
        }

        #endregion

        #region JoulesPerCubicMeter

        public double JoulesPerCubicMeter { get; set; }

        public double KilojoulesPerCubicMeter
        {
            get => JoulesPerCubicMeter * 1e-3;
            set => JoulesPerCubicMeter = value * 1e+3;
        }

        public double MegajoulesPerCubicMeter
        {
            get => JoulesPerCubicMeter * 1e-6;
            set => JoulesPerCubicMeter = value * 1e+6;
        }

        #endregion

        #region JoulesPerLiter

        public double JoulesPerLiter
        {
            get => JoulesPerCubicMeter * 1e-3;
            set => JoulesPerCubicMeter = value * 1e+3;
        }

        public double KilojoulesPerLiter
        {
            get => JoulesPerCubicMeter * 1e-6;
            set => JoulesPerCubicMeter = value * 1e+6;
        }

        public double MegajoulesPerLiter
        {
            get => JoulesPerCubicMeter * 1e-9;
            set => JoulesPerCubicMeter = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
