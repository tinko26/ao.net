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
    public struct Voltage :
        IComparable<Voltage>,
        IEquatable<Voltage>
    {
        #region Constants

        public static readonly Voltage Max = new Voltage(double.MaxValue);

        public static readonly Voltage Min = new Voltage(double.MinValue);

        public static readonly Voltage NegativeInfinity = new Voltage(double.NegativeInfinity);

        public static readonly Voltage PositiveInfinity = new Voltage(double.PositiveInfinity);

        public static readonly Voltage Unit = new Voltage(1);

        public static readonly Voltage Zero = new Voltage();

        #endregion

        #region Construction

        public Voltage(double volts)
        {
            Volts = volts;
        }

        #endregion

        #region Methods

        public int CompareTo(Voltage x)
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

        public bool Equals(Voltage x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Voltage)) return false;

            var y = (Voltage)x;

            return this == y;
        }

        public override int GetHashCode() => Volts.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Voltage x, Voltage y) => x.Volts == y.Volts;

        public static bool operator !=(Voltage x, Voltage y) => x.Volts != y.Volts;

        public static bool operator <(Voltage x, Voltage y) => x.Volts < y.Volts;

        public static bool operator <=(Voltage x, Voltage y) => x.Volts <= y.Volts;

        public static bool operator >(Voltage x, Voltage y) => x.Volts > y.Volts;

        public static bool operator >=(Voltage x, Voltage y) => x.Volts >= y.Volts;

        #endregion

        #region Operators

        public static Voltage operator +(Voltage x) => x;

        public static Voltage operator +(Voltage x, Voltage y) => new Voltage(x.Volts + y.Volts);

        public static Voltage operator -(Voltage x) => new Voltage(-x.Volts);

        public static Voltage operator -(Voltage x, Voltage y) => new Voltage(x.Volts - y.Volts);

        public static Voltage operator *(double x, Voltage y) => new Voltage(x * y.Volts);

        public static Voltage operator *(Voltage x, double y) => new Voltage(x.Volts * y);

        public static Voltage operator /(Voltage x, double y) => new Voltage(x.Volts / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(Voltage x, Voltage y) => x.Volts / y.Volts;

        #endregion

        #region Properties

        #region Volts

        public double Nanovolts
        {
            get => Volts * 1e+9;
            set => Volts = value * 1e-9;
        }

        public double Microvolts
        {
            get => Volts * 1e+6;
            set => Volts = value * 1e-6;
        }

        public double Millivolts
        {
            get => Volts * 1e+3;
            set => Volts = value * 1e-3;
        }

        public double Volts { get; set; }

        public double Kilovolts
        {
            get => Volts * 1e-3;
            set => Volts = value * 1e+3;
        }

        public double Megavolts
        {
            get => Volts * 1e-6;
            set => Volts = value * 1e+6;
        }

        public double Gigavolts
        {
            get => Volts * 1e-9;
            set => Volts = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
