using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Datr.Test.Tests
{
    [TestClass]
    public class ExcludedPropertiesTests
    {
        //[TestMethod]
        //public void ExcludedPropertiesByName()
        //{
        //    var datr = new Datr();
        //    datr.ExcludedPropertyNames.Add("Primitives");

        //    var classes = datr.Create<ClassWithClassProperty>();

        //    Assert.IsNull(classes.BasicClass);
        //    Assert.IsNotNull(classes.Strings1);
        //}

        //[TestMethod]
        //public void ExcludedPropertiesByTypeAndName()
        //{
        //    var datr = new Datr()
        //    {
        //        ExcludedTypeProperties = new List<TypeProperty>
        //        {
        //            new TypeProperty(typeof(ClassWithClassProperty), "strings1")
        //        }
        //    };

        //    var classes = datr.Create<ClassWithClassProperty>();

        //    Assert.IsNull(classes.Strings1);
        //    Assert.IsNotNull(classes.BasicClass);
        //    Assert.IsNotNull(classes.Strings2);
        //}

        //[TestMethod]
        //public void ExcludedClassPropertyPropertiesByTypeAndName()
        //{
        //    var datr = new Datr()
        //    {
        //        ExcludedTypeProperties = new List<TypeProperty>
        //        {
        //            new TypeProperty(typeof(Strings), "string1")
        //        }
        //    };

        //    var childClass = datr.Create<ChildClass>();

        //    Assert.IsNull(childClass.ChildStrings.String1);
        //    Assert.IsNull(childClass.ParentStrings.String1);
        //    Assert.IsFalse(string.IsNullOrEmpty(childClass.ChildStrings.String2));
        //    Assert.IsFalse(string.IsNullOrEmpty(childClass.ParentStrings.String2));
        //}

        //[TestMethod]
        //public void InheritedClassPropertiesExcludedByTypeAndName()
        //{
        //    var datr = new Datr()
        //    {
        //        ExcludedTypeProperties = new List<TypeProperty>
        //        {
        //            new TypeProperty(typeof(ChildClass), "ParentStrings")
        //        }
        //    };

        //    var childClass = datr.Create<ChildClass>();
        //    Assert.IsNull(childClass.ParentStrings);
        //}
    }
}
