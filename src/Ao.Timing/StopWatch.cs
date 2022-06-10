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

using Ao.Measurements;
using System;

namespace Ao.Timing
{
	public sealed class StopWatch
	{
		#region Construction

		public StopWatch(Func<Time> timestamp) => Now = timestamp ?? throw new ArgumentNullException();

		#endregion

		#region Fields

		private bool enabled = false;

		private Time end = Time.Zero;

		private Time elapsed = Time.Zero;

		private readonly Func<Time> Now;

		private Time start = Time.Zero;

		#endregion

		#region Methods

		public Time Cycle()
		{
			if (Enabled)
			{
				Enabled = false;

				var c = end - start;

				Enabled = true;

				return c;
			}

			else
			{
				return Time.Zero;
			}
		}

		public void Disable() => Enabled = false;

		public void Enable() => Enabled = true;

		public void Reset()
		{
			elapsed = Time.Zero;

			start = Now();

			end = start;
		}

		public void Restart()
		{
			Stop();
			Reset();
			Start();
		}

		public void Start() => Enabled = true;

		public void Stop() => Enabled = false;

		#endregion

		#region Properties

		public Time Elapsed => elapsed + ElapsedCycle;

		public Time ElapsedCycle => enabled ? Now() - start : end - start;

		public bool Enabled
		{
			get => enabled;
			set
			{
				if (value == enabled) return;

				if (value)
				{
					start = Now();
				}

				else
				{
					end = Now();

					elapsed += end - start;
				}

				enabled = value;
			}
		}

		#endregion
	}
}
