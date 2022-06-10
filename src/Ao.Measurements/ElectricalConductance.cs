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
    public struct ElectricalConductance :
        IComparable<ElectricalConductance>,
        IEquatable<ElectricalConductance>
    {
        #region Constants

        public static readonly ElectricalConductance Max = new ElectricalConductance(double.MaxValue);

        public static readonly ElectricalConductance Min = new ElectricalConductance(double.MinValue);

        public static readonly ElectricalConductance NegativeInfinity = new ElectricalConductance(double.NegativeInfinity);

        public static readonly ElectricalConductance PositiveInfinity = new ElectricalConductance(double.PositiveInfinity);

        public static readonly ElectricalConductance Unit = new ElectricalConductance(1);

        public static readonly ElectricalConductance Zero = new ElectricalConductance();

        #endregion

        #region Construction

        public ElectricalConductance(double siemens)
        {
            Siemens = siemens;
        }

        #endregion

        #region Methods

        public int CompareTo(ElectricalConductance x)
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

        public bool Equals(ElectricalConductance x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is ElectricalConductance)) return false;

            var y = (ElectricalConductance)x;

            return this == y;
        }

        public override int GetHashCode() => Siemens.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(ElectricalConductance x, ElectricalConductance y) => x.Siemens == y.Siemens;

        public static bool operator !=(ElectricalConductance x, ElectricalConductance y) => x.Siemens != y.Siemens;

        public static bool operator <(ElectricalConductance x, ElectricalConductance y) => x.Siemens < y.Siemens;

        public static bool operator <=(ElectricalConductance x, ElectricalConductance y) => x.Siemens <= y.Siemens;

        public static bool operator >(ElectricalConductance x, ElectricalConductance y) => x.Siemens > y.Siemens;

        public static bool operator >=(ElectricalConductance x, ElectricalConductance y) => x.Siemens >= y.Siemens;

        #endregion

        #region Operators

        public static ElectricalConductance operator +(ElectricalConductance x) => x;

        public static ElectricalConductance operator +(ElectricalConductance x, ElectricalConductance y) => new ElectricalConductance(x.Siemens + y.Siemens);

        public static ElectricalConductance operator -(ElectricalConductance x) => new ElectricalConductance(-x.Siemens);

        public static ElectricalConductance operator -(ElectricalConductance x, ElectricalConductance y) => new ElectricalConductance(x.Siemens - y.Siemens);

        public static ElectricalConductance operator *(double x, ElectricalConductance y) => new ElectricalConductance(x * y.Siemens);

        public static ElectricalConductance operator *(ElectricalConductance x, double y) => new ElectricalConductance(x.Siemens * y);

        public static ElectricalConductance operator /(ElectricalConductance x, double y) => new ElectricalConductance(x.Siemens / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(ElectricalConductance x, ElectricalConductance y) => x.Siemens / y.Siemens;

        #endregion

        #region Properties

        #region Siemens

        public double Nanosiemens
        {
            get => Siemens * 1e+9;
            set => Siemens = value * 1e-9;
        }

        public double Microsiemens
        {
            get => Siemens * 1e+6;
            set => Siemens = value * 1e-6;
        }

        public double Millisiemens
        {
            get => Siemens * 1e+3;
            set => Siemens = value * 1e-3;
        }

        public double Siemens { get; set; }

        public double Kilosiemens
        {
            get => Siemens * 1e-3;
            set => Siemens = value * 1e+3;
        }

        public double Megasiemens
        {
            get => Siemens * 1e-6;
            set => Siemens = value * 1e+6;
        }

        public double Gigasiemens
        {
            get => Siemens * 1e-9;
            set => Siemens = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
