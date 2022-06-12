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
		#region Methods

        public void Solve()
		{
            // Init.

            var BestPosition = double.PositiveInfinity;

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

            double ParticleBestPosition;

            double ParticleBestPositionOfNeighbors;

            double ParticlePosition;

            var Particles = this.Particles;

            double ParticleValue;

            double ParticleVelocity;

            double ParticleVelocityCognitive;

            double ParticleVelocityInertial;

            double ParticleVelocitySocial;

            var Rand = this.Rand;

            var Social = this.Social;


            // Init.

            var MaxVelocity = Math.Abs(MaxVelocityStart);


            // Init.

            var HistoryStore = new double[HistorySize];

            var ParticleStore = new Particle[Particles];


			// Init particle store.

			{
                var T = MaxPosition - MinPosition;

                for (var i = 0; i < Particles; i++)
                {
                    ParticleStore[i].BestValue = double.PositiveInfinity;

                    ParticleStore[i].Position = MinPosition + T * Rand();

                    ParticleStore[i].Velocity = MaxVelocity * Rand();
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

                    ParticleVelocityCognitive = Cognitive * Rand() * (ParticleBestPosition - ParticlePosition);

                    ParticleVelocitySocial = Social * Rand() * (ParticleBestPositionOfNeighbors - ParticleBestPosition);

                    ParticleVelocity = ParticleVelocityCognitive + ParticleVelocityInertial + ParticleVelocitySocial;

                    if (ParticleVelocity > MaxVelocity)
					{
                        ParticleVelocity = MaxVelocity;
					}

                    else if (ParticleVelocity < -MaxVelocity)
					{
                        ParticleVelocity = -MaxVelocity;
					}

                    ParticleStore[i].Velocity = ParticleVelocity;
                }


                // Update maximum velocity.

                if (History)
				{
                    if (HistoryAverageDeviation <= HistoryAverageDeviationThreshold)
					{
                        MaxVelocity = MaxVelocity * MaxVelocityDrop;
					}
				}


                // Update positions.

                for (var i = 0; i < Particles; i++)
				{
                    ParticlePosition = ParticleStore[i].Position;

                    ParticleVelocity = ParticleStore[i].Velocity;

                    ParticlePosition = ParticlePosition + ParticleVelocity;

                    ParticlePosition = Math.Max(ParticlePosition, MinPosition);

                    ParticlePosition = Math.Min(ParticlePosition, MaxPosition);

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
                    if (MaxVelocity <= MaxVelocityThreshold)
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

        private double BestPositionOfNeighbors(Particle[] ParticleStore, int i)
		{
			var N = Neighbors;

			var P = Particles;

			// LBEST.

			if (N < P)
			{
				var BestPosition = double.PositiveInfinity;

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

		public double BestPosition { get; private set; }

		public double BestValue { get; private set; }

		public double BestValueThreshold { get; set; } = double.NegativeInfinity;

        public double Cognitive { get; set; } = 2.0;

        public double HistoryAverageDeviationThreshold { get; set; } = 1e-6;

		public int HistorySize { get; set; } = 5;

        public double Inertial { get; set; } = 0.8;

        public int Iterations { get; private set; }

		public int MaxIterations { get; set; } = 0;

		public double MaxPosition { get; set; }

		public double MaxVelocity { get; private set; }

		public double MaxVelocityDrop { get; set; } = 0.7;

		public double MaxVelocityStart { get; set; }

		public double MaxVelocityThreshold { get; set; } = 1e-6;

		public double MinPosition { get; set; }

		public int Neighbors { get; set; } = 10;

		public int Particles { get; set; } = 1000;

		public Func<double, double> Objective { get; set; }

		public Func<double> Rand { get; set; }

		public double Social { get; set; } = 0.8;

		#endregion

		#region Types

		private struct Particle
		{
			public double BestPosition;

			public double BestValue;

			public double Position;

			public double Value;

			public double Velocity;
		}

		#endregion
	}
}
