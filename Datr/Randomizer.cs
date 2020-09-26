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

        #region Fully Random
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
            var charCount = Math.Abs(Short());
            
            return new string(Enumerable.Repeat(chars, charCount).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        internal DateTime DateTime()
        {
            var ticks = Math.Abs(Long());
            return new DateTime(ticks);
        }

        private int NextInt32()
        {
            int firstBits = _random.Next(0, 1 << 4) << 28;
            int lastBits = _random.Next(0, 1 << 28);
            return firstBits | lastBits;
        }

        #endregion

        #region FixedRanges
        internal int FixedRangeInt(FixedRange range)
        {
            switch (range.Range)
            {
                case Range.GreaterThan:
                    return _random.Next((int)range.MinValue, int.MaxValue);
                case Range.LessThan:
                    return _random.Next(int.MinValue, (int)range.MaxValue);
                case Range.Between:
                    return _random.Next((int)range.MinValue, (int)range.MaxValue);
                case Range.Outside:
                    var min = _random.Next(int.MinValue, (int)range.MinValue);
                    var max = _random.Next((int)range.MaxValue, int.MaxValue);
                    return Bool() ? min : max;
                default:
                    throw new Exception("Error generating random integer within range");
            }
        }

        internal uint FixedRangeUInt(FixedRange range)
        {
            do
            {
                var num = UInt();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (uint)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (uint)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (uint)range.MinValue && num <= (uint)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (uint)range.MinValue || num > (uint)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random unsigned integer within range");
                }
            } while (true);
        }

        internal byte FixedRangeByte(FixedRange range)
        {
            do
            {
                var num = Byte();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (byte)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (byte)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (byte)range.MinValue && num <= (byte)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (byte)range.MinValue || num > (byte)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random byte within range");
                }
            } while (true);
        }

        internal sbyte FixedRangeSByte(FixedRange range)
        {
            do
            {
                var num = SByte();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (sbyte)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (sbyte)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (sbyte)range.MinValue && num <= (sbyte)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (sbyte)range.MinValue || num > (sbyte)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random signed byte within range");
                }
            } while (true);
        }

        internal short FixedRangeShort(FixedRange range)
        {
            do
            {
                var num = Short();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (short)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (short)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (short)range.MinValue && num <= (short)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (short)range.MinValue || num > (short)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random short within range");
                }
            } while (true);
        }

        internal ushort FixedRangeUShort(FixedRange range)
        {
            do
            {
                var num = UShort();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (ushort)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (ushort)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (ushort)range.MinValue && num <= (ushort)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (ushort)range.MinValue || num > (ushort)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random unsigned short within range");
                }
            } while (true);
        }

        internal decimal FixedRangeDecimal(FixedRange range)
        {
            do
            {
                var num = Decimal();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (decimal)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (decimal)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (decimal)range.MinValue && num <= (decimal)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (decimal)range.MinValue || num > (decimal)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random decimal within range");
                }
            } while (true);
        }

        internal double FixedRangeDouble(FixedRange range)
        {
            do
            {
                var num = Double();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (double)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (double)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (double)range.MinValue && num <= (double)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (double)range.MinValue || num > (double)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random double within range");
                }
            } while (true);
        }

        internal float FixedRangeFloat(FixedRange range)
        {
            do
            {
                var num = Float();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (float)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (float)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (float)range.MinValue && num <= (float)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (float)range.MinValue || num > (float)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random float within range");
                }
            } while (true);
        }

        internal long FixedRangeLong(FixedRange range)
        {
            do
            {
                var num = Long();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (long)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (long)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (long)range.MinValue && num <= (long)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (long)range.MinValue || num > (long)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random long within range");
                }
            } while (true);
        }

        internal ulong FixedRangeULong(FixedRange range)
        {
            do
            {
                var num = ULong();
                switch (range.Range)
                {
                    case Range.GreaterThan:
                        if (num >= (ulong)range.MinValue) return num;
                        break;

                    case Range.LessThan:
                        if (num <= (ulong)range.MaxValue) return num;
                        break;

                    case Range.Between:
                        if (num >= (ulong)range.MinValue && num <= (ulong)range.MaxValue) return num;
                        break;

                    case Range.Outside:
                        if (num < (ulong)range.MinValue || num > (ulong)range.MaxValue) return num;
                        break;

                    default:
                        throw new Exception("Error generating random unsigned long within range");
                }
            } while (true);
        }

        internal string FixedRangeString(FixedRange range)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 !\"£$%^&*()-=_+[]{};'#:@~,./<>?\\";
            int charCount = FixedRangeInt(range);

            return new string(Enumerable.Repeat(chars, charCount).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        #endregion
    }
}
