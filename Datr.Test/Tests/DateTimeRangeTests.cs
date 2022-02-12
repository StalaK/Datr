using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests;

[TestClass]
public class DateTimeRangeTests
{
    [TestMethod]
    public void AddDateTimeRangeToList()
    {
        var datr = new Datr();
        datr.SetDateTimeRange<ValuesClass>("DateTime", Range.GreaterThan, new DateTime(1991, 05, 11));

        Assert.AreEqual(1, datr.FixedRanges.Count);
        Assert.AreEqual(typeof(DateTime), datr.FixedRanges[0].DataType);
        Assert.AreEqual(typeof(ValuesClass), datr.FixedRanges[0].ClassType);
        Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
        Assert.AreEqual(new DateTime(1991, 05, 11), datr.FixedRanges[0].MinValue);
        Assert.IsNull(datr.FixedRanges[0].MaxValue);
    }

    [TestMethod]
    public void DateTimeRangeLessThan()
    {
        var datr = new Datr();
        datr.SetDateTimeRange<ValuesClass>("DateTime", Range.LessThan, maxValue: new DateTime(1991, 05, 11));

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.DateTime <= new DateTime(1991, 05, 11), $"Value generated is {basicClass.DateTime}");
        }
    }

    [TestMethod]
    public void DateTimeRangeGreaterThan()
    {
        var datr = new Datr();
        datr.SetDateTimeRange<ValuesClass>("DateTime", Range.GreaterThan, new DateTime(1991, 05, 11));

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.DateTime >= new DateTime(1991, 05, 11), $"Value generated is {basicClass.DateTime}");
        }
    }

    [TestMethod]
    public void DateTimeRangeBetween()
    {
        var datr = new Datr();
        datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Between, new DateTime(1991, 05, 11), new DateTime(1993, 04, 15));

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.DateTime >= new DateTime(1991, 05, 11), $"Value generated is {basicClass.DateTime}");
            Assert.IsTrue(basicClass.DateTime <= new DateTime(1993, 04, 15), $"Value generated is {basicClass.DateTime}");
        }
    }

    [TestMethod]
    public void DateTimeRangeOutside()
    {
        var datr = new Datr();
        datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Outside, new DateTime(1991, 05, 11), new DateTime(1993, 04, 15));

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.DateTime < new DateTime(1991, 05, 11) || basicClass.DateTime >= new DateTime(1993, 04, 15), $"Value generated is {basicClass.DateTime}");
        }
    }

    [TestMethod]
    public void DateTimeRangeMinValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Between, maxValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMinValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Outside, maxValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMaxValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Between, minValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMaxValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Outside, minValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMinValueNullGreaterThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.GreaterThan, maxValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMaxValueNullLessThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.LessThan, minValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMaxValueEqualMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Between, minValue: new DateTime(1991, 05, 11), maxValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMaxValueEqualMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Between, minValue: new DateTime(1991, 05, 11), maxValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMaxValueLessThanMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Between, minValue: new DateTime(1991, 05, 11), maxValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMaxValueLessThanMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.Between, minValue: new DateTime(1991, 05, 11), maxValue: new DateTime(1991, 05, 11)));
    }

    [TestMethod]
    public void DateTimeRangeMinValueEqualsDateTimeMax()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.GreaterThan, minValue: DateTime.MaxValue));
    }

    [TestMethod]
    public void DateTimeRangeMaxValueEqualsDateTimeMin()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDateTimeRange<ValuesClass>("DateTime", Range.LessThan, maxValue: DateTime.MinValue));
    }
}
