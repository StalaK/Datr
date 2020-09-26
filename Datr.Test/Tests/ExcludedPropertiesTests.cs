using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Datr.Test.Tests
{
    [TestClass]
    public class ExcludedPropertiesTests
    {
        [TestMethod]
        public void ExcludePropetiesByName()
        {
            var datr = new Datr
            {
                ExcludedPropertyNames = new List<string> { "Int", "Char" }
            };

            var basicClass= datr.Create<BasicClass>();

            Assert.AreEqual(0, basicClass.Int);
            Assert.AreEqual(0, (int)basicClass.Char);
        }

        [TestMethod]
        public void ExcludePropetiesByTypeAndName()
        {
            var datr = new Datr
            {
                ExcludedTypeProperties = new List<TypeProperty>
                {
                    new TypeProperty(typeof(BasicClass), "Int"),
                    new TypeProperty(typeof(BasicClass), "NotChar"),
                }
            };

            var basicClass = datr.Create<BasicClass>();

            Assert.AreEqual(0, basicClass.Int);
            Assert.IsNotNull(basicClass.Char);
        }

        [TestMethod]
        public void ExcludeInheritedPropetiesByName()
        {
            var datr = new Datr
            {
                ExcludedPropertyNames = new List<string> { "ParentInt", "ParentString" }
            };

            var childClass = datr.Create<ChildClass>();

            Assert.AreEqual(0, childClass.ParentInt);
            Assert.IsTrue(string.IsNullOrEmpty(childClass.ParentString));
        }

        [TestMethod]
        public void ExcludeInheritedPropetiesByTypeAndName()
        {
            var datr = new Datr
            {
                ExcludedTypeProperties = new List<TypeProperty>
                {
                    new TypeProperty(typeof(ChildClass), "ParentInt"),
                    new TypeProperty(typeof(ParentClass), "ParentString"),
                }
            };

            var childClass = datr.Create<ChildClass>();

            Assert.AreEqual(0, childClass.ParentInt);
            Assert.IsFalse(string.IsNullOrEmpty(childClass.ParentString));
        }
    }
}
