using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Datr.Test.Tests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void StringsPopulated()
        {
            var datr = new Datr();
            var strings = datr.Create<Strings>();
            Assert.IsFalse(string.IsNullOrEmpty(strings.String1));
        }

        [TestMethod]
        public void IgnorePropertiesByName()
        {
            var datr = new Datr();
            datr.IgnoredPropertyNames.Add("string1");

            var strings = datr.Create<Strings>();

            Assert.IsNull(strings.String1);
            Assert.IsFalse(string.IsNullOrEmpty(strings.String2));
        }

        [TestMethod]
        public void IgnorePropertiesByTypeAndName()
        {
            var datr = new Datr
            {
                IgnoredTypeProperties = new List<TypeProperty>
                {
                    new TypeProperty(typeof(Strings), "String1")
                }
            };
            

            var strings = datr.Create<Strings>();

            Assert.IsNull(strings.String1);
            Assert.IsFalse(string.IsNullOrEmpty(strings.String2));
        }
    }
}
