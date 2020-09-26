using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class ULongRangeTests
    {
        [TestMethod]
        public void AddULongRangeToList()
        {
            var datr = new Datr();
            datr.SetULongRange<BasicClass>("ULong", Range.GreaterThan, (ulong)100000000000);

            Assert.AreEqual(1, datr.FixedRanges.Count);
            Assert.AreEqual(typeof(ulong), datr.FixedRanges[0].DataType);
            Assert.AreEqual(typeof(BasicClass), datr.FixedRanges[0].ClassType);
            Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
            Assert.AreEqual((ulong)100000000000, datr.FixedRanges[0].MinValue);
            Assert.IsNull(datr.FixedRanges[0].MaxValue);
        }

        [TestMethod]
        public void ULongRangeLessThan()
        {
            var datr = new Datr();
            datr.SetULongRange<BasicClass>("ULong", Range.LessThan, maxValue: (ulong)100000000000);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.ULong <= (ulong)100000000000, $"Value generated is {basicClass.ULong}");
            }
        }

        [TestMethod]
        public void ULongRangeGreaterThan()
        {
            var datr = new Datr();
            datr.SetULongRange<BasicClass>("ULong", Range.GreaterThan, (ulong)100000000000);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.ULong >= (ulong)100000000000, $"Value generated is {basicClass.ULong}");
            }
        }

        [TestMethod]
        public void ULongRangeBetween()
        {
            var datr = new Datr();
            datr.SetULongRange<BasicClass>("ULong", Range.Between, (ulong)100000000000, (ulong)9000000000000);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.ULong >= (ulong)100000000000, $"Value generated is {basicClass.ULong}");
                Assert.IsTrue(basicClass.ULong <= (ulong)9000000000000, $"Value generated is {basicClass.ULong}");
            }
        }

        [TestMethod]
        public void ULongRangeOutside()
        {
            var datr = new Datr();
            datr.SetULongRange<BasicClass>("ULong", Range.Outside, (ulong)100000000000, (ulong)9000000000000);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.ULong < (ulong)100000000000 || basicClass.ULong >= (ulong)9000000000000, $"Value generated is {basicClass.ULong}");
            }
        }

        [TestMethod]
        public void ULongRangeMinValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, maxValue: (ulong)100000000000));
        }

        [TestMethod]
        public void ULongRangeMinValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Outside, maxValue: (ulong)100000000000));
        }

        [TestMethod]
        public void ULongRangeMaxValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100000000000));
        }

        [TestMethod]
        public void ULongRangeMaxValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Outside, minValue: (ulong)100000000000));
        }

        [TestMethod]
        public void ULongRangeMinValueNullGreaterThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.GreaterThan, maxValue: (ulong)100000000000));
        }

        [TestMethod]
        public void ULongRangeMaxValueNullLessThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.LessThan, minValue: (ulong)100000000000));
        }

        [TestMethod]
        public void ULongRangeMaxValueEqualMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100000000000, maxValue: (ulong)100000000000));
        }

        [TestMethod]
        public void ULongRangeMaxValueEqualMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100000000000, maxValue: (ulong)100000000000));
        }

        [TestMethod]
        public void ULongRangeMaxValueLessThanMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100000000000, maxValue: 10000000000));
        }

        [TestMethod]
        public void ULongRangeMaxValueLessThanMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100000000000, maxValue: (ulong)10000000000));
        }

        [TestMethod]
        public void ULongRangeMinValueEqualsULongMax()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.GreaterThan, minValue: ulong.MaxValue));
        }

        [TestMethod]
        public void ULongRangeMaxValueEqualsULongMin()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.LessThan, maxValue: ulong.MinValue));
        }
    }
}
