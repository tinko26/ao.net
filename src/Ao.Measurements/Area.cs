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
    public struct Area :
        IComparable<Area>,
        IEquatable<Area>
    {
        #region Constants

        public static readonly Area Max = new Area(double.MaxValue);

        public static readonly Area Min = new Area(double.MinValue);

        public static readonly Area NegativeInfinity = new Area(double.NegativeInfinity);

        public static readonly Area PositiveInfinity = new Area(double.PositiveInfinity);

        public static readonly Area Unit = new Area(1);

        public static readonly Area Zero = new Area();

        #endregion

        #region Construction

        public Area(double squareMeters)
        {
            SquareMeters = squareMeters;
        }

        #endregion

        #region Methods

        public int CompareTo(Area x)
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

        public bool Equals(Area x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Area)) return false;

            var y = (Area)x;

            return this == y;
        }

        public override int GetHashCode() => SquareMeters.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Area x, Area y) => x.SquareMeters == y.SquareMeters;

        public static bool operator !=(Area x, Area y) => x.SquareMeters != y.SquareMeters;

        public static bool operator <(Area x, Area y) => x.SquareMeters < y.SquareMeters;

        public static bool operator <=(Area x, Area y) => x.SquareMeters <= y.SquareMeters;

        public static bool operator >(Area x, Area y) => x.SquareMeters > y.SquareMeters;

        public static bool operator >=(Area x, Area y) => x.SquareMeters >= y.SquareMeters;

        #endregion

        #region Operators

        public static Area operator +(Area x) => x;

        public static Area operator +(Area x, Area y) => new Area(x.SquareMeters + y.SquareMeters);

        public static Area operator -(Area x) => new Area(-x.SquareMeters);

        public static Area operator -(Area x, Area y) => new Area(x.SquareMeters - y.SquareMeters);

        public static Area operator *(double x, Area y) => new Area(x * y.SquareMeters);

        public static Area operator *(Area x, double y) => new Area(x.SquareMeters * y);

        public static Area operator /(Area x, double y) => new Area(x.SquareMeters / y);

        #endregion

        #region Operators (*)

        public static Volume operator *(Area x, Length y) => new Volume(x.SquareMeters * y.Meters);

        #endregion

        #region Operators (/)

        public static double operator /(Area x, Area y) => x.SquareMeters / y.SquareMeters;

        public static Length operator /(Area x, Length y) => new Length(x.SquareMeters / y.Meters);

        #endregion

        #region Properties

        #region Ares

        public double Ares
        {
            get => SquareMeters * 10e-2;
            set => SquareMeters = value * 10e+2;
        }

        #endregion

        #region Hectares

        public double Hectares
        {
            get => SquareMeters * 10e-4;
            set => SquareMeters = value * 10e+4;
        }

        #endregion

        #region SquareMeters

        public double SquareNanometers
        {
            get => SquareMeters * 1e+18;
            set => SquareMeters = value * 1e-18;
        }

        public double SquareMicrometers
        {
            get => SquareMeters * 1e+12;
            set => SquareMeters = value * 1e-12;
        }

        public double SquareMillimeters
        {
            get => SquareMeters * 1e+6;
            set => SquareMeters = value * 1e-6;
        }

        public double SquareCentimeters
        {
            get => SquareMeters * 1e+4;
            set => SquareMeters = value * 1e-4;
        }

        public double SquareDecimeters
        {
            get => SquareMeters * 1e+2;
            set => SquareMeters = value * 1e-2;
        }

        public double SquareMeters { get; set; }

        public double SquareKilometers
        {
            get => SquareMeters * 1e-6;
            set => SquareMeters = value * 1e+6;
        }

        #endregion

        #endregion
    }
}
