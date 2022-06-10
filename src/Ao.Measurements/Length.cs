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
    public struct Length :
        IComparable<Length>,
        IEquatable<Length>
    {
        #region Constants

        public static readonly Length Max = new Length(double.MaxValue);

        public static readonly Length Min = new Length(double.MinValue);

        public static readonly Length NegativeInfinity = new Length(double.NegativeInfinity);

        public static readonly Length PositiveInfinity = new Length(double.PositiveInfinity);

        public static readonly Length Unit = new Length(1);

        public static readonly Length Zero = new Length();

        #endregion

        #region Construction

        public Length(double meters)
        {
            Meters = meters;
        }

        #endregion

        #region Methods

        public int CompareTo(Length x)
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

        public bool Equals(Length x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Length)) return false;

            var y = (Length)x;

            return this == y;
        }

        public override int GetHashCode() => Meters.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Length x, Length y) => x.Meters == y.Meters;

        public static bool operator !=(Length x, Length y) => x.Meters != y.Meters;

        public static bool operator <(Length x, Length y) => x.Meters < y.Meters;

        public static bool operator <=(Length x, Length y) => x.Meters <= y.Meters;

        public static bool operator >(Length x, Length y) => x.Meters > y.Meters;

        public static bool operator >=(Length x, Length y) => x.Meters >= y.Meters;

        #endregion

        #region Operators

        public static Length operator +(Length x) => x;

        public static Length operator +(Length x, Length y) => new Length(x.Meters + y.Meters);

        public static Length operator -(Length x) => new Length(-x.Meters);

        public static Length operator -(Length x, Length y) => new Length(x.Meters - y.Meters);

        public static Length operator *(double x, Length y) => new Length(x * y.Meters);

        public static Length operator *(Length x, double y) => new Length(x.Meters * y);

        public static Length operator /(Length x, double y) => new Length(x.Meters / y);

        #endregion

        #region Operators (*)

        public static Volume operator *(Length x, Area y) => new Volume(x.Meters * y.SquareMeters);

        public static Velocity operator *(Length x, Frequency y) => new Velocity(x.Meters * y.Hertz);

        public static Area operator *(Length x, Length y) => new Area(x.Meters * y.Meters);

        #endregion

        #region Operators (/)

        public static double operator /(Length x, Length y) => x.Meters / y.Meters;

        public static Velocity operator /(Length x, Time y) => new Velocity(x.Meters / y.Seconds);

        public static Time operator /(Length x, Velocity y) => new Time(x.Meters / y.MetersPerSecond);

        #endregion

        #region Properties

        #region Meters

        public double Nanometers
        {
            get => Meters * 1e+9;
            set => Meters = value * 1e-9;
        }

        public double Micrometers
        {
            get => Meters * 1e+6;
            set => Meters = value * 1e-6;
        }

        public double Millimeters
        {
            get => Meters * 1e+3;
            set => Meters = value * 1e-3;
        }

        public double Centimeters
        {
            get => Meters * 1e+2;
            set => Meters = value * 1e-2;
        }

        public double Decimeters
        {
            get => Meters * 1e+1;
            set => Meters = value * 1e-1;
        }

        public double Meters { get; set; }

        public double Kilometers
        {
            get => Meters * 1e-3;
            set => Meters = value * 1e+3;
        }

        #endregion

        #endregion
    }
}
