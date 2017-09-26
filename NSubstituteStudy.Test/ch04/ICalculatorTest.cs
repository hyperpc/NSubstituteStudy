using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstituteStudy.ch04;

namespace NSubstituteStudy.Test.ch04
{
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_Add_ReturnsValueUseArgsMatcher()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(Arg.Any<int>(), 5).Returns(10);
            Assert.AreEqual(calculator.Add(123, 5), 10);
            Assert.AreEqual(calculator.Add(-9, 5), 10);
            Assert.AreNotEqual(calculator.Add(-9, -9), 10);

            calculator.Add(1, Arg.Is<int>(x => x < 0)).Returns(345);
            Assert.AreEqual(calculator.Add(1, -2), 345);
            Assert.AreNotEqual(calculator.Add(1, 2), 345);

            calculator.Add(Arg.Is<int>(0), Arg.Is<int>(0)).Returns(99);
            Assert.AreEqual(calculator.Add(0, 0), 99);
        }
    }
}
