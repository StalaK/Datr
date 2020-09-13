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
            Assert.IsNotNull(classes.Primatives);
        }

        [TestMethod]
        public void ClassesBoolPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.Bool);
        }

        [TestMethod]
        public void ClassesSBytePopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.SByte);
        }

        [TestMethod]
        public void ClassesBytePopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.Byte);
        }

        [TestMethod]
        public void ClassesShortPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.Short);
        }

        [TestMethod]
        public void ClassesUShortPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.UShort);
        }

        [TestMethod]
        public void ClassesCharPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.Char);
        }

        [TestMethod]
        public void ClassesDoublePopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.Double);
        }

        [TestMethod]
        public void ClassesFloatPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.Float);
        }

        [TestMethod]
        public void ClassesUIntPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.UInt);
        }

        [TestMethod]
        public void ClassesLongPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.Long);
        }

        [TestMethod]
        public void ClassesULongPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.ULong);
        }

        [TestMethod]
        public void ClassesDecimalPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.Decimal);
        }

        [TestMethod]
        public void ClassesIntPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primatives.Bool);
        }

        [TestMethod]
        public void StringsPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsFalse(string.IsNullOrEmpty(classes.Strings.String1));
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
            Assert.IsFalse(string.IsNullOrEmpty(childClass.ChildStrings.String1));
            Assert.IsNotNull(childClass.ParentStrings);
            Assert.IsFalse(string.IsNullOrEmpty(childClass.ParentStrings.String1));

            Assert.IsNotNull(childClass.ChildPrimatives);
            Assert.IsFalse(char.GetNumericValue(childClass.ChildPrimatives.Char) == 0);
            Assert.IsNotNull(childClass.ParentPrimatives);
            Assert.IsFalse(char.GetNumericValue(childClass.ParentPrimatives.Char) == 0);
        }

        [TestMethod]
        public void IgnoredPropertiesByName()
        {
            var datr = new Datr();
            datr.IgnoredPropertyNames.Add("Primatives");

            var classes = datr.Create<Classes>();

            Assert.IsNull(classes.Primatives);
            Assert.IsNotNull(classes.Strings);
        }

        private Classes ClassesSetup()
        {
            var datr = new Datr();
            return datr.Create<Classes>();
        }
    }
}
