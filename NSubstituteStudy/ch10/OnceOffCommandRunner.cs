
namespace NSubstituteStudy.ch10
{
    public class OnceOffCommandRunner
    {
        ICommand command;

        public OnceOffCommandRunner(ICommand command)
        {
            this.command = command;
        }

        public void Run()
        {
            if (command == null)
                return;

            command.Execute();
            command = null;
        }
    }
}
