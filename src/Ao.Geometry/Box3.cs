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
using System;

namespace Ao.Geometry
{
    public struct Box3
    {
        #region Construction

        public Box3(double minX, double minY, double minZ, double maxX, double maxY, double maxZ)
        {
            MinX = minX;
            MinY = minY;
            MinZ = minZ;
            MaxX = maxX;
            MaxY = maxY;
            MaxZ = maxZ;
        }

        #endregion

        #region Methods

        public bool Contains(Point3 P) =>
            MinX <= P.X && P.X <= MaxX &&
            MinY <= P.Y && P.Y <= MaxY &&
            MinZ <= P.Z && P.Z <= MaxZ;

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            MinX.GetHashCode() ^
            MinY.GetHashCode() ^
            MinZ.GetHashCode() ^
            MaxX.GetHashCode() ^
            MaxY.GetHashCode() ^
            MaxZ.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Box3 FromCenterAndDim(Point3 C, Dim3 D)
        {
            var w = 0.5 * D.Width;
            var h = 0.5 * D.Height;
            var d = 0.5 * D.Depth;

            return new Box3
            (
                C.X - w,
                C.Y - h,
                C.Z - d,
                C.X + w,
                C.Y + h,
                C.Z + d
            );
        }

        public static Box3 FromMinAndMax(Point3 Min, Point3 Max) => new Box3(Min.X, Min.Y, Min.Z, Max.X, Max.Y, Max.Z);

        public static Box3 FromPoint(Point3 P) => new Box3(P.X, P.Y, P.Z, P.X, P.Y, P.Z);

        public static Box3 FromRanges(Range X, Range Y, Range Z) => new Box3(X.Min, Y.Min, Z.Min, X.Max, Y.Max, Z.Max);

        #endregion

        #region Operators

        public static Box3 operator +(Box3 B, Point3 P)
        {
            if (P.X < B.MinX)
            {
                B.MinX = P.X;
            }

            else if (P.X > B.MaxX)
            {
                B.MaxX = P.X;
            }

            if (P.Y < B.MinY)
            {
                B.MinY = P.Y;
            }

            else if (P.Y > B.MaxY)
            {
                B.MaxY = P.Y;
            }

            if (P.Z < B.MinZ)
            {
                B.MinZ = P.Z;
            }

            else if (P.Z > B.MaxZ)
            {
                B.MaxZ = P.Z;
            }

            return B;
        }

        public static Box3 operator +(Box3 B, Vector3 T)
        {
            return new Box3
            (
                B.MinX + T.M1,
                B.MinY + T.M2,
                B.MinZ + T.M3,
                B.MaxX + T.M1,
                B.MaxY + T.M2,
                B.MaxZ + T.M3
            );
        }

        public static Box3 operator -(Box3 B, Vector3 T)
        {
            return new Box3
            (
                B.MinX - T.M1,
                B.MinY - T.M2,
                B.MinZ - T.M3,
                B.MaxX - T.M1,
                B.MaxY - T.M2,
                B.MaxZ - T.M3
            );
        }

        public static Box3 operator *(double S, Box3 B)
        {
            B.MinX *= S;
            B.MinY *= S;
            B.MinZ *= S;
            B.MaxX *= S;
            B.MaxY *= S;
            B.MaxZ *= S;

            return B;
        }

        public static Box3 operator *(Box3 B, double S)
        {
            B.MinX *= S;
            B.MinY *= S;
            B.MinZ *= S;
            B.MaxX *= S;
            B.MaxY *= S;
            B.MaxZ *= S;

            return B;
        }

        public static Box3 operator /(Box3 B, double S)
        {
            B.MinX /= S;
            B.MinY /= S;
            B.MinZ /= S;
            B.MaxX /= S;
            B.MaxY /= S;
            B.MaxZ /= S;

            return B;
        }

        #endregion

        #region Properties

        public double Bottom
        {
            get => MinY;
            set => MinY = value;
        }

        public Sphere3 BoundingSphere => new Sphere3(Center, 0.5 * Diagonal);

        public Point3 Center => new Point3(CenterX, CenterY, CenterZ);

        public double CenterX => 0.5 * (MinX + MaxX);

        public double CenterY => 0.5 * (MinY + MaxY);

        public double CenterZ => 0.5 * (MinZ + MaxZ);

        public Box3 Centralized
        {
            get
            {
                var w = 0.5 * Width;
                var h = 0.5 * Height;
                var d = 0.5 * Depth;

                return new Box3(-w, -h, -d, w, h, d);
            }
        }

        public double Depth => MaxZ - MinZ;

        public double Diagonal => Math.Sqrt(DiagonalSqr);

        public double DiagonalSqr
        {
            get
            {
                var w = Width;
                var h = Height;
                var d = Depth;

                return w * w + h * h + d * d;
            }
        }

        public Dim3 Dim => new Dim3(Width, Height, Depth);

        public double Far
        {
            get => MaxZ;
            set => MaxZ = value;
        }

        public double Height => MaxY - MinY;

        public double Left
        {
            get => MinX;
            set => MinX = value;
        }

        public Point3 LeftBottomFar => new Point3(Left, Bottom, Far);

        public Point3 LeftBottomNear => new Point3(Left, Bottom, Near);

        public Point3 LeftTopFar => new Point3(Left, Top, Far);

        public Point3 LeftTopNear => new Point3(Left, Top, Near);

        public Point3 Max
        {
            get => new Point3(MaxX, MaxY, MaxZ);
            set
            {
                MaxX = value.X;
                MaxY = value.Y;
                MaxZ = value.Z;
            }
        }

        public double MaxX { get; set; }

        public double MaxY { get; set; }

        public double MaxZ { get; set; }

        public Point3 Min
        {
            get => new Point3(MinX, MinY, MinZ);
            set
            {
                MinX = value.X;
                MinY = value.Y;
                MinZ = value.Z;
            }
        }

        public double MinX { get; set; }

        public double MinY { get; set; }

        public double MinZ { get; set; }

        public double Near
        {
            get => MinZ;
            set => MinZ = value;
        }

        public Range RangeX
        {
            get => new Range(MinX, MaxX);
            set
            {
                MinX = value.Min;
                MaxX = value.Max;
            }
        }

        public Range RangeY
        {
            get => new Range(MinY, MaxY);
            set
            {
                MinY = value.Min;
                MaxY = value.Max;
            }
        }

        public Range RangeZ
        {
            get => new Range(MinZ, MaxZ);
            set
            {
                MinZ = value.Min;
                MaxZ = value.Max;
            }
        }

        public double Right
        {
            get => MaxX;
            set => MaxX = value;
        }

        public Point3 RightBottomFar => new Point3(Right, Bottom, Far);

        public Point3 RightBottomNear => new Point3(Right, Bottom, Near);

        public Point3 RightTopFar => new Point3(Right, Top, Far);

        public Point3 RightTopNear => new Point3(Right, Top, Near);

        public double SurfaceArea
        {
            get
            {
                var w = Width;
                var h = Height;
                var d = Depth;

                return 2 * (w * (h + d) + h * d);
            }
        }

        public double Top
        {
            get => MaxY;
            set => MaxY = value;
        }

        public double Volume => Width * Height * Depth;

        public double Width => MaxX - MinX;

        #endregion
    }
}
