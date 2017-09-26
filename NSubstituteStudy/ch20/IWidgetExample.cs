using System.Collections.Generic;

namespace NSubstituteStudy.ch20
{
    public class IWidgetExample
    {
        private List<Widget> Widgets;

        public List<Widget> Add(Widget widget)
        {
            if (Widgets == null)
                Widgets = new List<Widget>();

            Widgets.Add(widget);

            return Widgets;
        }

        public void Remove(Widget widget)
        {
            foreach (var w in Widgets)
            {
                if (w == widget)
                    Widgets.Remove(w);
            }
        }

        public Widget GetWidget(int i)
        {
            return Widgets[i];
        }
    }
}
