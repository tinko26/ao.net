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
    public struct Dim3
    {
        #region Construction

        public Dim3(double length)
        {
            Width = length;

            Height = length;

            Depth = length;
        }

        public Dim3(double width, double height, double depth)
        {
            Width = width;

            Height = height;

            Depth = depth;
        }

        #endregion

        #region Methods (Override)

        public override int GetHashCode() =>
            Width.GetHashCode() ^
            Height.GetHashCode() ^
            Depth.GetHashCode();

        #endregion

        #region Methods (Static)

        public static Dim3 FromRanges(Range Width, Range Height, Range Depth) => new Dim3(Width.Diameter, Height.Diameter, Depth.Diameter);

        #endregion

        #region Operators

        public static Dim3 operator *(double S, Dim3 D) => new Dim3(S * D.Width, S * D.Height, S * D.Depth);

        public static Dim3 operator *(Dim3 D, double S) => new Dim3(D.Width * S, D.Height * S, D.Depth * S);

        public static Dim3 operator /(Dim3 D, double S) => new Dim3(D.Width / S, D.Height / S, D.Depth / S);

        #endregion

        #region Properties

        public double Depth { get; set; }

        public double Diagonal => Math.Sqrt(DiagonalSqr);

        public double DiagonalSqr => Width * Width + Height * Height + Depth * Depth;

        public double Height { get; set; }

        public double SurfaceArea => 2 * (Width * (Height + Depth) + Height * Depth);

        public double Volume => Width * Height * Depth;

        public double Width { get; set; }

        #endregion
    }
}
