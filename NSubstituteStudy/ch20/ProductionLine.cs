using System.Collections.Generic;

namespace NSubstituteStudy.ch20
{
    public class ProductionLine
    {
        IWidgetBuilder builder;
        public ProductionLine(IWidgetBuilder builder)
        {
            this.builder = builder;
        }

        public IWidgetBuilder[] Run()
        {
            return builder
                .Quantity(2)
                .AddLineItem("Thingoe")
                .AddLineItem("Other thingoe")
                .GetWidgets();
        }
    }
}
