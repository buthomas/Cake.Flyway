using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    public class FlywayValidateTests : FlywayInfoTests
    {
        public override IFlywayFixture CreateFixture()
        {
            return new FlywayValidateFixture();
        }
        
        [Test]
        public void TestCleanOnValidationError()
        {
            Fixture.FlywayConfiguration.CleanOnValidationError = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -cleanOnValidationError=true");
        }

        [Test]
        public void TestIgnoreMissingMigrations()
        {
            Fixture.FlywayConfiguration.IgnoreMissingMigrations = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -ignoreMissingMigrations=true");
        }

        [Test]
        public void TestIgnoreFutureMigrations()
        {
            Fixture.FlywayConfiguration.IgnoreFutureMigrations = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -ignoreFutureMigrations=true");
        }
    }
}
