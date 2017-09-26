
namespace NSubstituteStudy.ch09
{
    public class SomethingThatNeedsACommand
    {
        ICommand command;
        public SomethingThatNeedsACommand(ICommand command)
        {
            this.command = command;
        }
        public void DoSomething() { command.Execute(); }
        public void DonotDoAnything() { }
    }
}
