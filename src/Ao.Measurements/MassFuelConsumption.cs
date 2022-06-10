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
    public struct MassFuelConsumption :
        IComparable<MassFuelConsumption>,
        IEquatable<MassFuelConsumption>
    {
        #region Constants

        public static readonly MassFuelConsumption Max = new MassFuelConsumption(double.MaxValue);

        public static readonly MassFuelConsumption Min = new MassFuelConsumption(double.MinValue);

        public static readonly MassFuelConsumption NegativeInfinity = new MassFuelConsumption(double.NegativeInfinity);

        public static readonly MassFuelConsumption PositiveInfinity = new MassFuelConsumption(double.PositiveInfinity);

        public static readonly MassFuelConsumption Unit = new MassFuelConsumption(1);

        public static readonly MassFuelConsumption Zero = new MassFuelConsumption();

        #endregion

        #region Construction

        public MassFuelConsumption(double kilogramsPerMeter)
        {
            KilogramsPerMeter = kilogramsPerMeter;
        }

        #endregion

        #region Methods

        public int CompareTo(MassFuelConsumption x)
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

        public bool Equals(MassFuelConsumption x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is MassFuelConsumption)) return false;

            var y = (MassFuelConsumption)x;

            return this == y;
        }

        public override int GetHashCode() => KilogramsPerMeter.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(MassFuelConsumption x, MassFuelConsumption y) => x.KilogramsPerMeter == y.KilogramsPerMeter;

        public static bool operator !=(MassFuelConsumption x, MassFuelConsumption y) => x.KilogramsPerMeter != y.KilogramsPerMeter;

        public static bool operator <(MassFuelConsumption x, MassFuelConsumption y) => x.KilogramsPerMeter < y.KilogramsPerMeter;

        public static bool operator <=(MassFuelConsumption x, MassFuelConsumption y) => x.KilogramsPerMeter <= y.KilogramsPerMeter;

        public static bool operator >(MassFuelConsumption x, MassFuelConsumption y) => x.KilogramsPerMeter > y.KilogramsPerMeter;

        public static bool operator >=(MassFuelConsumption x, MassFuelConsumption y) => x.KilogramsPerMeter >= y.KilogramsPerMeter;

        #endregion

        #region Operators

        public static MassFuelConsumption operator +(MassFuelConsumption x) => x;

        public static MassFuelConsumption operator +(MassFuelConsumption x, MassFuelConsumption y) => new MassFuelConsumption(x.KilogramsPerMeter + y.KilogramsPerMeter);

        public static MassFuelConsumption operator -(MassFuelConsumption x) => new MassFuelConsumption(-x.KilogramsPerMeter);

        public static MassFuelConsumption operator -(MassFuelConsumption x, MassFuelConsumption y) => new MassFuelConsumption(x.KilogramsPerMeter - y.KilogramsPerMeter);

        public static MassFuelConsumption operator *(double x, MassFuelConsumption y) => new MassFuelConsumption(x * y.KilogramsPerMeter);

        public static MassFuelConsumption operator *(MassFuelConsumption x, double y) => new MassFuelConsumption(x.KilogramsPerMeter * y);

        public static MassFuelConsumption operator /(MassFuelConsumption x, double y) => new MassFuelConsumption(x.KilogramsPerMeter / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(MassFuelConsumption x, MassFuelConsumption y) => x.KilogramsPerMeter / y.KilogramsPerMeter;

        #endregion

        #region Properties

        #region KilogramsPerKilometer

        public double GramsPerKilometer
        {
            get => KilogramsPerMeter * 1e+6;
            set => KilogramsPerMeter = value * 1e-6;
        }

        public double KilogramsPerKilometer
        {
            get => KilogramsPerMeter * 1e+3;
            set => KilogramsPerMeter = value * 1e-3;
        }

        #endregion

        #region KilogramsPerMeter

        public double GramsPerMeter
        {
            get => KilogramsPerMeter * 1e+3;
            set => KilogramsPerMeter = value * 1e-3;
        }

        public double KilogramsPerMeter { get; set; }

        #endregion

        #endregion
    }
}
