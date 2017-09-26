using System;

namespace NSubstituteStudy.ch17
{
    public interface IOrderProcessor
    {
        void ProcessOrder(int orderId, Action<bool> orderProcessed);
    }
}
