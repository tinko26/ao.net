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
    public struct Power :
        IComparable<Power>,
        IEquatable<Power>
    {
        #region Constants

        public static readonly Power Max = new Power(double.MaxValue);

        public static readonly Power Min = new Power(double.MinValue);

        public static readonly Power NegativeInfinity = new Power(double.NegativeInfinity);

        public static readonly Power PositiveInfinity = new Power(double.PositiveInfinity);

        public static readonly Power Unit = new Power(1);

        public static readonly Power Zero = new Power();

        #endregion

        #region Construction

        public Power(double watts)
        {
            Watts = watts;
        }

        #endregion

        #region Methods

        public int CompareTo(Power x)
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

        public bool Equals(Power x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Power)) return false;

            var y = (Power)x;

            return this == y;
        }

        public override int GetHashCode() => Watts.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Power x, Power y) => x.Watts == y.Watts;

        public static bool operator !=(Power x, Power y) => x.Watts != y.Watts;

        public static bool operator <(Power x, Power y) => x.Watts < y.Watts;

        public static bool operator <=(Power x, Power y) => x.Watts <= y.Watts;

        public static bool operator >(Power x, Power y) => x.Watts > y.Watts;

        public static bool operator >=(Power x, Power y) => x.Watts >= y.Watts;

        #endregion

        #region Operators

        public static Power operator +(Power x) => x;

        public static Power operator +(Power x, Power y) => new Power(x.Watts + y.Watts);

        public static Power operator -(Power x) => new Power(-x.Watts);

        public static Power operator -(Power x, Power y) => new Power(x.Watts - y.Watts);

        public static Power operator *(double x, Power y) => new Power(x * y.Watts);

        public static Power operator *(Power x, double y) => new Power(x.Watts * y);

        public static Power operator /(Power x, double y) => new Power(x.Watts / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(Power x, Power y) => x.Watts / y.Watts;

        #endregion

        #region Properties

        #region VoltAmperes

        public double VoltAmperes
        {
            get => Watts;
            set => Watts = value;
        }

        #endregion

        #region Watts

        public double Nanowatts
        {
            get => Watts * 1e+9;
            set => Watts = value * 1e-9;
        }

        public double Microwatts
        {
            get => Watts * 1e+6;
            set => Watts = value * 1e-6;
        }

        public double Milliwatts
        {
            get => Watts * 1e+3;
            set => Watts = value * 1e-3;
        }

        public double Watts { get; set; }

        public double Kilowatts
        {
            get => Watts * 1e-3;
            set => Watts = value * 1e+3;
        }

        public double Megawatts
        {
            get => Watts * 1e-6;
            set => Watts = value * 1e+6;
        }

        public double Gigawatts
        {
            get => Watts * 1e-9;
            set => Watts = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
