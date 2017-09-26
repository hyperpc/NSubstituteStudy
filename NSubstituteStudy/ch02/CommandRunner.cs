
namespace NSubstituteStudy.ch02
{
    public class CommandRunner
    {
        private ICommand _command;

        public CommandRunner(ICommand command)
        {
            _command = command;
        }

        public void RunCommand()
        {
            _command.Execute();
            _command.Dispose();
        }
    }
}
