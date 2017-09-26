using NSubstitute;
using NSubstituteStudy.ch08;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch08
{
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_Mode_ReturnValuesReplacedTimes()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Mode.Returns("DEC,HEX,OCT");
            calculator.Mode.Returns(x=>"???");
            calculator.Mode.Returns("HEX");
            calculator.Mode.Returns("BIN");
            Assert.AreEqual(calculator.Mode, "BIN");
        }
    }
}
