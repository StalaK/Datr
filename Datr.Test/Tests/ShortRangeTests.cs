using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class ShortRangeTests
    {
        [TestMethod]
        public void AddShortRangeToList()
        {
            var datr = new Datr();
            datr.SetShortRange<BasicClass>("Short", Range.GreaterThan, (short)100);

            Assert.AreEqual(1, datr.FixedRanges.Count);
            Assert.AreEqual(typeof(short), datr.FixedRanges[0].DataType);
            Assert.AreEqual(typeof(BasicClass), datr.FixedRanges[0].ClassType);
            Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
            Assert.AreEqual((short)100, datr.FixedRanges[0].MinValue);
            Assert.IsNull(datr.FixedRanges[0].MaxValue);
        }

        [TestMethod]
        public void ShortRangeLessThan()
        {
            var datr = new Datr();
            datr.SetShortRange<BasicClass>("Short", Range.LessThan, maxValue: (short)100);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Short <= (short)100, $"Value generated is {basicClass.Short}");
            }
        }

        [TestMethod]
        public void ShortRangeGreaterThan()
        {
            var datr = new Datr();
            datr.SetShortRange<BasicClass>("Short", Range.GreaterThan, (short)100);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Short >= (short)100, $"Value generated is {basicClass.Short}");
            }
        }

        [TestMethod]
        public void ShortRangeBetween()
        {
            var datr = new Datr();
            datr.SetShortRange<BasicClass>("Short", Range.Between, (short)5, (short)50);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Short >= (short)5, $"Value generated is {basicClass.Short}");
                Assert.IsTrue(basicClass.Short <= (short)50, $"Value generated is {basicClass.Short}");
            }
        }

        [TestMethod]
        public void ShortRangeOutside()
        {
            var datr = new Datr();
            datr.SetShortRange<BasicClass>("Short", Range.Outside, (short)5, (short)50);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Short < (short)5 || basicClass.Short >= (short)50, $"Value generated is {basicClass.Short}");
            }
        }

        [TestMethod]
        public void ShortRangeMinValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.Between, maxValue: (short)100));
        }

        [TestMethod]
        public void ShortRangeMinValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.Outside, maxValue: (short)100));
        }

        [TestMethod]
        public void ShortRangeMaxValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.Between, minValue: (short)100));
        }

        [TestMethod]
        public void ShortRangeMaxValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.Outside, minValue: (short)100));
        }

        [TestMethod]
        public void ShortRangeMinValueNullGreaterThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.GreaterThan, maxValue: (short)100));
        }

        [TestMethod]
        public void ShortRangeMaxValueNullLessThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.LessThan, minValue: (short)100));
        }

        [TestMethod]
        public void ShortRangeMaxValueEqualMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.Between, minValue: (short)100, maxValue: (short)100));
        }

        [TestMethod]
        public void ShortRangeMaxValueEqualMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.Between, minValue: (short)100, maxValue: (short)100));
        }

        [TestMethod]
        public void ShortRangeMaxValueLessThanMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.Between, minValue: (short)100, maxValue: 90));
        }

        [TestMethod]
        public void ShortRangeMaxValueLessThanMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.Between, minValue: (short)100, maxValue: (short)90));
        }

        [TestMethod]
        public void ShortRangeMinValueEqualsShortMax()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.GreaterThan, minValue: short.MaxValue));
        }

        [TestMethod]
        public void ShortRangeMaxValueEqualsShortMin()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetShortRange<BasicClass>("Short", Range.LessThan, maxValue: short.MinValue));
        }
    }
}
