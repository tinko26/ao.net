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

namespace Ao.Optimization
{
    public sealed class PSO1
    {
        #region History

        public double HistoryAverageDeviationThreshold { get; set; } = 0.001;

        private const int HistoryCount = 5;

        #endregion

        #region Iterations

        public int Iterations { get; private set; }

        public int IterationsMax { get; set; } = -1;

        #endregion

        #region Objective

        public Func<double, double> Objective { get; set; } = x => double.NegativeInfinity;

        #endregion

        #region Particle

        private struct Particle
        {
            public double Position;

            public double PositionBest;

            public double Value;

            public double ValueBest;

            public double Velocity;
        }

        public int ParticleCount { get; set; } = 1000;

        public int ParticleNeighborCount { get; set; } = 10;

        #endregion

        #region Position

        public double PositionBest { get; private set; }

        private double PositionBestOfNeighbors(Particle[] ps, int i)
        {
            var n = ParticleCount;

            var m = ParticleNeighborCount;


            // GBEST.

            if (m >= n)
            {
                return PositionBest;
            }

            // LBEST.

            else
            {
                var p = double.PositiveInfinity;
                var v = double.PositiveInfinity;

                for (var j = 1; j <= m; j++)
                {
                    var k = (i + j) % n;

                    if (ps[k].ValueBest < v)
                    {
                        p = ps[k].PositionBest;
                        v = ps[k].ValueBest;
                    }
                }

                return p;
            }
        }

        public double PositionMax { get; set; }

        public double PositionMin { get; set; }

        #endregion

        #region Solve

        public void Solve()
        {
            // Initialize.

            Iterations = 0;

            ValueBest = double.PositiveInfinity;

            VelocityMax = Math.Abs(VelocityMaxStart);


            // Initialize.

            var hadt = HistoryAverageDeviationThreshold;

            var hn = HistoryCount;

            var n = ParticleCount;

            var o = Objective;

            var pmin = PositionMin;
            var pmax = PositionMax;

            var wc = WeightCognitive;
            var wi = WeightInertial;
            var ws = WeightSocial;


            // Initialize.

            var ha = 0.0;

            var had = 0.0;

            var hi = 0;

            var hs = new double[hn];

            var ps = new Particle[n];

            var r = new Random();


            // Initialize.

            for (var i = 0; i < n; i++)
            {
                ps[i].Position = pmin + (pmax - pmin) * r.NextDouble();

                ps[i].Velocity = VelocityMax * r.NextDouble();

                ps[i].ValueBest = double.PositiveInfinity;
            }


            // Iterate.

            var history = false;

            var iterating = true;

            do
            {
                // Iterate.

                Iterations++;

                history = (Iterations >= hn);


                // Update Values.

                for (var i = 0; i < n; i++)
                {
                    var p = ps[i].Position;

                    var v = o(p);

                    if (v < ps[i].ValueBest)
                    {
                        ps[i].PositionBest = p;
                        ps[i].ValueBest = v;

                        if (v < ValueBest)
                        {
                            ValueBest = v;
                            PositionBest = p;
                        }
                    }

                    ps[i].Value = v;
                }


                // Update History.

                hs[hi] = ValueBest;

                hi = (hi + 1) % hn;

                if (history)
                {
                    ha = hs[0];

                    for (var i = 1; i < hn; i++)
                    {
                        ha += hs[i];
                    }

                    ha /= hn;

                    had = Math.Abs(ValueBest - ha);
                }


                // Update Velocities.

                for (var i = 0; i < n; i++)
                {
                    var p = ps[i].Position;

                    var pb = ps[i].PositionBest;

                    var pn = PositionBestOfNeighbors(ps, i);

                    var rc = r.NextDouble();
                    var rs = r.NextDouble();

                    var v = ps[i].Velocity;

                    var vi = wi * v;
                    var vc = wc * rc * (pb - p);
                    var vs = ws * rs * (pn - p);

                    v = vi + vc + vs;

                    if (Math.Abs(v) > VelocityMax)
                    {
                        v = v / Math.Abs(v) * VelocityMax;
                    }

                    ps[i].Velocity = v;
                }


                // Update Maximum Velocity.

                if (history)
                {
                    if (had <= hadt)
                    {
                        VelocityMax = VelocityMax * VelocityMaxDrop;
                    }
                }


                // Update Positions.

                for (var i = 0; i < n; i++)
                {
                    var p = ps[i].Position;
                    var v = ps[i].Velocity;

                    p = p + v;

                    if (p > PositionMax) p = PositionMax;
                    if (p < PositionMin) p = PositionMin;

                    ps[i].Position = p;
                }


                // Iterate.

                iterating = iterating && (IterationsMax <= 0 || Iterations < IterationsMax);

                iterating = iterating && (ValueBest > ValueBestThreshold);

                iterating = iterating && (VelocityMax > VelocityMaxThreshold);
            }
            while (iterating);
        }

        #endregion

        #region Value

        public double ValueBest { get; private set; }

        public double ValueBestThreshold { get; set; } = double.NegativeInfinity;

        #endregion

        #region Velocity

        public double VelocityMax { get; private set; }

        public double VelocityMaxDrop { get; set; } = 0.7;

        public double VelocityMaxStart { get; set; }

        public double VelocityMaxThreshold { get; set; } = 0.001;

        #endregion

        #region Weight

        public double WeightCognitive { get; set; } = 2.0;

        public double WeightInertial { get; set; } = 0.8;

        public double WeightSocial { get; set; } = 0.8;

        #endregion
    }
}
