using System;
using System.Collections.Generic;

namespace Datr.Test.Objects
{
    public class ValuesClass
    {
        public TestEnum TestEnum { get; set; }
        public string String { get; set; }
        public DateTime DateTime { get; set; }
        public bool Bool { get; set; }
        public sbyte SByte { get; set; }
        public byte Byte { get; set; }
        public short Short { get; set; }
        public ushort UShort { get; set; }
        public char Char { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }
        public uint UInt { get; set; }
        public long Long { get; set; }
        public ulong ULong { get; set; }
        public decimal Decimal { get; set; }
        public int Int { get; set; }
        public int[] IntArray { get; set; }
        public string[] StringArray { get; set; }
        public List<int> IntList { get; set; }
    }

    public enum TestEnum
    {
        Zero = 0,
        One = 1,
        Twenty = 20,
        OneHundred = 100
    }
}
