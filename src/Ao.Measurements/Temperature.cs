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
    public struct Temperature :
        IComparable<Temperature>,
        IEquatable<Temperature>
    {
        #region Constants

        public static readonly Temperature Max = new Temperature(double.MaxValue);

        public static readonly Temperature Min = new Temperature(double.MinValue);

        public static readonly Temperature NegativeInfinity = new Temperature(double.NegativeInfinity);

        public static readonly Temperature PositiveInfinity = new Temperature(double.PositiveInfinity);

        public static readonly Temperature Unit = new Temperature(1);

        public static readonly Temperature Zero = new Temperature();

        #endregion

        #region Construction

        public Temperature(double kelvin)
        {
            Kelvin = kelvin;
        }

        #endregion

        #region Methods

        public int CompareTo(Temperature x)
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

        public bool Equals(Temperature x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Temperature)) return false;

            var y = (Temperature)x;

            return this == y;
        }

        public override int GetHashCode() => Kelvin.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Temperature x, Temperature y) => x.Kelvin == y.Kelvin;

        public static bool operator !=(Temperature x, Temperature y) => x.Kelvin != y.Kelvin;

        public static bool operator <(Temperature x, Temperature y) => x.Kelvin < y.Kelvin;

        public static bool operator <=(Temperature x, Temperature y) => x.Kelvin <= y.Kelvin;

        public static bool operator >(Temperature x, Temperature y) => x.Kelvin > y.Kelvin;

        public static bool operator >=(Temperature x, Temperature y) => x.Kelvin >= y.Kelvin;

        #endregion

        #region Operators

        public static Temperature operator +(Temperature x) => x;

        public static Temperature operator +(Temperature x, Temperature y) => new Temperature(x.Kelvin + y.Kelvin);

        public static Temperature operator -(Temperature x) => new Temperature(-x.Kelvin);

        public static Temperature operator -(Temperature x, Temperature y) => new Temperature(x.Kelvin - y.Kelvin);

        public static Temperature operator *(double x, Temperature y) => new Temperature(x * y.Kelvin);

        public static Temperature operator *(Temperature x, double y) => new Temperature(x.Kelvin * y);

        public static Temperature operator /(Temperature x, double y) => new Temperature(x.Kelvin / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(Temperature x, Temperature y) => x.Kelvin / y.Kelvin;

        #endregion

        #region Properties

        #region Celsius

        public double Celsius
        {
            get => Kelvin - 273.15;
            set => Kelvin = value + 273.15;
        }

        #endregion

        #region Fahrenheit

        public double Fahrenheit
        {
            get => Kelvin * 1.8 - 459.67;
            set => Kelvin = (value + 459.67) / 1.8;
        }

        #endregion

        #region Kelvin

        public double Kelvin { get; set; }

        #endregion

        #endregion
    }
}
