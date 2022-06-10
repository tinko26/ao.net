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

#include "pch.h"

#include "Include.h"

#include "MultimediaTimerOneShot.h"
#include "MultimediaTimerPeriodic.h"

namespace Ao
{
	namespace Timing
	{
		namespace Win32
		{
			VOID CALLBACK MultimediaTimerOneShotCallback(UINT id, UINT reserved1, DWORD_PTR reserved2, DWORD_PTR reserved3, DWORD_PTR reserved4)
			{
				MultimediaTimerOneShot::InstancesCallback(id);
			}

			VOID CALLBACK MultimediaTimerPeriodicCallback(UINT id, UINT reserved1, DWORD_PTR reserved2, DWORD_PTR reserved3, DWORD_PTR reserved4)
			{
				MultimediaTimerPeriodic::InstancesCallback(id);
			}
		}
	}
}
