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
    public struct FrequencyRate :
        IComparable<FrequencyRate>,
        IEquatable<FrequencyRate>
    {
        #region Constants

        public static readonly FrequencyRate Max = new FrequencyRate(double.MaxValue);

        public static readonly FrequencyRate Min = new FrequencyRate(double.MinValue);

        public static readonly FrequencyRate NegativeInfinity = new FrequencyRate(double.NegativeInfinity);

        public static readonly FrequencyRate PositiveInfinity = new FrequencyRate(double.PositiveInfinity);

        public static readonly FrequencyRate Unit = new FrequencyRate(1);

        public static readonly FrequencyRate Zero = new FrequencyRate();

        #endregion

        #region Construction

        public FrequencyRate(double hertzPerSecond)
        {
            HertzPerSecond = hertzPerSecond;
        }

        #endregion

        #region Methods

        public int CompareTo(FrequencyRate x)
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

        public bool Equals(FrequencyRate x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is FrequencyRate)) return false;

            var y = (FrequencyRate)x;

            return this == y;
        }

        public override int GetHashCode() => HertzPerSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(FrequencyRate x, FrequencyRate y) => x.HertzPerSecond == y.HertzPerSecond;

        public static bool operator !=(FrequencyRate x, FrequencyRate y) => x.HertzPerSecond != y.HertzPerSecond;

        public static bool operator <(FrequencyRate x, FrequencyRate y) => x.HertzPerSecond < y.HertzPerSecond;

        public static bool operator <=(FrequencyRate x, FrequencyRate y) => x.HertzPerSecond <= y.HertzPerSecond;

        public static bool operator >(FrequencyRate x, FrequencyRate y) => x.HertzPerSecond > y.HertzPerSecond;

        public static bool operator >=(FrequencyRate x, FrequencyRate y) => x.HertzPerSecond >= y.HertzPerSecond;

        #endregion

        #region Operators

        public static FrequencyRate operator +(FrequencyRate x) => x;

        public static FrequencyRate operator +(FrequencyRate x, FrequencyRate y) => new FrequencyRate(x.HertzPerSecond + y.HertzPerSecond);

        public static FrequencyRate operator -(FrequencyRate x) => new FrequencyRate(-x.HertzPerSecond);

        public static FrequencyRate operator -(FrequencyRate x, FrequencyRate y) => new FrequencyRate(x.HertzPerSecond - y.HertzPerSecond);

        public static FrequencyRate operator *(double x, FrequencyRate y) => new FrequencyRate(x * y.HertzPerSecond);

        public static FrequencyRate operator *(FrequencyRate x, double y) => new FrequencyRate(x.HertzPerSecond * y);

        public static FrequencyRate operator /(FrequencyRate x, double y) => new FrequencyRate(x.HertzPerSecond / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(FrequencyRate x, FrequencyRate y) => x.HertzPerSecond / y.HertzPerSecond;

        #endregion

        #region Properties

        #region HertzPerSecond

        public double NanohertzPerSecond
        {
            get => HertzPerSecond * 1e+9;
            set => HertzPerSecond = value * 1e-9;
        }

        public double MicrohertzPerSecond
        {
            get => HertzPerSecond * 1e+6;
            set => HertzPerSecond = value * 1e-6;
        }

        public double MillihertzPerSecond
        {
            get => HertzPerSecond * 1e+3;
            set => HertzPerSecond = value * 1e-3;
        }

        public double HertzPerSecond { get; set; }

        public double KilohertzPerSecond
        {
            get => HertzPerSecond * 1e-3;
            set => HertzPerSecond = value * 1e+3;
        }

        public double MegahertzPerSecond
        {
            get => HertzPerSecond * 1e-6;
            set => HertzPerSecond = value * 1e+6;
        }

        public double GigahertzPerSecond
        {
            get => HertzPerSecond * 1e-9;
            set => HertzPerSecond = value * 1e+9;
        }

        #endregion

        #region RotationsPerHourPerSecond

        public double RotationsPerHourPerSecond
        {
            get => HertzPerSecond * 3600;
            set => HertzPerSecond = value / 3600;
        }

        #endregion

        #region RotationsPerMinutePerSecond

        public double RotationsPerMinutePerSecond
        {
            get => HertzPerSecond * 60;
            set => HertzPerSecond = value / 60;
        }

        #endregion

        #region RotationsPerSecondPerSecond

        public double RotationsPerSecondPerSecond
        {
            get => HertzPerSecond;
            set => HertzPerSecond = value;
        }

        #endregion

        #endregion
    }
}
