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
    public sealed class SpheroidalEarth
    {
        #region Construction

        public SpheroidalEarth(Length equatorialRadius, Length polarRadius)
        {
            EquatorialRadius = equatorialRadius;

            PolarRadius = polarRadius;

            Flattening = 1.0 - polarRadius / equatorialRadius;
        }

        #endregion

        #region Methods

        public Angle Bearing(GeographicPosition2 G1, GeographicPosition2 G2)
        {
            var f = Flattening;

            var L = G2.Longitude.Radians - G1.Longitude.Radians;

            var tanU1 = (1 - f) * Math.Tan(G1.Latitude.Radians);
            var tanU2 = (1 - f) * Math.Tan(G2.Latitude.Radians);

            var cosU1 = 1.0 / Math.Sqrt(1.0 + tanU1 * tanU1);
            var cosU2 = 1.0 / Math.Sqrt(1.0 + tanU2 * tanU2);

            var sinU1 = tanU1 * cosU1;
            var sinU2 = tanU2 * cosU2;

            var l = L;

            var dl = 0.0;

            var dlThreshold = 1e-12;

            var n = 0;

            var nMax = 100;

            double cos2a;

            double cos2om;

            double cosl;

            double coso;

            double sinl;

            double sino;

            double o;

            do
            {
                n++;

                sinl = Math.Sin(l);

                cosl = Math.Cos(l);

                var t1 = cosU2 * sinl;

                var t2 = cosU1 * sinU2 - sinU1 * cosU2 * cosl;

                sino = Math.Sqrt(t1 * t1 + t2 * t2);

                coso = sinU1 * sinU2 + cosU1 * cosU2 * cosl;

                o = Math.Atan2(sino, coso);

                var sina = cosU1 * cosU2 * sinl / sino;

                if (double.IsNaN(sina) || double.IsInfinity(sina))
                {
                    sina = 1;
                }

                cos2a = 1.0 - sina * sina;

                cos2om = coso - 2.0 * sinU1 * sinU2 / cos2a;

                if (double.IsNaN(cos2om) || double.IsInfinity(cos2om))
                {
                    cos2om = 0;
                }

                var C = f / 16.0 * cos2a * (4 + f * (4 - 3 * cos2a));

                var lPrev = l;

                l = L + (1 - C) * f * sina * (o + C * sino * (cos2om + C * coso * (-1 + 2 * cos2om * cos2om)));

                dl = Math.Abs(l - lPrev);
            }
            while (dl > dlThreshold && n < nMax);

            var u2 = cos2a * (EquatorialRadius * EquatorialRadius - PolarRadius * PolarRadius) / (PolarRadius * PolarRadius);

            var A = 1 + u2 / 16384 * (4096 + u2 * (-768 + u2 * (320 - 175 * u2)));

            var B = u2 / 1024 * (256 + u2 * (-128 + u2 * (74 - 47 * u2)));

            var @do =
                B * sino * (cos2om + B / 4 * (coso * (-1 + 2 * cos2om * cos2om)
                - B / 6 * cos2om * (-3 + 4 * sino * sino) * (-3 + 4 * cos2om * cos2om)));

            sinl = Math.Sin(l);

            cosl = Math.Cos(l);

            var bs = Math.Atan2(cosU2 * sinl, +cosU1 * sinU2 - sinU1 * cosU2 * cosl);

            var be = Math.Atan2(cosU1 * sinl, -sinU1 * cosU2 + cosU1 * sinU2 * cosl);

            if (bs < 0)
            {
                return new Angle { Radians = bs + 2.0 * Math.PI };
            }

            else
            {
                return new Angle { Radians = bs };
            }
        }

        public Length EuclideanDistance(GeographicPosition2 G1, GeographicPosition2 G2) => new Length((Point(G2) - Point(G1)).Length);

        public Length EuclideanDistance(GeographicPosition2 G1, GeographicPosition3 G2) => new Length((Point(G2) - Point(G1)).Length);

        public Length EuclideanDistance(GeographicPosition3 G1, GeographicPosition2 G2) => new Length((Point(G2) - Point(G1)).Length);

        public Length EuclideanDistance(GeographicPosition3 G1, GeographicPosition3 G2) => new Length((Point(G2) - Point(G1)).Length);

        public Length GreatCircleDistance(GeographicPosition2 G1, GeographicPosition2 G2) => GreatCircleDistance(G1, G2, Length.Zero);

        public Length GreatCircleDistance(GeographicPosition2 G1, GeographicPosition2 G2, Length Altitude)
        {
            var RE = EquatorialRadius.Meters + Altitude.Meters;

            var RP = PolarRadius.Meters + Altitude.Meters;

            var f = 1.0 - RP / RE;

            var L = G2.Longitude.Radians - G1.Longitude.Radians;

            var tanU1 = (1 - f) * Math.Tan(G1.Latitude.Radians);
            var tanU2 = (1 - f) * Math.Tan(G2.Latitude.Radians);

            var cosU1 = 1.0 / Math.Sqrt(1.0 + tanU1 * tanU1);
            var cosU2 = 1.0 / Math.Sqrt(1.0 + tanU2 * tanU2);

            var sinU1 = tanU1 * cosU1;
            var sinU2 = tanU2 * cosU2;

            var l = L;

            var dl = 0.0;

            var dlThreshold = 1e-12;

            var n = 0;

            var nMax = 100;

            double cos2a;

            double cos2om;

            double cosl;

            double coso;

            double sinl;

            double sino;

            double o;

            do
            {
                n++;

                sinl = Math.Sin(l);

                cosl = Math.Cos(l);

                var t1 = cosU2 * sinl;

                var t2 = cosU1 * sinU2 - sinU1 * cosU2 * cosl;

                sino = Math.Sqrt(t1 * t1 + t2 * t2);

                coso = sinU1 * sinU2 + cosU1 * cosU2 * cosl;

                o = Math.Atan2(sino, coso);

                var sina = cosU1 * cosU2 * sinl / sino;

                if (double.IsNaN(sina) || double.IsInfinity(sina))
                {
                    sina = 1;
                }

                cos2a = 1.0 - sina * sina;

                cos2om = coso - 2.0 * sinU1 * sinU2 / cos2a;

                if (double.IsNaN(cos2om) || double.IsInfinity(cos2om))
                {
                    cos2om = 0;
                }

                var C = f / 16.0 * cos2a * (4 + f * (4 - 3 * cos2a));

                var lPrev = l;

                l = L + (1 - C) * f * sina * (o + C * sino * (cos2om + C * coso * (-1 + 2 * cos2om * cos2om)));

                dl = Math.Abs(l - lPrev);
            }
            while (dl > dlThreshold && n < nMax);

            var u2 = cos2a * (RE * RE - RP * RP) / (RP * RP);

            var A = 1 + u2 / 16384 * (4096 + u2 * (-768 + u2 * (320 - 175 * u2)));

            var B = u2 / 1024 * (256 + u2 * (-128 + u2 * (74 - 47 * u2)));

            var @do =
                B * sino * (cos2om + B / 4 * (coso * (-1 + 2 * cos2om * cos2om)
                - B / 6 * cos2om * (-3 + 4 * sino * sino) * (-3 + 4 * cos2om * cos2om)));

            return new Length(RP * A * (o - @do));
        }

        public Point3 Point(GeographicPosition2 G)
        {
            var RE = EquatorialRadius.Meters;

            var RP = PolarRadius.Meters;

            var LA = G.Latitude.Radians;

            var CA = Math.Cos(LA);
            var SA = Math.Sin(LA);

            var LO = G.Longitude.Radians;

            var CO = Math.Cos(LO);
            var SO = Math.Sin(LO);

            var X = RE * CA * CO;
            var Y = RE * CA * SO;

            var Z = RP * SA;

            return new Point3(X, Y, Z);
        }

        public Point3 Point(GeographicPosition3 G)
        {
            var T1 = Point(new GeographicPosition2(G.Latitude, G.Longitude));

            var T2 = T1 - Point3.Origin;

            var T3 = T2.Length;

            var T4 = G.Altitude.Meters;

            var T5 = (T3 + T4) / T3;

            return Point3.Origin + T5 * T2;
        }

        #endregion

        #region Properties

        public Length EquatorialRadius { get; }

        public double Flattening { get; }

        public Length PolarRadius { get; }

        #endregion
    }
}
