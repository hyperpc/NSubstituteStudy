using System;

namespace NSubstituteStudy.ch02
{
    public interface ICommand : IDisposable
    {
        void Execute();
    }
}
