using NSubstitute;
using NSubstituteStudy.ch12;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch12
{
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_Add_PassFuncToCallbackWhenDo()
        {
            var calculator = Substitute.For<ICalculator>();

            var counter = 0;
            calculator.Add(0, 0)
                .ReturnsForAnyArgs(x => 0)
                .AndDoes(x => counter++);

            calculator.Add(7, 3);
            calculator.Add(2, 2);
            calculator.Add(11, -3);
            Assert.AreEqual(counter, 3);
        }

        [TestMethod]
        public void ICalculator_Add_NonVoidFuncCallbackWhenDo()
        {
            var calculator = Substitute.For<ICalculator>();

            var counter = 0;
            calculator.Add(1, 2).Returns(3);
            calculator
                .When(x => x.Add(Arg.Any<int>(), Arg.Any<int>()))
                .Do(x => counter++);

            var result = calculator.Add(1, 2);
            Assert.AreEqual(3, result);
            Assert.AreEqual(1, counter);
        }
    }
}
