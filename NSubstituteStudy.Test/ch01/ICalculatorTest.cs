using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Exceptions;
using NSubstituteStudy.ch01;

namespace NSubstituteStudy.Test
{
    [TestClass]
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_GetInstance_ReturnICalculator()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
        }

        [TestMethod]
        public void ICalculator_AddWithTwoInteger_ReturnSpecifiedValue()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);

            int actual = calculator.Add(1, 2);
            Assert.AreEqual<int>(3, actual);
        }

        [TestMethod]
        public void ICalculator_AddWithTwoInteger_ReceivedSpecificCall()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2);

            calculator.Received().Add(1, 2);
            calculator.DidNotReceive().Add(5, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(ReceivedCallsException))]
        public void ICalculator_AddWithTwoInteger_NotReceivedSpecificCall()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(5, 7);

            calculator.Received().Add(1, 2);
        }

        [TestMethod]
        public void ICalculator_AddWithTwoInteger_MatchArguments()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(10, -5);
            calculator.Received().Add(10, Arg.Any<int>());
            calculator.Received().Add(10, Arg.Is<int>(x => x < 0));
        }

        [TestMethod]
        public void ICalculator_AddWithTwoInteger_PassFuncToReturns()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(Arg.Any<int>(), Arg.Any<int>())
                .Returns(x => (int)x[0] + (int)x[1]);

            int actual = calculator.Add(5, 10);
            Assert.AreEqual<int>(15, actual);
        }

        [TestMethod]
        public void ICalculator_Mode_SetPropertyValue()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Mode.Returns("DEC");
            Assert.AreEqual<string>("DEC", calculator.Mode);
            calculator.Mode.Returns("HEX");
            Assert.AreEqual<string>("HEX", calculator.Mode);
        }

        [TestMethod]
        public void ICalculator_Mode_SetPropertyMultipleValues()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Mode.Returns("DEC", "HEX", "BIN");

            Assert.AreEqual<string>("DEC", calculator.Mode);
            Assert.AreEqual<string>("HEX", calculator.Mode);
            Assert.AreEqual<string>("BIN", calculator.Mode);
        }

        [TestMethod]
        public void ICalculator_PoweringUp_RaiseEvent()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            bool eventWasRaised = false;

            calculator.PoweringUp += (sender, args) => { eventWasRaised = true; };
            calculator.PoweringUp += Raise.Event();

            Assert.IsTrue(eventWasRaised); 
        }

    }
}
