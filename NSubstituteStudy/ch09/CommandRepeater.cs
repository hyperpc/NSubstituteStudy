
namespace NSubstituteStudy.ch09
{
    public class CommandRepeater
    {
        ICommand command;
        int numberOfTimesToCall;

        public CommandRepeater(ICommand command, int numberOfTimesToCall)
        {
            this.command = command;
            this.numberOfTimesToCall = numberOfTimesToCall;
        }

        public void Execute()
        {
            for (int i = 0; i < numberOfTimesToCall; i++)
                command.Execute();
        }
    }
}
