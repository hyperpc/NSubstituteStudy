using NSubstitute;
using NSubstituteStudy.ch09;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace NSubstituteStudy.Test.ch09
{
    public class ICommandTest
    {
        [TestMethod]
        public void ICommand_Execute_CheckReceiveCall()
        { 
            //Arrange
            var command = Substitute.For<ICommand>();
            var something = new SomethingThatNeedsACommand(command);

            //Act
            something.DoSomething();

            //Assert
            command.Received().Execute();
        }

        [TestMethod]
        public void ICommand_Execute_CheckNotReceiveCall()
        {
            //Arrange
            var command = Substitute.For<ICommand>();
            var something = new SomethingThatNeedsACommand(command);

            //Act
            something.DonotDoAnything();

            //Assert
            command.DidNotReceive().Execute();
        }

        [TestMethod]
        public void ICommand_Execute_CheckReceiveNumberofTimesCall()
        {
            //Arrange
            var command = Substitute.For<ICommand>();
            var repeater = new CommandRepeater(command, 3);

            //Act
            repeater.Execute();

            //Assert
            //command.Received(2).Execute();
            command.Received(3).Execute();
            //command.Received(4).Execute();
        }

        [TestMethod]
        public void ICalculator_Add_CheckCallReceivedWithArgs()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(1, 2);
            calculator.Add(-100, 100);

            calculator.Received().Add(Arg.Any<int>(), 2);
            calculator.Received().Add(Arg.Is<int>(x => x < 0), 100);
            calculator.DidNotReceive().Add(Arg.Any<int>(), Arg.Is<int>(x => x >= 500));
        }

        [TestMethod]
        public void ICalculator_Add_CheckCallReceivedIgnoringArgs()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(1, 3);

            calculator.ReceivedWithAnyArgs().Add(1, 1);
            calculator.DidNotReceiveWithAnyArgs().Add(0, 0);
        }

        [TestMethod]
        public void ICalculator_Mode_CheckReceivedPropertyCalls()
        {
            var calculator = Substitute.For<ICalculator>();

            var mode = calculator.Mode;
            calculator.Mode = "TEST";

            var temp = calculator.Received().Mode;

            calculator.Received().Mode = "TEST";
        }

        [TestMethod]
        public void Dictionary_Indexer_CheckReceivedCalls()
        {
            var dictionary = Substitute.For<IDictionary<string, int>>();
            dictionary["test"] = 1;

            dictionary.Received()["test"] = 1;
            dictionary.Received()["test"] = Arg.Is<int>(x => x < 5);
        }

        [TestMethod]
        public void ICommand_Execute_CheckReceivedEventSubscribeCalls()
        {
            var command = Substitute.For<ICommand>();
            var watcher = new CommandWatcher(command);

            command.Executed += Raise.Event();

            Assert.IsTrue(watcher.DidStuff);
        }

        [TestMethod]
        public void ICommand_Execute_MakeSureReceivedEventSubscribeCalls()
        {
            var command = Substitute.For<ICommand>();
            var watcher = new CommandWatcher(command);
            //不推荐此做法。
            //更好的办法是测试行为，而不是具体实现。
            command.Received().Executed += watcher.OnExecuted;
            //或者有可能事件处理器不可访问。
            command.Received().Executed += Arg.Any<EventHandler>();
        }

    }
}
