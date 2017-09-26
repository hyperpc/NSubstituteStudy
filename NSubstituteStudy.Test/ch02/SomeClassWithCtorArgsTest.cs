using System;
using NSubstitute;
using NSubstituteStudy.ch02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSubstituteStudy.Test
{
    public class SomeClassWithCtorArgsTest
    {
        [TestMethod]
        public void SomeClassWithCtorArgs_GetInstanceWithArgs_SpecifiedOneClassType()
        {
            var substitute = Substitute.For(
                new[] { typeof(ICommand), typeof(IDisposable), typeof(SomeClassWithCtorArgs) },
                new object[] { 5, "hello world" }
                );

            Assert.IsNotInstanceOfType(substitute, typeof(ICommand));
            Assert.IsInstanceOfType(substitute, typeof(ICommand));
            Assert.IsInstanceOfType(substitute, typeof(IDisposable));
            Assert.IsInstanceOfType(substitute, typeof(SomeClassWithCtorArgs));
        }

        [TestMethod]
        public void Test_CreatingSubstitute_ForDelegate()
        {
            var func = Substitute.For<Func<string>>();
            func().Returns("hello");
            Assert.AreEqual<string>("hello", func());
        }
    }
}
