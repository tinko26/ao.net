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
    public struct AngularAcceleration :
        IComparable<AngularAcceleration>,
        IEquatable<AngularAcceleration>
    {
        #region Constants

        public static readonly AngularAcceleration Max = new AngularAcceleration(double.MaxValue);

        public static readonly AngularAcceleration Min = new AngularAcceleration(double.MinValue);

        public static readonly AngularAcceleration NegativeInfinity = new AngularAcceleration(double.NegativeInfinity);

        public static readonly AngularAcceleration PositiveInfinity = new AngularAcceleration(double.PositiveInfinity);

        public static readonly AngularAcceleration Unit = new AngularAcceleration(1);

        public static readonly AngularAcceleration Zero = new AngularAcceleration();

        #endregion

        #region Construction

        public AngularAcceleration(double degreesPerSquareSecond)
        {
            DegreesPerSquareSecond = degreesPerSquareSecond;
        }

        #endregion

        #region Methods

        public int CompareTo(AngularAcceleration x)
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

        public bool Equals(AngularAcceleration x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is AngularAcceleration)) return false;

            var y = (AngularAcceleration)x;

            return this == y;
        }

        public override int GetHashCode() => DegreesPerSquareSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(AngularAcceleration x, AngularAcceleration y) => x.DegreesPerSquareSecond == y.DegreesPerSquareSecond;

        public static bool operator !=(AngularAcceleration x, AngularAcceleration y) => x.DegreesPerSquareSecond != y.DegreesPerSquareSecond;

        public static bool operator <(AngularAcceleration x, AngularAcceleration y) => x.DegreesPerSquareSecond < y.DegreesPerSquareSecond;

        public static bool operator <=(AngularAcceleration x, AngularAcceleration y) => x.DegreesPerSquareSecond <= y.DegreesPerSquareSecond;

        public static bool operator >(AngularAcceleration x, AngularAcceleration y) => x.DegreesPerSquareSecond > y.DegreesPerSquareSecond;

        public static bool operator >=(AngularAcceleration x, AngularAcceleration y) => x.DegreesPerSquareSecond >= y.DegreesPerSquareSecond;

        #endregion

        #region Operators

        public static AngularAcceleration operator +(AngularAcceleration x) => x;

        public static AngularAcceleration operator +(AngularAcceleration x, AngularAcceleration y) => new AngularAcceleration(x.DegreesPerSquareSecond + y.DegreesPerSquareSecond);

        public static AngularAcceleration operator -(AngularAcceleration x) => new AngularAcceleration(-x.DegreesPerSquareSecond);

        public static AngularAcceleration operator -(AngularAcceleration x, AngularAcceleration y) => new AngularAcceleration(x.DegreesPerSquareSecond - y.DegreesPerSquareSecond);

        public static AngularAcceleration operator *(double x, AngularAcceleration y) => new AngularAcceleration(x * y.DegreesPerSquareSecond);

        public static AngularAcceleration operator *(AngularAcceleration x, double y) => new AngularAcceleration(x.DegreesPerSquareSecond * y);

        public static AngularAcceleration operator /(AngularAcceleration x, double y) => new AngularAcceleration(x.DegreesPerSquareSecond / y);

        #endregion

        #region Operators (*)

        public static AngularJerk operator *(AngularAcceleration x, Frequency y) => new AngularJerk(x.DegreesPerSquareSecond * y.Hertz);

        public static AngularVelocity operator *(AngularAcceleration x, Time y) => new AngularVelocity(x.DegreesPerSquareSecond * y.Seconds);

        #endregion

        #region Operators (/)

        public static double operator /(AngularAcceleration x, AngularAcceleration y) => x.DegreesPerSquareSecond / y.DegreesPerSquareSecond;

        public static Time operator /(AngularAcceleration x, AngularJerk y) => new Time(x.DegreesPerSquareSecond / y.DegreesPerCubicSecond);

        public static Frequency operator /(AngularAcceleration x, AngularVelocity y) => new Frequency(x.DegreesPerSquareSecond / y.DegreesPerSecond);

        public static AngularVelocity operator /(AngularAcceleration x, Frequency y) => new AngularVelocity(x.DegreesPerSquareSecond / y.Hertz);

        public static AngularJerk operator /(AngularAcceleration x, Time y) => new AngularJerk(x.DegreesPerSquareSecond / y.Seconds);

        #endregion

        #region Properties

        #region ArcsecondsPerSquareSecond

        public double NanoarcsecondsPerSquareSecond
        {
            get => DegreesPerSquareSecond * (3.6 * 10e+12);
            set => DegreesPerSquareSecond = value / (3.6 * 10e+12);
        }

        public double MicroarcsecondsPerSquareSecond
        {
            get => DegreesPerSquareSecond * (3.6 * 10e+9);
            set => DegreesPerSquareSecond = value / (3.6 * 10e+9);
        }

        public double MilliarcsecondsPerSquareSecond
        {
            get => DegreesPerSquareSecond * (3.6 * 10e+6);
            set => DegreesPerSquareSecond = value / (3.6 * 10e+6);
        }

        public double ArcsecondsPerSquareSecond
        {
            get => DegreesPerSquareSecond * 3600.0;
            set => DegreesPerSquareSecond = value / 3600.0;
        }

        #endregion

        #region ArcminutesPerSquareSecond

        public double ArcminutesPerSquareSecond
        {
            get => DegreesPerSquareSecond * 60.0;
            set => DegreesPerSquareSecond = value / 60.0;
        }

        #endregion

        #region DegreesPerSquareSecond

        public double NanodegreesPerSquareSecond
        {
            get => DegreesPerSquareSecond * 1e+9;
            set => DegreesPerSquareSecond = value * 1e-9;
        }

        public double MicrodegreesPerSquareSecond
        {
            get => DegreesPerSquareSecond * 1e+6;
            set => DegreesPerSquareSecond = value * 1e-6;
        }

        public double MillidegreesPerSquareSecond
        {
            get => DegreesPerSquareSecond * 1e+3;
            set => DegreesPerSquareSecond = value * 1e-3;
        }

        public double DegreesPerSquareSecond { get; set; }

        #endregion

        #region RadiansPerSquareSecond

        public double NanoradiansPerSquareSecond
        {
            get => RadiansPerSquareSecond * 1e+9;
            set => RadiansPerSquareSecond = value * 1e-9;
        }

        public double MicroradiansPerSquareSecond
        {
            get => RadiansPerSquareSecond * 1e+6;
            set => RadiansPerSquareSecond = value * 1e-6;
        }

        public double MilliradiansPerSquareSecond
        {
            get => RadiansPerSquareSecond * 1e+3;
            set => RadiansPerSquareSecond = value * 1e-3;
        }

        public double RadiansPerSquareSecond
        {
            get => DegreesPerSquareSecond * Math.PI / 180.0;
            set => DegreesPerSquareSecond = value * 180.0 / Math.PI;
        }

        #endregion

        #endregion
    }
}
