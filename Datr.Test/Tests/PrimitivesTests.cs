using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Datr.Test.Tests
{
    [TestClass]
    public class PrimitivesTests
    {
        [TestMethod]
        public void BoolPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.Bool);
        }

        [TestMethod]
        public void SBytePopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.SByte);
        }

        [TestMethod]
        public void BytePopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.Byte);
        }

        [TestMethod]
        public void ShortPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.Short);
        }

        [TestMethod]
        public void UShortPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.UShort);
        }

        [TestMethod]
        public void CharPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.Char);
        }

        [TestMethod]
        public void DoublePopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.Double);
        }

        [TestMethod]
        public void FloatPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.Float);
        }

        [TestMethod]
        public void UIntPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.UInt);
        }

        [TestMethod]
        public void LongPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.Long);
        }

        [TestMethod]
        public void ULongPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.ULong);
        }

        [TestMethod]
        public void DecimalPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.Decimal);
        }

        [TestMethod]
        public void IntPopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.Int);
        }

        [TestMethod]
        public void DateTimePopulated()
        {
            var primitives = Setup();
            Assert.IsNotNull(primitives.DateTime);
            Assert.AreNotEqual(new DateTime(), primitives.DateTime);
        }

        [TestMethod]
        public void ExcludePropetiesByName()
        {
            var datr = new Datr
            {
                ExcludedPropertyNames = new List<string> { "Int", "Char" }
            };

            var primitives = datr.Create<BasicClass>();

            Assert.AreEqual(0, primitives.Int);
            Assert.AreEqual(0, (int)primitives.Char);
        }

        [TestMethod]
        public void ExcludePropetiesByTypeAndName()
        {
            var datr = new Datr
            {
                ExcludedTypeProperties = new List<TypeProperty>
                {
                    new TypeProperty(typeof(BasicClass), "Int"),
                    new TypeProperty(typeof(BasicClass), "NotChar"),
                }
            };

            var primitives = datr.Create<BasicClass>();

            Assert.AreEqual(0, primitives.Int);
            Assert.IsNotNull(primitives.Char);
        }

        private BasicClass Setup()
        {
            var datr = new Datr();
            return datr.Create<BasicClass>();
        }
    }
}
