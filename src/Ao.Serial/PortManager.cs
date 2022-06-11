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
using System.IO.Ports;
using System.Management;

namespace Ao.Serial
{
    public static class PortManager
    {
        #region Events

        public static event PortEventHandler PortConnected;

        public static event PortEventHandler PortDisconnected;

        #endregion

        #region Fields

        private static readonly object Sync = new object();

        private static readonly ManagementEventWatcher Watcher;

        #endregion

        #region Initialization

        static PortManager()
        {
            Watcher = new ManagementEventWatcher();

            Watcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");

            Watcher.EventArrived += Update;

            Watcher.Start();

            Update();
        }

        #endregion

        #region Methods

        private static void Update()
        {
            lock (Sync)
            {
                var P1 = new HashSet<string>(Ports);

                var P2 = new HashSet<string>();

                var P3 = SerialPort.GetPortNames();

                foreach (var x in P3)
                {
                    if (P1.Contains(x))
                    {
                        P1.Remove(x);
                    }

                    else
                    {
                        P2.Add(x);
                    }
                }

                Ports = new HashSet<string>(P3);

                foreach (var x in P1) PortDisconnected?.Invoke(null, new PortEventArgs(x));

                foreach (var x in P2) PortConnected?.Invoke(null, new PortEventArgs(x));
            }
        }

        private static void Update(object sender, EventArrivedEventArgs e) => Update();

        #endregion

        #region Properties

        public static HashSet<string> Ports { get; private set; } = new HashSet<string>();

        #endregion
    }
}
