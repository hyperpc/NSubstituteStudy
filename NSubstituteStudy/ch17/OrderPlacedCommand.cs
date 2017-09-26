
namespace NSubstituteStudy.ch17
{
    public class OrderPlacedCommand
    {
        IOrderProcessor orderProcessor;
        IEvents events;
        public OrderPlacedCommand(IOrderProcessor orderProcessor, IEvents events)
        {
            this.orderProcessor = orderProcessor;
            this.events = events;
        }
        public void Execute(ICart cart)
        {
            orderProcessor.ProcessOrder(
                cart.OrderId,
                wasOk => { if (wasOk) events.RaiseOrderProcessed(cart.OrderId); }
            );
        }
    }
}
