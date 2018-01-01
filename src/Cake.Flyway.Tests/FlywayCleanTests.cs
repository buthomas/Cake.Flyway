using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    public class FlywayCleanTests : FlywayTestsBase
    {
        public override IFlywayFixture CreateFixture()
        {
            return new FlywayCleanFixture();
        }

        [Test]
        public void TestCleanDisabled()
        {
            Fixture.FlywayConfiguration.CleanDisabled = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"clean -cleanDisabled=true");
        }
    }
}