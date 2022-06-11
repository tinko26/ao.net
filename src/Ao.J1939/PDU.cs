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

using Ao.Bits;
using Ao.Can;

namespace Ao.J1939
{
    public struct PDU
    {
        public CAN CAN => new CAN
        {
            Data = CANData,

            DLC = 8,

            EID = CANEID,

            IDE = true,

            RTR = false,

            SID = CANSID
        };

        public ulong CANData { get; set; }

        public uint CANEID
        {
            get
            {
                var X = 0U;

                X.SetBits(16, 2, PF);

                X.SetBits(8, 8, PS);

                X.SetBits(0, 8, SourceAddress);

                return X;
            }
            set
            {
                var T0 = value.GetBits(16, 2);

                var T1 = (uint)PF;

                T1.SetBits(0, 2, T0);

                PF = (byte)T1;

                PS = (byte)value.GetBits(8, 8);

                SourceAddress = (byte)value.GetBits(0, 8);
            }
        }

        public uint CANSID
        {
            get
            {
                var X = 0U;

                X.SetBits(8, 3, (uint)Priority);

                X.SetBits(7, 1, (uint)DataPageExtended);

                X.SetBits(6, 1, (uint)DataPage);

                X.SetBits(0, 6, PF.GetBits(2, 6));

                return X;
            }
            set
            {
                Priority = (Priority)value.GetBits(8, 3);

                DataPageExtended = (DataPage)value.GetBits(7, 1);

                DataPage = (DataPage)value.GetBits(6, 1);

                var T0 = value.GetBits(0, 6);

                var T1 = (uint)PF;

                T1.SetBits(2, 6, T0);

                PF = (byte)T1;
            }
        }

        public uint CANXID
        {
            get
            {
                var X = 0U;

                X.SetBits(26, 3, (uint)Priority);

                X.SetBits(25, 1, (uint)DataPageExtended);

                X.SetBits(24, 1, (uint)DataPage);

                X.SetBits(16, 8, PF);

                X.SetBits(8, 8, PS);

                X.SetBits(0, 8, SourceAddress);

                return X;
            }
            set
            {
                Priority = (Priority)value.GetBits(26, 3);

                DataPageExtended = (DataPage)value.GetBits(25, 1);

                DataPage = (DataPage)value.GetBits(24, 1);

                PF = (byte)value.GetBits(16, 8);

                PS = (byte)value.GetBits(8, 8);

                SourceAddress = (byte)value.GetBits(0, 8);
            }
        }

        public DataPage DataPage { get; set; }

        public DataPage DataPageExtended { get; set; }

        public bool IsBroadcast => PF >= 0xF0;

        public bool IsProprietary => PF == 0xEF || PF == 0xFF;

        public bool IsStandard => !IsProprietary;

        public bool IsUnicast => !IsBroadcast;

        public byte PF { get; set; }

        public PGN PGN
        {
            get => new PGN
            {
                DataPage = DataPage,

                DataPageExtended = DataPageExtended,

                PF = PF,

                PS = PS
            };
            set
            {
                DataPage = value.DataPage;

                DataPageExtended = value.DataPageExtended;

                PF = value.PF;

                PS = value.PS;
            }
        }

        public Priority Priority { get; set; }

        public byte PS { get; set; }

        public byte SourceAddress { get; set; }
    }
}
