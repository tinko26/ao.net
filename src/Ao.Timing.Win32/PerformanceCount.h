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
			public value struct PerformanceCount : 
				public System::IComparable<PerformanceCount>,
				public System::IEquatable<PerformanceCount>
			{
				public:

				PerformanceCount(long long value)
				{
					this->value = value;
				}

				private:

				long long value;

				public:

				virtual int CompareTo(PerformanceCount x)
				{
					if (*this < x)
					{
						return -1;
					}

					else if (*this > x)
					{
						return 1;
					}

					else
					{
						return 0;
					}
				}

				virtual bool Equals(PerformanceCount x)
				{
					return *this == x;
				}

				virtual bool Equals(System::Object^ x) override
				{
					if (x == nullptr) return false;

					if (x->GetType() != PerformanceCount::typeid) return false;

					PerformanceCount y = safe_cast<PerformanceCount>(x);

					return *this == y;
				}

				virtual int GetHashCode() override
				{
					return value.GetHashCode();
				}

				public:

				static bool operator ==(PerformanceCount a, PerformanceCount b) { return a.value == b.value; }

				static bool operator !=(PerformanceCount a, PerformanceCount b) { return a.value != b.value; }

				static bool operator >(PerformanceCount a, PerformanceCount b) { return a.value > b.value; }

				static bool operator >=(PerformanceCount a, PerformanceCount b) { return a.value >= b.value; }

				static bool operator <(PerformanceCount a, PerformanceCount b) { return a.value < b.value; }

				static bool operator <=(PerformanceCount a, PerformanceCount b) { return a.value <= b.value; }

				public:

				property long long Value
				{
					long long get() 
					{ 
						return value; 
					}
					void set(long long x)
					{
						value = x;
					}
				}

				property Ao::Measurements::Time Time
				{
					Ao::Measurements::Time get();
				}

			};
		}
	}
}