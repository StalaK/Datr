using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests;

[TestClass]
public class NullableValuesTests
{
    [TestMethod]
    public void BoolPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.Bool);
    }

    [TestMethod]
    public void SBytePopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.SByte);
    }

    [TestMethod]
    public void BytePopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.Byte);
    }

    [TestMethod]
    public void ShortPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.Short);
    }

    [TestMethod]
    public void UShortPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.UShort);
    }

    [TestMethod]
    public void CharPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.Char);
    }

    [TestMethod]
    public void DoublePopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.Double);
    }

    [TestMethod]
    public void FloatPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.Float);
    }

    [TestMethod]
    public void UIntPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.UInt);
    }

    [TestMethod]
    public void LongPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.Long);
    }

    [TestMethod]
    public void ULongPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.ULong);
    }

    [TestMethod]
    public void DecimalPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.Decimal);
    }

    [TestMethod]
    public void IntPopulated()
    {
        var nullables = Setup();
        Assert.IsNotNull(nullables.Int);
    }

    private static NullablesClass Setup()
    {
        var datr = new Datr();
        return datr.Create<NullablesClass>();
    }
}
