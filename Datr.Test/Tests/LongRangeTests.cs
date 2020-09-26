using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class LongRangeTests
    {
        [TestMethod]
        public void AddLongRangeToList()
        {
            var datr = new Datr();
            datr.SetLongRange<BasicClass>("Long", Range.GreaterThan, (long)100);

            Assert.AreEqual(1, datr.FixedRanges.Count);
            Assert.AreEqual(typeof(long), datr.FixedRanges[0].DataType);
            Assert.AreEqual(typeof(BasicClass), datr.FixedRanges[0].ClassType);
            Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
            Assert.AreEqual((long)100, datr.FixedRanges[0].MinValue);
            Assert.IsNull(datr.FixedRanges[0].MaxValue);
        }

        [TestMethod]
        public void LongRangeLessThan()
        {
            var datr = new Datr();
            datr.SetLongRange<BasicClass>("Long", Range.LessThan, maxValue: (long)100000000000);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Long <= (long)100000000000, $"Value generated is {basicClass.Long}");
            }
        }

        [TestMethod]
        public void LongRangeGreaterThan()
        {
            var datr = new Datr();
            datr.SetLongRange<BasicClass>("Long", Range.GreaterThan, (long)100000000000);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Long >= (long)100000000000, $"Value generated is {basicClass.Long}");
            }
        }

        [TestMethod]
        public void LongRangeBetween()
        {
            var datr = new Datr();
            datr.SetLongRange<BasicClass>("Long", Range.Between, (long)-100000000000, (long)900000000000);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Long >= (long)-100000000000, $"Value generated is {basicClass.Long}");
                Assert.IsTrue(basicClass.Long <= (long)900000000000, $"Value generated is {basicClass.Long}");
            }
        }

        [TestMethod]
        public void LongRangeOutside()
        {
            var datr = new Datr();
            datr.SetLongRange<BasicClass>("Long", Range.Outside, (long)-100000000000, (long)900000000000);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.Long < (long)-100000000000 || basicClass.Long >= (long)900000000000, $"Value generated is {basicClass.Long}");
            }
        }

        [TestMethod]
        public void LongRangeMinValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.Between, maxValue: (long)100000000000));
        }

        [TestMethod]
        public void LongRangeMinValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.Outside, maxValue: (long)100000000000));
        }

        [TestMethod]
        public void LongRangeMaxValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.Between, minValue: (long)100000000000));
        }

        [TestMethod]
        public void LongRangeMaxValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.Outside, minValue: (long)100000000000));
        }

        [TestMethod]
        public void LongRangeMinValueNullGreaterThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.GreaterThan, maxValue: (long)100000000000));
        }

        [TestMethod]
        public void LongRangeMaxValueNullLessThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.LessThan, minValue: (long)100000000000));
        }

        [TestMethod]
        public void LongRangeMaxValueEqualMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.Between, minValue: (long)100000000000, maxValue: (long)100000000000));
        }

        [TestMethod]
        public void LongRangeMaxValueEqualMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.Between, minValue: (long)100000000000, maxValue: (long)100000000000));
        }

        [TestMethod]
        public void LongRangeMaxValueLessThanMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.Between, minValue: (long)100000000000, maxValue: 10000000000));
        }

        [TestMethod]
        public void LongRangeMaxValueLessThanMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.Between, minValue: (long)100000000000, maxValue: (long)10000000000));
        }

        [TestMethod]
        public void LongRangeMinValueEqualsLongMax()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.GreaterThan, minValue: long.MaxValue));
        }

        [TestMethod]
        public void LongRangeMaxValueEqualsLongMin()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetLongRange<BasicClass>("Long", Range.LessThan, maxValue: long.MinValue));
        }
    }
}
