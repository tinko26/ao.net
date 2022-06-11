﻿// MIT License

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
using System.Collections.Generic;
using System.Linq;

namespace Ao.Can
{
    public sealed class CANStatExtendedData
    {
        #region Methods

        public void Add(Time T, CAN C)
        {
            var i = C.XID;

            if (!Data.ContainsKey(i))
            {
                Data[i] = new CANStatData();

                Time[i] = new CANStatTime();
            }

            Data[i].Add(T, C);

            Time[i].Add(T);
        }

        #endregion

        #region Properties

        public Dictionary<uint, CANStatData> Data { get; } = new Dictionary<uint, CANStatData>();

        public IEnumerable<uint> EID => XID.Select(x => x & 0x3FFFFU).Distinct();

        public IEnumerable<uint> SID => XID.Select(x => (x >> 18) & 0x7FFU).Distinct();

        public Dictionary<uint, CANStatTime> Time { get; } = new Dictionary<uint, CANStatTime>();

        public IEnumerable<uint> XID => Data.Keys;

        #endregion
    }
}
