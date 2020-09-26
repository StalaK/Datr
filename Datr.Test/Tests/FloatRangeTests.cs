using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class FloatRangeTests
    {
        [TestMethod]
        public void AddFloatRangeToList()
        {
            var datr = new Datr();
            datr.SetFloatRange<BasicClass>("Float", Range.GreaterThan, (float)100);

            Assert.AreEqual(1, datr.FixedRanges.Count);
            Assert.AreEqual(typeof(float), datr.FixedRanges[0].DataType);
            Assert.AreEqual(typeof(BasicClass), datr.FixedRanges[0].ClassType);
            Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
            Assert.AreEqual((float)100, datr.FixedRanges[0].MinValue);
            Assert.IsNull(datr.FixedRanges[0].MaxValue);
        }

        [TestMethod]
        public void FloatRangeLessThan()
        {
            var datr = new Datr();
            datr.SetFloatRange<BasicClass>("Float", Range.LessThan, maxValue: (float)100);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Float <= (float)100, $"Value generated is {basicClass.Float}");
            }
        }

        [TestMethod]
        public void FloatRangeGreaterThan()
        {
            var datr = new Datr();
            datr.SetFloatRange<BasicClass>("Float", Range.GreaterThan, (float)100);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Float >= (float)100, $"Value generated is {basicClass.Float}");
            }
        }

        [TestMethod]
        public void FloatRangeBetween()
        {
            var datr = new Datr();
            datr.SetFloatRange<BasicClass>("Float", Range.Between, (float)5, (float)50);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Float >= (float)5, $"Value generated is {basicClass.Float}");
                Assert.IsTrue(basicClass.Float <= (float)50, $"Value generated is {basicClass.Float}");
            }
        }

        [TestMethod]
        public void FloatRangeOutside()
        {
            var datr = new Datr();
            datr.SetFloatRange<BasicClass>("Float", Range.Outside, (float)5, (float)50);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Float < (float)5 || basicClass.Float >= (float)50, $"Value generated is {basicClass.Float}");
            }
        }

        [TestMethod]
        public void FloatRangeMinValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.Between, maxValue: (float)100));
        }

        [TestMethod]
        public void FloatRangeMinValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.Outside, maxValue: (float)100));
        }

        [TestMethod]
        public void FloatRangeMaxValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.Between, minValue: (float)100));
        }

        [TestMethod]
        public void FloatRangeMaxValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.Outside, minValue: (float)100));
        }

        [TestMethod]
        public void FloatRangeMinValueNullGreaterThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.GreaterThan, maxValue: (float)100));
        }

        [TestMethod]
        public void FloatRangeMaxValueNullLessThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.LessThan, minValue: (float)100));
        }

        [TestMethod]
        public void FloatRangeMaxValueEqualMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.Between, minValue: (float)100, maxValue: (float)100));
        }

        [TestMethod]
        public void FloatRangeMaxValueEqualMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.Between, minValue: (float)100, maxValue: (float)100));
        }

        [TestMethod]
        public void FloatRangeMaxValueLessThanMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.Between, minValue: (float)100, maxValue: 90));
        }

        [TestMethod]
        public void FloatRangeMaxValueLessThanMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.Between, minValue: (float)100, maxValue: (float)90));
        }

        [TestMethod]
        public void FloatRangeMinValueEqualsFloatMax()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.GreaterThan, minValue: float.MaxValue));
        }

        [TestMethod]
        public void FloatRangeMaxValueEqualsFloatMin()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetFloatRange<BasicClass>("Float", Range.LessThan, maxValue: float.MinValue));
        }
    }
}
