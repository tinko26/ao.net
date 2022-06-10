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

#pragma once

#include "Include.h"

#include "PerformanceCount.h"

namespace Ao
{
	namespace Timing
	{
		namespace Win32
		{
			public ref class Performance abstract sealed
			{
				private:

				static Performance()
				{
					Ao::Measurements::Frequency f;

					LARGE_INTEGER t;

					IsSupported = ::QueryPerformanceFrequency(&t) != FALSE;

					f.Hertz = IsSupported ? (double)t.QuadPart : 0;

					Frequency = f;
				}

				public:

				static initonly Ao::Measurements::Frequency Frequency;

				static initonly bool IsSupported;

				public:

				static property PerformanceCount Count
				{
					PerformanceCount get()
					{
						LARGE_INTEGER pc;

						::QueryPerformanceCounter(&pc);

						return PerformanceCount(pc.QuadPart);
					}
				}

			};
		}
	}
}
