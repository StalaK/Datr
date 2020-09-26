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

            var primitives = datr.Create<BasicClass>();
            Assert.AreEqual(1234, primitives.Int);
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
            //Assert.AreEqual("FixedString", classWithClassProperty.BasicClass.String);
            //Assert.AreEqual("FixedString", classWithClassProperty.BasicClass.DateTime);
            //Assert.AreEqual("FixedString", classWithClassProperty.BasicClass.Bool);
            //Assert.AreEqual("FixedString", classWithClassProperty.BasicClass.SByte);
            //Assert.AreEqual("FixedString", classWithClassProperty.BasicClass.String);
            Assert.AreEqual<BasicClass>(fixedClass, classWithClassProperty.BasicClass);

        }
    }
}
