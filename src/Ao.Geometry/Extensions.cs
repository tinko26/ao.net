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

namespace Ao.Geometry
{
	public static class Extensions
	{
        #region Point2

        public static double Distance(this Point2 P, General2 G) => G.Distance(P);

        public static double Distance(this Point2 P, Hesse2 H) => H.Distance(P);

        public static double Distance(this Point2 P, Line2 L) => L.Distance(P);

        public static bool IsInside(this Point2 P, Box2 B) =>
            B.MinX < P.X && P.X < B.MaxX &&
            B.MinY < P.Y && P.Y < B.MaxY;

        public static bool IsInside(this Point2 P, Circle2 C) => P.DistanceSqr(C.Center) < C.RadiusSqr;

        public static bool IsInside(this Point2 P, Hesse2 H) => (H.D - H.Normal * (P - Point2.Origin)) > 0;

        public static bool IsLeft(this Point2 P, Line2 L) => L.Direction % (P - L.Base) > 0;

        public static bool IsOutside(this Point2 P, Box2 B) =>
            P.X < B.MinX || B.MaxX < P.X ||
            P.Y < B.MinY || B.MaxY < P.Y;

        public static bool IsOutside(this Point2 P, Circle2 C) => P.DistanceSqr(C.Center) > C.RadiusSqr;

        public static bool IsOutside(this Point2 P, Hesse2 H) => (H.D - H.Normal * (P - Point2.Origin)) < 0;

        public static bool IsRight(this Point2 P, Line2 L) => L.Direction % (P - L.Base) < 0;

        #endregion

        #region Point3

        public static double Distance(this Point3 P, General3 G) => G.Distance(P);

        public static double Distance(this Point3 P, Hesse3 H) => H.Distance(P);

        public static double Distance(this Point3 P, Line3 L) => L.Distance(P);

        public static double Distance(this Point3 P, Plane3 Plane) => Plane.Distance(P);

        public static double DistanceSqr(this Point3 P, Line3 L) => L.DistanceSqr(P);

        public static bool IsInside(this Point3 P, Box3 B) =>
            B.MinX < P.X && P.X < B.MaxX &&
            B.MinY < P.Y && P.Y < B.MaxY &&
            B.MinZ < P.Z && P.Z < B.MaxZ;

        public static bool IsInside(this Point3 P, Hesse3 H) => (H.D - H.Normal * (P - Point3.Origin)) > 0;

        public static bool IsInside(this Point3 P, Sphere3 S) => P.DistanceSqr(S.Center) < S.RadiusSqr;

        public static bool IsOutside(this Point3 P, Box3 B) =>
            P.X < B.MinX || B.MaxX < P.X ||
            P.Y < B.MinY || B.MaxY < P.Y ||
            P.Z < B.MinZ || B.MaxZ < P.Z;

        public static bool IsOutside(this Point3 P, Hesse3 H) => (H.D - H.Normal * (P - Point3.Origin)) < 0;

        public static bool IsOutside(this Point3 P, Sphere3 S) => P.DistanceSqr(S.Center) > S.RadiusSqr;

        #endregion
    }
}
