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
    public sealed class PSO2
    {
        #region Methods

        public void Solve()
        {
            // Init.

            var BestPosition = new Vector2
            {
                M1 = double.PositiveInfinity,
                M2 = double.PositiveInfinity
            };

            var BestValue = double.PositiveInfinity;

            var BestValueThreshold = this.BestValueThreshold;

            var Cognitive = this.Cognitive;

            bool History;

            var HistoryAverage = 0.0;

            var HistoryAverageDeviation = 0.0;

            var HistoryAverageDeviationThreshold = this.HistoryAverageDeviationThreshold;

            var HistoryIndex = 0;

            var HistorySize = this.HistorySize;

            var Inertial = this.Inertial;

            var Iterate = true;

            var Iterations = 0;

            var MaxIterations = this.MaxIterations;

            var MaxPosition = this.MaxPosition;

            var MaxVelocityDrop = this.MaxVelocityDrop;

            var MaxVelocityStart = this.MaxVelocityStart;

            var MaxVelocityThreshold = this.MaxVelocityThreshold;

            var MinPosition = this.MinPosition;

            var Objective = this.Objective;

            Vector2 ParticleBestPosition;

            Vector2 ParticleBestPositionOfNeighbors;

            Vector2 ParticlePosition;

            var Particles = this.Particles;

            double ParticleValue;

            Vector2 ParticleVelocity;

            Vector2 ParticleVelocityCognitive;

            Vector2 ParticleVelocityInertial;

            Vector2 ParticleVelocitySocial;

            var Rand = this.Rand;

            var Social = this.Social;


            // Init.

            var MaxVelocity = new Vector2
            {
                M1 = Math.Abs(MaxVelocityStart.M1),
                M2 = Math.Abs(MaxVelocityStart.M2)
            };


            // Init.

            var HistoryStore = new double[HistorySize];

            var ParticleStore = new Particle[Particles];


            // Init particle store.

            {
                var T = MaxPosition - MinPosition;

                for (var i = 0; i < Particles; i++)
                {
                    ParticleStore[i].BestValue = double.PositiveInfinity;

                    ParticleStore[i].Position.M1 = MinPosition.M1 + T.M1 * Rand();
                    ParticleStore[i].Position.M2 = MinPosition.M2 + T.M2 * Rand();

                    ParticleStore[i].Velocity.M1 = MaxVelocity.M1 * Rand();
                    ParticleStore[i].Velocity.M2 = MaxVelocity.M2 * Rand();
                }
            }


            // Iterate.

            do
            {
                Iterations++;

                History = Iterations >= HistorySize;


                // Update values.

                for (var i = 0; i < Particles; i++)
                {
                    ParticlePosition = ParticleStore[i].Position;

                    ParticleValue = Objective(ParticlePosition);

                    if (ParticleValue < ParticleStore[i].BestValue)
                    {
                        ParticleStore[i].BestPosition = ParticlePosition;

                        ParticleStore[i].BestValue = ParticleValue;

                        if (ParticleValue < BestValue)
                        {
                            BestPosition = ParticlePosition;

                            BestValue = ParticleValue;
                        }
                    }

                    ParticleStore[i].Value = ParticleValue;
                }


                // Update history.

                HistoryStore[HistoryIndex] = BestValue;

                HistoryIndex = HistoryIndex + 1;

                HistoryIndex = HistoryIndex % HistorySize;

                if (History)
                {
                    HistoryAverage = HistoryStore[0];

                    for (var i = 1; i < HistorySize; i++)
                    {
                        HistoryAverage = HistoryAverage + HistoryStore[i];
                    }

                    HistoryAverage = HistoryAverage / HistorySize;

                    HistoryAverageDeviation = Math.Abs(BestValue - HistoryAverage);
                }


                // Update Velocities.

                for (var i = 0; i < Particles; i++)
                {
                    ParticleBestPosition = ParticleStore[i].BestPosition;

                    ParticlePosition = ParticleStore[i].Position;

                    ParticleBestPositionOfNeighbors = BestPositionOfNeighbors(ParticleStore, i);

                    ParticleVelocity = ParticleStore[i].Velocity;

                    ParticleVelocityInertial = Inertial * ParticleVelocity;

                    ParticleVelocityCognitive = new Vector2
                    {
                        M1 = Cognitive * Rand() * (ParticleBestPosition.M1 - ParticlePosition.M1),
                        M2 = Cognitive * Rand() * (ParticleBestPosition.M2 - ParticlePosition.M2)
                    };

                    ParticleVelocitySocial = new Vector2
                    {
                        M1 = Social * Rand() * (ParticleBestPositionOfNeighbors.M1 - ParticleBestPosition.M1),
                        M2 = Social * Rand() * (ParticleBestPositionOfNeighbors.M2 - ParticleBestPosition.M2)
                    };

                    ParticleVelocity = ParticleVelocityCognitive + ParticleVelocityInertial + ParticleVelocitySocial;

                    ParticleVelocity.M1 = Math.Min(ParticleVelocity.M1, +MaxVelocity.M1);
                    ParticleVelocity.M2 = Math.Min(ParticleVelocity.M2, +MaxVelocity.M2);

                    ParticleVelocity.M1 = Math.Max(ParticleVelocity.M1, -MaxVelocity.M1);
                    ParticleVelocity.M2 = Math.Max(ParticleVelocity.M2, -MaxVelocity.M2);

                    ParticleStore[i].Velocity = ParticleVelocity;
                }


                // Update maximum velocity.

                if (History)
                {
                    if (HistoryAverageDeviation <= HistoryAverageDeviationThreshold)
                    {
                        MaxVelocity.M1 = MaxVelocity.M1 * MaxVelocityDrop.M1;
                        MaxVelocity.M2 = MaxVelocity.M2 * MaxVelocityDrop.M2;
                    }
                }


                // Update positions.

                for (var i = 0; i < Particles; i++)
                {
                    ParticlePosition = ParticleStore[i].Position;

                    ParticleVelocity = ParticleStore[i].Velocity;

                    ParticlePosition = ParticlePosition + ParticleVelocity;

                    ParticlePosition.M1 = Math.Max(ParticlePosition.M1, MinPosition.M1);
                    ParticlePosition.M2 = Math.Max(ParticlePosition.M2, MinPosition.M2);

                    ParticlePosition.M1 = Math.Min(ParticlePosition.M1, MaxPosition.M1);
                    ParticlePosition.M2 = Math.Min(ParticlePosition.M2, MaxPosition.M2);

                    ParticleStore[i].Position = ParticlePosition;
                }


                // Iterate.

                if (MaxIterations > 0)
                {
                    if (Iterations >= MaxIterations)
                    {
                        Iterate = false;
                    }
                }

                if (Iterate)
                {
                    if (BestValue <= BestValueThreshold)
                    {
                        Iterate = false;
                    }
                }

                if (Iterate)
                {
                    if 
                    (
                        MaxVelocity.M1 <= MaxVelocityThreshold.M1 ||
                        MaxVelocity.M2 <= MaxVelocityThreshold.M2
                    )
                    {
                        Iterate = false;
                    }
                }
            }
            while (Iterate);


            // Ready.

            this.BestPosition = BestPosition;

            this.BestValue = BestValue;

            this.Iterations = Iterations;

            this.MaxVelocity = MaxVelocity;
        }

        #endregion

        #region Methods (Private)

        private Vector2 BestPositionOfNeighbors(Particle[] ParticleStore, int i)
        {
            var N = Neighbors;

            var P = Particles;

            // LBEST.

            if (N < P)
            {
                var BestPosition = new Vector2
                {
                    M1 = double.PositiveInfinity,
                    M2 = double.PositiveInfinity
                };

                var BestValue = double.PositiveInfinity;

                for (var n = 1; n <= N; n++)
                {
                    var j = (i + n) % P;

                    if (ParticleStore[j].BestValue < BestValue)
                    {
                        BestPosition = ParticleStore[j].BestPosition;

                        BestValue = ParticleStore[j].BestValue;
                    }
                }

                return BestPosition;
            }

            // GBEST.

            else
            {
                return BestPosition;
            }
        }

        #endregion

        #region Properties

        public Vector2 BestPosition { get; private set; }

        public double BestValue { get; private set; }

        public double BestValueThreshold { get; set; } = double.NegativeInfinity;

        public double Cognitive { get; set; } = 2.0;

        public double HistoryAverageDeviationThreshold { get; set; } = 1e-6;

        public int HistorySize { get; set; } = 5;

        public double Inertial { get; set; } = 0.8;

        public int Iterations { get; private set; }

        public int MaxIterations { get; set; } = 0;

        public Vector2 MaxPosition { get; set; }

        public Vector2 MaxVelocity { get; private set; }

        public Vector2 MaxVelocityDrop { get; set; } = new Vector2
        {
            M1 = 0.7,
            M2 = 0.7
        };

        public Vector2 MaxVelocityStart { get; set; }

        public Vector2 MaxVelocityThreshold { get; set; } = new Vector2
        {
            M1 = 1e-6,
            M2 = 1e-6
        };

        public Vector2 MinPosition { get; set; }

        public int Neighbors { get; set; } = 10;

        public int Particles { get; set; } = 1000;

        public Func<Vector2, double> Objective { get; set; }

        public Func<double> Rand { get; set; }

        public double Social { get; set; } = 0.8;

        #endregion

        #region Types

        private struct Particle
        {
            public Vector2 BestPosition;

            public double BestValue;

            public Vector2 Position;

            public double Value;

            public Vector2 Velocity;
        }

        #endregion
    }
}
