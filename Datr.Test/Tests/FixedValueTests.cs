using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Datr.Test.Tests;

[TestClass]
public class FixedValueTests
{
    [TestMethod]
    public void FixedInt()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Int", 1234)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(1234, basicClass.Int);
    }

    [TestMethod]
    public void FixedString()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "String", "Fixed value string")
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual("Fixed value string", basicClass.String);
    }

    [TestMethod]
    public void FixedDateTime()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "DateTime", new DateTime(1991, 05, 11))
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(new DateTime(1991, 05, 11), basicClass.DateTime);
    }

    [TestMethod]
    public void FixedBool()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Bool", true)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.IsTrue(basicClass.Bool);
    }

    [TestMethod]
    public void FixedSByte()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "SByte", (sbyte)123)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual((sbyte)123, basicClass.SByte);
    }

    [TestMethod]
    public void FixedByte()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Byte", (byte)123)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual((byte)123, basicClass.Byte);
    }

    [TestMethod]
    public void FixedShort()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Short", (short)1234)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual((short)1234, basicClass.Short);
    }

    [TestMethod]
    public void FixedUShort()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "UShort", (ushort)1234)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(1234, basicClass.UShort);
    }

    [TestMethod]
    public void FixedDouble()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Double", 1234D)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(1234D, basicClass.Double);
    }

    [TestMethod]
    public void FixedFloat()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Float", 1234F)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(1234F, basicClass.Float);
    }

    [TestMethod]
    public void FixedUInt()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "UInt", 1234U)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(1234U, basicClass.UInt);
    }

    [TestMethod]
    public void FixedLong()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Long", 1234L)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(1234L, basicClass.Long);
    }

    [TestMethod]
    public void FixedULong()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "ULong", 1234UL)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(1234UL, basicClass.ULong);
    }

    [TestMethod]
    public void FixedDecimal()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Decimal", 1234M)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(1234M, basicClass.Decimal);
    }

    [TestMethod]
    public void FixedChar()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Char", 'F')
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual('F', basicClass.Char);
    }

    [TestMethod]
    public void InvalidDataThrowsException()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "Int", "OneTwoThree")
            }
        };

        Assert.ThrowsException<ArgumentException>(() => datr.Create<ValuesClass>());
    }

    [TestMethod]
    public void FixedClass()
    {
        var datr = new Datr();
        var fixedClass = new ValuesClass
        {
            String = "Fixed String",
            DateTime = new DateTime(1991, 05, 11),
            Bool = true,
            SByte = -5,
            Byte = 3,
            Short = -20000,
            UShort = 50000,
            Char = '■',
            Double = 3.486,
            Float = 0.1234f,
            UInt = 4000000000,
            Int = -1500000,
            Long = 372036854775808,
            ULong = 184467440737095516
        };

        datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ClassWithClassProperty), "ValuesClass", fixedClass)
            };

        var classWithClassProperty = datr.Create<ClassWithClassProperty>();

        Assert.AreEqual<ValuesClass>(fixedClass, classWithClassProperty.ValuesClass);
    }

    [TestMethod]
    public void FixedIntArray()
    {
        var intArray = new int[] { 1, 2, 3, 5, 8, 13 };

        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "IntArray", intArray)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(intArray, basicClass.IntArray);
    }

    [TestMethod]
    public void FixedStringArray()
    {
        var stringArray = new string[] { "Hello", "World", "Datr", "Test" };

        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "StringArray", stringArray)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(stringArray, basicClass.StringArray);
    }

    [TestMethod]
    public void FixedIntList()
    {
        var intList = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5 };

        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "IntList", intList)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(intList, basicClass.IntList);
    }

    [TestMethod]
    public void FixedEnum()
    {
        var datr = new Datr
        {
            FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(ValuesClass), "TestEnum", TestEnum.Twenty)
            }
        };

        var basicClass = datr.Create<ValuesClass>();
        Assert.AreEqual(TestEnum.Twenty, basicClass.TestEnum);
    }
}
