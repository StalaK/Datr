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
                new FixedValue(typeof(Primitives), "Int", 1234)
            };

            var primitives = datr.Create<Primitives>();
            Assert.AreEqual(1234, primitives.Int);
        }

        [TestMethod]
        public void InvalidDataThrowsException()
        {
            var datr = new Datr();
            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(Primitives), "Int", "OneTwoThree")
            };

            Assert.ThrowsException<ArgumentException>(() => datr.Create<Primitives>());
        }

        [TestMethod]
        public void FixedClass()
        {
            var datr = new Datr();
            var fixedClass = new Strings { String1 = "Fixed String #1", String2 = "Fixed String #2" };

            datr.FixedValues = new List<FixedValue>
            {
                new FixedValue(typeof(Classes), "Strings1", fixedClass)
            };

            var primitives = datr.Create<Classes>();
            Assert.AreEqual("Fixed String #1", primitives.Strings1.String1);
            Assert.AreEqual("Fixed String #2", primitives.Strings1.String2);
            Assert.AreNotEqual("Fixed String #1", primitives.Strings2.String1);
            Assert.AreNotEqual("Fixed String #2", primitives.Strings2.String2);
        }
    }
}
