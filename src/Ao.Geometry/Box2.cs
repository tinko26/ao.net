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
	public struct Box2
	{
        #region Construction

        public Box2(double minX, double minY, double maxX, double maxY)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
        }

        #endregion

        #region Methods

        public bool Contains(Point2 P) =>
            MinX <= P.X && P.X <= MaxX &&
            MinY <= P.Y && P.Y <= MaxY;

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            MinX.GetHashCode() ^
            MinY.GetHashCode() ^
            MaxX.GetHashCode() ^
            MaxY.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Box2 FromCenterAndDim(Point2 C, Dim2 D)
        {
            var w = 0.5 * D.Width;
            var h = 0.5 * D.Height;

            return new Box2
            (
                C.X - w,
                C.Y - h,
                C.X + w,
                C.Y + h
            );
        }

        public static Box2 FromMinAndMax(Point2 Min, Point2 Max) => new Box2(Min.X, Min.Y, Max.X, Max.Y);

        public static Box2 FromPoint(Point2 P) => new Box2(P.X, P.Y, P.X, P.Y);

        public static Box2 FromRanges(Range X, Range Y) => new Box2(X.Min, Y.Min, X.Max, Y.Max);

        #endregion

        #region Operators

        public static Box2 operator +(Box2 B, Point2 P)
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

            return B;
        }

        public static Box2 operator +(Box2 B, Vector2 T)
        {
            return new Box2
            (
                B.MinX + T.M1,
                B.MinY + T.M2,
                B.MaxX + T.M1,
                B.MaxY + T.M2
            );
        }

        public static Box2 operator -(Box2 B, Vector2 T)
        {
            return new Box2
            (
                B.MinX - T.M1,
                B.MinY - T.M2,
                B.MaxX - T.M1,
                B.MaxY - T.M2
            );
        }

        public static Box2 operator *(double S, Box2 B)
        {
            B.MinX *= S;
            B.MinY *= S;
            B.MaxX *= S;
            B.MaxY *= S;

            return B;
        }

        public static Box2 operator *(Box2 B, double S)
        {
            B.MinX *= S;
            B.MinY *= S;
            B.MaxX *= S;
            B.MaxY *= S;

            return B;
        }

        public static Box2 operator /(Box2 B, double S)
        {
            B.MinX /= S;
            B.MinY /= S;
            B.MaxX /= S;
            B.MaxY /= S;

            return B;
        }

        #endregion

        #region Properties

        public double Area => Width * Height;

        public double AspectRatio => Width / Height;

        public double Bottom
        {
            get => MinY;
            set => MinY = value;
        }

        public Circle2 BoundingCircle => new Circle2(Center, 0.5 * Diagonal);

        public Point2 Center => new Point2(CenterX, CenterY);

        public double CenterX => 0.5 * (MinX + MaxX);

        public double CenterY => 0.5 * (MinY + MaxY);

        public Box2 Centralized
        {
            get
            {
                var w = 0.5 * Width;
                var h = 0.5 * Height;

                return new Box2(-w, -h, w, h);
            }
        }

        public double Diagonal => Math.Sqrt(DiagonalSqr);

        public double DiagonalSqr
        {
            get
            {
                var w = Width;
                var h = Height;

                return w * w + h * h;
            }
        }

        public Dim2 Dim => new Dim2(Width, Height);

        public double Height => MaxY - MinY;

        public double Left
        {
            get => MinX;
            set => MinX = value;
        }

        public Point2 LeftBottom => new Point2(Left, Bottom);

        public Point2 LeftTop => new Point2(Left, Top);

        public Point2 Max
        {
            get => new Point2(MaxX, MaxY);
            set
            {
                MaxX = value.X;
                MaxY = value.Y;
            }
        }

        public double MaxX { get; set; }

        public double MaxY { get; set; }

        public Point2 Min
        {
            get => new Point2(MinX, MinY);
            set
            {
                MinX = value.X;
                MinY = value.Y;
            }
        }

        public double MinX { get; set; }

        public double MinY { get; set; }

        public double Perimeter => 2 * (Width + Height);

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

        public double Right
        {
            get => MaxX;
            set => MaxX = value;
        }

        public Point2 RightBottom => new Point2(Right, Bottom);

        public Point2 RightTop => new Point2(Right, Top);

        public double Top
        {
            get => MaxY;
            set => MaxY = value;
        }

        public double Width => MaxX - MinX;

        #endregion
    }
}
