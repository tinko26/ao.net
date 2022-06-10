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
using System;

namespace Ao.J1939
{
	public sealed class ACKM : PG
	{
		#region Fields

		private ulong Value;

		#endregion

		#region Properties

		public override string Acronym => "ACKM";

		public byte Address
		{
			get => (byte)Value.GetBits(32, 8);
			set
			{
				var T = Value;

				T.SetBits(32, 8, value);

				Value = T;
			}
		}

		public override byte[] Data 
		{ 
			get
			{
				var B = BitConverter.GetBytes(Value);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				return B;
			}
			set
			{
				var B = value;

				B = B.Resize(8);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				Value = BitConverter.ToUInt64(B, 0);
			}
		}

		public override int DataLength => 8;

		public override DataPage DataPage => DataPage.DataPage0;

		public override DataPage DataPageExtended => DataPage.DataPage0;

		public override byte GroupExtension => 0;

		public byte GroupFunction
		{
			get => (byte)Value.GetBits(8, 8);
			set
			{
				var T = Value;

				T.SetBits(8, 8, value);

				Value = T;
			}
		}

		public override bool IsDataLengthVariable => false;

		public override bool IsMultipacket => false;

		public override string Label => "Acknowledgement";

		public override byte PF => 0xE8;

		public PGN RequestedPGN
		{
			get
			{
				return new PGN 
				{ 
					Value = (uint)Value.GetBits(40, 24) 
				};
			}
			set
			{
				var T = Value;

				T.SetBits(40, 24, value.Value);

				Value = T;
			}
		}

		public ACKMResult Result
		{
			get => (ACKMResult)Value.GetBits(0, 8);
			set
			{
				var T = Value;

				T.SetBits(0, 8, (ulong)value);

				Value = T;
			}
		}

		#endregion
	}
}
