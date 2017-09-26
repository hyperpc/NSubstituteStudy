using NSubstitute;
using NSubstituteStudy.ch16;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch16
{
    public class ILookupTest
    {
        [TestMethod]
        public void ILookup_TryLookup_SetOutRefArgs()
        { 
            //Arrange
            var value = string.Empty;
            var lookup = Substitute.For<ILookup>();
            lookup
                .TryLookup("hello", out value)
                .Returns(x => { x[1] = " world!"; return true; });
            //Act
            var result = lookup.TryLookup("hello", out value);
            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(value, " world!");
        }
    }
}
