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
    public class Surface3
    {
        #region Methods

        public Vector3 Normal(double u, double v) => Vector3.Cross(PartialDerivativeU1(u, v), PartialDerivativeV1(u, v));

        public Plane3 TangentPlane(double u, double v) => Plane3.FromPointNormal(Position(u, v), Normal(u, v));

        public Vector3 UnitNormal(double u, double v) => Normal(u, v).Normalized;

        #endregion

        #region Properties

        public Func<double, double, Vector3> PartialDerivativeU1 { get; set; }

        public Func<double, double, Vector3> PartialDerivativeU2 { get; set; }

        public Func<double, double, Vector3> PartialDerivativeU3 { get; set; }

        public Func<double, double, Vector3> PartialDerivativeV1 { get; set; }

        public Func<double, double, Vector3> PartialDerivativeV2 { get; set; }

        public Func<double, double, Vector3> PartialDerivativeV3 { get; set; }

        public Func<double, double, Point3> Position { get; set; }

        #endregion
    }
}
