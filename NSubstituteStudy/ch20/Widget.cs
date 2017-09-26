using System.Linq;

namespace NSubstituteStudy.ch20
{
    public class Widget : IWidgetBuilder
    {
        IWidgetBuilder[] Widgets;

        public IWidgetBuilder Quantity(int i)
        {
            if (Widgets == null || Widgets.Count() <= 0 || i > Widgets.Count() - 1)
                return null;

            return Widgets[i];
        }

        public IWidgetBuilder AddLineItem(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || Widgets == null)
                return null;

            return Widgets[0];
        }

        public IWidgetBuilder[] GetWidgets()
        {
            return Widgets;
        }
    }
}
