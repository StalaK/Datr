using System;
using System.Linq;

namespace Datr;

internal class Randomizer
{
    private readonly Random _random;

    internal Randomizer()
    {
        _random = new Random();
    }

    internal bool Bool() => _random.Next(2) == 1;
    internal char Char() => (char)_random.Next(32, 591);

    internal int Int(FixedRange range = null) => range is null 
        ? _random.Next(int.MinValue, int.MaxValue)
        : FixedRangeInt(range);

    internal sbyte SByte(FixedRange range = null) => range is null
        ? (sbyte)_random.Next(sbyte.MinValue, sbyte.MaxValue + 1)
        : FixedRangeSByte(range);

    internal byte Byte(FixedRange range = null) => range is null
        ? (byte)_random.Next(byte.MinValue, byte.MaxValue + 1)
        : FixedRangeByte(range);

    internal short Short(FixedRange range = null) => range is null
        ? (short)_random.Next(short.MinValue, short.MaxValue + 1)
        : FixedRangeShort(range);

    internal ushort UShort(FixedRange range = null) => range is null
        ? (ushort)_random.Next(ushort.MinValue, ushort.MaxValue + 1)
        : FixedRangeUShort(range);

    internal double Double(FixedRange range = null) => range is null
        ? _random.NextDouble()
        : FixedRangeDouble(range);

    internal float Float(FixedRange range = null) => range is null
        ? (float)_random.NextDouble()
        : FixedRangeFloat(range);

    internal uint UInt(FixedRange range = null)
    {
        uint value;

        if (range is null)
        {
            var firstBits = (uint)_random.Next(0, 1 << 4) << 28;
            var lastBits = (uint)_random.Next(0, 1 << 28);
            value = firstBits | lastBits;
        }
        else
        {
          
            value = FixedRangeUInt(range);
        }

        return value;
    }

    internal long Long(FixedRange range = null)
    {
        long value;

        if (range is null)
        {
            var firstBits = (long)_random.Next(0, 1 << 30) << 34;
            var midBits = (long)_random.Next(0, 1 << 30) << 4;
            var lastBits = (long)_random.Next(0, 1 << 4);
            value = firstBits | midBits | lastBits;
        }
        else
        {
            return FixedRangeLong(range);
        }

        return value;
    }

    internal ulong ULong(FixedRange range = null)
    {
        ulong value;

        if (range is null)
        {
            var firstBits = (ulong)_random.Next(0, 1 << 30) << 34;
            var midBits = (ulong)_random.Next(0, 1 << 30) << 4;
            var lastBits = (ulong)_random.Next(0, 1 << 4);
            value = firstBits | midBits | lastBits;
        }
        else
        {
            value = FixedRangeULong(range);
        }

        return value;
    }

    internal decimal Decimal(FixedRange range = null)
    {
        decimal value;

        if (range is null)
        {
            var lo = NextInt32();
            var mid = NextInt32();
            var hi = NextInt32();
            var isNegative = Bool();
            var scale = (byte)_random.Next(29);

            value = new decimal(lo, mid, hi, isNegative, scale);
        }
        else
        {
            value = FixedRangeDecimal(range);
        }

        return value;
    }

    internal string String(FixedRange range = null)
    {
        string value;

        if (range is null)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 !\"£$%^&*()-=_+[]{};'#:@~,./<>?\\";
            var charCount = Byte() + 1;

            value = new string(Enumerable.Repeat(chars, charCount).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
        else
        {
            value = FixedRangeString(range);
        }

        return value;
    }

    internal DateTime DateTime(FixedRange range = null)
    {
        DateTime value;
        if (range is null)
        { 
            long ticks;

            do
            {
                ticks = Math.Abs(Long());
            } while (ticks <= 0 || ticks > System.DateTime.MaxValue.Ticks);

            value = new DateTime(ticks);
        }
        else
        {
            value = FixedRangeDateTime(range);
        }

        return value;
    }

    private int NextInt32()
    {
        int firstBits = _random.Next(0, 1 << 4) << 28;
        int lastBits = _random.Next(0, 1 << 28);
        return firstBits | lastBits;
    }

    private int FixedRangeInt(FixedRange range) => range.Range switch
    {
        Range.GreaterThan => _random.Next((int)range.MinValue, int.MaxValue),
        Range.LessThan => _random.Next(int.MinValue, (int)range.MaxValue),
        Range.Between => _random.Next((int)range.MinValue, (int)range.MaxValue),
        Range.Outside => Bool()
            ? _random.Next(int.MinValue, (int)range.MinValue)
            : _random.Next((int)range.MaxValue, int.MaxValue),

        _ => throw new Exception("Error generating random integer within range")
    };

    private uint FixedRangeUInt(FixedRange range)
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

    private byte FixedRangeByte(FixedRange range)
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

    private sbyte FixedRangeSByte(FixedRange range)
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

    private short FixedRangeShort(FixedRange range)
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

    private ushort FixedRangeUShort(FixedRange range)
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

    private decimal FixedRangeDecimal(FixedRange range)
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

    private double FixedRangeDouble(FixedRange range)
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

    private float FixedRangeFloat(FixedRange range)
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

    private long FixedRangeLong(FixedRange range)
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

    private ulong FixedRangeULong(FixedRange range)
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

    private string FixedRangeString(FixedRange range)
    {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 !\"£$%^&*()-=_+[]{};'#:@~,./<>?\\";
        int charCount = FixedRangeInt(range);

        return new string(Enumerable.Repeat(chars, charCount).Select(s => s[_random.Next(s.Length)]).ToArray());
    }

    private DateTime FixedRangeDateTime(FixedRange range)
    {
        FixedRange longRange;

        if (range.Range == Range.Outside)
        {
            var lowRange = new FixedRange
            {
                Range = Range.Between,
                MinValue = System.DateTime.MinValue.Ticks,
                MaxValue = ((DateTime)range.MinValue).Ticks
            };

            var highRange = new FixedRange
            {
                Range = Range.Between,
                MinValue = ((DateTime)range.MaxValue).Ticks,
                MaxValue = System.DateTime.MaxValue.Ticks
            };

            longRange = Bool() ? lowRange : highRange;
        }
        else
        {
            var minRangeTicks = range.MinValue == null
                ? System.DateTime.MinValue.Ticks
                : ((DateTime)range.MinValue).Ticks;

            var maxRangeTicks = range.MaxValue == null
                ? System.DateTime.MaxValue.Ticks
                : ((DateTime)range.MaxValue).Ticks;

            longRange = new FixedRange
            {
                Range = Range.Between,
                MinValue = minRangeTicks,
                MaxValue = maxRangeTicks
            };
        }

        var newDateTicks = FixedRangeLong(longRange);
        return new DateTime(newDateTicks);
    }
}
