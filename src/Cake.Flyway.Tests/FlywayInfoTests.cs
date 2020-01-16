using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    public class FlywayInfoTests : FlywayRepairTests
    {
        private const string Target = "1.2.3.99";

        public override IFlywayFixture CreateFixture()
        {
            return new FlywayFixture<FlywayInfoSettings>();
        }
        
        [Test]
        public void TestTarget()
        {
            Fixture.FlywayConfiguration.Target = Target;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -target={Target}");
        }

        [Test]
        public void TestOutOfOrder()
        {
            Fixture.FlywayConfiguration.OutOfOrder = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -outOfOrder=true");
        }
    }
}