using NSubstitute;
using NSubstituteStudy.ch06;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch06
{
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_Add_ReturnsSum()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(Arg.Any<int>(), Arg.Any<int>()).Returns(x => (int)x[0] + (int)x[1]);
            Assert.AreEqual(calculator.Add(1, 1), 2);
            Assert.AreEqual(calculator.Add(20, 30), 50);
            Assert.AreEqual(calculator.Add(-73, 9348), 9275);
        }

        [TestMethod]
        public void ICalculator_Add_ReturnsFromFuncCallback()
        {
            var calculator = Substitute.For<ICalculator>();

            var counter=0;
            calculator.Add(0, 0).ReturnsForAnyArgs(x => { counter++; return 0; });
            calculator.Add(7, 3);
            calculator.Add(2, 2);
            calculator.Add(11, -3);
            Assert.AreEqual(counter, 3);
        }

        [TestMethod]
        public void ICalculator_Add_ReturnsFromFuncCallbackWithAndDoes()
        {
            var calculator = Substitute.For<ICalculator>();

            var counter = 0;
            calculator.Add(0, 0).ReturnsForAnyArgs(x => 0).AndDoes(x => counter++);
            calculator.Add(7, 3);
            calculator.Add(2, 2);
            Assert.AreEqual(counter, 2);
        }
    }
}
