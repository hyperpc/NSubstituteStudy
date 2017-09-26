using NSubstitute.Extensions;
using NUnit.Framework;
using NSubstitute;
using NSubstituteStudy.ch20;

namespace NSubstituteStudy.Test.ch20
{
    public class IWidgetExampleTest
    {
        [Test]
        public void IWidgetExample_GetWidget_ReturnWidgetsFromBuilderTakesPrecedence()
        {
            var widget = new Widget();
            var otherWidget = new Widget();
            var sub = Substitute.For<IWidgetExample>();
            sub.GetWidget(1).Returns(widget);
            sub.ReturnsForAll<Widget>(otherWidget);

            Assert.That(sub.GetWidget(1), Is.SameAs(widget));
            Assert.That(sub.GetWidget(42), Is.SameAs(otherWidget));
        }
    }
}
