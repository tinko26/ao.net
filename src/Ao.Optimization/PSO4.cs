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

namespace Ao.Optimization
{
    public sealed class PSO4
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

        public Func<Vector4, double> Objective { get; set; } = x => double.NegativeInfinity;

        #endregion

        #region Particle

        private struct Particle
        {
            public Vector4 Position;

            public Vector4 PositionBest;

            public double Value;

            public double ValueBest;

            public Vector4 Velocity;
        }

        public int ParticleCount { get; set; } = 1000;

        public int ParticleNeighborCount { get; set; } = 10;

        #endregion

        #region Position

        public Vector4 PositionBest { get; private set; }

        private Vector4 PositionBestOfNeighbors(Particle[] ps, int i)
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
                var p = new Vector4
                {
                    M1 = double.PositiveInfinity,
                    M2 = double.PositiveInfinity,
                    M3 = double.PositiveInfinity,
                    M4 = double.PositiveInfinity
                };

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

        public Vector4 PositionMax { get; set; }

        public Vector4 PositionMin { get; set; }

        #endregion

        #region Solve

        public void Solve()
        {
            // Initialize.

            Iterations = 0;

            ValueBest = double.PositiveInfinity;

            VelocityMax = new Vector4
            {
                M1 = Math.Abs(VelocityMaxStart.M1),
                M2 = Math.Abs(VelocityMaxStart.M2),
                M3 = Math.Abs(VelocityMaxStart.M3),
                M4 = Math.Abs(VelocityMaxStart.M4)
            };


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
                ps[i].Position.M1 = pmin.M1 + (pmax.M1 - pmin.M1) * r.NextDouble();
                ps[i].Position.M2 = pmin.M2 + (pmax.M2 - pmin.M2) * r.NextDouble();
                ps[i].Position.M3 = pmin.M3 + (pmax.M3 - pmin.M3) * r.NextDouble();
                ps[i].Position.M4 = pmin.M4 + (pmax.M4 - pmin.M4) * r.NextDouble();

                ps[i].Velocity.M1 = VelocityMax.M1 * r.NextDouble();
                ps[i].Velocity.M2 = VelocityMax.M2 * r.NextDouble();
                ps[i].Velocity.M3 = VelocityMax.M3 * r.NextDouble();
                ps[i].Velocity.M4 = VelocityMax.M4 * r.NextDouble();

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

                    var v = ps[i].Velocity;

                    var vi = wi * v;

                    var vc = new Vector4
                    {
                        M1 = wc * r.NextDouble() * (pb.M1 - p.M1),
                        M2 = wc * r.NextDouble() * (pb.M2 - p.M2),
                        M3 = wc * r.NextDouble() * (pb.M3 - p.M3),
                        M4 = wc * r.NextDouble() * (pb.M4 - p.M4)
                    };

                    var vs = new Vector4
                    {
                        M1 = ws * r.NextDouble() * (pn.M1 - p.M1),
                        M2 = ws * r.NextDouble() * (pn.M2 - p.M2),
                        M3 = ws * r.NextDouble() * (pn.M3 - p.M3),
                        M4 = ws * r.NextDouble() * (pn.M4 - p.M4)
                    };

                    v = vi + vc + vs;

                    if (Math.Abs(v.M1) > VelocityMax.M1) { v.M1 = v.M1 / Math.Abs(v.M1) * VelocityMax.M1; }
                    if (Math.Abs(v.M2) > VelocityMax.M2) { v.M2 = v.M2 / Math.Abs(v.M2) * VelocityMax.M2; }
                    if (Math.Abs(v.M3) > VelocityMax.M3) { v.M3 = v.M3 / Math.Abs(v.M3) * VelocityMax.M3; }
                    if (Math.Abs(v.M4) > VelocityMax.M4) { v.M4 = v.M4 / Math.Abs(v.M4) * VelocityMax.M4; }

                    ps[i].Velocity = v;
                }


                // Update Maximum Velocity.

                if (history)
                {
                    if (had <= hadt)
                    {
                        var vm = VelocityMax;
                        var vd = VelocityMaxDrop;

                        vm.M1 *= vd.M1;
                        vm.M2 *= vd.M2;
                        vm.M3 *= vd.M3;
                        vm.M4 *= vd.M4;

                        VelocityMax = vm;
                    }
                }


                // Update Positions.

                for (var i = 0; i < n; i++)
                {
                    var p = ps[i].Position;
                    var v = ps[i].Velocity;

                    p = p + v;

                    if (p.M1 > PositionMax.M1) p.M1 = PositionMax.M1;
                    if (p.M2 > PositionMax.M2) p.M2 = PositionMax.M2;
                    if (p.M3 > PositionMax.M3) p.M3 = PositionMax.M3;
                    if (p.M4 > PositionMax.M4) p.M4 = PositionMax.M4;

                    if (p.M1 < PositionMin.M1) p.M1 = PositionMin.M1;
                    if (p.M2 < PositionMin.M2) p.M2 = PositionMin.M2;
                    if (p.M3 < PositionMin.M3) p.M3 = PositionMin.M3;
                    if (p.M4 < PositionMin.M4) p.M4 = PositionMin.M4;

                    ps[i].Position = p;
                }


                // Iterate.

                iterating = iterating && (IterationsMax <= 0 || Iterations < IterationsMax);

                iterating = iterating && (ValueBest > ValueBestThreshold);

                iterating = iterating &&
                (
                    (VelocityMax.M1 > VelocityMaxThreshold.M1) ||
                    (VelocityMax.M2 > VelocityMaxThreshold.M2) ||
                    (VelocityMax.M3 > VelocityMaxThreshold.M3) ||
                    (VelocityMax.M4 > VelocityMaxThreshold.M4)
                );
            }
            while (iterating);
        }

        #endregion

        #region Value

        public double ValueBest { get; private set; }

        public double ValueBestThreshold { get; set; } = double.NegativeInfinity;

        #endregion

        #region Velocity

        public Vector4 VelocityMax { get; private set; }

        public Vector4 VelocityMaxDrop { get; set; } = new Vector4
        {
            M1 = 0.7,
            M2 = 0.7,
            M3 = 0.7,
            M4 = 0.7
        };

        public Vector4 VelocityMaxStart { get; set; }

        public Vector4 VelocityMaxThreshold { get; set; } = new Vector4
        {
            M1 = 0.001,
            M2 = 0.001,
            M3 = 0.001,
            M4 = 0.001
        };

        #endregion

        #region Weight

        public double WeightCognitive { get; set; } = 2.0;

        public double WeightInertial { get; set; } = 0.8;

        public double WeightSocial { get; set; } = 0.8;

        #endregion
    }
}
