using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    public class FlywayMigrateTests
    {
        private const string InstalledBy = "User XY";

        [Test]
        public void TestWithoutSettings()
        {
            var fixture = new FlywayMigrateFixture();
            var result = fixture.Run();
            result.Args.ShouldBe("migrate");
        }

        [Test]
        public void TestMixed()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.Mixed = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"migrate -mixed=true");
        }

        [Test]
        public void TestGroup()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.Group = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"migrate -group=true");
        }

        [Test]
        public void TestValidateOnMigrate()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.ValidateOnMigrate = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"migrate -validateOnMigrate=true");
        }

        [Test]
        public void TestCleanOnValidationError()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.CleanOnValidationError = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"migrate -cleanOnValidationError=true");
        }

        [Test]
        public void TestIgnoreMissingMigrations()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.IgnoreMissingMigrations = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"migrate -ignoreMissingMigrations=true");
        }

        [Test]
        public void TestIgnoreFutureMigrations()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.IgnoreFutureMigrations = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"migrate -ignoreFutureMigrations=true");
        }

        [Test]
        public void TestCleanDisabled()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.CleanDisabled = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"migrate -cleanDisabled=true");
        }

        [Test]
        public void TestBaselineOnMigrate()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.BaselineOnMigrate = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"migrate -baselineOnMigrate=true");
        }

        [Test]
        public void TestInstalledBy()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.InstalledBy = InstalledBy;

            var result = fixture.Run();
            result.Args.ShouldBe($"migrate -installedBy={InstalledBy}");
        }
        
        [Test]
        public void TestMultipleSettings()
        {
            var fixture = new FlywayMigrateFixture();
            fixture.FlywayConfiguration.Mixed = false;
            fixture.FlywayConfiguration.Group = false;
            fixture.FlywayConfiguration.ValidateOnMigrate = false;
            fixture.FlywayConfiguration.CleanOnValidationError = false;
            fixture.FlywayConfiguration.IgnoreMissingMigrations = false;
            fixture.FlywayConfiguration.IgnoreFutureMigrations = false;
            fixture.FlywayConfiguration.CleanDisabled = false;
            fixture.FlywayConfiguration.BaselineOnMigrate = false;
            fixture.FlywayConfiguration.InstalledBy = InstalledBy;

            var result = fixture.Run();
            result.Args.ShouldBe(
                "migrate " + 
                $"-mixed=false " +
                $"-group=false " +
                $"-validateOnMigrate=false " +
                $"-cleanOnValidationError=false " +
                $"-ignoreMissingMigrations=false " +
                $"-ignoreFutureMigrations=false " +
                $"-cleanDisabled=false " + 
                $"-baselineOnMigrate=false " +
                $"-installedBy={InstalledBy}");
        }
    }
}