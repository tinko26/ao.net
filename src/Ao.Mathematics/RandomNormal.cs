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
    public sealed class RandomNormal
    {
        #region Construction

        public RandomNormal()
        {
            Random = new RandomUniform();

            Mean = 0;

            Variance = 1;
        }

        public RandomNormal(int seed)
        {
            Random = new RandomUniform(seed);

            Mean = 0;

            Variance = 1;
        }

        #endregion

        #region Fields

        private readonly RandomUniform Random;

        #endregion

        #region Methods

        public double NextBoxMuller()
        {
            var u1 = 1 - Random.Next();
            var u2 = 1 - Random.Next();

            var s = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);

            return Mean + StandardDeviation * s;
        }

        public double NextPolar()
        {
            double u;
            double v;

            double q;

            do
            {
                u = 2 * Random.Next() - 1;
                v = 2 * Random.Next() - 1;

                q = u * u + v * v;
            }
            while (q <= 0.0000001 || q >= 0.9999999);

            var p = Math.Sqrt(-2 * Math.Log(q) / q);

            var xu = u * p;
            var xv = v * p;

            return Mean + StandardDeviation * xu;
        }

        #endregion

        #region Properties

        public double Mean { get; set; }

        public double StandardDeviation
        {
            get => Math.Sqrt(Variance);
            set
            {
                Variance = value * value;
            }
        }

        public double Variance { get; set; }

        #endregion
    }
}
