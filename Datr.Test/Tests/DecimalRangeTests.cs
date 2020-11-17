using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class DecimalRangeTests
    {
        [TestMethod]
        public void AddDecimalRangeToList()
        {
            var datr = new Datr();
            datr.SetDecimalRange<ValuesClass>("Decimal", Range.GreaterThan, (decimal)100);

            Assert.AreEqual(1, datr.FixedRanges.Count);
            Assert.AreEqual(typeof(decimal), datr.FixedRanges[0].DataType);
            Assert.AreEqual(typeof(ValuesClass), datr.FixedRanges[0].ClassType);
            Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
            Assert.AreEqual((decimal)100, datr.FixedRanges[0].MinValue);
            Assert.IsNull(datr.FixedRanges[0].MaxValue);
        }

        [TestMethod]
        public void DecimalRangeLessThan()
        {
            var datr = new Datr();
            datr.SetDecimalRange<ValuesClass>("Decimal", Range.LessThan, maxValue: (decimal)100);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<ValuesClass>();
                Assert.IsTrue(basicClass.Decimal <= (decimal)100, $"Value generated is {basicClass.Decimal}");
            }
        }

        [TestMethod]
        public void DecimalRangeGreaterThan()
        {
            var datr = new Datr();
            datr.SetDecimalRange<ValuesClass>("Decimal", Range.GreaterThan, (decimal)100);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<ValuesClass>();
                Assert.IsTrue(basicClass.Decimal >= (decimal)100, $"Value generated is {basicClass.Decimal}");
            }
        }

        [TestMethod]
        public void DecimalRangeBetween()
        {
            var datr = new Datr();
            datr.SetDecimalRange<ValuesClass>("Decimal", Range.Between, (decimal)5, (decimal)50);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<ValuesClass>();
                Assert.IsTrue(basicClass.Decimal >= (decimal)5, $"Value generated is {basicClass.Decimal}");
                Assert.IsTrue(basicClass.Decimal <= (decimal)50, $"Value generated is {basicClass.Decimal}");
            }
        }

        [TestMethod]
        public void DecimalRangeOutside()
        {
            var datr = new Datr();
            datr.SetDecimalRange<ValuesClass>("Decimal", Range.Outside, (decimal)5, (decimal)50);

            for (int i = 0; i < 100; i++)
            {
                var basicClass = datr.Create<ValuesClass>();
                Assert.IsTrue(basicClass.Decimal < (decimal)5 || basicClass.Decimal >= (decimal)50, $"Value generated is {basicClass.Decimal}");
            }
        }

        [TestMethod]
        public void DecimalRangeMinValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.Between, maxValue: (decimal)100));
        }

        [TestMethod]
        public void DecimalRangeMinValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.Outside, maxValue: (decimal)100));
        }

        [TestMethod]
        public void DecimalRangeMaxValueNullBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.Between, minValue: (decimal)100));
        }

        [TestMethod]
        public void DecimalRangeMaxValueNullOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.Outside, minValue: (decimal)100));
        }

        [TestMethod]
        public void DecimalRangeMinValueNullGreaterThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.GreaterThan, maxValue: (decimal)100));
        }

        [TestMethod]
        public void DecimalRangeMaxValueNullLessThanRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.LessThan, minValue: (decimal)100));
        }

        [TestMethod]
        public void DecimalRangeMaxValueEqualMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.Between, minValue: (decimal)100, maxValue: (decimal)100));
        }

        [TestMethod]
        public void DecimalRangeMaxValueEqualMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.Between, minValue: (decimal)100, maxValue: (decimal)100));
        }

        [TestMethod]
        public void DecimalRangeMaxValueLessThanMinValueBetweenRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.Between, minValue: (decimal)100, maxValue: 90));
        }

        [TestMethod]
        public void DecimalRangeMaxValueLessThanMinValueOutsideRange()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.Between, minValue: (decimal)100, maxValue: (decimal)90));
        }

        [TestMethod]
        public void DecimalRangeMinValueEqualsDecimalMax()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.GreaterThan, minValue: decimal.MaxValue));
        }

        [TestMethod]
        public void DecimalRangeMaxValueEqualsDecimalMin()
        {
            var datr = new Datr();
            Assert.ThrowsException<ArgumentException>(() => datr.SetDecimalRange<ValuesClass>("Decimal", Range.LessThan, maxValue: decimal.MinValue));
        }
    }
}
