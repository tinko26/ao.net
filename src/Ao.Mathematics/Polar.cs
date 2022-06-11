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
    public struct Polar : IEquatable<Polar>
    {
        #region Construction

        public Polar(double radius, double azimuth)
        {
            Radius = radius;

            Azimuth = azimuth;
        }

        #endregion

        #region Methods

        public bool Equals(Polar x) => this == x;

        public Complex ToComplex() => new Complex(Radius * Math.Cos(Azimuth), Radius * Math.Sin(Azimuth));

        public Point2 ToPoint() => new Point2(Radius * Math.Cos(Azimuth), Radius * Math.Sin(Azimuth));

        public Vector2 ToVector() => new Vector2(Radius * Math.Cos(Azimuth), Radius * Math.Sin(Azimuth));

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Polar)) return false;

            var y = (Polar)x;

            return this == y;
        }

        public override int GetHashCode() =>
            Radius.GetHashCode() ^
            Azimuth.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Polar FromComplex(Complex complex) => complex.ToPolar();

        public static Polar FromPoint(Point2 point) => point.ToPolar();

        public static Polar FromVector(Vector2 vector) => vector.ToPolar();

        #endregion

        #region Operators

        public static bool operator ==(Polar a, Polar b) => a.Radius == b.Radius && a.Azimuth == b.Azimuth;

        public static bool operator !=(Polar a, Polar b) => a.Radius != b.Radius || a.Azimuth != b.Azimuth;

        #endregion

        #region Properties

        public double Azimuth { get; set; }

        public double Radius { get; set; }

        #endregion
    }
}
