using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Datr.Test.Tests
{
    [TestClass]
    public class ClassesTests
    {
        [TestMethod]
        public void ClassPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives);
        }

        [TestMethod]
        public void ClassesBoolPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.Bool);
        }

        [TestMethod]
        public void ClassesSBytePopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.SByte);
        }

        [TestMethod]
        public void ClassesBytePopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.Byte);
        }

        [TestMethod]
        public void ClassesShortPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.Short);
        }

        [TestMethod]
        public void ClassesUShortPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.UShort);
        }

        [TestMethod]
        public void ClassesCharPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.Char);
        }

        [TestMethod]
        public void ClassesDoublePopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.Double);
        }

        [TestMethod]
        public void ClassesFloatPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.Float);
        }

        [TestMethod]
        public void ClassesUIntPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.UInt);
        }

        [TestMethod]
        public void ClassesLongPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.Long);
        }

        [TestMethod]
        public void ClassesULongPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.ULong);
        }

        [TestMethod]
        public void ClassesDecimalPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.Decimal);
        }

        [TestMethod]
        public void ClassesIntPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsNotNull(classes.Primitives.Bool);
        }

        [TestMethod]
        public void StringsPopulated()
        {
            var classes = ClassesSetup();
            Assert.IsFalse(string.IsNullOrEmpty(classes.Strings1.String1));
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

            Assert.IsNotNull(childClass.ChildPrimitives);
            Assert.IsFalse(char.GetNumericValue(childClass.ChildPrimitives.Char) == 0);
            Assert.IsNotNull(childClass.ParentPrimitives);
            Assert.IsFalse(char.GetNumericValue(childClass.ParentPrimitives.Char) == 0);
        }

        [TestMethod]
        public void IgnoredPropertiesByName()
        {
            var datr = new Datr();
            datr.IgnoredPropertyNames.Add("Primitives");

            var classes = datr.Create<Classes>();

            Assert.IsNull(classes.Primitives);
            Assert.IsNotNull(classes.Strings1);
        }

        [TestMethod]
        public void IgnoredPropertiesByTypeAndName()
        {
            var datr = new Datr()
            {
                IgnoredTypeProperties = new List<TypeProperty>
                {
                    new TypeProperty(typeof(Classes), "strings1")
                }
            };

            var classes = datr.Create<Classes>();

            Assert.IsNull(classes.Strings1);
            Assert.IsNotNull(classes.Primitives);
            Assert.IsNotNull(classes.Strings2);
        }

        [TestMethod]
        public void IgnoredClassPropertyPropertiesByTypeAndName()
        {
            var datr = new Datr()
            {
                IgnoredTypeProperties = new List<TypeProperty>
                {
                    new TypeProperty(typeof(Strings), "string1")
                }
            };

            var childClass = datr.Create<ChildClass>();

            Assert.IsNull(childClass.ChildStrings.String1);
            Assert.IsNull(childClass.ParentStrings.String1);
            Assert.IsFalse(string.IsNullOrEmpty(childClass.ChildStrings.String2));
            Assert.IsFalse(string.IsNullOrEmpty(childClass.ParentStrings.String2));
        }

        [TestMethod]
        public void InheritedClassPropertiesIgnoredByTypeAndName()
        {
            var datr = new Datr()
            {
                IgnoredTypeProperties = new List<TypeProperty>
                {
                    new TypeProperty(typeof(ChildClass), "ParentStrings")
                }
            };

            var childClass = datr.Create<ChildClass>();
            Assert.IsNull(childClass.ParentStrings);
        }

        private Classes ClassesSetup()
        {
            var datr = new Datr();
            return datr.Create<Classes>();
        }
    }
}
