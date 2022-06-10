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
    public struct ElectricalConductivity :
        IComparable<ElectricalConductivity>,
        IEquatable<ElectricalConductivity>
    {
        #region Constants

        public static readonly ElectricalConductivity Max = new ElectricalConductivity(double.MaxValue);

        public static readonly ElectricalConductivity Min = new ElectricalConductivity(double.MinValue);

        public static readonly ElectricalConductivity NegativeInfinity = new ElectricalConductivity(double.NegativeInfinity);

        public static readonly ElectricalConductivity PositiveInfinity = new ElectricalConductivity(double.PositiveInfinity);

        public static readonly ElectricalConductivity Unit = new ElectricalConductivity(1);

        public static readonly ElectricalConductivity Zero = new ElectricalConductivity();

        #endregion

        #region Construction

        public ElectricalConductivity(double siemensPerMeter)
        {
            SiemensPerMeter = siemensPerMeter;
        }

        #endregion

        #region Methods

        public int CompareTo(ElectricalConductivity x)
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

        public bool Equals(ElectricalConductivity x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is ElectricalConductivity)) return false;

            var y = (ElectricalConductivity)x;

            return this == y;
        }

        public override int GetHashCode() => SiemensPerMeter.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(ElectricalConductivity x, ElectricalConductivity y) => x.SiemensPerMeter == y.SiemensPerMeter;

        public static bool operator !=(ElectricalConductivity x, ElectricalConductivity y) => x.SiemensPerMeter != y.SiemensPerMeter;

        public static bool operator <(ElectricalConductivity x, ElectricalConductivity y) => x.SiemensPerMeter < y.SiemensPerMeter;

        public static bool operator <=(ElectricalConductivity x, ElectricalConductivity y) => x.SiemensPerMeter <= y.SiemensPerMeter;

        public static bool operator >(ElectricalConductivity x, ElectricalConductivity y) => x.SiemensPerMeter > y.SiemensPerMeter;

        public static bool operator >=(ElectricalConductivity x, ElectricalConductivity y) => x.SiemensPerMeter >= y.SiemensPerMeter;

        #endregion

        #region Operators

        public static ElectricalConductivity operator +(ElectricalConductivity x) => x;

        public static ElectricalConductivity operator +(ElectricalConductivity x, ElectricalConductivity y) => new ElectricalConductivity(x.SiemensPerMeter + y.SiemensPerMeter);

        public static ElectricalConductivity operator -(ElectricalConductivity x) => new ElectricalConductivity(-x.SiemensPerMeter);

        public static ElectricalConductivity operator -(ElectricalConductivity x, ElectricalConductivity y) => new ElectricalConductivity(x.SiemensPerMeter - y.SiemensPerMeter);

        public static ElectricalConductivity operator *(double x, ElectricalConductivity y) => new ElectricalConductivity(x * y.SiemensPerMeter);

        public static ElectricalConductivity operator *(ElectricalConductivity x, double y) => new ElectricalConductivity(x.SiemensPerMeter * y);

        public static ElectricalConductivity operator /(ElectricalConductivity x, double y) => new ElectricalConductivity(x.SiemensPerMeter / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(ElectricalConductivity x, ElectricalConductivity y) => x.SiemensPerMeter / y.SiemensPerMeter;

        #endregion

        #region Properties

        #region SiemensPerMeter

        public double NanosiemensPerMeter
        {
            get => SiemensPerMeter * 1e+9;
            set => SiemensPerMeter = value * 1e-9;
        }

        public double MicrosiemensPerMeter
        {
            get => SiemensPerMeter * 1e+6;
            set => SiemensPerMeter = value * 1e-6;
        }

        public double MillisiemensPerMeter
        {
            get => SiemensPerMeter * 1e+3;
            set => SiemensPerMeter = value * 1e-3;
        }

        public double SiemensPerMeter { get; set; }

        public double KilosiemensPerMeter
        {
            get => SiemensPerMeter * 1e-3;
            set => SiemensPerMeter = value * 1e+3;
        }

        public double MegasiemensPerMeter
        {
            get => SiemensPerMeter * 1e-6;
            set => SiemensPerMeter = value * 1e+6;
        }

        public double GigasiemensPerMeter
        {
            get => SiemensPerMeter * 1e-9;
            set => SiemensPerMeter = value * 1e+9;
        }

        #endregion

        #region SiemensPerMillimeter

        public double NanosiemensPerMillimeter
        {
            get => SiemensPerMeter * 1e+6;
            set => SiemensPerMeter = value * 1e-6;
        }

        public double MicrosiemensPerMillimeter
        {
            get => SiemensPerMeter * 1e+3;
            set => SiemensPerMeter = value * 1e-3;
        }

        public double MillisiemensPerMillimeter
        {
            get => SiemensPerMeter;
            set => SiemensPerMeter = value;
        }

        public double SiemensPerMillimeter
        {
            get => SiemensPerMeter * 1e-3;
            set => SiemensPerMeter = value * 1e+3;
        }

        public double KilosiemensPerMillimeter
        {
            get => SiemensPerMeter * 1e-6;
            set => SiemensPerMeter = value * 1e+6;
        }

        public double MegasiemensPerMillimeter
        {
            get => SiemensPerMeter * 1e-9;
            set => SiemensPerMeter = value * 1e+9;
        }

        public double GigasiemensPerMillimeter
        {
            get => SiemensPerMeter * 1e-12;
            set => SiemensPerMeter = value * 1e+12;
        }

        #endregion

        #endregion
    }
}
