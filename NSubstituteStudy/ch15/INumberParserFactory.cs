
namespace NSubstituteStudy.ch15
{
    public interface INumberParserFactory
    {
        INumberParser Create(char delimiter);
    }
}
