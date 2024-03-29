﻿using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests;

[TestClass]
public class IntRangeTests
{
    [TestMethod]
    public void AddIntRangeToList()
    {
        var datr = new Datr();
        datr.SetIntRange<ValuesClass>("Int", Range.GreaterThan, 100);

        Assert.AreEqual(1, datr.FixedRanges.Count);
        Assert.AreEqual(typeof(int), datr.FixedRanges[0].DataType);
        Assert.AreEqual(typeof(ValuesClass), datr.FixedRanges[0].ClassType);
        Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
        Assert.AreEqual(100, datr.FixedRanges[0].MinValue);
        Assert.IsNull(datr.FixedRanges[0].MaxValue);
    }

    [TestMethod]
    public void IntRangeLessThan()
    {
        var datr = new Datr();
        datr.SetIntRange<ValuesClass>("Int", Range.LessThan, maxValue: 100);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Int <= 100, $"Value generated is {basicClass.Int}");
        }
    }

    [TestMethod]
    public void IntRangeGreaterThan()
    {
        var datr = new Datr();
        datr.SetIntRange<ValuesClass>("Int", Range.GreaterThan, 100);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Int >= 100, $"Value generated is {basicClass.Int}");
        }
    }

    [TestMethod]
    public void IntRangeBetween()
    {
        var datr = new Datr();
        datr.SetIntRange<ValuesClass>("Int", Range.Between, -50, 50);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Int >= -50, $"Value generated is {basicClass.Int}");
            Assert.IsTrue(basicClass.Int <= 50, $"Value generated is {basicClass.Int}");
        }
    }

    [TestMethod]
    public void IntRangeOutside()
    {
        var datr = new Datr();
        datr.SetIntRange<ValuesClass>("Int", Range.Outside, -50, 50);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.Int < -50 || basicClass.Int >= 50, $"Value generated is {basicClass.Int}");
        }
    }

    [TestMethod]
    public void RangeValidForArray()
    {
        var datr = new Datr();
        datr.SetIntRange<ValuesClass>("IntArray", Range.Between, -50, 50);

        var basicClass = datr.Create<ValuesClass>();

        foreach (var val in basicClass.IntArray)
        {
            Assert.IsTrue(val >= -50, $"Value generated is {val}");
            Assert.IsTrue(val <= 50, $"Value generated is {val}");
        }
    }

    [TestMethod]
    public void RangeValidForList()
    {
        var datr = new Datr();
        datr.SetIntRange<ValuesClass>("IntList", Range.Between, -50, 50);

        var basicClass = datr.Create<ValuesClass>();

        foreach (var val in basicClass.IntList)
        {
            Assert.IsTrue(val >= -50, $"Value generated is {val}");
            Assert.IsTrue(val <= 50, $"Value generated is {val}");
        }
    }

    [TestMethod]
    public void IntRangeMinValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.Between, maxValue: 100));
    }

    [TestMethod]
    public void IntRangeMinValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.Outside, maxValue: 100));
    }

    [TestMethod]
    public void IntRangeMaxValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.Between, minValue: 100));
    }

    [TestMethod]
    public void IntRangeMaxValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.Outside, minValue: 100));
    }

    [TestMethod]
    public void IntRangeMinValueNullGreaterThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.GreaterThan, maxValue: 100));
    }

    [TestMethod]
    public void IntRangeMaxValueNullLessThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.LessThan, minValue: 100));
    }

    [TestMethod]
    public void IntRangeMaxValueEqualMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.Between, minValue: 100, maxValue: 100));
    }

    [TestMethod]
    public void IntRangeMaxValueEqualMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.Between, minValue: 100, maxValue: 100));
    }

    [TestMethod]
    public void IntRangeMaxValueLessThanMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.Between, minValue: 100, maxValue: 90));
    }

    [TestMethod]
    public void IntRangeMaxValueLessThanMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.Between, minValue: 100, maxValue: 90));
    }

    [TestMethod]
    public void IntRangeMinValueEqualsIntMax()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.GreaterThan, minValue: int.MaxValue));
    }

    [TestMethod]
    public void IntRangeMaxValueEqualsIntMin()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetIntRange<ValuesClass>("Int", Range.LessThan, maxValue: int.MinValue));
    }
}
