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

namespace Ao
{
    namespace Timing
    {
        namespace Win32
        {
            public ref class MultimediaTimer abstract sealed
            {

            private:

                static MultimediaTimer()
                {
                    TIMECAPS caps;

                    UINT result = ::timeGetDevCaps(&caps, sizeof(TIMECAPS));

                    if (result != TIMERR_NOERROR)
                    {
                        MinResolutionMs = 0;
                        MaxResolutionMs = 0;
                    }

                    else
                    {
                        MinResolutionMs = caps.wPeriodMin;
                        MaxResolutionMs = caps.wPeriodMax;
                    }

                    Ao::Measurements::Time t;

                    t.Milliseconds = MaxDelayMs; MaxDelay = t;
                    t.Milliseconds = MinDelayMs; MinDelay = t;

                    t.Milliseconds = MaxResolutionMs; MaxResolution = t;
                    t.Milliseconds = MinResolutionMs; MinResolution = t;
                }

            public:

                static initonly Ao::Measurements::Time MaxDelay;

                static initonly Ao::Measurements::Time MaxResolution;

                static initonly Ao::Measurements::Time MinDelay;

                static initonly Ao::Measurements::Time MinResolution;

            public:

                static initonly UINT MaxDelayMs = UINT::MaxValue;

                static initonly UINT MaxResolutionMs;

                static initonly UINT MinDelayMs = 0;

                static initonly UINT MinResolutionMs;

            };
        }
    }
}
