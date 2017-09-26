using NSubstitute;
using NSubstituteStudy.ch17;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test.ch17
{
    public class OrderPlacedCommandTest
    {
        [TestMethod]
        public void OrderPlacedCommand_Execute_InvokeCallbackWhenArgsMatched()
        {
            //Arrange
            var cart = Substitute.For<ICart>();
            var events = Substitute.For<IEvents>();
            var processor = Substitute.For<IOrderProcessor>();
            cart.OrderId = 3;
            //设置processor：当ID=3时，调用回调函数，参数为true
            processor.ProcessOrder(3, Arg.Invoke(true));
            //Arg.InvokeDelegate()

            //Act
            var command = new OrderPlacedCommand(processor, events);
            command.Execute(cart);

            //Assert
            events.Received().RaiseOrderProcessed(3);
        }
    }
}
