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
	public sealed class TD : PG
	{
		#region Fields

		private ulong data;

		#endregion

		#region Properties

		public override string Acronym => "TD";

		public override byte[] Data 
		{ 
			get
			{
				var B = BitConverter.GetBytes(data);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				return B;
			}
			set
			{
				var B = value;

				B.Resize(8);

				if (!BitConverter.IsLittleEndian)
				{
					B = B.Reverse();
				}

				data = BitConverter.ToUInt64(B, 0);
			}
		}

		public override int DataLength => 8;

		public override DataPage DataPage => DataPage.DataPage0;

		public override DataPage DataPageExtended => DataPage.DataPage0;

		public DateTime DateTime
		{
			get => new DateTime(Year, Month, Day, Hour, Minute, Second, Millisecond);
			set
			{
				Year = value.Year;

				Month = value.Month;

				Day = value.Day;

				Hour = value.Hour;

				Minute = value.Minute;

				Second = value.Second;

				Millisecond = value.Millisecond;
			}
		}

		public int Day
		{
			get => ((int)data.GetBits(32, 8) + 3) / 4;
			set
			{
				var T1 = (ulong)(value * 4);

				var T2 = data;

				T2.SetBits(32, 8, T1);

				data = T2;
			}
		}

		public override byte GroupExtension => 0xE6;

		public int Hour
		{
			get => (int)data.GetBits(16, 8);
			set
			{
				var T1 = (ulong)value;

				var T2 = data;

				T2.SetBits(16, 8, T1);

				data = T2;
			}
		}

		public override bool IsDataLengthVariable => false;

		public override bool IsMultipacket => false;

		public TDKind Kind
		{
			get
			{
				var T = data.GetBits(56, 8);

				if (T == 0xFAUL)
				{
					return TDKind.Local;
				}

				else if (T == 0xF9UL)
				{
					return TDKind.UtcWithoutLocalOffset;
				}

				else
				{
					return TDKind.UtcWithLocalOffset;
				}
			}
			set
			{
				var T1 = data;

				if (value == TDKind.Local)
				{
					T1.SetBits(56, 8, 0xFAUL);
				}

				else if (value == TDKind.UtcWithoutLocalOffset)
				{
					T1.SetBits(56, 8, 0xF9UL);
				}

				else
				{
					var T2 = (int)T1.GetBits(56, 8) - 125;

					if (T2 < -23 || T2 > 23)
					{
						T1.SetBits(56, 8, 125UL);
					}

					var T3 = (int)T1.GetBits(48, 8) - 125;

					if (T3 < -59 || T3 > 59)
					{
						T1.SetBits(48, 8, 125UL);
					}
				}

				data = T1;
			}
		}

		public override string Label => "Time/Date";

		public int LocalHourOffset
		{
			get
			{
				var T = data.GetBits(56, 8);

				switch (T)
				{
					case 0xFAUL:
					case 0xF9UL:

						return 0;

					default:

						return (int)T - 125;
				}
			}
			set
			{
				var T1 = (ulong)(value + 125);

				var T2 = data;

				T2.SetBits(56, 8, T1);

				data = T2;
			}
		}

		public int LocalMinuteOffset
		{
			get => (int)data.GetBits(48, 8) - 125;
			set
			{
				var T1 = (ulong)(value + 125);

				var T2 = data;

				T2.SetBits(48, 8, T1);

				data = T2;
			}
		}

		public int Millisecond
		{
			get => (int)data.GetBits(0, 2) * 250;
			set
			{
				var T1 = (ulong)value / 250;

				var T2 = data;

				T2.SetBits(0, 2, T1);

				data = T2;
			}
		}

		public int Minute
		{
			get => (int)data.GetBits(8, 8);
			set
			{
				var T1 = (ulong)value;

				var T2 = data;

				T2.SetBits(8, 8, T1);

				data = T2;
			}
		}

		public int Month
		{
			get => (int)data.GetBits(24, 8);
			set
			{
				var T1 = (ulong)value;

				var T2 = data;

				T2.SetBits(24, 8, T1);

				data = T2;
			}
		}

		public override byte PF => 0xFE;

		public int Second
		{
			get => (int)data.GetBits(2, 6);
			set
			{
				var T1 = (ulong)value;

				var T2 = data;

				T2.SetBits(2, 6, T1);

				data = T2;
			}
		}

		public int Year
		{
			get => (int)data.GetBits(40, 8) + 1985;
			set
			{
				var T1 = (ulong)(value - 1985);

				var T2 = data;

				T2.SetBits(40, 8, T1);

				data = T2;
			}
		}

		#endregion
	}
}
