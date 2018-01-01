using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    public class BooleanExtensionsTests
    {
        [Test]
        public void TestNull()
        {
            bool? x = null;
            x.ToLowerString().ShouldBeNull();
        }

        [Test]
        public void TestTrue()
        {
            bool? x = true;
            x.ToLowerString().ShouldBe("true");
        }

        [Test]
        public void TestFalse()
        {
            bool? x = false;
            x.ToLowerString().ShouldBe("false");
        }
    }
}
