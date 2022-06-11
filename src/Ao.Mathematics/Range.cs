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

namespace Ao.Mathematics
{
    public struct Range : IEquatable<Range>
    {
        #region Construction

        public Range(double min, double max)
        {
            Min = min;
            Max = max;
        }

        #endregion

        #region Methods

        public bool Equals(Range x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Range)) return false;

            var y = (Range)x;

            return this == y;
        }

        public override int GetHashCode() =>
            Min.GetHashCode() ^
            Max.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(Range a, Range b) => a.Min == b.Min && a.Max == b.Max;

        public static bool operator !=(Range a, Range b) => a.Min != b.Min || a.Max != b.Max;

        #endregion

        #region Properties

        public Range Backward => (Min < Max) ? new Range(Max, Min) : this;

        public double Center => 0.5 * (Min + Max);

        public double Diameter => Math.Abs(Max - Min);

        public Range Forward => (Max < Min) ? new Range(Max, Min) : this;

        public bool IsBackward => Max < Min;

        public bool IsBounded => !double.IsInfinity(Min) && !double.IsInfinity(Max);

        public bool IsDegenerate => Min == Max;

        public bool IsForward => Min < Max;

        public bool IsHalfBounded => !double.IsInfinity(Min) ^ !double.IsInfinity(Max);

        public bool IsLeftBounded => !double.IsInfinity(Min);

        public bool IsProper => Min != Max;

        public bool IsRightBounded => !double.IsInfinity(Max);

        public double Max { get; set; }

        public double Min { get; set; }

        public double Radius => 0.5 * Math.Abs(Max - Min);

        public Range Reversed => new Range(Max, Min);

        #endregion
    }
}
