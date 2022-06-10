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
    public struct Angle :
        IComparable<Angle>,
        IEquatable<Angle>
    {
        #region Constants

        public static readonly Angle Max = new Angle(double.MaxValue);

        public static readonly Angle Min = new Angle(double.MinValue);

        public static readonly Angle NegativeInfinity = new Angle(double.NegativeInfinity);

        public static readonly Angle Pi = new Angle(180);

        public static readonly Angle PiHalf = new Angle(90);

        public static readonly Angle PositiveInfinity = new Angle(double.PositiveInfinity);

        public static readonly Angle Unit = new Angle(1);

        public static readonly Angle Zero = new Angle();

        #endregion

        #region Construction

        public Angle(double degrees)
        {
            Degrees = degrees;
        }

        #endregion

        #region Methods

        public int CompareTo(Angle x)
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

        public bool Equals(Angle x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Angle)) return false;

            var y = (Angle)x;

            return this == y;
        }

        public override int GetHashCode() => Degrees.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Angle x, Angle y) => x.Degrees == y.Degrees;

        public static bool operator !=(Angle x, Angle y) => x.Degrees != y.Degrees;

        public static bool operator <(Angle x, Angle y) => x.Degrees < y.Degrees;

        public static bool operator <=(Angle x, Angle y) => x.Degrees <= y.Degrees;

        public static bool operator >(Angle x, Angle y) => x.Degrees > y.Degrees;

        public static bool operator >=(Angle x, Angle y) => x.Degrees >= y.Degrees;

        #endregion

        #region Operators

        public static Angle operator +(Angle x) => x;

        public static Angle operator +(Angle x, Angle y) => new Angle(x.Degrees + y.Degrees);

        public static Angle operator -(Angle x) => new Angle(-x.Degrees);

        public static Angle operator -(Angle x, Angle y) => new Angle(x.Degrees - y.Degrees);

        public static Angle operator *(double x, Angle y) => new Angle(x * y.Degrees);

        public static Angle operator *(Angle x, double y) => new Angle(x.Degrees * y);

        public static Angle operator /(Angle x, double y) => new Angle(x.Degrees / y);

        #endregion

        #region Operators (*)

        public static AngularVelocity operator *(Angle x, Frequency y) => new AngularVelocity(x.Degrees * y.Hertz);

        #endregion

        #region Operators (/)

        public static double operator /(Angle x, Angle y) => x.Degrees / y.Degrees;

        public static Time operator /(Angle x, AngularVelocity y) => new Time(x.Degrees / y.DegreesPerSecond);

        public static AngularVelocity operator /(Angle x, Time y) => new AngularVelocity(x.Degrees / y.Seconds);

        #endregion

        #region Properties

        #region Arcminutes

        public double Arcminutes
        {
            get => Degrees * 60.0;
            set => Degrees = value / 60.0;
        }

        #endregion

        #region Arcseconds

        public double Nanoarcseconds
        {
            get => Degrees * (3.6 * 10e+12);
            set => Degrees = value / (3.6 * 10e+12);
        }

        public double Microarcseconds
        {
            get => Degrees * (3.6 * 10e+9);
            set => Degrees = value / (3.6 * 10e+9);
        }

        public double Milliarcseconds
        {
            get => Degrees * (3.6 * 10e+6);
            set => Degrees = value / (3.6 * 10e+6);
        }

        public double Arcseconds
        {
            get => Degrees * 3600.0;
            set => Degrees = value / 3600.0;
        }

        #endregion

        #region Degrees

        public double Nanodegrees
        {
            get => Degrees * 1e+9;
            set => Degrees = value * 1e-9;
        }

        public double Microdegrees
        {
            get => Degrees * 1e+6;
            set => Degrees = value * 1e-6;
        }

        public double Millidegrees
        {
            get => Degrees * 1e+3;
            set => Degrees = value * 1e-3;
        }

        public double Degrees { get; set; }

        #endregion

        #region Radians

        public double Nanoradians
        {
            get => Radians * 1e+9;
            set => Radians = value * 1e-9;
        }

        public double Microradians
        {
            get => Radians * 1e+6;
            set => Radians = value * 1e-6;
        }

        public double Milliradians
        {
            get => Radians * 1e+3;
            set => Radians = value * 1e-3;
        }

        public double Radians
        {
            get => Degrees * Math.PI / 180.0;
            set => Degrees = value * 180.0 / Math.PI;
        }

        #endregion

        #endregion
    }
}
