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
	public sealed class CA : PG
	{
		public override string Acronym => "CA";

		public byte Address { get; set; }

		public override byte[] Data
		{
			get
			{
				var B = BitConverter.GetBytes(NAME.Value);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				B = B.Resize(9);

				B[8] = Address;

				return B;
			}
			set
			{
				var B = value;

				B = B.Resize(9);

				Address = B[8];

				B = B.Resize(8);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				NAME = new NAME
				{
					Value = BitConverter.ToUInt64(B, 0)
				};
			}
		}

		public override int DataLength => 9;

		public override DataPage DataPage => DataPage.DataPage0;

		public override DataPage DataPageExtended => DataPage.DataPage0;

		public override byte GroupExtension => 0xD8;

		public override bool IsDataLengthVariable => false;

		public override bool IsMultipacket => true;

		public override string Label => "Commanded Address";

		public NAME NAME { get; set; }

		public override byte PF => 0xFE;
	}
}
