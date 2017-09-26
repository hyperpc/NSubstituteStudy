
namespace NSubstituteStudy.ch15
{
    public interface IRequest
    {
        IIdentity Identity { get; }
        IIdentity NewIdentity(string name);
    }
}
