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
    public struct Velocity :
        IComparable<Velocity>,
        IEquatable<Velocity>
    {
        #region Constants

        public static readonly Velocity Max = new Velocity(double.MaxValue);

        public static readonly Velocity Min = new Velocity(double.MinValue);

        public static readonly Velocity NegativeInfinity = new Velocity(double.NegativeInfinity);

        public static readonly Velocity PositiveInfinity = new Velocity(double.PositiveInfinity);

        public static readonly Velocity Unit = new Velocity(1);

        public static readonly Velocity Zero = new Velocity();

        #endregion

        #region Construction

        public Velocity(double metersPerSecond)
        {
            MetersPerSecond = metersPerSecond;
        }

        #endregion

        #region Methods

        public int CompareTo(Velocity x)
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

        public bool Equals(Velocity x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Velocity)) return false;

            var y = (Velocity)x;

            return this == y;
        }

        public override int GetHashCode() => MetersPerSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Velocity x, Velocity y) => x.MetersPerSecond == y.MetersPerSecond;

        public static bool operator !=(Velocity x, Velocity y) => x.MetersPerSecond != y.MetersPerSecond;

        public static bool operator <(Velocity x, Velocity y) => x.MetersPerSecond < y.MetersPerSecond;

        public static bool operator <=(Velocity x, Velocity y) => x.MetersPerSecond <= y.MetersPerSecond;

        public static bool operator >(Velocity x, Velocity y) => x.MetersPerSecond > y.MetersPerSecond;

        public static bool operator >=(Velocity x, Velocity y) => x.MetersPerSecond >= y.MetersPerSecond;

        #endregion

        #region Operators

        public static Velocity operator +(Velocity x) => x;

        public static Velocity operator +(Velocity x, Velocity y) => new Velocity(x.MetersPerSecond + y.MetersPerSecond);

        public static Velocity operator -(Velocity x) => new Velocity(-x.MetersPerSecond);

        public static Velocity operator -(Velocity x, Velocity y) => new Velocity(x.MetersPerSecond - y.MetersPerSecond);

        public static Velocity operator *(double x, Velocity y) => new Velocity(x * y.MetersPerSecond);

        public static Velocity operator *(Velocity x, double y) => new Velocity(x.MetersPerSecond * y);

        public static Velocity operator /(Velocity x, double y) => new Velocity(x.MetersPerSecond / y);

        #endregion

        #region Operators (*)

        public static Acceleration operator *(Velocity x, Frequency y) => new Acceleration(x.MetersPerSecond * y.Hertz);

        public static Length operator *(Velocity x, Time y) => new Length(x.MetersPerSecond * y.Seconds);

        #endregion

        #region Operators (/)

        public static Time operator /(Velocity x, Acceleration y) => new Time(x.MetersPerSecond / y.MetersPerSquareSecond);

        public static Length operator /(Velocity x, Frequency y) => new Length(x.MetersPerSecond / y.Hertz);

        public static Frequency operator /(Velocity x, Length y) => new Frequency(x.MetersPerSecond / y.Meters);

        public static Acceleration operator /(Velocity x, Time y) => new Acceleration(x.MetersPerSecond / y.Seconds);

        public static double operator /(Velocity x, Velocity y) => x.MetersPerSecond / y.MetersPerSecond;

        #endregion

        #region Properties

        #region MetersPerHour

        public double MetersPerHour
        {
            get => MetersPerSecond * 3600;
            set => MetersPerSecond = value / 3600;
        }

        public double KilometersPerHour
        {
            get => MetersPerSecond * 3600 * 1e-3;
            set => MetersPerSecond = value / 3600 * 1e+3;
        }

        #endregion

        #region MetersPerSecond

        public double NanometersPerSecond
        {
            get => MetersPerSecond * 1e+9;
            set => MetersPerSecond = value * 1e-9;
        }

        public double MicrometersPerSecond
        {
            get => MetersPerSecond * 1e+6;
            set => MetersPerSecond = value * 1e-6;
        }

        public double MillimetersPerSecond
        {
            get => MetersPerSecond * 1e+3;
            set => MetersPerSecond = value * 1e-3;
        }

        public double CentimetersPerSecond
        {
            get => MetersPerSecond * 1e+2;
            set => MetersPerSecond = value * 1e-2;
        }

        public double DecimetersPerSecond
        {
            get => MetersPerSecond * 1e+1;
            set => MetersPerSecond = value * 1e-1;
        }

        public double MetersPerSecond { get; set; }

        public double KilometersPerSecond
        {
            get => MetersPerSecond * 1e-3;
            set => MetersPerSecond = value * 1e+3;
        }

        #endregion

        #endregion
    }
}
