using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstituteStudy.ch02;
using System;

namespace NSubstituteStudy.Test
{
    public class ICommandTest
    {
        [TestMethod]
        public void ICommand_Execute_MultipleInterfaces()
        {
            var command = Substitute.For<ICommand, IDisposable>();

            var runner = new CommandRunner(command);
            runner.RunCommand();

            command.Received().Execute();
            ((IDisposable)command).Received().Dispose();
        }

    }
}
