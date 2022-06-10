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
    public struct Frequency :
        IComparable<Frequency>,
        IEquatable<Frequency>
    {
        #region Constants

        public static readonly Frequency Max = new Frequency(double.MaxValue);

        public static readonly Frequency Min = new Frequency(double.MinValue);

        public static readonly Frequency NegativeInfinity = new Frequency(double.NegativeInfinity);

        public static readonly Frequency PositiveInfinity = new Frequency(double.PositiveInfinity);

        public static readonly Frequency Unit = new Frequency(1);

        public static readonly Frequency Zero = new Frequency();

        #endregion

        #region Construction

        public Frequency(double hertz)
        {
            Hertz = hertz;
        }

        #endregion

        #region Methods

        public int CompareTo(Frequency x)
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

        public bool Equals(Frequency x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Frequency)) return false;

            var y = (Frequency)x;

            return this == y;
        }

        public override int GetHashCode() => Hertz.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Frequency x, Frequency y) => x.Hertz == y.Hertz;

        public static bool operator !=(Frequency x, Frequency y) => x.Hertz != y.Hertz;

        public static bool operator <(Frequency x, Frequency y) => x.Hertz < y.Hertz;

        public static bool operator <=(Frequency x, Frequency y) => x.Hertz <= y.Hertz;

        public static bool operator >(Frequency x, Frequency y) => x.Hertz > y.Hertz;

        public static bool operator >=(Frequency x, Frequency y) => x.Hertz >= y.Hertz;

        #endregion

        #region Operators

        public static Frequency operator +(Frequency x) => x;

        public static Frequency operator +(Frequency x, Frequency y) => new Frequency(x.Hertz + y.Hertz);

        public static Frequency operator -(Frequency x) => new Frequency(-x.Hertz);

        public static Frequency operator -(Frequency x, Frequency y) => new Frequency(x.Hertz - y.Hertz);

        public static Frequency operator *(double x, Frequency y) => new Frequency(x * y.Hertz);

        public static Frequency operator *(Frequency x, double y) => new Frequency(x.Hertz * y);

        public static Frequency operator /(Frequency x, double y) => new Frequency(x.Hertz / y);

        #endregion

        #region Operators (*)

        public static Jerk operator *(Frequency x, Acceleration y) => new Jerk(x.Hertz * y.MetersPerSquareSecond);

        public static AngularVelocity operator *(Frequency x, Angle y) => new AngularVelocity(x.Hertz * y.Degrees);

        public static AngularJerk operator *(Frequency x, AngularAcceleration y) => new AngularJerk(x.Hertz * y.DegreesPerSquareSecond);

        public static AngularAcceleration operator *(Frequency x, AngularVelocity y) => new AngularAcceleration(x.Hertz * y.DegreesPerSecond);

        public static Velocity operator *(Frequency x, Length y) => new Velocity(x.Hertz * y.Meters);

        public static double operator *(Frequency x, Time y) => x.Hertz * y.Seconds;

        public static Acceleration operator *(Frequency x, Velocity y) => new Acceleration(x.Hertz * y.MetersPerSecond);

        #endregion

        #region Operators (/)

        public static Time operator /(double x, Frequency y) => new Time(x / y.Hertz);

        public static double operator /(Frequency x, Frequency y) => x.Hertz / y.Hertz;

        #endregion

        #region Properties

        #region Hertz

        public double Nanohertz
        {
            get => Hertz * 1e+9;
            set => Hertz = value * 1e-9;
        }

        public double Microhertz
        {
            get => Hertz * 1e+6;
            set => Hertz = value * 1e-6;
        }

        public double Millihertz
        {
            get => Hertz * 1e+3;
            set => Hertz = value * 1e-3;
        }

        public double Hertz { get; set; }

        public double Kilohertz
        {
            get => Hertz * 1e-3;
            set => Hertz = value * 1e+3;
        }

        public double Megahertz
        {
            get => Hertz * 1e-6;
            set => Hertz = value * 1e+6;
        }

        public double Gigahertz
        {
            get => Hertz * 1e-9;
            set => Hertz = value * 1e+9;
        }

        #endregion

        #region RotationsPerHour

        public double RotationsPerHour
        {
            get => Hertz * 3600;
            set => Hertz = value / 3600;
        }

        #endregion

        #region RotationsPerMinute

        public double RotationsPerMinute
        {
            get => Hertz * 60;
            set => Hertz = value / 60;
        }

        #endregion

        #region RotationsPerSecond

        public double RotationsPerSecond
        {
            get => Hertz;
            set => Hertz = value;
        }

        #endregion

        #endregion
    }
}
