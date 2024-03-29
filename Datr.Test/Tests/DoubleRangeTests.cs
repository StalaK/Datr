﻿using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests;

[TestClass]
public class DoubleRangeTests
{
    [TestMethod]
    public void AddDoubleRangeToList()
    {
        var datr = new Datr();
        datr.SetDoubleRange<ValuesClass>("Double", Range.GreaterThan, (double)100);

        Assert.AreEqual(1, datr.FixedRanges.Count);
        Assert.AreEqual(typeof(double), datr.FixedRanges[0].DataType);
        Assert.AreEqual(typeof(ValuesClass), datr.FixedRanges[0].ClassType);
        Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
        Assert.AreEqual((double)100, datr.FixedRanges[0].MinValue);
        Assert.IsNull(datr.FixedRanges[0].MaxValue);
    }

    [TestMethod]
    public void DoubleRangeLessThan()
    {
        var datr = new Datr();
        datr.SetDoubleRange<ValuesClass>("Double", Range.LessThan, maxValue: (double)0.3);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Double <= (double)0.3, $"Value generated is {basicClass.Double}");
        }
    }

    [TestMethod]
    public void DoubleRangeGreaterThan()
    {
        var datr = new Datr();
        datr.SetDoubleRange<ValuesClass>("Double", Range.GreaterThan, (double)0.3);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Double >= (double)0.3, $"Value generated is {basicClass.Double}");
        }
    }

    [TestMethod]
    public void DoubleRangeBetween()
    {
        var datr = new Datr();
        datr.SetDoubleRange<ValuesClass>("Double", Range.Between, (double)0.12345, (double)0.5678);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Double >= (double)0.12345, $"Value generated is {basicClass.Double}");
            Assert.IsTrue(basicClass.Double <= (double)0.5678, $"Value generated is {basicClass.Double}");
        }
    }

    [TestMethod]
    public void DoubleRangeOutside()
    {
        var datr = new Datr();
        datr.SetDoubleRange<ValuesClass>("Double", Range.Outside, (double)0.12345, (double)0.5678);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Double < (double)0.12345 || basicClass.Double >= (double)0.5678, $"Value generated is {basicClass.Double}");
        }
    }

    [TestMethod]
    public void DoubleRangeMinValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.Between, maxValue: (double)0.5));
    }

    [TestMethod]
    public void DoubleRangeMinValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.Outside, maxValue: (double)0.5));
    }

    [TestMethod]
    public void DoubleRangeMaxValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.Between, minValue: (double)0.5));
    }

    [TestMethod]
    public void DoubleRangeMaxValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.Outside, minValue: (double)0.5));
    }

    [TestMethod]
    public void DoubleRangeMinValueNullGreaterThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.GreaterThan, maxValue: (double)0.5));
    }

    [TestMethod]
    public void DoubleRangeMaxValueNullLessThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.LessThan, minValue: (double)0.5));
    }

    [TestMethod]
    public void DoubleRangeMaxValueEqualMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.Between, minValue: (double)0.1, maxValue: (double)0.1));
    }

    [TestMethod]
    public void DoubleRangeMaxValueEqualMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.Between, minValue: (double)0.1, maxValue: (double)0.1));
    }

    [TestMethod]
    public void DoubleRangeMaxValueLessThanMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.Between, minValue: (double)0.9, maxValue: 0.8));
    }

    [TestMethod]
    public void DoubleRangeMaxValueLessThanMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.Between, minValue: (double)0.9, maxValue: (double)0.8));
    }

    [TestMethod]
    public void DoubleRangeMinValueEqualsDoubleMax()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.GreaterThan, minValue: double.MaxValue));
    }

    [TestMethod]
    public void DoubleRangeMaxValueEqualsDoubleMin()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetDoubleRange<ValuesClass>("Double", Range.LessThan, maxValue: double.MinValue));
    }
}
