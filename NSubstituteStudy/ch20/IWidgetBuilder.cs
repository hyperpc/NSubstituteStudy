using System.Collections.Generic;

namespace NSubstituteStudy.ch20
{
    public interface IWidgetBuilder
    {
        IWidgetBuilder Quantity(int i);
        IWidgetBuilder AddLineItem(string s);
        IWidgetBuilder[] GetWidgets();
    }
}
