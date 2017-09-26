using NSubstitute;
using NSubstituteStudy.ch05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch05
{
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_Add_ReturnsValueWithAnyArgu()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(1, 2).ReturnsForAnyArgs(100);
            Assert.AreEqual(calculator.Add(1, 2), 100);
            Assert.AreEqual(calculator.Add(-7, 15), 100);
        }
    }
}
