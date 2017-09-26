using System;

namespace NSubstituteStudy.ch09
{
    public interface ICommand
    {
        void Execute();
        event EventHandler Executed;
    }
}
