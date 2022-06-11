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

namespace Ao.J1939
{
    public sealed class TPDT : PG
    {
        public override string Acronym => "TP.DT";

        public override byte[] Data
        {
            get
            {
                var B = new byte[8];

                B[0] = SequenceNumber;

                B[1] = PacketizedData0;
                B[2] = PacketizedData1;
                B[3] = PacketizedData2;
                B[4] = PacketizedData3;
                B[5] = PacketizedData4;
                B[6] = PacketizedData5;
                B[7] = PacketizedData6;

                return B;
            }
            set
            {
                var B = value;

                B = B.Resize(8);

                SequenceNumber = B[0];

                PacketizedData0 = B[1];
                PacketizedData1 = B[2];
                PacketizedData2 = B[3];
                PacketizedData3 = B[4];
                PacketizedData4 = B[5];
                PacketizedData5 = B[6];
                PacketizedData6 = B[7];
            }
        }

        public override int DataLength => 8;

        public override DataPage DataPage => DataPage.DataPage0;

        public override DataPage DataPageExtended => DataPage.DataPage0;

        public override byte GroupExtension => 0;

        public override bool IsDataLengthVariable => false;

        public override bool IsMultipacket => false;

        public override string Label => "Transport Protocol - Data Transfer";

        public byte[] PacketizedData
        {
            get => new byte[7]
            {
                PacketizedData0,
                PacketizedData1,
                PacketizedData2,
                PacketizedData3,
                PacketizedData4,
                PacketizedData5,
                PacketizedData6
            };
            set
            {
                var B = value.Resize(7);

                PacketizedData0 = B[0];
                PacketizedData1 = B[1];
                PacketizedData2 = B[2];
                PacketizedData3 = B[3];
                PacketizedData4 = B[4];
                PacketizedData5 = B[5];
                PacketizedData6 = B[6];
            }
        }

        public byte PacketizedData0 { get; set; }

        public byte PacketizedData1 { get; set; }

        public byte PacketizedData2 { get; set; }

        public byte PacketizedData3 { get; set; }

        public byte PacketizedData4 { get; set; }

        public byte PacketizedData5 { get; set; }

        public byte PacketizedData6 { get; set; }

        public override byte PF => 0xEB;

        public byte SequenceNumber { get; set; }
    }
}
