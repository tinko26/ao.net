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
    public struct PowerRate :
        IComparable<PowerRate>,
        IEquatable<PowerRate>
    {
        #region Constants

        public static readonly PowerRate Max = new PowerRate(double.MaxValue);

        public static readonly PowerRate Min = new PowerRate(double.MinValue);

        public static readonly PowerRate NegativeInfinity = new PowerRate(double.NegativeInfinity);

        public static readonly PowerRate PositiveInfinity = new PowerRate(double.PositiveInfinity);

        public static readonly PowerRate Unit = new PowerRate(1);

        public static readonly PowerRate Zero = new PowerRate();

        #endregion

        #region Construction

        public PowerRate(double wattsPerSecond)
        {
            WattsPerSecond = wattsPerSecond;
        }

        #endregion

        #region Methods

        public int CompareTo(PowerRate x)
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

        public bool Equals(PowerRate x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is PowerRate)) return false;

            var y = (PowerRate)x;

            return this == y;
        }

        public override int GetHashCode() => WattsPerSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(PowerRate x, PowerRate y) => x.WattsPerSecond == y.WattsPerSecond;

        public static bool operator !=(PowerRate x, PowerRate y) => x.WattsPerSecond != y.WattsPerSecond;

        public static bool operator <(PowerRate x, PowerRate y) => x.WattsPerSecond < y.WattsPerSecond;

        public static bool operator <=(PowerRate x, PowerRate y) => x.WattsPerSecond <= y.WattsPerSecond;

        public static bool operator >(PowerRate x, PowerRate y) => x.WattsPerSecond > y.WattsPerSecond;

        public static bool operator >=(PowerRate x, PowerRate y) => x.WattsPerSecond >= y.WattsPerSecond;

        #endregion

        #region Operators

        public static PowerRate operator +(PowerRate x) => x;

        public static PowerRate operator +(PowerRate x, PowerRate y) => new PowerRate(x.WattsPerSecond + y.WattsPerSecond);

        public static PowerRate operator -(PowerRate x) => new PowerRate(-x.WattsPerSecond);

        public static PowerRate operator -(PowerRate x, PowerRate y) => new PowerRate(x.WattsPerSecond - y.WattsPerSecond);

        public static PowerRate operator *(double x, PowerRate y) => new PowerRate(x * y.WattsPerSecond);

        public static PowerRate operator *(PowerRate x, double y) => new PowerRate(x.WattsPerSecond * y);

        public static PowerRate operator /(PowerRate x, double y) => new PowerRate(x.WattsPerSecond / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(PowerRate x, PowerRate y) => x.WattsPerSecond / y.WattsPerSecond;

        #endregion

        #region Properties

        #region WattsPerSecond

        public double NanowattsPerSecond
        {
            get => WattsPerSecond * 1e+9;
            set => WattsPerSecond = value * 1e-9;
        }

        public double MicrowattsPerSecond
        {
            get => WattsPerSecond * 1e+6;
            set => WattsPerSecond = value * 1e-6;
        }

        public double MilliwattsPerSecond
        {
            get => WattsPerSecond * 1e+3;
            set => WattsPerSecond = value * 1e-3;
        }

        public double WattsPerSecond { get; set; }

        public double KilowattsPerSecond
        {
            get => WattsPerSecond * 1e-3;
            set => WattsPerSecond = value * 1e+3;
        }

        public double MegawattsPerSecond
        {
            get => WattsPerSecond * 1e-6;
            set => WattsPerSecond = value * 1e+6;
        }

        public double GigawattsPerSecond
        {
            get => WattsPerSecond * 1e-9;
            set => WattsPerSecond = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
