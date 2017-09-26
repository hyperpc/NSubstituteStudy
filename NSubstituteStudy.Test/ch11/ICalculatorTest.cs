using NSubstitute;
using NSubstituteStudy.ch11;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace NSubstituteStudy.Test.ch11
{
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_Add_IgnoringArgs()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(Arg.Any<int>(), 5).Returns(7);

            Assert.AreEqual(calculator.Add(42, 5), 7);
            Assert.AreEqual(calculator.Add(123, 5), 7);
            Assert.AreNotEqual(calculator.Add(1, 7), 7);
        }

        [TestMethod]
        public void ICalculator_Add_ConditionMatchArgs()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(1, -10);

            calculator.Received().Add(1, Arg.Is<int>(x => x < 0));
            calculator.Received().Add(1, Arg.Is<int>(x => ((IList)new[] { -2, -5, -10 }).Contains(x)));
            calculator.DidNotReceive().Add(Arg.Is<int>(x => x > 10), -10);
        }

        [TestMethod]
        public void ICalculator_Add_MatchSpecifiedArgs()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(0, 40);

            // 这里可能不工作，NSubstitute 在这种情况下无法确定在哪个参数上应用匹配器
            //calculator.Received().Add(0, Arg.Any<int>());

            calculator.Received().Add(Arg.Is(0), Arg.Any<int>());
        }
    }
}
