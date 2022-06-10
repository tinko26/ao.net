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
    public struct Jerk :
        IComparable<Jerk>,
        IEquatable<Jerk>
    {
        #region Constants

        public static readonly Jerk Max = new Jerk(double.MaxValue);

        public static readonly Jerk Min = new Jerk(double.MinValue);

        public static readonly Jerk NegativeInfinity = new Jerk(double.NegativeInfinity);

        public static readonly Jerk PositiveInfinity = new Jerk(double.PositiveInfinity);

        public static readonly Jerk Unit = new Jerk(1);

        public static readonly Jerk Zero = new Jerk();

        #endregion

        #region Construction

        public Jerk(double metersPerCubicSecond)
        {
            MetersPerCubicSecond = metersPerCubicSecond;
        }

        #endregion

        #region Methods

        public int CompareTo(Jerk x)
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

        public bool Equals(Jerk x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Jerk)) return false;

            var y = (Jerk)x;

            return this == y;
        }

        public override int GetHashCode() => MetersPerCubicSecond.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Jerk x, Jerk y) => x.MetersPerCubicSecond == y.MetersPerCubicSecond;

        public static bool operator !=(Jerk x, Jerk y) => x.MetersPerCubicSecond != y.MetersPerCubicSecond;

        public static bool operator <(Jerk x, Jerk y) => x.MetersPerCubicSecond < y.MetersPerCubicSecond;

        public static bool operator <=(Jerk x, Jerk y) => x.MetersPerCubicSecond <= y.MetersPerCubicSecond;

        public static bool operator >(Jerk x, Jerk y) => x.MetersPerCubicSecond > y.MetersPerCubicSecond;

        public static bool operator >=(Jerk x, Jerk y) => x.MetersPerCubicSecond >= y.MetersPerCubicSecond;

        #endregion

        #region Operators

        public static Jerk operator +(Jerk x) => x;

        public static Jerk operator +(Jerk x, Jerk y) => new Jerk(x.MetersPerCubicSecond + y.MetersPerCubicSecond);

        public static Jerk operator -(Jerk x) => new Jerk(-x.MetersPerCubicSecond);

        public static Jerk operator -(Jerk x, Jerk y) => new Jerk(x.MetersPerCubicSecond - y.MetersPerCubicSecond);

        public static Jerk operator *(double x, Jerk y) => new Jerk(x * y.MetersPerCubicSecond);

        public static Jerk operator *(Jerk x, double y) => new Jerk(x.MetersPerCubicSecond * y);

        public static Jerk operator /(Jerk x, double y) => new Jerk(x.MetersPerCubicSecond / y);

        #endregion

        #region Operators (*)

        public static Acceleration operator *(Jerk x, Time y) => new Acceleration(x.MetersPerCubicSecond * y.Seconds);

        #endregion

        #region Operators (/)

        public static Frequency operator /(Jerk x, Acceleration y) => new Frequency(x.MetersPerCubicSecond / y.MetersPerSquareSecond);

        public static Acceleration operator /(Jerk x, Frequency y) => new Acceleration(x.MetersPerCubicSecond / y.Hertz);

        public static double operator /(Jerk x, Jerk y) => x.MetersPerCubicSecond / y.MetersPerCubicSecond;

        #endregion

        #region Properties

        #region MetersPerCubicSecond

        public double NanometersPerCubicSecond
        {
            get => MetersPerCubicSecond * 1e+9;
            set => MetersPerCubicSecond = value * 1e-9;
        }

        public double MicrometersPerCubicSecond
        {
            get => MetersPerCubicSecond * 1e+6;
            set => MetersPerCubicSecond = value * 1e-6;
        }

        public double MillimetersPerCubicSecond
        {
            get => MetersPerCubicSecond * 1e+3;
            set => MetersPerCubicSecond = value * 1e-3;
        }

        public double CentimetersPerCubicSecond
        {
            get => MetersPerCubicSecond * 1e+2;
            set => MetersPerCubicSecond = value * 1e-2;
        }

        public double DecimetersPerCubicSecond
        {
            get => MetersPerCubicSecond * 1e+1;
            set => MetersPerCubicSecond = value * 1e-1;
        }

        public double MetersPerCubicSecond { get; set; }

        public double KilometersPerCubicSecond
        {
            get => MetersPerCubicSecond * 1e-3;
            set => MetersPerCubicSecond = value * 1e+3;
        }

        #endregion

        #endregion
    }
}
