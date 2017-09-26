using NSubstitute;
using NSubstituteStudy.ch06;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch06
{
    public class IFooTest
    {
        [TestMethod]
        public void IFoo_Bar_ReturnFromFuncWithCallInfo()
        {
            var foo = Substitute.For<IFoo>();
            foo.Bar(0, string.Empty).ReturnsForAnyArgs(x => string.Format("Hello {0}", x.Arg<string>()));
            Assert.AreEqual(foo.Bar(7, "World"), "Hello World");
        }
    }
}
