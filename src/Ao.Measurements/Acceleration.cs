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
    public struct Acceleration :
        IComparable<Acceleration>,
        IEquatable<Acceleration>
    {
        #region Constants

        public static readonly Acceleration Max = new Acceleration(double.MaxValue);

        public static readonly Acceleration Min = new Acceleration(double.MinValue);

        public static readonly Acceleration NegativeInfinity = new Acceleration(double.NegativeInfinity);

        public static readonly Acceleration PositiveInfinity = new Acceleration(double.PositiveInfinity);

        public static readonly Acceleration Unit = new Acceleration(1);

        public static readonly Acceleration Zero = new Acceleration();

        #endregion

        #region Construction

        public Acceleration(double metersPerSquareSecond)
        {
            MetersPerSquareSecond = metersPerSquareSecond;
        }

        #endregion

        #region Methods

        public int CompareTo(Acceleration x)
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

        public bool Equals(Acceleration x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Acceleration)) return false;

            var y = (Acceleration)x;

            return this == y;
        }

        public override int GetHashCode() => MetersPerSquareSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Acceleration x, Acceleration y) => x.MetersPerSquareSecond == y.MetersPerSquareSecond;

        public static bool operator !=(Acceleration x, Acceleration y) => x.MetersPerSquareSecond != y.MetersPerSquareSecond;

        public static bool operator <(Acceleration x, Acceleration y) => x.MetersPerSquareSecond < y.MetersPerSquareSecond;

        public static bool operator <=(Acceleration x, Acceleration y) => x.MetersPerSquareSecond <= y.MetersPerSquareSecond;

        public static bool operator >(Acceleration x, Acceleration y) => x.MetersPerSquareSecond > y.MetersPerSquareSecond;

        public static bool operator >=(Acceleration x, Acceleration y) => x.MetersPerSquareSecond >= y.MetersPerSquareSecond;

        #endregion

        #region Operators

        public static Acceleration operator +(Acceleration x) => x;

        public static Acceleration operator +(Acceleration x, Acceleration y) => new Acceleration(x.MetersPerSquareSecond + y.MetersPerSquareSecond);

        public static Acceleration operator -(Acceleration x) => new Acceleration(-x.MetersPerSquareSecond);

        public static Acceleration operator -(Acceleration x, Acceleration y) => new Acceleration(x.MetersPerSquareSecond - y.MetersPerSquareSecond);

        public static Acceleration operator *(double x, Acceleration y) => new Acceleration(x * y.MetersPerSquareSecond);

        public static Acceleration operator *(Acceleration x, double y) => new Acceleration(x.MetersPerSquareSecond * y);

        public static Acceleration operator /(Acceleration x, double y) => new Acceleration(x.MetersPerSquareSecond / y);

        #endregion

        #region Operators (*)

        public static Jerk operator *(Acceleration x, Frequency y) => new Jerk(x.MetersPerSquareSecond * y.Hertz);

        public static Velocity operator *(Acceleration x, Time y) => new Velocity(x.MetersPerSquareSecond * y.Seconds);

        #endregion

        #region Operators (/)

        public static double operator /(Acceleration x, Acceleration y) => x.MetersPerSquareSecond / y.MetersPerSquareSecond;

        public static Velocity operator /(Acceleration x, Frequency y) => new Velocity(x.MetersPerSquareSecond / y.Hertz);

        public static Time operator /(Acceleration x, Jerk y) => new Time(x.MetersPerSquareSecond / y.MetersPerCubicSecond);

        public static Jerk operator /(Acceleration x, Time y) => new Jerk(x.MetersPerSquareSecond / y.Seconds);

        public static Frequency operator /(Acceleration x, Velocity y) => new Frequency(x.MetersPerSquareSecond / y.MetersPerSecond);

        #endregion

        #region Properties

        #region G

        public double G
        {
            get => MetersPerSquareSecond / 9.81;
            set => MetersPerSquareSecond = 9.81 * value;
        }

        #endregion

        #region MetersPerSquareSecond

        public double NanometersPerSquareSecond
        {
            get => MetersPerSquareSecond * 1e+9;
            set => MetersPerSquareSecond = 1e-9 * value;
        }

        public double MicrometersPerSquareSecond
        {
            get => MetersPerSquareSecond * 1e+6;
            set => MetersPerSquareSecond = 1e-6 * value;
        }

        public double MillimetersPerSquareSecond
        {
            get => MetersPerSquareSecond * 1e+3;
            set => MetersPerSquareSecond = 1e-3 * value;
        }

        public double CentimetersPerSquareSecond
        {
            get => MetersPerSquareSecond * 1e+2;
            set => MetersPerSquareSecond = 1e-2 * value;
        }

        public double DecimetersPerSquareSecond
        {
            get => MetersPerSquareSecond * 1e+1;
            set => MetersPerSquareSecond = 1e-1 * value;
        }

        public double MetersPerSquareSecond { get; set; }

        public double KilometersPerSquareSecond
        {
            get => MetersPerSquareSecond * 1e-3;
            set => MetersPerSquareSecond = 1e+3 * value;
        }

        #endregion

        #endregion
    }
}
