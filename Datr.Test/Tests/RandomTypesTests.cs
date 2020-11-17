using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class RandomTypesTests
    {
        [TestMethod]
        public void BoolPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.Bool);
        }

        [TestMethod]
        public void SBytePopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.SByte);
        }

        [TestMethod]
        public void BytePopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.Byte);
        }

        [TestMethod]
        public void ShortPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.Short);
        }

        [TestMethod]
        public void UShortPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.UShort);
        }

        [TestMethod]
        public void CharPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.Char);
        }

        [TestMethod]
        public void DoublePopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.Double);
        }

        [TestMethod]
        public void FloatPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.Float);
        }

        [TestMethod]
        public void UIntPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.UInt);
        }

        [TestMethod]
        public void LongPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.Long);
        }

        [TestMethod]
        public void ULongPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.ULong);
        }

        [TestMethod]
        public void DecimalPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.Decimal);
        }

        [TestMethod]
        public void IntPopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.Int);
        }

        [TestMethod]
        public void DateTimePopulated()
        {
            var types = Setup();
            Assert.IsNotNull(types.DateTime);
            Assert.AreNotEqual(new DateTime(), types.DateTime);
        }

        [TestMethod]
        public void IntArrayPopulated()
        {
            var types = Setup();

            Assert.IsTrue(types.IntArray.Length > 0);
            foreach (var val in types.IntArray)
            {
                Assert.IsNotNull(val);
            }
        }

        [TestMethod]
        public void StringArrayPopulated()
        {
            var types = Setup();

            Assert.IsTrue(types.StringArray.Length > 0);
            foreach (var val in types.StringArray)
            {
                Assert.IsFalse(string.IsNullOrEmpty(val));
            }
        }

        private ValuesClass Setup()
        {
            var datr = new Datr();
            return datr.Create<ValuesClass>();
        }
    }
}
