using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Datr.Test.Tests
{
    [TestClass]
    public class SubClassesTests
    {
        [TestMethod]
        public void SubClassPopulated()
        {
            var classes = ClassSetup();
            Assert.IsNotNull(classes.ValuesClass);
        }

        [TestMethod]
        public void SubClassPropertiesPopulated()
        {
            var classWithProperty = ClassSetup();
            Assert.IsNotNull(classWithProperty.ValuesClass.Bool);
            Assert.IsNotNull(classWithProperty.ValuesClass.SByte);
            Assert.IsNotNull(classWithProperty.ValuesClass.Byte);
            Assert.IsNotNull(classWithProperty.ValuesClass.Short);
            Assert.IsNotNull(classWithProperty.ValuesClass.UShort);
            Assert.IsNotNull(classWithProperty.ValuesClass.Char);
            Assert.IsNotNull(classWithProperty.ValuesClass.Double);
            Assert.IsNotNull(classWithProperty.ValuesClass.Float);
            Assert.IsNotNull(classWithProperty.ValuesClass.UInt);
            Assert.IsNotNull(classWithProperty.ValuesClass.Long);
            Assert.IsNotNull(classWithProperty.ValuesClass.ULong);
            Assert.IsNotNull(classWithProperty.ValuesClass.Decimal);
            Assert.IsNotNull(classWithProperty.ValuesClass.Int);

            Assert.IsFalse(string.IsNullOrEmpty(classWithProperty.ValuesClass.String));
            Assert.AreNotEqual(new DateTime(), classWithProperty.ValuesClass.DateTime);
        }

        [TestMethod]
        public void MainClassPropertiesPopulated()
        {
            var classWithProperty = ClassSetup();
            Assert.IsFalse(string.IsNullOrEmpty(classWithProperty.MainClassString));
            Assert.AreNotEqual(0, classWithProperty.MainClassInt);
        }

        [TestMethod]
        public void SubClassArrayPopulated()
        {
            var classes = ClassSetup();
            Assert.IsTrue(classes.BasicClassArray.Length > 0);
            foreach (var val in classes.BasicClassArray)
            {
                Assert.IsNotNull(val.Bool);
                Assert.IsNotNull(val.SByte);
                Assert.IsNotNull(val.Byte);
                Assert.IsNotNull(val.Short);
                Assert.IsNotNull(val.UShort);
                Assert.IsNotNull(val.Char);
                Assert.IsNotNull(val.Double);
                Assert.IsNotNull(val.Float);
                Assert.IsNotNull(val.UInt);
                Assert.IsNotNull(val.Long);
                Assert.IsNotNull(val.ULong);
                Assert.IsNotNull(val.Decimal);
                Assert.IsNotNull(val.Int);

                Assert.IsFalse(string.IsNullOrEmpty(val.String));
                Assert.AreNotEqual(new DateTime(), val.DateTime);
            }
        }

        [TestMethod]
        public void SubClassListPopulated()
        {
            var classes = ClassSetup();
            Assert.IsTrue(classes.BasicClassList.Count > 0);
            foreach (var val in classes.BasicClassList)
            {
                Assert.IsNotNull(val.Bool);
                Assert.IsNotNull(val.SByte);
                Assert.IsNotNull(val.Byte);
                Assert.IsNotNull(val.Short);
                Assert.IsNotNull(val.UShort);
                Assert.IsNotNull(val.Char);
                Assert.IsNotNull(val.Double);
                Assert.IsNotNull(val.Float);
                Assert.IsNotNull(val.UInt);
                Assert.IsNotNull(val.Long);
                Assert.IsNotNull(val.ULong);
                Assert.IsNotNull(val.Decimal);
                Assert.IsNotNull(val.Int);

                Assert.IsFalse(string.IsNullOrEmpty(val.String));
                Assert.AreNotEqual(new DateTime(), val.DateTime);
            }
        }

        private ClassWithClassProperty ClassSetup()
        {
            var datr = new Datr();
            return datr.Create<ClassWithClassProperty>();
        }
    }
}

