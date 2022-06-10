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
    public struct AngularVelocity :
        IComparable<AngularVelocity>,
        IEquatable<AngularVelocity>
    {
        #region Constants

        public static readonly AngularVelocity Max = new AngularVelocity(double.MaxValue);

        public static readonly AngularVelocity Min = new AngularVelocity(double.MinValue);

        public static readonly AngularVelocity NegativeInfinity = new AngularVelocity(double.NegativeInfinity);

        public static readonly AngularVelocity PositiveInfinity = new AngularVelocity(double.PositiveInfinity);

        public static readonly AngularVelocity Unit = new AngularVelocity(1);

        public static readonly AngularVelocity Zero = new AngularVelocity();

        #endregion

        #region Construction

        public AngularVelocity(double degreesPerSecond)
        {
            DegreesPerSecond = degreesPerSecond;
        }

        #endregion

        #region Methods

        public int CompareTo(AngularVelocity x)
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

        public bool Equals(AngularVelocity x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is AngularVelocity)) return false;

            var y = (AngularVelocity)x;

            return this == y;
        }

        public override int GetHashCode() => DegreesPerSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(AngularVelocity x, AngularVelocity y) => x.DegreesPerSecond == y.DegreesPerSecond;

        public static bool operator !=(AngularVelocity x, AngularVelocity y) => x.DegreesPerSecond != y.DegreesPerSecond;

        public static bool operator <(AngularVelocity x, AngularVelocity y) => x.DegreesPerSecond < y.DegreesPerSecond;

        public static bool operator <=(AngularVelocity x, AngularVelocity y) => x.DegreesPerSecond <= y.DegreesPerSecond;

        public static bool operator >(AngularVelocity x, AngularVelocity y) => x.DegreesPerSecond > y.DegreesPerSecond;

        public static bool operator >=(AngularVelocity x, AngularVelocity y) => x.DegreesPerSecond >= y.DegreesPerSecond;

        #endregion

        #region Operators

        public static AngularVelocity operator +(AngularVelocity x) => x;

        public static AngularVelocity operator +(AngularVelocity x, AngularVelocity y) => new AngularVelocity(x.DegreesPerSecond + y.DegreesPerSecond);

        public static AngularVelocity operator -(AngularVelocity x) => new AngularVelocity(-x.DegreesPerSecond);

        public static AngularVelocity operator -(AngularVelocity x, AngularVelocity y) => new AngularVelocity(x.DegreesPerSecond - y.DegreesPerSecond);

        public static AngularVelocity operator *(double x, AngularVelocity y) => new AngularVelocity(x * y.DegreesPerSecond);

        public static AngularVelocity operator *(AngularVelocity x, double y) => new AngularVelocity(x.DegreesPerSecond * y);

        public static AngularVelocity operator /(AngularVelocity x, double y) => new AngularVelocity(x.DegreesPerSecond / y);

        #endregion

        #region Operators (*)

        public static AngularAcceleration operator *(AngularVelocity x, Frequency y) => new AngularAcceleration(x.DegreesPerSecond * y.Hertz);

        public static Angle operator *(AngularVelocity x, Time y) => new Angle(x.DegreesPerSecond * y.Seconds);

        #endregion

        #region Operators (/)

        public static Frequency operator /(AngularVelocity x, Angle y) => new Frequency(x.DegreesPerSecond / y.Degrees);

        public static Time operator /(AngularVelocity x, AngularAcceleration y) => new Time(x.DegreesPerSecond / y.DegreesPerSquareSecond);

        public static double operator /(AngularVelocity x, AngularVelocity y) => x.DegreesPerSecond / y.DegreesPerSecond;

        public static Angle operator /(AngularVelocity x, Frequency y) => new Angle(x.DegreesPerSecond / y.Hertz);

        public static AngularAcceleration operator /(AngularVelocity x, Time y) => new AngularAcceleration(x.DegreesPerSecond / y.Seconds);

        #endregion

        #region Properties

        #region ArcminutesPerSecond

        public double ArcminutesPerSecond
        {
            get => DegreesPerSecond * 60.0;
            set => DegreesPerSecond = value / 60.0;
        }

        #endregion

        #region ArcsecondsPerSecond

        public double NanoarcsecondsPerSecond
        {
            get => DegreesPerSecond * (3.6 * 10e+12);
            set => DegreesPerSecond = value / (3.6 * 10e+12);
        }

        public double MicroarcsecondsPerSecond
        {
            get => DegreesPerSecond * (3.6 * 10e+9);
            set => DegreesPerSecond = value / (3.6 * 10e+9);
        }

        public double MilliarcsecondsPerSecond
        {
            get => DegreesPerSecond * (3.6 * 10e+6);
            set => DegreesPerSecond = value / (3.6 * 10e+6);
        }

        public double ArcsecondsPerSecond
        {
            get => DegreesPerSecond * 3600.0;
            set => DegreesPerSecond = value / 3600.0;
        }

        #endregion

        #region DegreesPerSecond

        public double NanodegreesPerSecond
        {
            get => DegreesPerSecond * 1e+9;
            set => DegreesPerSecond = value * 1e-9;
        }

        public double MicrodegreesPerSecond
        {
            get => DegreesPerSecond * 1e+6;
            set => DegreesPerSecond = value * 1e-6;
        }

        public double MillidegreesPerSecond
        {
            get => DegreesPerSecond * 1e+3;
            set => DegreesPerSecond = value * 1e-3;
        }

        public double DegreesPerSecond { get; set; }

        #endregion

        #region RadiansPerSecond

        public double MicroradiansPerSecond
        {
            get => RadiansPerSecond * 1e+6;
            set => RadiansPerSecond = value * 1e-6;
        }

        public double MilliradiansPerSecond
        {
            get => RadiansPerSecond * 1e+3;
            set => RadiansPerSecond = value * 1e-3;
        }

        public double NanoradiansPerSecond
        {
            get => RadiansPerSecond * 1e+9;
            set => RadiansPerSecond = value * 1e-9;
        }

        public double RadiansPerSecond
        {
            get => DegreesPerSecond * Math.PI / 180.0;
            set => DegreesPerSecond = value * 180.0 / Math.PI;
        }

        #endregion

        #endregion
    }
}
