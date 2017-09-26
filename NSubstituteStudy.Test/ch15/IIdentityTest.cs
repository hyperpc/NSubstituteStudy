using NSubstitute;
using NSubstituteStudy.ch15;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch15
{
    public class IIdentityTest
    {
        [TestMethod]
        public void IIdentity_Model_AutoRecursiveMocksDefaultValues()
        {
            var identity = Substitute.For<IIdentity>();
            Assert.AreEqual(string.Empty, identity.Name);
            Assert.AreEqual(0, identity.Roles().Length);
        }
    }
}
