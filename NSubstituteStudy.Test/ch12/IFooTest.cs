using NSubstitute;
using NSubstituteStudy.ch12;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch12
{
    public class IFooTest
    {
        [TestMethod]
        public void IFoo_SayHello_VoidFuncCallbackWhenDo()
        {
            var counter = 0;
            var foo = Substitute.For<IFoo>();

            foo.When(x => x.SayHello("World")).Do(x => counter++);
            foo.SayHello("World");
            foo.SayHello("World");
            Assert.AreEqual(counter, 2);
        }
    }
}
