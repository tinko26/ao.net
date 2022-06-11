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

#include "MultimediaTimer.h"

namespace Ao
{
    namespace Timing
    {
        namespace Win32
        {
            VOID CALLBACK MultimediaTimerOneShotCallback
            (
                UINT id,
                UINT reserved1,
                DWORD_PTR reserved2,
                DWORD_PTR reserved3,
                DWORD_PTR reserved4
            );

            public ref class MultimediaTimerOneShot sealed
            {

            public:

                MultimediaTimerOneShot(System::Func<Ao::Measurements::Time>^ t)
                {
                    if (t == nullptr) throw gcnew System::ArgumentNullException();

                    timestamp = t;
                }

            private:

                UINT delay = 0;

                UINT id = 0;

                UINT resolution = MultimediaTimer::MaxResolutionMs;

                UINT resolutionBegun;

                initonly System::Func<Ao::Measurements::Time>^ timestamp;

            private:

                static initonly System::Collections::Generic::Dictionary<UINT, MultimediaTimerOneShot^>^ Instances = gcnew System::Collections::Generic::Dictionary<UINT, MultimediaTimerOneShot^>();

                static initonly System::Object^ InstancesSync = gcnew System::Object();

            private:

                void Callback()
                {
                    Stop();

                    Elapsed(this, gcnew TimerEventArgs(Now));
                }

                void Stop()
                {
                    InstancesRemove(id);

                    ::timeEndPeriod(resolutionBegun);

                    id = 0;
                }

            private:

                static void InstancesAdd(UINT id, MultimediaTimerOneShot^ x)
                {
                    ::msclr::lock lock(InstancesSync);

                    if (x != nullptr)
                    {
                        Instances[id] = x;
                    }
                }

                static MultimediaTimerOneShot^ InstancesGet(UINT id)
                {
                    ::msclr::lock lock(InstancesSync);

                    if (Instances->ContainsKey(id))
                    {
                        return Instances[id];
                    }

                    else
                    {
                        return nullptr;
                    }
                }

                static void InstancesRemove(UINT id)
                {
                    ::msclr::lock lock(InstancesSync);

                    Instances->Remove(id);
                }

            internal:

                static void InstancesCallback(UINT id)
                {
                    MultimediaTimerOneShot^ x = InstancesGet(id);

                    if (x != nullptr)
                    {
                        x->Callback();
                    }
                }

            public:

                void Start()
                {
                    if (id == 0)
                    {
                        UINT r = resolution;

                        UINT b = ::timeBeginPeriod(r);

                        if (TIMERR_NOERROR == b)
                        {
                            resolutionBegun = r;

                            id = ::timeSetEvent
                            (
                                delay,
                                r,
                                MultimediaTimerOneShotCallback,
                                NULL,
                                TIME_CALLBACK_FUNCTION |
                                TIME_ONESHOT
                            );

                            if (id == 0)
                            {
                                ::timeEndPeriod(r);
                            }

                            else
                            {
                                InstancesAdd(id, this);
                            }
                        }
                    }
                }

            public:

                event TimerEventHandler^ Elapsed;

            public:

                property Ao::Measurements::Time Delay
                {
                    Ao::Measurements::Time get()
                    {
                        Ao::Measurements::Time x;

                        x.Milliseconds = DelayMs;

                        return x;
                    }
                    void set(Ao::Measurements::Time x)
                    {
                        DelayMs = static_cast<UINT>(x.Milliseconds);
                    }
                }

                property UINT DelayMs
                {
                    UINT get()
                    {
                        return delay;
                    }
                    void set(UINT x)
                    {
                        x = System::Math::Min(x, MultimediaTimer::MaxDelayMs);

                        x = System::Math::Max(x, MultimediaTimer::MinDelayMs);

                        delay = x;
                    }
                }

                property bool IsRunning
                {
                    bool get() { return id != 0; }
                }

                property Ao::Measurements::Time Now
                {
                    Ao::Measurements::Time get() { return timestamp(); }
                }

                property Ao::Measurements::Time Resolution
                {
                    Ao::Measurements::Time get()
                    {
                        Ao::Measurements::Time x;

                        x.Milliseconds = ResolutionMs;

                        return x;
                    }
                    void set(Ao::Measurements::Time x)
                    {
                        ResolutionMs = static_cast<UINT>(x.Milliseconds);
                    }
                }

                property UINT ResolutionMs
                {
                    UINT get()
                    {
                        return resolution;
                    }
                    void set(UINT x)
                    {
                        x = System::Math::Min(x, MultimediaTimer::MaxResolutionMs);

                        x = System::Math::Max(x, MultimediaTimer::MinResolutionMs);

                        resolution = x;
                    }
                }

                property System::Func<Ao::Measurements::Time>^ Timestamp
                {
                    System::Func<Ao::Measurements::Time>^ get() { return timestamp; }
                }

            };
        }
    }
}
