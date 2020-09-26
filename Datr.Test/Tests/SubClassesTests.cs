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
            Assert.IsNotNull(classes.BasicClass);
        }

        [TestMethod]
        public void SubClassPropertiesPopulated()
        {
            var classWithProperty = ClassSetup();
            Assert.IsNotNull(classWithProperty.BasicClass.Bool);
            Assert.IsNotNull(classWithProperty.BasicClass.SByte);
            Assert.IsNotNull(classWithProperty.BasicClass.Byte);
            Assert.IsNotNull(classWithProperty.BasicClass.Short);
            Assert.IsNotNull(classWithProperty.BasicClass.UShort);
            Assert.IsNotNull(classWithProperty.BasicClass.Char);
            Assert.IsNotNull(classWithProperty.BasicClass.Double);
            Assert.IsNotNull(classWithProperty.BasicClass.Float);
            Assert.IsNotNull(classWithProperty.BasicClass.UInt);
            Assert.IsNotNull(classWithProperty.BasicClass.Long);
            Assert.IsNotNull(classWithProperty.BasicClass.ULong);
            Assert.IsNotNull(classWithProperty.BasicClass.Decimal);
            Assert.IsNotNull(classWithProperty.BasicClass.Int);

            Assert.IsFalse(string.IsNullOrEmpty(classWithProperty.BasicClass.String));
            Assert.AreNotEqual(new DateTime(), classWithProperty.BasicClass.DateTime);
        }

        [TestMethod]
        public void MainClassPropertiesPopulated()
        {
            var classWithProperty = ClassSetup();
            Assert.IsFalse(string.IsNullOrEmpty(classWithProperty.MainClassString));
            Assert.AreNotEqual(0, classWithProperty.MainClassInt);
        }

        private ClassWithClassProperty ClassSetup()
        {
            var datr = new Datr();
            return datr.Create<ClassWithClassProperty>();
        }
    }
}

