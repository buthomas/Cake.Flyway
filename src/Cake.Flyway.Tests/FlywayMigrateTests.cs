using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    public class FlywayMigrateTests : FlywayValidateTests
    {
        private const string BaselineVersion = "1.2.3.99";
        private const string BaselineDescription = "Lorem ipsum dolor sit ament";
        private const string InstalledBy = "User XY";

        public override IFlywayFixture CreateFixture()
        {
            return new FlywayFixture<FlywayMigrateSettings>();
        }

        [Test]
        public void TestMixed()
        {
            Fixture.FlywayConfiguration.Mixed = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -mixed=true");
        }

        [Test]
        public void TestGroup()
        {
            Fixture.FlywayConfiguration.Group = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -group=true");
        }

        [Test]
        public void TestValidateOnMigrate()
        {
            Fixture.FlywayConfiguration.ValidateOnMigrate = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -validateOnMigrate=true");
        }
        
        [Test]
        public void TestCleanDisabled()
        {
            Fixture.FlywayConfiguration.CleanDisabled = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -cleanDisabled=true");
        }

        [Test]
        public void TestBaselineOnMigrate()
        {
            Fixture.FlywayConfiguration.BaselineOnMigrate = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -baselineOnMigrate=true");
        }

        [Test]
        public void TestBaselineVersion()
        {
            Fixture.FlywayConfiguration.BaselineVersion = BaselineVersion;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -baselineVersion=\"{BaselineVersion}\"");
        }

        [Test]
        public void TestBaselineDescription()
        {
            Fixture.FlywayConfiguration.BaselineDescription = BaselineDescription;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -baselineDescription=\"{BaselineDescription}\"");
        }

        [Test]
        public void TestInstalledBy()
        {
            Fixture.FlywayConfiguration.InstalledBy = InstalledBy;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -installedBy={InstalledBy}");
        }
    }
}