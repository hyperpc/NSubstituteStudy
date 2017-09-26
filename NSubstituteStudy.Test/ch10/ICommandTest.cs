using NSubstitute;
using NSubstituteStudy.ch10;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch10
{
    public class ICommandTest
    {
        [TestMethod]
        public void ICommand_Execute_ClearReceiveCallToForgetPrecall()
        {
            var command = Substitute.For<ICommand>();
            var runner = new OnceOffCommandRunner(command);

            //first run
            runner.Run();
            command.Received().Execute();

            //forget pre-call on command
            command.ClearReceivedCalls();
            //ClearReceivedCalls()不会清理通过Returns()为替代实例设定的返回值。如果需要这样做，可通过再次调用Returns()来替换之前指定的值得方式来进行



            //second run
            runner.Run();
            command.DidNotReceive().Execute();
        }
    }
}
