using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Datr.Test.Tests
{
    [TestClass]
    public class ClassesTests
    {
        [TestMethod]
        public void ClassPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives);
        }

        [TestMethod]
        public void ClassesBoolPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.Bool);
        }

        [TestMethod]
        public void ClassesSBytePopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.SByte);
        }

        [TestMethod]
        public void ClassesBytePopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.Byte);
        }

        [TestMethod]
        public void ClassesShortPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.Short);
        }

        [TestMethod]
        public void ClassesUShortPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.UShort);
        }

        [TestMethod]
        public void ClassesCharPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.Char);
        }

        [TestMethod]
        public void ClassesDoublePopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.Double);
        }

        [TestMethod]
        public void ClassesFloatPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.Float);
        }

        [TestMethod]
        public void ClassesUIntPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.UInt);
        }

        [TestMethod]
        public void ClassesLongPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.Long);
        }

        [TestMethod]
        public void ClassesULongPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.ULong);
        }

        [TestMethod]
        public void ClassesDecimalPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.Decimal);
        }

        [TestMethod]
        public void ClassesIntPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.primatives.Bool);
        }

        [TestMethod]
        public void StringsPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsFalse(string.IsNullOrEmpty(classes.strings.String));
        }

        [TestMethod]
        public void InheritedPropertiesPopulated()
        {
            var datr = new Datr();
            var childClass = datr.Create<ChildClass>();

            Assert.IsNotNull(childClass.ChildInt);
            Assert.IsNotNull(childClass.ParentInt);

            Assert.IsNotNull(childClass.ChildString);
            Assert.IsNotNull(childClass.ParentString);

            Assert.IsNotNull(childClass.ChildStrings);
            Assert.IsFalse(string.IsNullOrEmpty(childClass.ChildStrings.String));
            Assert.IsNotNull(childClass.ParentStrings);
            Assert.IsFalse(string.IsNullOrEmpty(childClass.ParentStrings.String));

            Assert.IsNotNull(childClass.ChildPrimatives);
            Assert.IsFalse(char.GetNumericValue(childClass.ChildPrimatives.Char) == 0);
            Assert.IsNotNull(childClass.ParentPrimatives);
            Assert.IsFalse(char.GetNumericValue(childClass.ParentPrimatives.Char) == 0);
        }

        private Classes ClassesSetup()
        {
            var datr = new Datr();
            return datr.Create<Classes>();
        }
    }
}
