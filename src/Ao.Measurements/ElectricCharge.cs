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
    public struct ElectricCharge :
        IComparable<ElectricCharge>,
        IEquatable<ElectricCharge>
    {
        #region Constants

        public static readonly ElectricCharge Max = new ElectricCharge(double.MaxValue);

        public static readonly ElectricCharge Min = new ElectricCharge(double.MinValue);

        public static readonly ElectricCharge NegativeInfinity = new ElectricCharge(double.NegativeInfinity);

        public static readonly ElectricCharge PositiveInfinity = new ElectricCharge(double.PositiveInfinity);

        public static readonly ElectricCharge Unit = new ElectricCharge(1);

        public static readonly ElectricCharge Zero = new ElectricCharge();

        #endregion

        #region Construction

        public ElectricCharge(double coulombs)
        {
            Coulombs = coulombs;
        }

        #endregion

        #region Methods

        public int CompareTo(ElectricCharge x)
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

        public bool Equals(ElectricCharge x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is ElectricCharge)) return false;

            var y = (ElectricCharge)x;

            return this == y;
        }

        public override int GetHashCode() => Coulombs.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(ElectricCharge x, ElectricCharge y) => x.Coulombs == y.Coulombs;

        public static bool operator !=(ElectricCharge x, ElectricCharge y) => x.Coulombs != y.Coulombs;

        public static bool operator <(ElectricCharge x, ElectricCharge y) => x.Coulombs < y.Coulombs;

        public static bool operator <=(ElectricCharge x, ElectricCharge y) => x.Coulombs <= y.Coulombs;

        public static bool operator >(ElectricCharge x, ElectricCharge y) => x.Coulombs > y.Coulombs;

        public static bool operator >=(ElectricCharge x, ElectricCharge y) => x.Coulombs >= y.Coulombs;

        #endregion

        #region Operators

        public static ElectricCharge operator +(ElectricCharge x) => x;

        public static ElectricCharge operator +(ElectricCharge x, ElectricCharge y) => new ElectricCharge(x.Coulombs + y.Coulombs);

        public static ElectricCharge operator -(ElectricCharge x) => new ElectricCharge(-x.Coulombs);

        public static ElectricCharge operator -(ElectricCharge x, ElectricCharge y) => new ElectricCharge(x.Coulombs - y.Coulombs);

        public static ElectricCharge operator *(double x, ElectricCharge y) => new ElectricCharge(x * y.Coulombs);

        public static ElectricCharge operator *(ElectricCharge x, double y) => new ElectricCharge(x.Coulombs * y);

        public static ElectricCharge operator /(ElectricCharge x, double y) => new ElectricCharge(x.Coulombs / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(ElectricCharge x, ElectricCharge y) => x.Coulombs / y.Coulombs;

        #endregion

        #region Properties

        #region AmpereHours

        public double MicroampereHours
        {
            get => AmpereHours * 1e+6;
            set => AmpereHours = value * 1e-6;
        }

        public double MilliampereHours
        {
            get => AmpereHours * 1e+3;
            set => AmpereHours = value * 1e-3;
        }

        public double AmpereHours
        {
            get => AmpereSeconds / 3600;
            set => AmpereSeconds = value * 3600;
        }

        #endregion

        #region AmpereSeconds

        public double AmpereSeconds
        {
            get => Coulombs;
            set => Coulombs = value;
        }

        #endregion

        #region Coulombs

        public double Coulombs { get; set; }

        #endregion

        #endregion
    }
}
