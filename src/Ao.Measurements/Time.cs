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
    public struct Time :
        IComparable<Time>,
        IEquatable<Time>
    {
        #region Constants

        public static readonly Time Max = new Time(double.MaxValue);

        public static readonly Time Min = new Time(double.MinValue);

        public static readonly Time NegativeInfinity = new Time(double.NegativeInfinity);

        public static readonly Time PositiveInfinity = new Time(double.PositiveInfinity);

        public static readonly Time Unit = new Time(1);

        public static readonly Time Zero = new Time();

        #endregion

        #region Construction

        public Time(double seconds)
        {
            Seconds = seconds;
        }

        #endregion

        #region Methods

        public int CompareTo(Time x)
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

        public bool Equals(Time x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Time)) return false;

            var y = (Time)x;

            return this == y;
        }

        public override int GetHashCode() => Seconds.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Time x, Time y) => x.Seconds == y.Seconds;

        public static bool operator !=(Time x, Time y) => x.Seconds != y.Seconds;

        public static bool operator <(Time x, Time y) => x.Seconds < y.Seconds;

        public static bool operator <=(Time x, Time y) => x.Seconds <= y.Seconds;

        public static bool operator >(Time x, Time y) => x.Seconds > y.Seconds;

        public static bool operator >=(Time x, Time y) => x.Seconds >= y.Seconds;

        #endregion

        #region Operators

        public static Time operator +(Time x) => x;

        public static Time operator +(Time x, Time y) => new Time(x.Seconds + y.Seconds);

        public static Time operator -(Time x) => new Time(-x.Seconds);

        public static Time operator -(Time x, Time y) => new Time(x.Seconds - y.Seconds);

        public static Time operator *(double x, Time y) => new Time(x * y.Seconds);

        public static Time operator *(Time x, double y) => new Time(x.Seconds * y);

        public static Time operator /(Time x, double y) => new Time(x.Seconds / y);

        #endregion

        #region Operators (*)

        public static Velocity operator *(Time x, Acceleration y) => new Velocity(x.Seconds * y.MetersPerSquareSecond);

        public static AngularVelocity operator *(Time x, AngularAcceleration y) => new AngularVelocity(x.Seconds * y.DegreesPerSquareSecond);

        public static AngularAcceleration operator *(Time x, AngularJerk y) => new AngularAcceleration(x.Seconds * y.DegreesPerCubicSecond);

        public static Angle operator *(Time x, AngularVelocity y) => new Angle(x.Seconds * y.DegreesPerSecond);

        public static double operator *(Time x, Frequency y) => x.Seconds * y.Hertz;

        public static Acceleration operator *(Time x, Jerk y) => new Acceleration(x.Seconds * y.MetersPerCubicSecond);

        public static Length operator *(Time x, Velocity y) => new Length(x.Seconds * y.MetersPerSecond);

        #endregion

        #region Operators (/)

        public static Frequency operator /(double x, Time y) => new Frequency(x / y.Seconds);

        public static double operator /(Time x, Time y) => x.Seconds / y.Seconds;

        #endregion

        #region Properties

        #region Hours

        public double Hours
        {
            get => Seconds / 3600.0;
            set => Seconds = value * 3600.0;
        }

        #endregion

        #region Minutes

        public double Minutes
        {
            get => Seconds / 60.0;
            set => Seconds = value * 60.0;
        }

        #endregion

        #region Seconds

        public double Nanoseconds
        {
            get => Seconds * 1e+9;
            set => Seconds = value * 1e-9;
        }

        public double Microseconds
        {
            get => Seconds * 1e+6;
            set => Seconds = value * 1e-6;
        }

        public double Milliseconds
        {
            get => Seconds * 1e+3;
            set => Seconds = value * 1e-3;
        }

        public double Seconds { get; set; }

        #endregion

        #endregion
    }
}
