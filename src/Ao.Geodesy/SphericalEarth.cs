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

using Ao.Mathematics;
using Ao.Measurements;
using System;

namespace Ao.Geodesy
{
    public sealed class SphericalEarth
    {
        #region Construction

        public SphericalEarth(Length radius) => Radius = radius;

        #endregion

        #region Methods

        public Angle Bearing(GeographicPosition2 G1, GeographicPosition2 G2)
        {
            var LA1 = G1.Latitude.Radians;
            var LA2 = G2.Latitude.Radians;

            var CA1 = Math.Cos(LA1);
            var CA2 = Math.Cos(LA2);
            var SA1 = Math.Sin(LA1);
            var SA2 = Math.Sin(LA2);

            var LO1 = G1.Longitude.Radians;
            var LO2 = G2.Longitude.Radians;

            var LOD = LO2 - LO1;

            var COD = Math.Cos(LOD);
            var SOD = Math.Sin(LOD);

            var T1 = CA1 * SA2 - CA2 * SA1 * COD;

            var T2 = SOD * CA2;

            var T3 = Math.Atan2(T2, T1);

            if (T3 < 0)
            {
                return new Angle
                {
                    Radians = T3 + 2.0 * Math.PI
                };
            }

            else
            {
                return new Angle
                {
                    Radians = T3
                };
            }
        }

        public Length EuclideanDistance(GeographicPosition2 G1, GeographicPosition2 G2) => new Length((Point(G2) - Point(G1)).Length);

        public Length EuclideanDistance(GeographicPosition2 G1, GeographicPosition3 G2) => new Length((Point(G2) - Point(G1)).Length);

        public Length EuclideanDistance(GeographicPosition3 G1, GeographicPosition2 G2) => new Length((Point(G2) - Point(G1)).Length);

        public Length EuclideanDistance(GeographicPosition3 G1, GeographicPosition3 G2) => new Length((Point(G2) - Point(G1)).Length);

        public Length GreatCircleDistance(GeographicPosition2 G1, GeographicPosition2 G2) => GreatCircleDistance(G1, G2, Length.Zero);

        public Length GreatCircleDistance(GeographicPosition2 G1, GeographicPosition2 G2, Length Altitude)
        {
            var R = Radius + Altitude;

            var LA1 = G1.Latitude.Radians;
            var LA2 = G2.Latitude.Radians;

            var LO1 = G1.Longitude.Radians;
            var LO2 = G2.Longitude.Radians;

            var LAD = LA2 - LA1;
            var LOD = LO2 - LO1;

            var SAD = Math.Sin(0.5 * LAD);
            var SOD = Math.Sin(0.5 * LOD);

            var A = SAD * SAD + Math.Cos(LA1) * Math.Cos(LA2) * SOD * SOD;

            var C = 2.0 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1 - A));

            return R * C;
        }

        public Point3 Point(GeographicPosition2 G)
        {
            var R = Radius.Meters;

            var LA = G.Latitude.Radians;

            var LO = G.Longitude.Radians;

            var CA = Math.Cos(LA);
            var CO = Math.Cos(LO);

            var SA = Math.Sin(LA);
            var SO = Math.Sin(LO);

            var X = R * CA * CO;
            var Y = R * CA * SO;
            var Z = R * SA;

            return new Point3(X, Y, Z);
        }

        public Point3 Point(GeographicPosition3 G)
        {
            var R = Radius.Meters + G.Altitude.Meters;

            var LA = G.Latitude.Radians;

            var LO = G.Longitude.Radians;

            var CA = Math.Cos(LA);
            var CO = Math.Cos(LO);

            var SA = Math.Sin(LA);
            var SO = Math.Sin(LO);

            var X = R * CA * CO;
            var Y = R * CA * SO;
            var Z = R * SA;

            return new Point3(X, Y, Z);
        }

        #endregion

        #region Properties

        public Length Radius { get; }

        #endregion
    }
}
