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
    public struct Cylindrical : IEquatable<Cylindrical>
    {
        #region Construction

        public Cylindrical(double radius, double azimuth, double z)
        {
            Radius = radius;

            Azimuth = azimuth;

            Z = z;
        }

        #endregion

        #region Methods

        public bool Equals(Cylindrical x) => this == x;

        public Point3 ToPoint() => new Point3(Radius * Math.Cos(Azimuth), Radius * Math.Sin(Azimuth), Z);

        public Vector3 ToVector() => new Vector3(Radius * Math.Cos(Azimuth), Radius * Math.Sin(Azimuth), Z);

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is Cylindrical)) return false;

            var y = (Cylindrical)x;

            return this == y;
        }

        public override int GetHashCode() =>
            Radius.GetHashCode() ^
            Azimuth.GetHashCode() ^
            Z.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Cylindrical FromPoint(Point3 point) => point.ToCylindrical();

        public static Cylindrical FromVector(Vector3 vector) => vector.ToCylindrical();

        #endregion

        #region Operators

        public static bool operator ==(Cylindrical a, Cylindrical b) => a.Radius == b.Radius && a.Azimuth == b.Azimuth && a.Z == b.Z;

        public static bool operator !=(Cylindrical a, Cylindrical b) => a.Radius != b.Radius || a.Azimuth != b.Azimuth || a.Z != b.Z;

        #endregion

        #region Properties

        public double Azimuth { get; set; }

        public double Radius { get; set; }

        public double Z { get; set; }

        #endregion
    }
}
