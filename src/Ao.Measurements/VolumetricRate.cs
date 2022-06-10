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
    public struct VolumetricRate :
        IComparable<VolumetricRate>,
        IEquatable<VolumetricRate>
    {
        #region Constants

        public static readonly VolumetricRate Max = new VolumetricRate(double.MaxValue);

        public static readonly VolumetricRate Min = new VolumetricRate(double.MinValue);

        public static readonly VolumetricRate NegativeInfinity = new VolumetricRate(double.NegativeInfinity);

        public static readonly VolumetricRate PositiveInfinity = new VolumetricRate(double.PositiveInfinity);

        public static readonly VolumetricRate Unit = new VolumetricRate(1);

        public static readonly VolumetricRate Zero = new VolumetricRate();

        #endregion

        #region Construction

        public VolumetricRate(double cubicMetersPerSecond)
        {
            CubicMetersPerSecond = cubicMetersPerSecond;
        }

        #endregion

        #region Methods

        public int CompareTo(VolumetricRate x)
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

        public bool Equals(VolumetricRate x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is VolumetricRate)) return false;

            var y = (VolumetricRate)x;

            return this == y;
        }

        public override int GetHashCode() => CubicMetersPerSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(VolumetricRate x, VolumetricRate y) => x.CubicMetersPerSecond == y.CubicMetersPerSecond;

        public static bool operator !=(VolumetricRate x, VolumetricRate y) => x.CubicMetersPerSecond != y.CubicMetersPerSecond;

        public static bool operator <(VolumetricRate x, VolumetricRate y) => x.CubicMetersPerSecond < y.CubicMetersPerSecond;

        public static bool operator <=(VolumetricRate x, VolumetricRate y) => x.CubicMetersPerSecond <= y.CubicMetersPerSecond;

        public static bool operator >(VolumetricRate x, VolumetricRate y) => x.CubicMetersPerSecond > y.CubicMetersPerSecond;

        public static bool operator >=(VolumetricRate x, VolumetricRate y) => x.CubicMetersPerSecond >= y.CubicMetersPerSecond;

        #endregion

        #region Operators

        public static VolumetricRate operator +(VolumetricRate x) => x;

        public static VolumetricRate operator +(VolumetricRate x, VolumetricRate y) => new VolumetricRate(x.CubicMetersPerSecond + y.CubicMetersPerSecond);

        public static VolumetricRate operator -(VolumetricRate x) => new VolumetricRate(-x.CubicMetersPerSecond);

        public static VolumetricRate operator -(VolumetricRate x, VolumetricRate y) => new VolumetricRate(x.CubicMetersPerSecond - y.CubicMetersPerSecond);

        public static VolumetricRate operator *(double x, VolumetricRate y) => new VolumetricRate(x * y.CubicMetersPerSecond);

        public static VolumetricRate operator *(VolumetricRate x, double y) => new VolumetricRate(x.CubicMetersPerSecond * y);

        public static VolumetricRate operator /(VolumetricRate x, double y) => new VolumetricRate(x.CubicMetersPerSecond / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(VolumetricRate x, VolumetricRate y) => x.CubicMetersPerSecond / y.CubicMetersPerSecond;

        #endregion

        #region Properties

        #region CubicMetersPerHour

        public double CubicNanometersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+27;
            set => CubicMetersPerSecond = value / 3600 * 1e-27;
        }

        public double CubicMicrometersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+18;
            set => CubicMetersPerSecond = value / 3600 * 1e-18;
        }

        public double CubicMillimetersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+9;
            set => CubicMetersPerSecond = value / 3600 * 1e-9;
        }

        public double CubicCentimetersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+6;
            set => CubicMetersPerSecond = value / 3600 * 1e-6;
        }

        public double CubicDecimetersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+3;
            set => CubicMetersPerSecond = value / 3600 * 1e-3;
        }

        public double CubicMetersPerHour
        {
            get => CubicMetersPerSecond * 3600;
            set => CubicMetersPerSecond = value / 3600;
        }

        public double CubicKilometersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e-9;
            set => CubicMetersPerSecond = value / 3600 * 1e+9;
        }

        #endregion

        #region CubicMetersPerMinute

        public double CubicNanometersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+27;
            set => CubicMetersPerSecond = value / 60 * 1e-27;
        }

        public double CubicMicrometersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+18;
            set => CubicMetersPerSecond = value / 60 * 1e-18;
        }

        public double CubicMillimetersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+9;
            set => CubicMetersPerSecond = value / 60 * 1e-9;
        }

        public double CubicCentimetersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+6;
            set => CubicMetersPerSecond = value / 60 * 1e-6;
        }

        public double CubicDecimetersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+3;
            set => CubicMetersPerSecond = value / 60 * 1e-3;
        }

        public double CubicMetersPerMinute
        {
            get => CubicMetersPerSecond * 60;
            set => CubicMetersPerSecond = value / 60;
        }

        public double CubicKilometersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e-9;
            set => CubicMetersPerSecond = value / 60 * 1e+9;
        }

        #endregion

        #region CubicMetersPerSecond

        public double CubicNanometersPerSecond
        {
            get => CubicMetersPerSecond * 1e+27;
            set => CubicMetersPerSecond = value * 1e-27;
        }

        public double CubicMicrometersPerSecond
        {
            get => CubicMetersPerSecond * 1e+18;
            set => CubicMetersPerSecond = value * 1e-18;
        }

        public double CubicMillimetersPerSecond
        {
            get => CubicMetersPerSecond * 1e+9;
            set => CubicMetersPerSecond = value * 1e-9;
        }

        public double CubicCentimetersPerSecond
        {
            get => CubicMetersPerSecond * 1e+6;
            set => CubicMetersPerSecond = value * 1e-6;
        }

        public double CubicDecimetersPerSecond
        {
            get => CubicMetersPerSecond * 1e+3;
            set => CubicMetersPerSecond = value * 1e-3;
        }

        public double CubicMetersPerSecond { get; set; }

        public double CubicKilometersPerSecond
        {
            get => CubicMetersPerSecond * 1e-9;
            set => CubicMetersPerSecond = value * 1e+9;
        }

        #endregion

        #region LitersPerHour

        public double NanolitersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+12;
            set => CubicMetersPerSecond = value / 3600 * 1e-12;
        }

        public double MicrolitersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+9;
            set => CubicMetersPerSecond = value / 3600 * 1e-9;
        }

        public double MillilitersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+6;
            set => CubicMetersPerSecond = value / 3600 * 1e-6;
        }

        public double CentilitersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+5;
            set => CubicMetersPerSecond = value / 3600 * 1e-5;
        }

        public double DecilitersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+4;
            set => CubicMetersPerSecond = value / 3600 * 1e-4;
        }

        public double LitersPerHour
        {
            get => CubicMetersPerSecond * 3600 * 1e+3;
            set => CubicMetersPerSecond = value / 3600 * 1e-3;
        }

        #endregion

        #region LitersPerMinute

        public double NanolitersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+12;
            set => CubicMetersPerSecond = value / 60 * 1e-12;
        }

        public double MicrolitersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+9;
            set => CubicMetersPerSecond = value / 60 * 1e-9;
        }

        public double MillilitersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+6;
            set => CubicMetersPerSecond = value / 60 * 1e-6;
        }

        public double CentilitersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+5;
            set => CubicMetersPerSecond = value / 60 * 1e-5;
        }

        public double DecilitersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+4;
            set => CubicMetersPerSecond = value / 60 * 1e-4;
        }

        public double LitersPerMinute
        {
            get => CubicMetersPerSecond * 60 * 1e+3;
            set => CubicMetersPerSecond = value / 60 * 1e-3;
        }

        #endregion

        #region LitersPerSecond

        public double NanolitersPerSecond
        {
            get => CubicMetersPerSecond * 1e+12;
            set => CubicMetersPerSecond = value * 1e-12;
        }

        public double MicrolitersPerSecond
        {
            get => CubicMetersPerSecond * 1e+9;
            set => CubicMetersPerSecond = value * 1e-9;
        }

        public double MillilitersPerSecond
        {
            get => CubicMetersPerSecond * 1e+6;
            set => CubicMetersPerSecond = value * 1e-6;
        }

        public double CentilitersPerSecond
        {
            get => CubicMetersPerSecond * 1e+5;
            set => CubicMetersPerSecond = value * 1e-5;
        }

        public double DecilitersPerSecond
        {
            get => CubicMetersPerSecond * 1e+4;
            set => CubicMetersPerSecond = value * 1e-4;
        }

        public double LitersPerSecond
        {
            get => CubicMetersPerSecond * 1e+3;
            set => CubicMetersPerSecond = value * 1e-3;
        }

        #endregion

        #endregion
    }
}
