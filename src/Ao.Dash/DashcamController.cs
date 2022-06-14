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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ao.Dash
{
	public sealed class DashcamController : INotifyPropertyChanged
	{
		#region Construction

		public DashcamController()
		{
			DashcamManager.DashcamConnected += DashcamManager_DashcamConnected;

			DashcamManager.DashcamDisconnected += DashcamManager_DashcamDisconnected;
		}

		#endregion

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Fields

		private Dashcam Dashcam;

		private readonly object Sync = new object();

		#endregion

		#region Methods (Private)

		private void Dashcam_Frame(object sender, DashcamFrameEventArgs e)
		{
			var D = sender as Dashcam;

			var F1 = e.Frame;

			var F2 = new BitmapImage();

			using (var M = new MemoryStream())
			{
				F1.Save(M, ImageFormat.Bmp);

				M.Seek(0, SeekOrigin.Begin);

				F2.BeginInit();

				F2.CacheOption = BitmapCacheOption.OnLoad;

				F2.StreamSource = M;

				F2.EndInit();
			}

			F2.Freeze();

			Frame = F2;

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Frame"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceivedBytes"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceivedFrames"));
		}

		private void DashcamManager_DashcamConnected(object sender, DashcamEventArgs e) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Names"));

		private void DashcamManager_DashcamDisconnected(object sender, DashcamEventArgs e)
		{
			Stop(e.Dashcam);

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Names"));
		}

		private void Start(Dashcam D)
		{
			if (Dashcam == D) return;

			if (Dashcam != null)
			{
				Dashcam.Stop();

				Dashcam.Frame -= Dashcam_Frame;
			}

			Dashcam = D;

			Frame = null;

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BitsPerFrame"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BitsPerPixel"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BytesPerFrame"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Frame"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameAspectRatio"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameHeight"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FramePixels"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameRateAverage"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameRateMax"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameSize"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameWidth"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MonikerString"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceivedBytes"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceivedFrames"));

			if (Dashcam != null)
			{
				Dashcam.Frame += Dashcam_Frame;

				Dashcam.Start();
			}
		}

		private void StartMonikerString(string M) => Start(DashcamManager.Dashcams.Where(x => x.MonikerString == M).FirstOrDefault());

		private void StartName(string N) => Start(DashcamManager.Dashcams.Where(x => x.Name == N).FirstOrDefault());

		private void Stop(Dashcam D)
		{
			if (D == null) return;

			if (D != Dashcam) return;

			D.Stop();

			D.Frame -= Dashcam_Frame;

			Dashcam = null;

			Frame = null;

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BitsPerFrame"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BitsPerPixel"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BytesPerFrame"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Frame"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameAspectRatio"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameHeight"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FramePixels"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameRateAverage"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameRateMax"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameSize"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameWidth"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MonikerString"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceivedBytes"));

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceivedFrames"));
		}

		#endregion

		#region Properties

		public int BitsPerFrame => Dashcam?.BitsPerFrame ?? 0;

		public int BitsPerPixel => Dashcam?.BitsPerPixel ?? 0;

		public int BytesPerFrame => Dashcam?.BytesPerFrame ?? 0;

		public ImageSource Frame { get; private set; }

		public double FrameAspectRatio => Dashcam?.FrameAspectRatio ?? 0.0;

		public int FrameHeight => Dashcam?.FrameHeight ?? 0;

		public int FramePixels => Dashcam?.FramePixels ?? 0;

		public int FrameRateAverage => Dashcam?.FrameRateAverage ?? 0;

		public int FrameRateMax => Dashcam?.FrameRateMax ?? 0;

		public Size FrameSize => Dashcam?.FrameSize ?? Size.Empty;

		public int FrameWidth => Dashcam?.FrameWidth ?? 0;

		public string MonikerString => Dashcam?.MonikerString;

		public string Name
		{
			get => Dashcam?.Name ?? "None";
			set
			{
				lock (Sync)
				{
					StartName(value);
				}
			}
		}

		public List<string> Names
		{
			get
			{
				var L1 = new List<string>();

				var L2 = DashcamManager.Dashcams.Select(x => x.Name);

				L1.Add("None");

				L1.AddRange(L2);

				return L1;
			}
		}

		public long ReceivedBytes => Dashcam?.ReceivedBytes ?? 0L;

		public int ReceivedFrames => Dashcam?.ReceivedFrames ?? 0;

		#endregion
	}
}
