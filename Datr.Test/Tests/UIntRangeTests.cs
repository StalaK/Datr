using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests;

[TestClass]
public class UIntRangeTests
{
    [TestMethod]
    public void AddUIntRangeToList()
    {
        var datr = new Datr();
        datr.SetUIntRange<ValuesClass>("UInt", Range.GreaterThan, 100U);

        Assert.AreEqual(1, datr.FixedRanges.Count);
        Assert.AreEqual(typeof(uint), datr.FixedRanges[0].DataType);
        Assert.AreEqual(typeof(ValuesClass), datr.FixedRanges[0].ClassType);
        Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
        Assert.AreEqual(100U, datr.FixedRanges[0].MinValue);
        Assert.IsNull(datr.FixedRanges[0].MaxValue);
    }

    [TestMethod]
    public void UIntRangeLessThan()
    {
        var datr = new Datr();
        datr.SetUIntRange<ValuesClass>("UInt", Range.LessThan, maxValue: 100U);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.UInt <= 100U, $"Value generated is {basicClass.UInt}");
        }
    }

    [TestMethod]
    public void UIntRangeGreaterThan()
    {
        var datr = new Datr();
        datr.SetUIntRange<ValuesClass>("UInt", Range.GreaterThan, 100U);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.UInt >= 100U, $"Value generated is {basicClass.UInt}");
        }
    }

    [TestMethod]
    public void UIntRangeBetween()
    {
        var datr = new Datr();
        datr.SetUIntRange<ValuesClass>("UInt", Range.Between, 50U, 500U);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.UInt >= 50U, $"Value generated is {basicClass.UInt}");
            Assert.IsTrue(basicClass.UInt <= 500U, $"Value generated is {basicClass.UInt}");
        }
    }

    [TestMethod]
    public void UIntRangeOutside()
    {
        var datr = new Datr();
        datr.SetUIntRange<ValuesClass>("UInt", Range.Outside, 50U, 500U);

        for (int i = 0; i < 100; i++)
        {
            var basicClass = datr.Create<ValuesClass>();
            Assert.IsTrue(basicClass.UInt < 50U || basicClass.UInt >= 500U, $"Value generated is {basicClass.UInt}");
        }
    }

    [TestMethod]
    public void UIntRangeMinValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.Between, maxValue: 100U));
    }

    [TestMethod]
    public void UIntRangeMinValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.Outside, maxValue: 100U));
    }

    [TestMethod]
    public void UIntRangeMaxValueNullBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.Between, minValue: 100U));
    }

    [TestMethod]
    public void UIntRangeMaxValueNullOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.Outside, minValue: 100U));
    }

    [TestMethod]
    public void IntRangeMinValueNullGreaterThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.GreaterThan, maxValue: 100));
    }

    [TestMethod]
    public void UIntRangeMaxValueNullLessThanRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.LessThan, minValue: 100));
    }

    [TestMethod]
    public void UIntRangeMaxValueEqualMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.Between, minValue: 100, maxValue: 100));
    }

    [TestMethod]
    public void UIntRangeMaxValueEqualMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.Between, minValue: 100, maxValue: 100));
    }

    [TestMethod]
    public void UIntRangeMaxValueLessThanMinValueBetweenRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.Between, minValue: 100, maxValue: 90));
    }

    [TestMethod]
    public void UIntRangeMaxValueLessThanMinValueOutsideRange()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.Between, minValue: 100, maxValue: 90));
    }

    [TestMethod]
    public void UIntRangeMinValueEqualsUIntMax()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.GreaterThan, minValue: uint.MaxValue));
    }

    [TestMethod]
    public void UIntRangeMaxValueEqualsUIntMin()
    {
        var datr = new Datr();
        Assert.ThrowsException<ArgumentException>(() => datr.SetUIntRange<ValuesClass>("UInt", Range.LessThan, maxValue: uint.MinValue));
    }
}
