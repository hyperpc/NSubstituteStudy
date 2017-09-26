using NSubstitute;
using NSubstituteStudy.ch07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NSubstituteStudy.Test.ch07
{
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_Mode_ReturnsMultipleVlues()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Mode.Returns("DEC", "HEX", "BIN");
            Assert.AreEqual(calculator.Mode, "DEC");
            Assert.AreEqual(calculator.Mode, "HEX");
            Assert.AreEqual(calculator.Mode, "BIN");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ICalculator_Mode_ReturnsMultipleVluesWithCallback()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Mode.Returns(x => "DEX", x => "HEX", x => { throw new Exception(); });
            Assert.AreEqual(calculator.Mode, "DEX");
            Assert.AreEqual(calculator.Mode, "HEX");
            var result = calculator.Mode;
        }
    }
}
