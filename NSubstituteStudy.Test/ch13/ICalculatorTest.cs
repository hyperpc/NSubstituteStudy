using NSubstitute;
using NSubstituteStudy.ch13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NSubstituteStudy.Test.ch13
{
    public class ICalculatorTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ICalculator_Add_VoidFuncThrowException()
        {
            var calculator = Substitute.For<ICalculator>();

            //void func
            calculator.Add(-1, -1).Returns(x => { throw new Exception(); });

            //exception
            calculator.Add(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ICalculator_Add_VoidAndNonVoidFuncThrowException()
        {
            var calculator = Substitute.For<ICalculator>();

            //void func or non-void
            calculator.When(x => x.Add(-2, -2))
                .Do(x => { throw new Exception(); });

            //exception
            calculator.Add(-2, -2);
        }
    }
}
