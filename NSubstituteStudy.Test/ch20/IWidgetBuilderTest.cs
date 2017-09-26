using NSubstitute.Extensions;
using NUnit.Framework;
using NSubstitute;
using NSubstituteStudy.ch20;

namespace NSubstituteStudy.Test.ch20
{
    public class IWidgetBuilderTest
    {
        [Test]
        public void IWidgetBuilder_GetWidgets_ReturnWidgetsFromBuilder()
        {
            var builder = Substitute.For<IWidgetBuilder>();
            builder.ReturnsForAll<IWidgetBuilder>(builder);
            var line = new ProductionLine(builder);

            var result = line.Run();

            Assert.That(result, Is.EqualTo(builder.GetWidgets()));
        }

    }
}
