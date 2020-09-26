using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class SByteRangeTests
    {
        [TestMethod]
        public void AddSByteRangeToList()
        {
            var datr = new Datr();
            datr.SetSByteRange<BasicClass>("SByte", Range.GreaterThan, (sbyte)100);

            Assert.AreEqual(1, datr.FixedRanges.Count);
            Assert.AreEqual(typeof(sbyte), datr.FixedRanges[0].DataType);
            Assert.AreEqual(typeof(BasicClass), datr.FixedRanges[0].ClassType);
            Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
            Assert.AreEqual((sbyte)100, datr.FixedRanges[0].MinValue);
            Assert.IsNull(datr.FixedRanges[0].MaxValue);
        }

        [TestMethod]
        public void SByteRangeLessThan()
        {
            var datr = new Datr();
            datr.SetSByteRange<BasicClass>("SByte", Range.LessThan, maxValue: (sbyte)100);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.SByte <= (sbyte)100, $"Value generated is {basicClass.SByte}");
            }
        }

        [TestMethod]
        public void SByteRangeGreaterThan()
        {
            var datr = new Datr();
            datr.SetSByteRange<BasicClass>("SByte", Range.GreaterThan, (sbyte)100);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.SByte >= (sbyte)100, $"Value generated is {basicClass.SByte}");
            }
        }

        [TestMethod]
        public void SByteRangeBetween()
        {
            var datr = new Datr();
            datr.SetSByteRange<BasicClass>("SByte", Range.Between, (sbyte)-50, (sbyte)50);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.SByte >= (sbyte)-50, $"Value generated is {basicClass.SByte}");
                Assert.IsTrue(basicClass.SByte <= (sbyte)50, $"Value generated is {basicClass.SByte}");
            }
        }

        [TestMethod]
        public void SByteRangeOutside()
        {
            var datr = new Datr();
            datr.SetSByteRange<BasicClass>("SByte", Range.Outside, (sbyte)-50, (sbyte)50);

            for (int i = 0; i < 10; i++)
            {
                var basicClass = datr.Create<BasicClass>();
                Assert.IsTrue(basicClass.SByte < (sbyte)-50 || basicClass.SByte >= (sbyte)50, $"Value generated is {basicClass.SByte}");
            }
        }

        [TestMethod]
        public void SByteRangeMinValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.Between, maxValue: (sbyte)100));
        }

        [TestMethod]
        public void SByteRangeMinValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.Outside, maxValue: (sbyte)100));
        }

        [TestMethod]
        public void SByteRangeMaxValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.Between, minValue: (sbyte)100));
        }

        [TestMethod]
        public void SByteRangeMaxValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.Outside, minValue: (sbyte)100));
        }

        [TestMethod]
        public void SByteRangeMinValueNullGreaterThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.GreaterThan, maxValue: (sbyte)100));
        }

        [TestMethod]
        public void SByteRangeMaxValueNullLessThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.LessThan, minValue: (sbyte)100));
        }

        [TestMethod]
        public void SByteRangeMaxValueEqualMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.Between, minValue: (sbyte)100, maxValue: (sbyte)100));
        }

        [TestMethod]
        public void SByteRangeMaxValueEqualMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.Between, minValue: (sbyte)100, maxValue: (sbyte)100));
        }

        [TestMethod]
        public void SByteRangeMaxValueLessThanMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.Between, minValue: (sbyte)100, maxValue: 90));
        }

        [TestMethod]
        public void SByteRangeMaxValueLessThanMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.Between, minValue: (sbyte)100, maxValue: (sbyte)90));
        }

        [TestMethod]
        public void SByteRangeMinValueEqualsSByteMax()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.GreaterThan, minValue: sbyte.MaxValue));
        }

        [TestMethod]
        public void SByteRangeMaxValueEqualsSByteMin()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetSByteRange<BasicClass>("SByte", Range.LessThan, maxValue: sbyte.MinValue));
        }
    }
}
