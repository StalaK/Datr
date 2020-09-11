using Datr.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsFalse(string.IsNullOrEmpty(strings.String));
        }
    }
}
