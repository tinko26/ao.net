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

using AForge.Video.DirectShow;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace Ao.Dash
{
	public static class DashcamManager
	{
		#region Events

		public static event DashcamEventHandler DashcamConnected;

		public static event DashcamEventHandler DashcamDisconnected;

		#endregion

		#region Fields

		private static readonly Dictionary<string, Dashcam> dashcams = new Dictionary<string, Dashcam>();

		private static HashSet<string> dashcamsConnected = new HashSet<string>();

		private static readonly object Sync = new object();

		private static readonly ManagementEventWatcher Watcher = new ManagementEventWatcher
		{
			Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3")
		};

		#endregion

		#region Initialization

		static DashcamManager()
		{
			Watcher.EventArrived += Watcher_EventArrived;

			Watcher.Start();

			Update();
		}

		#endregion

		#region Methods (Private)

		private static void Update()
		{
			lock (Sync)
			{
				var D1 = dashcamsConnected;

				var D2 = new HashSet<string>();

				var D3 = new HashSet<string>();

				var F = new FilterInfoCollection(FilterCategory.VideoInputDevice);

				var N = F.Count;

				for (var I = 0; I < N; I++)
				{
					var M = F[I].MonikerString;

					if (D1.Contains(M))
					{
						D1.Remove(M);
					}

					else
					{
						D2.Add(M);

						if (!dashcams.ContainsKey(M))
						{
							dashcams[M] = new Dashcam(M, F[I].Name);
						}
					}

					D3.Add(M);
				}

				dashcamsConnected = D3;

				Dashcams = dashcams.Where(x => dashcamsConnected.Contains(x.Key)).Select(x => x.Value).ToList();

				foreach (var M in D1) DashcamDisconnected?.Invoke(null, new DashcamEventArgs(dashcams[M]));

				foreach (var M in D2) DashcamConnected?.Invoke(null, new DashcamEventArgs(dashcams[M]));
			}
		}

		private static void Watcher_EventArrived(object sender, EventArrivedEventArgs e) => Update();

		#endregion

		#region Properties

		public static List<Dashcam> Dashcams { get; private set; }

		#endregion
	}
}
