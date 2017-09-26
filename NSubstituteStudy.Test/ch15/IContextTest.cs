using NSubstitute;
using NSubstituteStudy.ch15;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch15
{
    public class IContextTest
    {
        [TestMethod]
        public void IContext_CurrentRequest_AutoRecursiveMocksSubsChain()
        {
            var context = Substitute.For<IContext>();
            context.CurrentRequest.Identity.Name.Returns("My pet fish Eric");

            Assert.AreEqual("My pet fish Eric", context.CurrentRequest.Identity.Name);
        }
    }
}
