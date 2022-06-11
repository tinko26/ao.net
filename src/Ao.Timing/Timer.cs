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
using System.Timers;
using Backend = System.Timers.Timer;

namespace Ao.Timing
{
    public sealed class Timer : IDisposable
    {
        #region Construction

        public Timer(Func<Time> timestamp)
        {
            Now = timestamp ?? throw new ArgumentNullException();

            Backend.Elapsed += BackendElapsed;
        }

        #endregion

        #region Destruction

        ~Timer() => Dispose(false);

        #endregion

        #region Events

        public event TimerEventHandler Elapsed;

        #endregion

        #region Fields

        private readonly Backend Backend = new Backend
        {
            AutoReset = true,

            Interval = 1000
        };

        private readonly Func<Time> Now;

        #endregion

        #region Methods

        public void Disable() => Enabled = false;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public void Enable() => Enabled = true;

        public void Reset()
        {
            if (Enabled)
            {
                Backend.Stop();

                Backend.Start();
            }
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

        #region Methods (Private)

        private void BackendElapsed(object sender, ElapsedEventArgs e) => Elapsed?.Invoke(this, new TimerEventArgs(Now()));

        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                // Managed resources.

                if (disposing)
                {
                    Backend.Dispose();
                }

                // Unmanaged resources.

                // ...

                Disposed = true;
            }
        }

        #endregion

        #region Properties

        public bool Disposed { get; private set; }

        public bool Enabled
        {
            get => Backend.Enabled;
            set => Backend.Enabled = value;
        }

        public Time Period
        {
            get => new Time
            {
                Milliseconds = Backend.Interval
            };
            set
            {
                Backend.Interval = value.Milliseconds;
            }
        }

        #endregion
    }
}
