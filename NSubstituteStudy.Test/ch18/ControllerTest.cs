using NSubstitute;
using NSubstituteStudy.ch18;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NSubstituteStudy.Test.ch18
{
    public class ControllerTest
    {
        [TestMethod]
        public void Controller_DoStuff_CallOrderInCommandRunWhileConnOpen()
        {
            var connection = Substitute.For<IConnection>();
            var command = Substitute.For<ICommand>();
            var controller = new Controller(connection, command);

            controller.DoStuff();

            Received.InOrder(() =>
                {
                    connection.Open();
                    command.Run(connection);
                    connection.Close();
                });

        }

        [TestMethod]
        public void Controller_DoStuff_CallOrderWhenSubscribeEventBeforeConnOpen()
        {
            var connection = Substitute.For<IConnection>();
            connection.SomethingHappened += () => {/* some event handler */};
            connection.Open();

            Received.InOrder(() =>
            {
                connection.SomethingHappened += Arg.Any<Action>();
                connection.Open();
            });
        }
    }
}
