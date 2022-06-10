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
	internal static class Extensions
	{
		public static Signal GetSignal(this byte X)
		{
			if (X < 0xFBU)
			{
				return Signal.Valid;
			}

			else if (X < 0xFCU)
			{
				return Signal.ParameterSpecificIndicator;
			}

			else if (X < 0xFEU)
			{
				return Signal.Reserved;
			}

			else if (X < 0xFFU)
			{
				return Signal.Error;
			}

			else
			{
				return Signal.NotAvailable;
			}
		}

		public static Signal GetSignal(this ushort X)
		{
			if (X < 0xFB00U)
			{
				return Signal.Valid;
			}

			else if (X < 0xFC00U)
			{
				return Signal.ParameterSpecificIndicator;
			}

			else if (X < 0xFE00U)
			{
				return Signal.Reserved;
			}

			else if (X < 0xFF00U)
			{
				return Signal.Error;
			}

			else
			{
				return Signal.NotAvailable;
			}
		}

		public static Signal GetSignal(this uint X)
		{
			if (X < 0xFB000000U)
			{
				return Signal.Valid;
			}

			else if (X < 0xFC000000U)
			{
				return Signal.ParameterSpecificIndicator;
			}

			else if (X < 0xFE000000U)
			{
				return Signal.Reserved;
			}

			else if (X < 0xFF000000U)
			{
				return Signal.Error;
			}

			else
			{
				return Signal.NotAvailable;
			}
		}

		public static byte[] Resize(this byte[] B1, int N2)
		{
			var B2 = new byte[N2];

			if (B1 != null)
			{
				var N1 = B1.Length;

				var N = Math.Min(N1, N2);

				for (var I = 0; I < N; I++)
				{
					B2[I] = B1[I];
				}
			}

			return B2;
		}

		public static byte[] Reverse(this byte[] B1)
		{
			if (B1 == null)
			{
				return null;
			}

			else
			{
				var N = B1.Length;

				var B2 = new byte[N];

				for (var I = 0; I < N; I++)
				{
					B2[I] = B1[N - 1 - I];
				}

				return B2;
			}
		}
	}
}
