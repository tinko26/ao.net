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

using Ao.Measurements;
using System;

namespace Ao.Geodesy
{
    public struct GeographicPosition2 : IEquatable<GeographicPosition2>
    {
        #region Construction

        public GeographicPosition2(Angle latitude, Angle longitude)
        {
            Latitude = latitude;

            Longitude = longitude;
        }

        #endregion

        #region Methods

        public bool Equals(GeographicPosition2 x) => this == x;

        #endregion

        #region Methods (Override)

        public override bool Equals(object x)
        {
            if (x == null) return false;

            if (!(x is GeographicPosition2)) return false;

            var y = (GeographicPosition2)x;

            return this == y;
        }

        public override int GetHashCode() =>
            Latitude.GetHashCode() ^
            Longitude.GetHashCode();

        #endregion

        #region Operators

        public static bool operator ==(GeographicPosition2 x, GeographicPosition2 y) => x.Latitude == y.Latitude && x.Longitude == y.Longitude;

        public static bool operator !=(GeographicPosition2 x, GeographicPosition2 y) => x.Latitude != y.Latitude || x.Longitude != y.Longitude;

        #endregion

        #region Properties

        public bool IsAntimeridian => IsEasternAntimeridian || IsWesternAntimeridian;

        public bool IsEasternAntimeridian => Longitude == GeographicCoordinates.EasternAntimeridian;

        public bool IsEasternHemisphere => GeographicCoordinates.PrimeMeridian < Longitude && Longitude <= GeographicCoordinates.EasternAntimeridian;

        public bool IsEquator => Latitude == GeographicCoordinates.Equator;

        public bool IsNorthernHemisphere => GeographicCoordinates.Equator < Latitude && Latitude <= GeographicCoordinates.NorthPole;

        public bool IsNorthPole => Latitude == GeographicCoordinates.NorthPole;

        public bool IsPole => IsNorthPole || IsSouthPole;

        public bool IsPrimeMeridian => Longitude == GeographicCoordinates.PrimeMeridian;

        public bool IsSouthernHemisphere => GeographicCoordinates.Equator > Latitude && Latitude >= GeographicCoordinates.SouthPole;

        public bool IsSouthPole => Latitude == GeographicCoordinates.SouthPole;

        public bool IsWesternAntimeridian => Longitude == GeographicCoordinates.WesternAntimeridian;

        public bool IsWesternHemisphere => GeographicCoordinates.PrimeMeridian > Longitude && Longitude >= GeographicCoordinates.WesternAntimeridian;

        public Angle Latitude { get; set; }

        public Angle Longitude { get; set; }

        #endregion
    }
}
