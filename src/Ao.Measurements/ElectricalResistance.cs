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
    public struct ElectricalResistance :
        IComparable<ElectricalResistance>,
        IEquatable<ElectricalResistance>
    {
        #region Constants

        public static readonly ElectricalResistance Max = new ElectricalResistance(double.MaxValue);

        public static readonly ElectricalResistance Min = new ElectricalResistance(double.MinValue);

        public static readonly ElectricalResistance NegativeInfinity = new ElectricalResistance(double.NegativeInfinity);

        public static readonly ElectricalResistance PositiveInfinity = new ElectricalResistance(double.PositiveInfinity);

        public static readonly ElectricalResistance Unit = new ElectricalResistance(1);

        public static readonly ElectricalResistance Zero = new ElectricalResistance();

        #endregion

        #region Construction

        public ElectricalResistance(double ohms)
        {
            Ohms = ohms;
        }

        #endregion

        #region Methods

        public int CompareTo(ElectricalResistance x)
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

        public bool Equals(ElectricalResistance x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is ElectricalResistance)) return false;

            var y = (ElectricalResistance)x;

            return this == y;
        }

        public override int GetHashCode() => Ohms.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(ElectricalResistance x, ElectricalResistance y) => x.Ohms == y.Ohms;

        public static bool operator !=(ElectricalResistance x, ElectricalResistance y) => x.Ohms != y.Ohms;

        public static bool operator <(ElectricalResistance x, ElectricalResistance y) => x.Ohms < y.Ohms;

        public static bool operator <=(ElectricalResistance x, ElectricalResistance y) => x.Ohms <= y.Ohms;

        public static bool operator >(ElectricalResistance x, ElectricalResistance y) => x.Ohms > y.Ohms;

        public static bool operator >=(ElectricalResistance x, ElectricalResistance y) => x.Ohms >= y.Ohms;

        #endregion

        #region Operators

        public static ElectricalResistance operator +(ElectricalResistance x) => x;

        public static ElectricalResistance operator +(ElectricalResistance x, ElectricalResistance y) => new ElectricalResistance(x.Ohms + y.Ohms);

        public static ElectricalResistance operator -(ElectricalResistance x) => new ElectricalResistance(-x.Ohms);

        public static ElectricalResistance operator -(ElectricalResistance x, ElectricalResistance y) => new ElectricalResistance(x.Ohms - y.Ohms);

        public static ElectricalResistance operator *(double x, ElectricalResistance y) => new ElectricalResistance(x * y.Ohms);

        public static ElectricalResistance operator *(ElectricalResistance x, double y) => new ElectricalResistance(x.Ohms * y);

        public static ElectricalResistance operator /(ElectricalResistance x, double y) => new ElectricalResistance(x.Ohms / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(ElectricalResistance x, ElectricalResistance y) => x.Ohms / y.Ohms;

        #endregion

        #region Properties

        #region Ohms

        public double Nanoohms
        {
            get => Ohms * 1e+9;
            set => Ohms = value * 1e-9;
        }

        public double Microohms
        {
            get => Ohms * 1e+6;
            set => Ohms = value * 1e-6;
        }

        public double Milliohms
        {
            get => Ohms * 1e+3;
            set => Ohms = value * 1e-3;
        }

        public double Ohms { get; set; }

        public double Kiloohms
        {
            get => Ohms * 1e-3;
            set => Ohms = value * 1e+3;
        }

        public double Megaohms
        {
            get => Ohms * 1e-6;
            set => Ohms = value * 1e+6;
        }

        public double Gigaohms
        {
            get => Ohms * 1e-9;
            set => Ohms = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
