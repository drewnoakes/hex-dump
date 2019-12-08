// Copyright (c) Drew Noakes. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Linq;
using Xunit;

namespace HexDump.Tests
{
    public class HexDumpTests
    {
        [Fact]
        public void Defaults()
        {
            Assert.Throws<ArgumentNullException>(() => HexDump.Format(null));

            Assert.Equal("", HexDump.Format(Array.Empty<byte>()));

            Assert.Equal("0000    61 62 63 64 65 66                                   abcdef           ", HexDump.Format(ByteSequence('a', 6)));
            Assert.Equal("0000    61 62 63 64 65 66 67 68  69 6A 6B 6C 6D 6E 6F 70    abcdefgh ijklmnop", HexDump.Format(ByteSequence('a', 16)));
            
            Assert.Equal(
                "0000    61 62 63 64 65 66 67 68  69 6A 6B 6C 6D 6E 6F 70    abcdefgh ijklmnop" + Environment.NewLine +
                "0010    71 72 73 74 75 76 77 78  79 7A                      qrstuvwx yz      ",
                HexDump.Format(ByteSequence('a', 26)));

            Assert.Equal(
                "0000    61 62 63 64 65 66 67 68  69 6A 6B 6C 6D 6E 6F 70" + Environment.NewLine +
                "0010    71 72 73 74 75 76 77 78  79 7A                  ",
                HexDump.Format(ByteSequence('a', 26), includeAscii: false));

            Assert.Equal(
                "61 62 63 64 65 66 67 68  69 6A 6B 6C 6D 6E 6F 70    abcdefgh ijklmnop" + Environment.NewLine +
                "71 72 73 74 75 76 77 78  79 7A                      qrstuvwx yz      ",
                HexDump.Format(ByteSequence('a', 26), includeOffset: false));

            Assert.Equal(
                "61 62 63 64 65 66 67 68  69 6A 6B 6C 6D 6E 6F 70" + Environment.NewLine +
                "71 72 73 74 75 76 77 78  79 7A                  ",
                HexDump.Format(ByteSequence('a', 26), includeOffset: false, includeAscii: false));
        }

        private static byte[] ByteSequence(char from, int count)
        {
            return Enumerable.Range(from, count).Select(i => (byte)i).ToArray();
        }
    }
}
