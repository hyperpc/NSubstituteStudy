using NSubstitute;
using NSubstituteStudy.ch03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch03
{
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_Add_ReturnsValueWithSpecifiedArgu()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);
            Assert.AreEqual(calculator.Add(1, 2), 3);
        }

        [TestMethod]
        public void ICalculator_Add_ReturnsDefaultValueWithDifferentArgu()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);
            Assert.AreNotEqual(calculator.Add(3, 6), 3);
        }

        [TestMethod]
        public void ICalculator_Add_ReturnsValueWithPropertySetter()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Mode.Returns("DEC");
            Assert.AreEqual(calculator.Mode, "DEC");

            calculator.Mode.Returns("HEX");
            Assert.AreEqual(calculator.Mode, "HEX");
        }
    }
}
