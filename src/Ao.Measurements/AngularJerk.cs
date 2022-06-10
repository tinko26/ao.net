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
    public struct AngularJerk :
        IComparable<AngularJerk>,
        IEquatable<AngularJerk>
    {
        #region Constants

        public static readonly AngularJerk Max = new AngularJerk(double.MaxValue);

        public static readonly AngularJerk Min = new AngularJerk(double.MinValue);

        public static readonly AngularJerk NegativeInfinity = new AngularJerk(double.NegativeInfinity);

        public static readonly AngularJerk PositiveInfinity = new AngularJerk(double.PositiveInfinity);

        public static readonly AngularJerk Unit = new AngularJerk(1);

        public static readonly AngularJerk Zero = new AngularJerk();

        #endregion

        #region Construction

        public AngularJerk(double degreesPerCubicSecond)
        {
            DegreesPerCubicSecond = degreesPerCubicSecond;
        }

        #endregion

        #region Methods

        public int CompareTo(AngularJerk x)
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

        public bool Equals(AngularJerk x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is AngularJerk)) return false;

            var y = (AngularJerk)x;

            return this == y;
        }

        public override int GetHashCode() => DegreesPerCubicSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(AngularJerk x, AngularJerk y) => x.DegreesPerCubicSecond == y.DegreesPerCubicSecond;

        public static bool operator !=(AngularJerk x, AngularJerk y) => x.DegreesPerCubicSecond != y.DegreesPerCubicSecond;

        public static bool operator <(AngularJerk x, AngularJerk y) => x.DegreesPerCubicSecond < y.DegreesPerCubicSecond;

        public static bool operator <=(AngularJerk x, AngularJerk y) => x.DegreesPerCubicSecond <= y.DegreesPerCubicSecond;

        public static bool operator >(AngularJerk x, AngularJerk y) => x.DegreesPerCubicSecond > y.DegreesPerCubicSecond;

        public static bool operator >=(AngularJerk x, AngularJerk y) => x.DegreesPerCubicSecond >= y.DegreesPerCubicSecond;

        #endregion

        #region Operators

        public static AngularJerk operator +(AngularJerk x) => x;

        public static AngularJerk operator +(AngularJerk x, AngularJerk y) => new AngularJerk(x.DegreesPerCubicSecond + y.DegreesPerCubicSecond);

        public static AngularJerk operator -(AngularJerk x) => new AngularJerk(-x.DegreesPerCubicSecond);

        public static AngularJerk operator -(AngularJerk x, AngularJerk y) => new AngularJerk(x.DegreesPerCubicSecond - y.DegreesPerCubicSecond);

        public static AngularJerk operator *(double x, AngularJerk y) => new AngularJerk(x * y.DegreesPerCubicSecond);

        public static AngularJerk operator *(AngularJerk x, double y) => new AngularJerk(x.DegreesPerCubicSecond * y);

        public static AngularJerk operator /(AngularJerk x, double y) => new AngularJerk(x.DegreesPerCubicSecond / y);

        #endregion

        #region Operators (*)

        public static AngularAcceleration operator *(AngularJerk x, Time y) => new AngularAcceleration(x.DegreesPerCubicSecond * y.Seconds);

        #endregion

        #region Operators (/)

        public static Frequency operator /(AngularJerk x, AngularAcceleration y) => new Frequency(x.DegreesPerCubicSecond / y.DegreesPerSquareSecond);

        public static double operator /(AngularJerk x, AngularJerk y) => x.DegreesPerCubicSecond / y.DegreesPerCubicSecond;

        public static AngularAcceleration operator /(AngularJerk x, Frequency y) => new AngularAcceleration(x.DegreesPerCubicSecond * y.Hertz);

        #endregion

        #region Properties

        #region ArcminutesPerCubicSecond

        public double ArcminutesPerCubicSecond
        {
            get => DegreesPerCubicSecond * 60.0;
            set => DegreesPerCubicSecond = value / 60.0;
        }

        #endregion

        #region ArcsecondsPerCubicSecond

        public double NanoarcsecondsPerCubicSecond
        {
            get => DegreesPerCubicSecond * (3.6 * 10e+12);
            set => DegreesPerCubicSecond = value / (3.6 * 10e+12);
        }

        public double MicroarcsecondsPerCubicSecond
        {
            get => DegreesPerCubicSecond * (3.6 * 10e+9);
            set => DegreesPerCubicSecond = value / (3.6 * 10e+9);
        }

        public double MilliarcsecondsPerCubicSecond
        {
            get => DegreesPerCubicSecond * (3.6 * 10e+6);
            set => DegreesPerCubicSecond = value / (3.6 * 10e+6);
        }

        public double ArcsecondsPerCubicSecond
        {
            get => DegreesPerCubicSecond * 3600.0;
            set => DegreesPerCubicSecond = value / 3600.0;
        }

        #endregion

        #region DegreesPerCubicSecond

        public double NanodegreesPerCubicSecond
        {
            get => DegreesPerCubicSecond * 1e+9;
            set => DegreesPerCubicSecond = value * 1e-9;
        }

        public double MicrodegreesPerCubicSecond
        {
            get => DegreesPerCubicSecond * 1e+6;
            set => DegreesPerCubicSecond = value * 1e-6;
        }

        public double MillidegreesPerCubicSecond
        {
            get => DegreesPerCubicSecond * 1e+3;
            set => DegreesPerCubicSecond = value * 1e-3;
        }

        public double DegreesPerCubicSecond { get; set; }

        #endregion

        #region RadiansPerCubicSecond

        public double NanoradiansPerCubicSecond
        {
            get => RadiansPerCubicSecond * 1e+9;
            set => RadiansPerCubicSecond = value * 1e-9;
        }

        public double MicroradiansPerCubicSecond
        {
            get => RadiansPerCubicSecond * 1e+6;
            set => RadiansPerCubicSecond = value * 1e-6;
        }

        public double MilliradiansPerCubicSecond
        {
            get => RadiansPerCubicSecond * 1e+3;
            set => RadiansPerCubicSecond = value * 1e-3;
        }

        public double RadiansPerCubicSecond
        {
            get => DegreesPerCubicSecond * Math.PI / 180.0;
            set => DegreesPerCubicSecond = value * 180.0 / Math.PI;
        }

        #endregion

        #endregion
    }
}
