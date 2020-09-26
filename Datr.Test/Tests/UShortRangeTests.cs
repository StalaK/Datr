using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class UShortRangeTests
    {
        [TestMethod]
        public void AddUShortRangeToList()
        {
            var datr = new Datr();
            datr.SetUShortRange<BasicClass>("UShort", Range.GreaterThan, (ushort)100);

            Assert.AreEqual(1, datr.FixedRanges.Count);
            Assert.AreEqual(typeof(ushort), datr.FixedRanges[0].DataType);
            Assert.AreEqual(typeof(BasicClass), datr.FixedRanges[0].ClassType);
            Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
            Assert.AreEqual((ushort)100, datr.FixedRanges[0].MinValue);
            Assert.IsNull(datr.FixedRanges[0].MaxValue);
        }

        [TestMethod]
        public void UShortRangeLessThan()
        {
            var datr = new Datr();
            datr.SetUShortRange<BasicClass>("UShort", Range.LessThan, maxValue: (ushort)100);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.UShort <= (ushort)100, $"Value generated is {basicClass.UShort}");
            }
        }

        [TestMethod]
        public void UShortRangeGreaterThan()
        {
            var datr = new Datr();
            datr.SetUShortRange<BasicClass>("UShort", Range.GreaterThan, (ushort)100);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.UShort >= (ushort)100, $"Value generated is {basicClass.UShort}");
            }
        }

        [TestMethod]
        public void UShortRangeBetween()
        {
            var datr = new Datr();
            datr.SetUShortRange<BasicClass>("UShort", Range.Between, (ushort)5, (ushort)50);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.UShort >= (ushort)5, $"Value generated is {basicClass.UShort}");
                Assert.IsTrue(basicClass.UShort <= (ushort)50, $"Value generated is {basicClass.UShort}");
            }
        }

        [TestMethod]
        public void UShortRangeOutside()
        {
            var datr = new Datr();
            datr.SetUShortRange<BasicClass>("UShort", Range.Outside, (ushort)5, (ushort)50);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.UShort < (ushort)5 || basicClass.UShort >= (ushort)50, $"Value generated is {basicClass.UShort}");
            }
        }

        [TestMethod]
        public void UShortRangeMinValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.Between, maxValue: (ushort)100));
        }

        [TestMethod]
        public void UShortRangeMinValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.Outside, maxValue: (ushort)100));
        }

        [TestMethod]
        public void UShortRangeMaxValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.Between, minValue: (ushort)100));
        }

        [TestMethod]
        public void UShortRangeMaxValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.Outside, minValue: (ushort)100));
        }

        [TestMethod]
        public void UShortRangeMinValueNullGreaterThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.GreaterThan, maxValue: (ushort)100));
        }

        [TestMethod]
        public void UShortRangeMaxValueNullLessThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.LessThan, minValue: (ushort)100));
        }

        [TestMethod]
        public void UShortRangeMaxValueEqualMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.Between, minValue: (ushort)100, maxValue: (ushort)100));
        }

        [TestMethod]
        public void UShortRangeMaxValueEqualMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.Between, minValue: (ushort)100, maxValue: (ushort)100));
        }

        [TestMethod]
        public void UShortRangeMaxValueLessThanMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.Between, minValue: (ushort)100, maxValue: 90));
        }

        [TestMethod]
        public void UShortRangeMaxValueLessThanMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.Between, minValue: (ushort)100, maxValue: (ushort)90));
        }

        [TestMethod]
        public void UShortRangeMinValueEqualsUShortMax()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.GreaterThan, minValue: ushort.MaxValue));
        }

        [TestMethod]
        public void UShortRangeMaxValueEqualsUShortMin()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetUShortRange<BasicClass>("UShort", Range.LessThan, maxValue: ushort.MinValue));
        }
    }
}
