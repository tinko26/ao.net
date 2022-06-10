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
    public struct SurfacePowerDensity :
        IComparable<SurfacePowerDensity>,
        IEquatable<SurfacePowerDensity>
    {
        #region Constants

        public static readonly SurfacePowerDensity Max = new SurfacePowerDensity(double.MaxValue);

        public static readonly SurfacePowerDensity Min = new SurfacePowerDensity(double.MinValue);

        public static readonly SurfacePowerDensity NegativeInfinity = new SurfacePowerDensity(double.NegativeInfinity);

        public static readonly SurfacePowerDensity PositiveInfinity = new SurfacePowerDensity(double.PositiveInfinity);

        public static readonly SurfacePowerDensity Unit = new SurfacePowerDensity(1);

        public static readonly SurfacePowerDensity Zero = new SurfacePowerDensity();

        #endregion

        #region Construction

        public SurfacePowerDensity(double wattsPerSquareMeter)
        {
            WattsPerSquareMeter = wattsPerSquareMeter;
        }

        #endregion

        #region Methods

        public int CompareTo(SurfacePowerDensity x)
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

        public bool Equals(SurfacePowerDensity x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is SurfacePowerDensity)) return false;

            var y = (SurfacePowerDensity)x;

            return this == y;
        }

        public override int GetHashCode() => WattsPerSquareMeter.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(SurfacePowerDensity x, SurfacePowerDensity y) => x.WattsPerSquareMeter == y.WattsPerSquareMeter;

        public static bool operator !=(SurfacePowerDensity x, SurfacePowerDensity y) => x.WattsPerSquareMeter != y.WattsPerSquareMeter;

        public static bool operator <(SurfacePowerDensity x, SurfacePowerDensity y) => x.WattsPerSquareMeter < y.WattsPerSquareMeter;

        public static bool operator <=(SurfacePowerDensity x, SurfacePowerDensity y) => x.WattsPerSquareMeter <= y.WattsPerSquareMeter;

        public static bool operator >(SurfacePowerDensity x, SurfacePowerDensity y) => x.WattsPerSquareMeter > y.WattsPerSquareMeter;

        public static bool operator >=(SurfacePowerDensity x, SurfacePowerDensity y) => x.WattsPerSquareMeter >= y.WattsPerSquareMeter;

        #endregion

        #region Operators

        public static SurfacePowerDensity operator +(SurfacePowerDensity x) => x;

        public static SurfacePowerDensity operator +(SurfacePowerDensity x, SurfacePowerDensity y) => new SurfacePowerDensity(x.WattsPerSquareMeter + y.WattsPerSquareMeter);

        public static SurfacePowerDensity operator -(SurfacePowerDensity x) => new SurfacePowerDensity(-x.WattsPerSquareMeter);

        public static SurfacePowerDensity operator -(SurfacePowerDensity x, SurfacePowerDensity y) => new SurfacePowerDensity(x.WattsPerSquareMeter - y.WattsPerSquareMeter);

        public static SurfacePowerDensity operator *(double x, SurfacePowerDensity y) => new SurfacePowerDensity(x * y.WattsPerSquareMeter);

        public static SurfacePowerDensity operator *(SurfacePowerDensity x, double y) => new SurfacePowerDensity(x.WattsPerSquareMeter * y);

        public static SurfacePowerDensity operator /(SurfacePowerDensity x, double y) => new SurfacePowerDensity(x.WattsPerSquareMeter / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(SurfacePowerDensity x, SurfacePowerDensity y) => x.WattsPerSquareMeter / y.WattsPerSquareMeter;

        #endregion

        #region Properties

        #region WattsPerSquareCentimeter

        public double NanowattsPerSquareCentimeter
        {
            get => WattsPerSquareMeter * 1e+5;
            set => WattsPerSquareMeter = value * 1e-5;
        }

        public double MicrowattsPerSquareCentimeter
        {
            get => WattsPerSquareMeter * 1e+2;
            set => WattsPerSquareMeter = value * 1e-2;
        }

        public double MilliwattsPerSquareCentimeter
        {
            get => WattsPerSquareMeter * 1e-1;
            set => WattsPerSquareMeter = value * 1e+1;
        }

        public double WattsPerSquareCentimeter
        {
            get => WattsPerSquareMeter * 1e-4;
            set => WattsPerSquareMeter = value * 1e+4;
        }

        public double KilowattsPerSquareCentimeter
        {
            get => WattsPerSquareMeter * 1e-7;
            set => WattsPerSquareMeter = value * 1e+7;
        }

        public double MegawattsPerSquareCentimeter
        {
            get => WattsPerSquareMeter * 1e-10;
            set => WattsPerSquareMeter = value * 1e+10;
        }

        public double GigawattsPerSquareCentimeter
        {
            get => WattsPerSquareMeter * 1e-13;
            set => WattsPerSquareMeter = value * 1e+13;
        }

        #endregion

        #region WattsPerSquareDecimeter

        public double NanowattsPerSquareDecimeter
        {
            get => WattsPerSquareMeter * 1e+7;
            set => WattsPerSquareMeter = value * 1e-7;
        }

        public double MicrowattsPerSquareDecimeter
        {
            get => WattsPerSquareMeter * 1e+4;
            set => WattsPerSquareMeter = value * 1e-4;
        }

        public double MilliwattsPerSquareDecimeter
        {
            get => WattsPerSquareMeter * 1e+1;
            set => WattsPerSquareMeter = value * 1e-1;
        }

        public double WattsPerSquareDecimeter
        {
            get => WattsPerSquareMeter * 1e-2;
            set => WattsPerSquareMeter = value * 1e+2;
        }

        public double KilowattsPerSquareDecimeter
        {
            get => WattsPerSquareMeter * 1e-5;
            set => WattsPerSquareMeter = value * 1e+5;
        }

        public double MegawattsPerSquareDecimeter
        {
            get => WattsPerSquareMeter * 1e-8;
            set => WattsPerSquareMeter = value * 1e+8;
        }

        public double GigawattsPerSquareDecimeter
        {
            get => WattsPerSquareMeter * 1e-11;
            set => WattsPerSquareMeter = value * 1e+11;
        }

        #endregion

        #region WattsPerSquareMeter

        public double NanowattsPerSquareMeter
        {
            get => WattsPerSquareMeter * 1e+9;
            set => WattsPerSquareMeter = value * 1e-9;
        }

        public double MicrowattsPerSquareMeter
        {
            get => WattsPerSquareMeter * 1e+6;
            set => WattsPerSquareMeter = value * 1e-6;
        }

        public double MilliwattsPerSquareMeter
        {
            get => WattsPerSquareMeter * 1e+3;
            set => WattsPerSquareMeter = value * 1e-3;
        }

        public double WattsPerSquareMeter { get; set; }

        public double KilowattsPerSquareMeter
        {
            get => WattsPerSquareMeter * 1e-3;
            set => WattsPerSquareMeter = value * 1e+3;
        }

        public double MegawattsPerSquareMeter
        {
            get => WattsPerSquareMeter * 1e-6;
            set => WattsPerSquareMeter = value * 1e+6;
        }

        public double GigawattsPerSquareMeter
        {
            get => WattsPerSquareMeter * 1e-9;
            set => WattsPerSquareMeter = value * 1e+9;
        }

        #endregion

        #region WattsPerSquareMillimeter

        public double NanowattsPerSquareMillimeter
        {
            get => WattsPerSquareMeter * 1e+3;
            set => WattsPerSquareMeter = value * 1e-3;
        }

        public double MicrowattsPerSquareMillimeter
        {
            get => WattsPerSquareMeter;
            set => WattsPerSquareMeter = value;
        }

        public double MilliwattsPerSquareMillimeter
        {
            get => WattsPerSquareMeter * 1e-3;
            set => WattsPerSquareMeter = value * 1e+3;
        }

        public double WattsPerSquareMillimeter
        {
            get => WattsPerSquareMeter * 1e-6;
            set => WattsPerSquareMeter = value * 1e+6;
        }

        public double KilowattsPerSquareMillimeter
        {
            get => WattsPerSquareMeter * 1e-9;
            set => WattsPerSquareMeter = value * 1e+9;
        }

        public double MegawattsPerSquareMillimeter
        {
            get => WattsPerSquareMeter * 1e-12;
            set => WattsPerSquareMeter = value * 1e+12;
        }

        public double GigawattsPerSquareMillimeter
        {
            get => WattsPerSquareMeter * 1e-15;
            set => WattsPerSquareMeter = value * 1e+15;
        }

        #endregion

        #endregion
    }
}
