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
    public struct Density :
        IComparable<Density>,
        IEquatable<Density>
    {
        #region Constants

        public static readonly Density Max = new Density(double.MaxValue);

        public static readonly Density Min = new Density(double.MinValue);

        public static readonly Density NegativeInfinity = new Density(double.NegativeInfinity);

        public static readonly Density PositiveInfinity = new Density(double.PositiveInfinity);

        public static readonly Density Unit = new Density(1);

        public static readonly Density Zero = new Density();

        #endregion

        #region Construction

        public Density(double kilogramsPerCubicMeter) => KilogramsPerCubicMeter = kilogramsPerCubicMeter;

        #endregion

        #region Methods

        public int CompareTo(Density x)
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

        public bool Equals(Density x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Density)) return false;

            var y = (Density)x;

            return this == y;
        }

        public override int GetHashCode() => KilogramsPerCubicMeter.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Density x, Density y) => x.KilogramsPerCubicMeter == y.KilogramsPerCubicMeter;

        public static bool operator !=(Density x, Density y) => x.KilogramsPerCubicMeter != y.KilogramsPerCubicMeter;

        public static bool operator <(Density x, Density y) => x.KilogramsPerCubicMeter < y.KilogramsPerCubicMeter;

        public static bool operator <=(Density x, Density y) => x.KilogramsPerCubicMeter <= y.KilogramsPerCubicMeter;

        public static bool operator >(Density x, Density y) => x.KilogramsPerCubicMeter > y.KilogramsPerCubicMeter;

        public static bool operator >=(Density x, Density y) => x.KilogramsPerCubicMeter >= y.KilogramsPerCubicMeter;

        #endregion

        #region Operators

        public static Density operator +(Density x) => x;

        public static Density operator +(Density x, Density y) => new Density(x.KilogramsPerCubicMeter + y.KilogramsPerCubicMeter);

        public static Density operator -(Density x) => new Density(-x.KilogramsPerCubicMeter);

        public static Density operator -(Density x, Density y) => new Density(x.KilogramsPerCubicMeter - y.KilogramsPerCubicMeter);

        public static Density operator *(double x, Density y) => new Density(x * y.KilogramsPerCubicMeter);

        public static Density operator *(Density x, double y) => new Density(x.KilogramsPerCubicMeter * y);

        public static Density operator /(Density x, double y) => new Density(x.KilogramsPerCubicMeter / y);

        #endregion

        #region Operators (*)

        public static Mass operator *(Density x, Volume y) => new Mass(x.KilogramsPerCubicMeter * y.CubicMeters);

        #endregion

        #region Operators (/)

        public static double operator /(Density x, Density y) => x.KilogramsPerCubicMeter / y.KilogramsPerCubicMeter;

        #endregion

        #region Properties

        #region KilogramsPerCubicCentimeter

        public double GramsPerCubicCentimeter
        {
            get => KilogramsPerCubicMeter * 1e-3;
            set => KilogramsPerCubicMeter = value * 1e+3;
        }

        public double KilogramsPerCubicCentimeter
        {
            get => KilogramsPerCubicMeter * 1e-6;
            set => KilogramsPerCubicMeter = value * 1e+6;
        }

        #endregion

        #region KilogramsPerCubicDecimeter

        public double GramsPerCubicDecimeter
        {
            get => KilogramsPerCubicMeter;
            set => KilogramsPerCubicMeter = value;
        }

        public double KilogramsPerCubicDecimeter
        {
            get => KilogramsPerCubicMeter * 1e-3;
            set => KilogramsPerCubicMeter = value * 1e+3;
        }

        #endregion

        #region KilogramsPerCubicMeter

        public double MilligramsPerCubicMeter
        {
            get => KilogramsPerCubicMeter * 1e+6;
            set => KilogramsPerCubicMeter = value * 1e-6;
        }

        public double GramsPerCubicMeter
        {
            get => KilogramsPerCubicMeter * 1e+3;
            set => KilogramsPerCubicMeter = value * 1e-3;
        }

        public double KilogramsPerCubicMeter { get; set; }

        #endregion

        #region KilogramsPerLiter

        public double MilligramsPerLiter
        {
            get => KilogramsPerCubicMeter * 1e+3;
            set => KilogramsPerCubicMeter = value * 1e-3;
        }

        public double GramsPerLiter
        {
            get => KilogramsPerCubicMeter;
            set => KilogramsPerCubicMeter = value;
        }

        public double KilogramsPerLiter
        {
            get => KilogramsPerCubicMeter * 1e-3;
            set => KilogramsPerCubicMeter = value * 1e+3;
        }

        #endregion

        #endregion
    }
}
