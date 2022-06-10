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

namespace Ao.J1939
{
	public sealed class RQST : PG
	{
		public override string Acronym => "RQST";

		public override byte[] Data
		{
			get
			{
				var B = BitConverter.GetBytes(RequestedPGN.Value);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				return B.Resize(3);
			}
			set
			{
				var B = value;

				B = B.Resize(3);

				B = B.Resize(4);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				RequestedPGN = new PGN
				{
					Value = BitConverter.ToUInt32(B, 0)
				};
			}
		}

		public override int DataLength => 3;

		public override DataPage DataPage => DataPage.DataPage0;

		public override DataPage DataPageExtended => DataPage.DataPage0;

		public override byte GroupExtension => 0;

		public override bool IsDataLengthVariable => false;

		public override bool IsMultipacket => false;

		public override string Label => "Request";

		public override byte PF => 0xEA;

		public PGN RequestedPGN { get; set; }
	}
}
