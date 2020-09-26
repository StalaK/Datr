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
            datr.SetULongRange<BasicClass>("ULong", Range.GreaterThan, (ulong)100);

            Assert.AreEqual(1, datr.FixedRanges.Count);
            Assert.AreEqual(typeof(ulong), datr.FixedRanges[0].DataType);
            Assert.AreEqual(typeof(BasicClass), datr.FixedRanges[0].ClassType);
            Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
            Assert.AreEqual((ulong)100, datr.FixedRanges[0].MinValue);
            Assert.IsNull(datr.FixedRanges[0].MaxValue);
        }

        [TestMethod]
        public void ULongRangeLessThan()
        {
            var datr = new Datr();
            datr.SetULongRange<BasicClass>("ULong", Range.LessThan, maxValue: (ulong)100);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.ULong <= (ulong)100, $"Value generated is {basicClass.ULong}");
            }
        }

        [TestMethod]
        public void ULongRangeGreaterThan()
        {
            var datr = new Datr();
            datr.SetULongRange<BasicClass>("ULong", Range.GreaterThan, (ulong)100);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.ULong >= (ulong)100, $"Value generated is {basicClass.ULong}");
            }
        }

        [TestMethod]
        public void ULongRangeBetween()
        {
            var datr = new Datr();
            datr.SetULongRange<BasicClass>("ULong", Range.Between, (ulong)5, (ulong)50);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.ULong >= (ulong)5, $"Value generated is {basicClass.ULong}");
                Assert.IsTrue(basicClass.ULong <= (ulong)50, $"Value generated is {basicClass.ULong}");
            }
        }

        [TestMethod]
        public void ULongRangeOutside()
        {
            var datr = new Datr();
            datr.SetULongRange<BasicClass>("ULong", Range.Outside, (ulong)5, (ulong)50);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.ULong < (ulong)5 || basicClass.ULong >= (ulong)50, $"Value generated is {basicClass.ULong}");
            }
        }

        [TestMethod]
        public void ULongRangeMinValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, maxValue: (ulong)100));
        }

        [TestMethod]
        public void ULongRangeMinValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Outside, maxValue: (ulong)100));
        }

        [TestMethod]
        public void ULongRangeMaxValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100));
        }

        [TestMethod]
        public void ULongRangeMaxValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Outside, minValue: (ulong)100));
        }

        [TestMethod]
        public void ULongRangeMinValueNullGreaterThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.GreaterThan, maxValue: (ulong)100));
        }

        [TestMethod]
        public void ULongRangeMaxValueNullLessThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.LessThan, minValue: (ulong)100));
        }

        [TestMethod]
        public void ULongRangeMaxValueEqualMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100, maxValue: (ulong)100));
        }

        [TestMethod]
        public void ULongRangeMaxValueEqualMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100, maxValue: (ulong)100));
        }

        [TestMethod]
        public void ULongRangeMaxValueLessThanMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100, maxValue: 90));
        }

        [TestMethod]
        public void ULongRangeMaxValueLessThanMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetULongRange<BasicClass>("ULong", Range.Between, minValue: (ulong)100, maxValue: (ulong)90));
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
