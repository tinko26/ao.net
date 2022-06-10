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
	public struct PGN : 
		IComparable<PGN>, 
		IEquatable<PGN>
	{
		#region Methods

		public int CompareTo(PGN x) => Value.CompareTo(x.Value);

		public bool Equals(PGN x) => this == x;

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is PGN)) return false;

			var y = (PGN)x;

			return this == y;
		}

		public override int GetHashCode() => Value.GetHashCode();

		#endregion

		#region Operators

		public static bool operator ==(PGN x, PGN y) => x.Value == y.Value;

		public static bool operator !=(PGN x, PGN y) => x.Value != y.Value;

		public static bool operator <(PGN x, PGN y) => x.Value < y.Value;

		public static bool operator <=(PGN x, PGN y) => x.Value <= y.Value;

		public static bool operator >(PGN x, PGN y) => x.Value > y.Value;

		public static bool operator >=(PGN x, PGN y) => x.Value >= y.Value;

		#endregion

		#region Properties

		public DataPage DataPage { get; set; }

		public DataPage DataPageExtended { get; set; }

		public bool IsBroadcast => PF >= 0xF0;

		public bool IsProprietary => PF == 0xEF || PF == 0xFF;

		public bool IsStandard => !IsProprietary;

		public bool IsUnicast => !IsBroadcast;

		public byte PF { get; set; }

		public byte PS { get; set; }

		public uint Value
		{
			get
			{
				var X = 0U;

				X.SetBits(17, 1, (uint)DataPageExtended);

				X.SetBits(16, 1, (uint)DataPage);

				X.SetBits(8, 8, PF);

				if (IsBroadcast)
				{
					X.SetBits(0, 8, PS);
				}

				return X;
			}
			set
			{
				DataPageExtended = (DataPage)value.GetBits(17, 1);

				DataPage = (DataPage)value.GetBits(16, 1);

				PF = (byte)value.GetBits(8, 8);

				if (IsBroadcast)
				{
					PS = (byte)value.GetBits(0, 8);
				}

				else
				{
					PS = 0;
				}
			}
		}

		#endregion
	}
}
