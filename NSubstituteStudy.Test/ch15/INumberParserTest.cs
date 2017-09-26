using NSubstitute;
using NSubstituteStudy.ch15;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch15
{
    public class INumberParserTest
    {
        [TestMethod]
        public void INumberParser_Parse_AutoRecursiveMocksManuallyCreateSubs()
        {
            var factory = Substitute.For<INumberParserFactory>();
            var parser = Substitute.For<INumberParser>();
            factory.Create(',').Returns(parser);
            parser.Parse("an expression").Returns(new int[] { 1, 2, 3 });

            var actual = factory.Create(',').Parse("an expression");
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, actual);
        }

        [TestMethod]
        public void INumberParser_Parse_AutoRecursiveMocksAutoCreateSubs()
        {
            var factory = Substitute.For<INumberParserFactory>();
            factory.Create(',').Parse("an expression").Returns(new int[] { 1, 2, 3 });

            var actual = factory.Create(',').Parse("an expression");
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, actual);
        }

        [TestMethod]
        public void INumberParser_Parse_AutoRecursiveMocksCallRecursivelySubbed()
        {
            var factory = Substitute.For<INumberParserFactory>();
            factory.Create(',').Parse("an expression").Returns(new int[] { 1, 2, 3 });

            var firstCall = factory.Create(',');
            var secondCall = factory.Create(',');
            var thirdCallWithDiffArg = factory.Create('x');

            Assert.AreSame(firstCall, secondCall);
            Assert.AreNotSame(firstCall, thirdCallWithDiffArg);
        }
    }
}
