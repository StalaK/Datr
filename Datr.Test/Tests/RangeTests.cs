using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class RangeTests
    {
        [TestMethod]
        public void AddIntRangeToList()
        {
            var datr = new Datr();
            datr.SetIntRange<Primitives>("Int", Range.GreaterThan, 100);

            Assert.AreEqual(1, datr.FixedRanges.Count);
            Assert.AreEqual(typeof(int), datr.FixedRanges[0].DataType);
            Assert.AreEqual(typeof(Primitives), datr.FixedRanges[0].ClassType);
            Assert.AreEqual(Range.GreaterThan, datr.FixedRanges[0].Range);
            Assert.AreEqual(100, datr.FixedRanges[0].MinValue);
            Assert.IsNull(datr.FixedRanges[0].MaxValue);
        }

        [TestMethod]
        public void IntRangeLessThan()
        {
            var datr = new Datr();
            datr.SetIntRange<Primitives>("Int", Range.LessThan, maxValue: 100);

            for (int i = 0; i < 100; i++)
            {
                var primitives = datr.Create<Primitives>();
                Assert.IsTrue(primitives.Int < 100, $"Value generated is {primitives.Int}");
            }
        }

        [TestMethod]
        public void IntRangeGreaterThan()
        {
            var datr = new Datr();
            datr.SetIntRange<Primitives>("Int", Range.GreaterThan, 100);

            for (int i = 0; i < 100; i++)
            {
                var primitives = datr.Create<Primitives>();
                Assert.IsTrue(primitives.Int >= 100, $"Value generated is {primitives.Int}");
            }
        }

        [TestMethod]
        public void IntRangeBetween()
        {
            var datr = new Datr();
            datr.SetIntRange<Primitives>("Int", Range.Between, -50, 50);

            for (int i = 0; i < 100; i++)
            {
                var primitives = datr.Create<Primitives>();
                Assert.IsTrue(primitives.Int >= -50, $"Value generated is {primitives.Int}");
                Assert.IsTrue(primitives.Int < 50, $"Value generated is {primitives.Int}");
            }
        }

        [TestMethod]
        public void IntRangeOutside()
        {
            var datr = new Datr();
            datr.SetIntRange<Primitives>("Int", Range.Outside, -50, 50);

            for (int i = 0; i < 100; i++)
            {
                var primitives = datr.Create<Primitives>();
                Assert.IsTrue(primitives.Int < -50 || primitives.Int >= 50, $"Value generated is {primitives.Int}");
            }
        }

        [TestMethod]
        public void IntRangeMinValueNullBetweenRange()
        {
            var datr = new Datr();
            datr.SetIntRange<Primitives>("Int", Range.Between, maxValue: 100);
            Assert.ThrowsException<ArgumentException>(() => datr.Create<Primitives>(), "SetIntRange: minValue and maxValue parameters must be set when using a range of Between or Outside.");
        }
    }
}
