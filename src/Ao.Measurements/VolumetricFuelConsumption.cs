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
    public struct VolumetricFuelConsumption :
        IComparable<VolumetricFuelConsumption>,
        IEquatable<VolumetricFuelConsumption>
    {
        #region Constants

        public static readonly VolumetricFuelConsumption Max = new VolumetricFuelConsumption(double.MaxValue);

        public static readonly VolumetricFuelConsumption Min = new VolumetricFuelConsumption(double.MinValue);

        public static readonly VolumetricFuelConsumption NegativeInfinity = new VolumetricFuelConsumption(double.NegativeInfinity);

        public static readonly VolumetricFuelConsumption PositiveInfinity = new VolumetricFuelConsumption(double.PositiveInfinity);

        public static readonly VolumetricFuelConsumption Unit = new VolumetricFuelConsumption(1);

        public static readonly VolumetricFuelConsumption Zero = new VolumetricFuelConsumption();

        #endregion

        #region Construction

        public VolumetricFuelConsumption(double cubicMetersPerMeter)
        {
            CubicMetersPerMeter = cubicMetersPerMeter;
        }

        #endregion

        #region Methods

        public int CompareTo(VolumetricFuelConsumption x)
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

        public bool Equals(VolumetricFuelConsumption x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is VolumetricFuelConsumption)) return false;

            var y = (VolumetricFuelConsumption)x;

            return this == y;
        }

        public override int GetHashCode() => CubicMetersPerMeter.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(VolumetricFuelConsumption x, VolumetricFuelConsumption y) => x.CubicMetersPerMeter == y.CubicMetersPerMeter;

        public static bool operator !=(VolumetricFuelConsumption x, VolumetricFuelConsumption y) => x.CubicMetersPerMeter != y.CubicMetersPerMeter;

        public static bool operator <(VolumetricFuelConsumption x, VolumetricFuelConsumption y) => x.CubicMetersPerMeter < y.CubicMetersPerMeter;

        public static bool operator <=(VolumetricFuelConsumption x, VolumetricFuelConsumption y) => x.CubicMetersPerMeter <= y.CubicMetersPerMeter;

        public static bool operator >(VolumetricFuelConsumption x, VolumetricFuelConsumption y) => x.CubicMetersPerMeter > y.CubicMetersPerMeter;

        public static bool operator >=(VolumetricFuelConsumption x, VolumetricFuelConsumption y) => x.CubicMetersPerMeter >= y.CubicMetersPerMeter;

        #endregion

        #region Operators

        public static VolumetricFuelConsumption operator +(VolumetricFuelConsumption x) => x;

        public static VolumetricFuelConsumption operator +(VolumetricFuelConsumption x, VolumetricFuelConsumption y) => new VolumetricFuelConsumption(x.CubicMetersPerMeter + y.CubicMetersPerMeter);

        public static VolumetricFuelConsumption operator -(VolumetricFuelConsumption x) => new VolumetricFuelConsumption(-x.CubicMetersPerMeter);

        public static VolumetricFuelConsumption operator -(VolumetricFuelConsumption x, VolumetricFuelConsumption y) => new VolumetricFuelConsumption(x.CubicMetersPerMeter - y.CubicMetersPerMeter);

        public static VolumetricFuelConsumption operator *(double x, VolumetricFuelConsumption y) => new VolumetricFuelConsumption(x * y.CubicMetersPerMeter);

        public static VolumetricFuelConsumption operator *(VolumetricFuelConsumption x, double y) => new VolumetricFuelConsumption(x.CubicMetersPerMeter * y);

        public static VolumetricFuelConsumption operator /(VolumetricFuelConsumption x, double y) => new VolumetricFuelConsumption(x.CubicMetersPerMeter / y);

        #endregion

        #region Operators (*)

        #endregion

        #region Operators (/)

        public static double operator /(VolumetricFuelConsumption x, VolumetricFuelConsumption y) => x.CubicMetersPerMeter / y.CubicMetersPerMeter;

        #endregion

        #region Properties

        #region CubicMetersPerMeter

        public double CubicMetersPerMeter { get; set; }

        #endregion

        #endregion
    }
}
