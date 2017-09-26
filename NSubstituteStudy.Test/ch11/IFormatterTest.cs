using NSubstitute;
using NSubstituteStudy.ch11;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch11
{
    public class IFormatterTest
    {
        [TestMethod]
        public void IFormatter_Format_MatchArgsSubTypes()
        {
            IFormatter formatter = Substitute.For<IFormatter>();

            formatter.Format(new object());
            formatter.Format("some string");

            formatter.Received().Format(Arg.Any<object>());
            formatter.Received().Format(Arg.Any<string>());
            formatter.DidNotReceive().Format(Arg.Any<int>());
        }

        [TestMethod]
        public void IFormatter_Format_ConditionMatchArgsThrowException()
        {
            //IFormatter formatter = Substitute.For<IFormatter>();

            //formatter.Format(Arg.Is<string>(x => x.Length <= 100)).Returns("Matched");

            //Assert.AreEqual("Matched", formatter.Format("Short"));
            //Assert.AreEqual("Matched", formatter.Format("Not matched, too long"));

            //Assert.AreNotEqual("Matched", formatter.Format(null));
        }
    }
}
