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
    public struct Spherical : IEquatable<Spherical>
    {
        #region Construction

        public Spherical(double radius, double azimuth, double inclination)
        {
            Radius = radius;

            Azimuth = azimuth;

            Inclination = inclination;
        }

        #endregion

        #region Methods

        public bool Equals(Spherical x) => this == x;

        public Point3 ToPoint()
        {
            var ca = Math.Cos(Azimuth);
            var sa = Math.Sin(Azimuth);

            var ci = Math.Cos(Inclination);
            var si = Math.Sin(Inclination);

            var x = Radius * si * ca;
            var y = Radius * si * sa;
            var z = Radius * ci;

            return new Point3(x, y, z);
        }

        public Vector3 ToVector()
        {
            var ca = Math.Cos(Azimuth);
            var sa = Math.Sin(Azimuth);

            var ci = Math.Cos(Inclination);
            var si = Math.Sin(Inclination);

            var x = Radius * si * ca;
            var y = Radius * si * sa;
            var z = Radius * ci;

            return new Vector3(x, y, z);
        }

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Spherical)) return false;

            var y = (Spherical)x;

            return this == y;
        }

        public override int GetHashCode() =>
            Radius.GetHashCode() ^
            Azimuth.GetHashCode() ^
            Inclination.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Spherical FromPoint(Point3 point) => point.ToSpherical();

        public static Spherical FromVector(Vector3 vector) => vector.ToSpherical();

        #endregion

        #region Operators

        public static bool operator ==(Spherical a, Spherical b) => a.Radius == b.Radius && a.Azimuth == b.Azimuth && a.Inclination == b.Inclination;

        public static bool operator !=(Spherical a, Spherical b) => a.Radius != b.Radius || a.Azimuth != b.Azimuth || a.Inclination != b.Inclination;

        #endregion

        #region Properties

        public double Azimuth { get; set; }

        public double Inclination { get; set; }

        public double Radius { get; set; }

        #endregion
    }
}
