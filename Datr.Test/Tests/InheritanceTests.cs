using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Datr.Test.Tests;

[TestClass]
public class InheritanceTests
{
    [TestMethod]
    public void InheritedPropertiesPopulated()
    {
        var datr = new Datr();
        var childClass = datr.Create<ChildClass>();

        Assert.IsNotNull(childClass.ChildInt);
        Assert.IsNotNull(childClass.ParentInt);

        Assert.IsNotNull(childClass.ChildString);
        Assert.IsNotNull(childClass.ParentString);

        Assert.IsNotNull(childClass.ChildSubClass);
        Assert.IsNotNull(childClass.ParentSubClass);
    }
}
