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

namespace Ao.J1939
{
	public enum FMI
	{
		AboveNormal = 0,

		BelowNormal = 1,

		DataErratic = 2,

		VoltageAboveNormal = 3,

		VoltageBelowNormal = 4,

		CurrentAboveNormal = 5,

		CurrentBelowNormal = 6,

		MechanicalSystemNotResponding = 7,

		AbnormalFrequency = 8,

		AbnormalUpdateRate = 9,

		AbnormalRateOfChange = 10,

		RootCause = 11,

		BadDevice = 12,

		Calibration = 13,

		SpecialInstructions = 14,

		AboveNormalLeast = 15,

		AboveNormalModerate = 16,

		BelowNormalLeast = 17,

		BelowNormalModerate = 18,

		ReceiverNetworkDataInError = 19,

		DataDriftedHigh = 20,

		DataDriftedLow = 21,

		FMI22 = 22,

		FMI23 = 23,

		FMI24 = 24,

		FMI25 = 25,

		FMI26 = 26,

		FMI27 = 27,

		FMI28 = 28,

		FMI29 = 29,

		FMI30 = 30,

		ConditionExists = 31
	}
}
