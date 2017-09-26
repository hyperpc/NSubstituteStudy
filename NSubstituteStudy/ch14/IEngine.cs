using System;

namespace NSubstituteStudy.ch14
{
    public interface IEngine
    {
        event EventHandler idling;
        event EventHandler<LowFuelWarningEventArgs> LowFuelWarning;
        event Action<int> RevvedAt;
    }
}
