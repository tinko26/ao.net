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
using System.Globalization;

namespace Ao.Logging
{
    public class LogLine
    {
        #region Methods

        public string Print(bool X) => X ? "1" : "0";

        public string Print(byte X) => X.ToString();

        public string Print(decimal X) => X.ToString(Culture);

        public string Print(double X) => X.ToString(Culture);

        public string Print(Enum X) => X.ToString();

        public string Print(float X) => X.ToString(Culture);

        public string Print(int X) => X.ToString();

        public string Print(long X) => X.ToString();

        public string Print(params string[] X) => string.Join(Separator, X);

        public string Print(sbyte X) => X.ToString();

        public string Print(short X) => X.ToString();

        public string Print(string X) => X;

        public string Print(uint X) => X.ToString();

        public string Print(ulong X) => X.ToString();

        public string Print(ushort X) => X.ToString();

        #endregion

        #region Properties

        public CultureInfo Culture { get; set; } = new CultureInfo("de");

        public string Separator { get; set; } = ";";

        #endregion
    }
}
