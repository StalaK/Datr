using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Datr.Test.Tests
{
    [TestClass]
    public class FixedValueTests
    {
        [TestMethod]
        public void FixedInt()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Int", 1234)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual(1234, basicClass.Int);
        }

        [TestMethod]
        public void FixedString()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "String", "Fixed value string")
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual("Fixed value string", basicClass.String);
        }

        [TestMethod]
        public void FixedDateTime()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "DateTime", new DateTime(1991, 05, 11))
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual(new DateTime(1991, 05, 11), basicClass.DateTime);
        }

        [TestMethod]
        public void FixedBool()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Bool", true)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.IsTrue(basicClass.Bool);
        }

        [TestMethod]
        public void FixedSByte()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "SByte", (sbyte)123)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual((sbyte)123, basicClass.SByte);
        }

        [TestMethod]
        public void FixedByte()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Byte", (byte)123)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual((byte)123, basicClass.Byte);
        }

        [TestMethod]
        public void FixedShort()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Short", (short)1234)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual((short)1234, basicClass.Short);
        }

        [TestMethod]
        public void FixedUShort()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "UShort", (ushort)1234)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual(1234, basicClass.UShort);
        }

        [TestMethod]
        public void FixedDouble()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Double", 1234D)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual(1234D, basicClass.Double);
        }

        [TestMethod]
        public void FixedFloat()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Float", 1234F)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual(1234F, basicClass.Float);
        }

        [TestMethod]
        public void FixedUInt()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "UInt", 1234U)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual(1234U, basicClass.UInt);
        }

        [TestMethod]
        public void FixedLong()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Long", 1234L)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual(1234L, basicClass.Long);
        }

        [TestMethod]
        public void FixedULong()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "ULong", 1234UL)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual(1234UL, basicClass.ULong);
        }

        [TestMethod]
        public void FixedDecimal()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Decimal", 1234M)
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual(1234M, basicClass.Decimal);
        }

        [TestMethod]
        public void FixedChar()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Char", 'F')
            };

            var basicClass = datr.Create<BasicClass>();
            Assert.AreEqual('F', basicClass.Char);
        }

        [TestMethod]
        public void InvalidDataThrowsException()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(BasicClass), "Int", "OneTwoThree")
            };

            Assert.ThrowsException<ArgumentException>(() => datr.Create<BasicClass>());
        }

        [TestMethod]
        public void FixedClass()
        {
            var datr = new Datr();
            var fixedClass = new BasicClass
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
                new FixedValue(typeof(ClassWithClassProperty), "BasicClass", fixedClass)
            };

            var classWithClassProperty = datr.Create<ClassWithClassProperty>();

            Assert.AreEqual<BasicClass>(fixedClass, classWithClassProperty.BasicClass);
        }
    }
}
