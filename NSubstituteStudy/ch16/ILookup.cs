
namespace NSubstituteStudy.ch16
{
    public interface ILookup
    {
        bool TryLookup(string key, out string value);
    }
}
