using NSubstitute;
using NSubstituteStudy.ch17;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NSubstituteStudy.Test.ch17
{
    public class ICalculatorTest
    {
        [TestMethod]
        public void ICalculator_Multiply_PerformActionWithMatchedArgs()
        {
            var calculator = Substitute.For<ICalculator>();

            var argUsed = 0;
            calculator.Multiply(Arg.Any<int>(), Arg.Do<int>(x => argUsed = x));

            calculator.Multiply(123, 42);

            Assert.AreEqual(42, argUsed);
        }

        [TestMethod]
        public void ICalculator_Multiply_PerformActionWithAnyMatchedArgs()
        {
            var calculator = Substitute.For<ICalculator>();

            var firstArgsMultiplied = new List<int>();
            calculator.Multiply(Arg.Do<int>(x => firstArgsMultiplied.Add(x)), 10);

            calculator.Multiply(2, 10);
            calculator.Multiply(5, 10);
            //第二个参数不为10， 所以不会被Arg.Do匹配
            calculator.Multiply(7, 4567);

            CollectionAssert.AreEqual(firstArgsMultiplied, new[] { 2, 5 });
        }

        [TestMethod]
        public void ICalculator_Multiply_ArgsActionCallSpecWithMatchedArgs()
        {
            var calculator = Substitute.For<ICalculator>();

            var numberOfCallsWhereFirstArgIsLessThanZero = 0;
            //指定调用参数：
            //第一个参数小于0
            //第二个参数可以为任意的int类型值
            //当此满足此规格时，计数器加1
            calculator.Multiply(
                Arg.Is<int>(x => x < 0),
                Arg.Do<int>(x => numberOfCallsWhereFirstArgIsLessThanZero++)
                ).Returns(123);

            var result = new[]
            {
                calculator.Multiply(-4, 3),
                calculator.Multiply(-27, 88),
                calculator.Multiply(-7, 8),
                //第一个参数>0， 所以不会被Arg.Do匹配
                calculator.Multiply(123, 2)
            };

            Assert.AreEqual(numberOfCallsWhereFirstArgIsLessThanZero, 3);
            CollectionAssert.AreEqual(result, new[] { 123, 123, 123, 0 });
        }

    }
}
