using System;

namespace NSubstituteStudy.ch18
{
    public interface IConnection
    {
        void Open();
        void Close();
        event Action SomethingHappened;
    }
}
