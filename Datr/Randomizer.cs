using System;
using System.Linq;

namespace Datr
{
    internal class Randomizer
    {
        private readonly Random _random;

        internal Randomizer()
        {
            _random = new Random();
        }

        internal bool Bool() => _random.Next(2) == 1;
        internal int Int() => _random.Next(int.MinValue, int.MaxValue);
        internal sbyte SByte() => (sbyte)_random.Next(sbyte.MinValue, sbyte.MaxValue + 1);
        internal byte Byte() => (byte)_random.Next(byte.MinValue, byte.MaxValue + 1);
        internal short Short() => (short)_random.Next(short.MinValue, short.MaxValue + 1);
        internal ushort UShort() => (ushort)_random.Next(ushort.MinValue, ushort.MaxValue + 1);
        internal char Char() => (char)_random.Next(32, 591);
        internal double Double() => _random.NextDouble();
        internal float Float() => (float)_random.NextDouble();

        internal uint UInt()
        {
            var firstBits = (uint)_random.Next(0, 1 << 4) << 28;
            var lastBits = (uint)_random.Next(0, 1 << 28);
            return firstBits | lastBits;
        }

        internal long Long()
        {
            var firstBits = (long)_random.Next(0, 1 << 30) << 34;
            var midBits = (long)_random.Next(0, 1 << 30) << 4;
            var lastBits = (long)_random.Next(0, 1 << 4);
            return firstBits | midBits | lastBits;
        }

        internal ulong ULong()
        {
            var firstBits = (ulong)_random.Next(0, 1 << 30) << 34;
            var midBits = (ulong)_random.Next(0, 1 << 30) << 4;
            var lastBits = (ulong)_random.Next(0, 1 << 4);
            return firstBits | midBits | lastBits;
        }

        internal decimal Decimal()
        {
            var lo = NextInt32();
            var mid = NextInt32();
            var hi = NextInt32();
            var isNegative = Bool();
            var scale = (byte)_random.Next(29);

            return new decimal(lo, mid, hi, isNegative, scale);
        }

        internal string String()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 !\"£$%^&*()-=_+[]{};'#:@~,./<>?\\";
            return new string(Enumerable.Repeat(chars, 100)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private int NextInt32()
        {
            int firstBits = _random.Next(0, 1 << 4) << 28;
            int lastBits = _random.Next(0, 1 << 28);
            return firstBits | lastBits;
        }
    }
}
