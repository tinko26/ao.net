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
    public struct Energy :
        IComparable<Energy>,
        IEquatable<Energy>
    {
        #region Constants

        public static readonly Energy Max = new Energy(double.MaxValue);

        public static readonly Energy Min = new Energy(double.MinValue);

        public static readonly Energy NegativeInfinity = new Energy(double.NegativeInfinity);

        public static readonly Energy PositiveInfinity = new Energy(double.PositiveInfinity);

        public static readonly Energy Unit = new Energy(1);

        public static readonly Energy Zero = new Energy();

        #endregion

        #region Construction

        public Energy(double joules)
        {
            Joules = joules;
        }

        #endregion

        #region Methods

        public int CompareTo(Energy x)
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

        public bool Equals(Energy x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Energy)) return false;

            var y = (Energy)x;

            return this == y;
        }

        public override int GetHashCode() => Joules.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Energy x, Energy y) => x.Joules == y.Joules;

        public static bool operator !=(Energy x, Energy y) => x.Joules != y.Joules;

        public static bool operator <(Energy x, Energy y) => x.Joules < y.Joules;

        public static bool operator <=(Energy x, Energy y) => x.Joules <= y.Joules;

        public static bool operator >(Energy x, Energy y) => x.Joules > y.Joules;

        public static bool operator >=(Energy x, Energy y) => x.Joules >= y.Joules;

        #endregion

        #region Operators

        public static Energy operator +(Energy x) => x;

        public static Energy operator +(Energy x, Energy y) => new Energy(x.Joules + y.Joules);

        public static Energy operator -(Energy x) => new Energy(-x.Joules);

        public static Energy operator -(Energy x, Energy y) => new Energy(x.Joules - y.Joules);

        public static Energy operator *(double x, Energy y) => new Energy(x * y.Joules);

        public static Energy operator *(Energy x, double y) => new Energy(x.Joules * y);

        public static Energy operator /(Energy x, double y) => new Energy(x.Joules / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(Energy x, Energy y) => x.Joules / y.Joules;

        #endregion

        #region Properties

        #region Joules

        public double Nanojoules
        {
            get => Joules * 1e+9;
            set => Joules = value * 1e-9;
        }

        public double Microjoules
        {
            get => Joules * 1e+6;
            set => Joules = value * 1e-6;
        }

        public double Millijoules
        {
            get => Joules * 1e+3;
            set => Joules = value * 1e-3;
        }

        public double Joules { get; set; }

        public double Kilojoules
        {
            get => Joules * 1e-3;
            set => Joules = value * 1e+3;
        }

        public double Megajoules
        {
            get => Joules * 1e-6;
            set => Joules = value * 1e+6;
        }

        public double Gigajoules
        {
            get => Joules * 1e-9;
            set => Joules = value * 1e+9;
        }

        #endregion

        #region NewtonMeters

        public double NewtonMeters
        {
            get => Joules;
            set => Joules = value;
        }

        #endregion

        #region VoltAmpereHours

        public double NanovoltAmpereHours
        {
            get => Joules / 3600 * 1e+9;
            set => Joules = value * 3600 * 1e-9;
        }

        public double MicrovoltAmpereHours
        {
            get => Joules / 3600 * 1e+6;
            set => Joules = value * 3600 * 1e-6;
        }

        public double MillivoltAmpereHours
        {
            get => Joules / 3600 * 1e+3;
            set => Joules = value * 3600 * 1e-3;
        }

        public double VoltAmpereHours
        {
            get => Joules / 3600;
            set => Joules = value * 3600;
        }

        public double KilovoltAmpereHours
        {
            get => Joules / 3600 * 1e-3;
            set => Joules = value * 3600 * 1e+3;
        }

        public double MegavoltAmpereHours
        {
            get => Joules / 3600 * 1e-6;
            set => Joules = value * 3600 * 1e+6;
        }

        public double GigavoltAmpereHours
        {
            get => Joules / 3600 * 1e-9;
            set => Joules = value * 3600 * 1e+9;
        }

        #endregion

        #region VoltAmpereSeconds

        public double VoltAmpereSeconds
        {
            get => Joules;
            set => Joules = value;
        }

        #endregion

        #region WattHours

        public double NanowattHours
        {
            get => Joules / 3600 * 1e+9;
            set => Joules = value * 3600 * 1e-9;
        }

        public double MicrowattHours
        {
            get => Joules / 3600 * 1e+6;
            set => Joules = value * 3600 * 1e-6;
        }

        public double MilliwattHours
        {
            get => Joules / 3600 * 1e+3;
            set => Joules = value * 3600 * 1e-3;
        }

        public double WattHours
        {
            get => Joules / 3600;
            set => Joules = value * 3600;
        }

        public double KilowattHours
        {
            get => Joules / 3600 * 1e-3;
            set => Joules = value * 3600 * 1e+3;
        }

        public double MegawattHours
        {
            get => Joules / 3600 * 1e-6;
            set => Joules = value * 3600 * 1e+6;
        }

        public double GigawattHours
        {
            get => Joules / 3600 * 1e-9;
            set => Joules = value * 3600 * 1e+9;
        }

        #endregion

        #region WattSeconds

        public double WattSeconds
        {
            get => Joules;
            set => Joules = value;
        }

        #endregion

        #endregion
    }
}
