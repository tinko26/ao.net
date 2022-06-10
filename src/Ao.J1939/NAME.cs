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
	public struct NAME : 
		IComparable<NAME>, 
		IEquatable<NAME>
	{
		#region Fields

		private ulong value;

		#endregion

		#region Methods

		public int CompareTo(NAME x) => value.CompareTo(x.value);

		public bool Equals(NAME x) => this == x;

		#endregion

		#region Methods (Override)

		public override bool Equals(object x)
		{
			if (x == null) return false;

			if (!(x is NAME)) return false;

			var y = (NAME)x;

			return this == y;
		}

		public override int GetHashCode() => value.GetHashCode();

		#endregion

		#region Operators

		public static bool operator ==(NAME x, NAME y) => x.value == y.value;

		public static bool operator !=(NAME x, NAME y) => x.value != y.value;

		public static bool operator <(NAME x, NAME y) => x.value < y.value;

		public static bool operator <=(NAME x, NAME y) => x.value <= y.value;

		public static bool operator >(NAME x, NAME y) => x.value > y.value;

		public static bool operator >=(NAME x, NAME y) => x.value >= y.value;

		#endregion

		#region Properties

		public bool ArbitraryAddressCapable
		{
			get => value.GetBits(63, 1) == 1UL;
			set
			{
				this.value.SetBits(63, 1, value ? 1UL : 0UL);
			}
		}

		public int ECUInstance
		{
			get => (int)value.GetBits(32, 3);
			set
			{
				this.value.SetBits(32, 3, (ulong)value);
			}
		}

		public int Function
		{
			get => (int)value.GetBits(40, 8);
			set
			{
				this.value.SetBits(40, 8, (ulong)value);
			}
		}

		public int FunctionInstance
		{
			get => (int)value.GetBits(35, 5);
			set
			{
				this.value.SetBits(35, 5, (ulong)value);
			}
		}

		public int ID
		{
			get => (int)value.GetBits(0, 21);
			set
			{
				this.value.SetBits(0, 21, (ulong)value);
			}
		}

		public int Industry
		{
			get => (int)value.GetBits(60, 3);
			set
			{
				this.value.SetBits(60, 3, (ulong)value);
			}
		}

		public int Manufacturer
		{
			get => (int)value.GetBits(21, 11);
			set
			{
				this.value.SetBits(21, 11, (ulong)value);
			}
		}

		public ulong Value
		{
			get => value;
			set
			{
				this.value = value & 0xFFFEFFFFFFFFFFFFUL;
			}
		}

		public int VehicleSystem
		{
			get => (int)value.GetBits(49, 7);
			set
			{
				this.value.SetBits(49, 7, (ulong)value);
			}
		}

		public int VehicleSystemInstance
		{
			get => (int)value.GetBits(56, 4);
			set
			{
				this.value.SetBits(56, 4, (ulong)value);
			}
		}

		#endregion
	}
}
