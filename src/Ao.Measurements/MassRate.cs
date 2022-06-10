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
    public struct MassRate :
        IComparable<MassRate>,
        IEquatable<MassRate>
    {
        #region Constants

        public static readonly MassRate Max = new MassRate(double.MaxValue);

        public static readonly MassRate Min = new MassRate(double.MinValue);

        public static readonly MassRate NegativeInfinity = new MassRate(double.NegativeInfinity);

        public static readonly MassRate PositiveInfinity = new MassRate(double.PositiveInfinity);

        public static readonly MassRate Unit = new MassRate(1);

        public static readonly MassRate Zero = new MassRate();

        #endregion

        #region Construction

        public MassRate(double kilogramsPerSecond) => KilogramsPerSecond = kilogramsPerSecond;

        #endregion

        #region Methods

        public int CompareTo(MassRate x)
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

        public bool Equals(MassRate x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is MassRate)) return false;

            var y = (MassRate)x;

            return this == y;
        }

        public override int GetHashCode() => KilogramsPerSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(MassRate x, MassRate y) => x.KilogramsPerSecond == y.KilogramsPerSecond;

        public static bool operator !=(MassRate x, MassRate y) => x.KilogramsPerSecond != y.KilogramsPerSecond;

        public static bool operator <(MassRate x, MassRate y) => x.KilogramsPerSecond < y.KilogramsPerSecond;

        public static bool operator <=(MassRate x, MassRate y) => x.KilogramsPerSecond <= y.KilogramsPerSecond;

        public static bool operator >(MassRate x, MassRate y) => x.KilogramsPerSecond > y.KilogramsPerSecond;

        public static bool operator >=(MassRate x, MassRate y) => x.KilogramsPerSecond >= y.KilogramsPerSecond;

        #endregion

        #region Operators

        public static MassRate operator +(MassRate x) => x;

        public static MassRate operator +(MassRate x, MassRate y) => new MassRate(x.KilogramsPerSecond + y.KilogramsPerSecond);

        public static MassRate operator -(MassRate x) => new MassRate(-x.KilogramsPerSecond);

        public static MassRate operator -(MassRate x, MassRate y) => new MassRate(x.KilogramsPerSecond - y.KilogramsPerSecond);

        public static MassRate operator *(double x, MassRate y) => new MassRate(x * y.KilogramsPerSecond);

        public static MassRate operator *(MassRate x, double y) => new MassRate(x.KilogramsPerSecond * y);

        public static MassRate operator /(MassRate x, double y) => new MassRate(x.KilogramsPerSecond / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(MassRate x, MassRate y) => x.KilogramsPerSecond / y.KilogramsPerSecond;

        #endregion

        #region Properties

        #region KilogramsPerHour

        public double NanogramsPerHour
        {
            get => KilogramsPerSecond * 3600 * 1e+12;
            set => KilogramsPerSecond = value / 3600 * 1e-12;
        }

        public double MicrogramsPerHour
        {
            get => KilogramsPerSecond * 3600 * 1e+9;
            set => KilogramsPerSecond = value / 3600 * 1e-9;
        }

        public double MilligramsPerHour
        {
            get => KilogramsPerSecond * 3600 * 1e+6;
            set => KilogramsPerSecond = value / 3600 * 1e-6;
        }

        public double GramsPerHour
        {
            get => KilogramsPerSecond * 3600 * 1e+3;
            set => KilogramsPerSecond = value / 3600 * 1e-3;
        }

        public double KilogramsPerHour
        {
            get => KilogramsPerSecond * 3600;
            set => KilogramsPerSecond = value / 3600;
        }

        #endregion

        #region KilogramsPerMinute

        public double NanogramsPerMinute
        {
            get => KilogramsPerSecond * 60 * 1e+12;
            set => KilogramsPerSecond = value / 60 * 1e-12;
        }

        public double MicrogramsPerMinute
        {
            get => KilogramsPerSecond * 60 * 1e+9;
            set => KilogramsPerSecond = value / 60 * 1e-9;
        }

        public double MilligramsPerMinute
        {
            get => KilogramsPerSecond * 60 * 1e+6;
            set => KilogramsPerSecond = value / 60 * 1e-6;
        }

        public double GramsPerMinute
        {
            get => KilogramsPerSecond * 60 * 1e+3;
            set => KilogramsPerSecond = value / 60 * 1e-3;
        }

        public double KilogramsPerMinute
        {
            get => KilogramsPerSecond * 60;
            set => KilogramsPerSecond = value / 60;
        }

        #endregion

        #region KilogramsPerSecond

        public double NanogramsPerSecond
        {
            get => KilogramsPerSecond * 1e+12;
            set => KilogramsPerSecond = value * 1e-12;
        }

        public double MicrogramsPerSecond
        {
            get => KilogramsPerSecond * 1e+9;
            set => KilogramsPerSecond = value * 1e-9;
        }

        public double MilligramsPerSecond
        {
            get => KilogramsPerSecond * 1e+6;
            set => KilogramsPerSecond = value * 1e-6;
        }

        public double GramsPerSecond
        {
            get => KilogramsPerSecond * 1e+3;
            set => KilogramsPerSecond = value * 1e-3;
        }

        public double KilogramsPerSecond { get; set; }

        #endregion

        #endregion
    }
}
