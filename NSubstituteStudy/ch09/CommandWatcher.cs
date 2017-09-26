using System;

namespace NSubstituteStudy.ch09
{
    public class CommandWatcher
    {
        ICommand command;
        public CommandWatcher(ICommand command)
        {
            this.command = command;
            this.command.Executed += OnExecuted;
        }

        public bool DidStuff { get; private set; }
        public void OnExecuted(object o, EventArgs e)
        {
            DidStuff = true;
        }
    }
}
