using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Datr.Test.Tests
{
    [TestClass]
    public class PrimativesTests
    {
        [TestMethod]
        public void BoolPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.Bool);
        }

        [TestMethod]
        public void SBytePopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.SByte);
        }

        [TestMethod]
        public void BytePopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.Byte);
        }

        [TestMethod]
        public void ShortPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.Short);
        }

        [TestMethod]
        public void UShortPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.UShort);
        }

        [TestMethod]
        public void CharPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.Char);
        }

        [TestMethod]
        public void DoublePopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.Double);
        }

        [TestMethod]
        public void FloatPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.Float);
        }

        [TestMethod]
        public void UIntPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.UInt);
        }

        [TestMethod]
        public void LongPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.Long);
        }

        [TestMethod]
        public void ULongPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.ULong);
        }

        [TestMethod]
        public void DecimalPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.Decimal);
        }

        [TestMethod]
        public void IntPopulated()
        {
            var primatives = Setup();
            Assert.IsNotNull(primatives.Bool);
        }

        private Primatives Setup()
        {
            var datr = new Datr();
            return datr.Create<Primatives>();
        }
    }
}
