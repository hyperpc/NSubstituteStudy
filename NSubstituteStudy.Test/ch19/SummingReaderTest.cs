using NSubstitute;
using NSubstituteStudy.ch19;
using NUnit.Framework;

namespace NSubstituteStudy.Test.ch19
{
    public class SummingReaderTest
    {
        [Test]
        public void SummingReader_ReadFile_SumAllNumbersInFileNotSafely()
        {
            var reader = Substitute.ForPartsOf<SummingReader>();
            reader.ReadFile(Arg.Is("foo.txt")).Returns("1,2,3,4,5");// CAUTION: real code warning!

            var result = reader.Read("foo.txt");
            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void SummingReader_ReadFile_SumAllNumbersInFileSafely()
        {
            var reader = Substitute.ForPartsOf<SummingReader>();
            reader.When(x => x.ReadFile("foo.txt")).DoNotCallBase();// Make sure the ReadFile call won't call real implementation
            reader.ReadFile(Arg.Is("foo.txt")).Returns("1,2,3,4,5");// This won't run the real ReadFile now

            var result = reader.Read("foo.txt");

            Assert.That(result, Is.EqualTo(15));
        }
    }
}
