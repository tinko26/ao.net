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

using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;

namespace Ao.Dash
{
    public sealed class Dashcam
    {
        #region Construction

        internal Dashcam(string monikerString, string name)
        {
            MonikerString = monikerString;

            Name = name;

            Source = new VideoCaptureDevice(monikerString);

            Source.NewFrame += Source_NewFrame;

            Source.PlayingFinished += Source_PlayingFinished;

            Source.SnapshotFrame += Source_SnapshotFrame;

            Source.VideoSourceError += Source_VideoSourceError;

            var V = Source.VideoCapabilities;

            var N = V.Length;

            var J = 0;

            for (var I = 1; I < N; I++)
            {
                if (V[I].FrameSize.Width > V[J].FrameSize.Width)
                {
                    J = I;
                }
            }

            Source.VideoResolution = V[J];

            BitsPerPixel = V[J].BitCount;

            FrameRateAverage = V[J].AverageFrameRate;

            FrameRateMax = V[J].MaximumFrameRate;

            FrameSize = V[J].FrameSize;

            FrameWidth = FrameSize.Width;

            FrameHeight = FrameSize.Height;

            FramePixels = FrameWidth * FrameHeight;

            FrameAspectRatio = (double)FrameWidth / FrameHeight;

            BitsPerFrame = BitsPerPixel * FramePixels;

            BytesPerFrame = BitsPerFrame / 8;
        }

        #endregion

        #region Events

        public event DashcamFrameEventHandler Frame;

        #endregion

        #region Fields

        private readonly VideoCaptureDevice Source;

        #endregion

        #region Methods

        public void Start()
        {
            ReceivedBytes = 0;

            ReceivedFrames = 0;

            Source.Start();
        }

        public void Stop() => Source.Stop();

        #endregion

        #region Methods (Private)

        private void Source_NewFrame(object sender, NewFrameEventArgs e)
        {
            ReceivedBytes += Source.BytesReceived;

            ReceivedFrames += Source.FramesReceived;

            var F1 = e.Frame;

            var F2 = F1.Clone() as Bitmap;

            Frame?.Invoke(this, new DashcamFrameEventArgs(F2));

            F2.Dispose();
        }

        private void Source_PlayingFinished(object sender, ReasonToFinishPlaying e)
        {
            switch (e)
            {
                case ReasonToFinishPlaying.DeviceLost: break;

                case ReasonToFinishPlaying.StoppedByUser: break;

                case ReasonToFinishPlaying.EndOfStreamReached: break;

                case ReasonToFinishPlaying.VideoSourceError: break;

                default:

                    break;
            }
        }

        private void Source_SnapshotFrame(object sender, NewFrameEventArgs e) { }

        private void Source_VideoSourceError(object sender, VideoSourceErrorEventArgs e) { }

        #endregion

        #region Properties

        public int BitsPerFrame { get; }

        public int BitsPerPixel { get; }

        public int BytesPerFrame { get; }

        public double FrameAspectRatio { get; }

        public int FrameHeight { get; }

        public int FramePixels { get; }

        public int FrameRateAverage { get; }

        public int FrameRateMax { get; }

        public Size FrameSize { get; }

        public int FrameWidth { get; }

        public bool IsRunning => Source.IsRunning;

        public string MonikerString { get; }

        public string Name { get; }

        public long ReceivedBytes { get; private set; }

        public int ReceivedFrames { get; private set; }

        #endregion
    }
}
