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
    public struct ElectricalResistivity :
        IComparable<ElectricalResistivity>,
        IEquatable<ElectricalResistivity>
    {
        #region Constants

        public static readonly ElectricalResistivity Max = new ElectricalResistivity(double.MaxValue);

        public static readonly ElectricalResistivity Min = new ElectricalResistivity(double.MinValue);

        public static readonly ElectricalResistivity NegativeInfinity = new ElectricalResistivity(double.NegativeInfinity);

        public static readonly ElectricalResistivity PositiveInfinity = new ElectricalResistivity(double.PositiveInfinity);

        public static readonly ElectricalResistivity Unit = new ElectricalResistivity(1);

        public static readonly ElectricalResistivity Zero = new ElectricalResistivity();

        #endregion

        #region Construction

        public ElectricalResistivity(double ohmMeters)
        {
            OhmMeters = ohmMeters;
        }

        #endregion

        #region Methods

        public int CompareTo(ElectricalResistivity x)
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

        public bool Equals(ElectricalResistivity x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is ElectricalResistivity)) return false;

            var y = (ElectricalResistivity)x;

            return this == y;
        }

        public override int GetHashCode() => OhmMeters.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(ElectricalResistivity x, ElectricalResistivity y) => x.OhmMeters == y.OhmMeters;

        public static bool operator !=(ElectricalResistivity x, ElectricalResistivity y) => x.OhmMeters != y.OhmMeters;

        public static bool operator <(ElectricalResistivity x, ElectricalResistivity y) => x.OhmMeters < y.OhmMeters;

        public static bool operator <=(ElectricalResistivity x, ElectricalResistivity y) => x.OhmMeters <= y.OhmMeters;

        public static bool operator >(ElectricalResistivity x, ElectricalResistivity y) => x.OhmMeters > y.OhmMeters;

        public static bool operator >=(ElectricalResistivity x, ElectricalResistivity y) => x.OhmMeters >= y.OhmMeters;

        #endregion

        #region Operators

        public static ElectricalResistivity operator +(ElectricalResistivity x) => x;

        public static ElectricalResistivity operator +(ElectricalResistivity x, ElectricalResistivity y) => new ElectricalResistivity(x.OhmMeters + y.OhmMeters);

        public static ElectricalResistivity operator -(ElectricalResistivity x) => new ElectricalResistivity(-x.OhmMeters);

        public static ElectricalResistivity operator -(ElectricalResistivity x, ElectricalResistivity y) => new ElectricalResistivity(x.OhmMeters - y.OhmMeters);

        public static ElectricalResistivity operator *(double x, ElectricalResistivity y) => new ElectricalResistivity(x * y.OhmMeters);

        public static ElectricalResistivity operator *(ElectricalResistivity x, double y) => new ElectricalResistivity(x.OhmMeters * y);

        public static ElectricalResistivity operator /(ElectricalResistivity x, double y) => new ElectricalResistivity(x.OhmMeters / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(ElectricalResistivity x, ElectricalResistivity y) => x.OhmMeters / y.OhmMeters;

        #endregion

        #region Properties

        #region OhmMeters

        public double NanoohmMeters
        {
            get => OhmMeters * 1e+9;
            set => OhmMeters = value * 1e-9;
        }

        public double MicroohmMeters
        {
            get => OhmMeters * 1e+6;
            set => OhmMeters = value * 1e-6;
        }

        public double MilliohmMeters
        {
            get => OhmMeters * 1e+3;
            set => OhmMeters = value * 1e-3;
        }

        public double OhmMeters { get; set; }

        public double KiloohmMeters
        {
            get => OhmMeters * 1e-3;
            set => OhmMeters = value * 1e+3;
        }

        public double MegaohmMeters
        {
            get => OhmMeters * 1e-6;
            set => OhmMeters = value * 1e+6;
        }

        public double GigaohmMeters
        {
            get => OhmMeters * 1e-9;
            set => OhmMeters = value * 1e+9;
        }

        #endregion

        #endregion
    }
}
