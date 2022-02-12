using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests;

[TestClass]
public class ByteRangeTests
{
    [TestMethod]
    public void AddByteRangeToList()
    {
        var datr = new Datr();
        datr.SetByteRange<ValuesClass>("Byte", Range.GreaterThan, (byte)100);

        Assert.AreEqual(1, datr.FixedRanges.Count);
        Assert.AreEqual(typeof(byte), datr.FixedRanges[0].DataType);
        Assert.AreEqual(typeof(ValuesClass), datr.FixedRanges[0].ClassType);
        Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
        Assert.AreEqual((byte)100, datr.FixedRanges[0].MinValue);
        Assert.IsNull(datr.FixedRanges[0].MaxValue);
    }

    [TestMethod]
    public void ByteRangeLessThan()
    {
        var datr = new Datr();
        datr.SetByteRange<ValuesClass>("Byte", Range.LessThan, maxValue: (byte)100);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Byte <= (byte)100, $"Value generated is {basicClass.Byte}");
        }
    }

    [TestMethod]
    public void ByteRangeGreaterThan()
    {
        var datr = new Datr();
        datr.SetByteRange<ValuesClass>("Byte", Range.GreaterThan, (byte)100);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Byte >= (byte)100, $"Value generated is {basicClass.Byte}");
        }
    }

    [TestMethod]
    public void ByteRangeBetween()
    {
        var datr = new Datr();
        datr.SetByteRange<ValuesClass>("Byte", Range.Between, (byte)5, (byte)50);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Byte >= (byte)5, $"Value generated is {basicClass.Byte}");
            Assert.IsTrue(basicClass.Byte <= (byte)50, $"Value generated is {basicClass.Byte}");
        }
    }

    [TestMethod]
    public void ByteRangeOutside()
    {
        var datr = new Datr();
        datr.SetByteRange<ValuesClass>("Byte", Range.Outside, (byte)5, (byte)50);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Byte < (byte)5 || basicClass.Byte >= (byte)50, $"Value generated is {basicClass.Byte}");
        }
    }

    [TestMethod]
    public void ByteRangeMinValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.Between, maxValue: (byte)100));
    }

    [TestMethod]
    public void ByteRangeMinValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.Outside, maxValue: (byte)100));
    }

    [TestMethod]
    public void ByteRangeMaxValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.Between, minValue: (byte)100));
    }

    [TestMethod]
    public void ByteRangeMaxValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.Outside, minValue: (byte)100));
    }

    [TestMethod]
    public void ByteRangeMinValueNullGreaterThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.GreaterThan, maxValue: (byte)100));
    }

    [TestMethod]
    public void ByteRangeMaxValueNullLessThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.LessThan, minValue: (byte)100));
    }

    [TestMethod]
    public void ByteRangeMaxValueEqualMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.Between, minValue: (byte)100, maxValue: (byte)100));
    }

    [TestMethod]
    public void ByteRangeMaxValueEqualMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.Between, minValue: (byte)100, maxValue: (byte)100));
    }

    [TestMethod]
    public void ByteRangeMaxValueLessThanMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.Between, minValue: (byte)100, maxValue: 90));
    }

    [TestMethod]
    public void ByteRangeMaxValueLessThanMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.Between, minValue: (byte)100, maxValue: (byte)90));
    }

    [TestMethod]
    public void ByteRangeMinValueEqualsByteMax()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.GreaterThan, minValue: byte.MaxValue));
    }

    [TestMethod]
    public void ByteRangeMaxValueEqualsByteMin()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetByteRange<ValuesClass>("Byte", Range.LessThan, maxValue: byte.MinValue));
    }
}
