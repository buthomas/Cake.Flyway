using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    public class FlywayInfoTests
    {
        private const string Location1 = "path/to/location1";
        private const string Location2 = "path/to/location2";
        private const string Classpath1 = "com.foo.bar";
        private const string MigrationPrefix = "MP_";
        private const string RepeatablePrefix = "RP_";
        private const string MigrationSeparator = "-";
        private const string MigrationSuffix = ".dbf";
        private const string Encoding = "ascii";
        private const string PlaceholderKey1 = "name1";
        private const string PlaceholderKey2 = "name2";
        private const string PlaceholderValue1 = "Lorem";
        private const string PlaceholderValue2 = "ipsum";
        private const string PlaceholderPrefix = "£[";
        private const string PlaceholderSuffix = "]";
        private const string Resolver1 = "com.foo.res1";
        private const string Resolver2 = "com.foo.res2";
        private const string Target = "1.2.3.99";

        [Test]
        public void TestWithoutSettings()
        {
            var fixture = new FlywayInfoFixture();
            var result = fixture.Run();
            result.Args.ShouldBe("info");
        }

        [Test]
        public void TestLocations()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.AddFilesystemLocation(Location1);
            fixture.FlywayConfiguration.AddFilesystemLocation(Location2);
            fixture.FlywayConfiguration.AddClasspathLocation(Classpath1);
            var result = fixture.Run();
            result.Args.ShouldBe($"info -locations=filesystem:{Location1},filesystem:{Location2},classpath:{Classpath1}");
        }

        [Test]
        public void TestSqlMigrationPrefix()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.SqlMigrationPrefix = MigrationPrefix;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -sqlMigrationPrefix={MigrationPrefix}");
        }

        [Test]
        public void TestRepeatableSqlMigrationPrefix()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.RepeatableSqlMigrationPrefix = RepeatablePrefix;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -repeatableSqlMigrationPrefix={RepeatablePrefix}");
        }

        [Test]
        public void TestSqlMigrationSeparator()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.SqlMigrationSeparator = MigrationSeparator;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -sqlMigrationSeparator={MigrationSeparator}");
        }

        [Test]
        public void TestMigrationSuffix()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.SqlMigrationSuffix = MigrationSuffix;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -sqlMigrationSuffix={MigrationSuffix}");
        }

        [Test]
        public void TestEncoding()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.Encoding = Encoding;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -encoding={Encoding}");
        }

        [Test]
        public void TestPlaceholderReplacement()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.PlaceholderReplacement = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -placeholderReplacement=true");
        }

        [Test]
        public void TestPlaceholders()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.Placeholders.Add(PlaceholderKey1, PlaceholderValue1);
            fixture.FlywayConfiguration.Placeholders.Add(PlaceholderKey2, PlaceholderValue2);

            var result = fixture.Run();
            result.Args.ShouldBe(
                $"info -placeholders.{PlaceholderKey1}=\"{PlaceholderValue1}\" " +
                $"-placeholders.{PlaceholderKey2}=\"{PlaceholderValue2}\"");
        }

        [Test]
        public void TestPlaceholderPrefix()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.PlaceholderPrefix = PlaceholderPrefix;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -placeholderPrefix={PlaceholderPrefix}");
        }

        [Test]
        public void TestPlaceholderSiffix()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.PlaceholderSuffix = PlaceholderSuffix;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -placeholderSuffix={PlaceholderSuffix}");
        }

        [Test]
        public void TestResolvers()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.Resolvers.Add(Resolver1);
            fixture.FlywayConfiguration.Resolvers.Add(Resolver2);
            
            var result = fixture.Run();
            result.Args.ShouldBe($"info -resolvers={Resolver1},{Resolver2}");
        }

        [Test]
        public void TestSkipDefaultResolvers()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.SkipDefaultResolvers = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -skipDefaultResolvers=true");
        }

        [Test]
        public void TestTarget()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.Target = Target;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -target={Target}");
        }

        [Test]
        public void TestOutOfOrder()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.OutOfOrder = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"info -outOfOrder=true");
        }

        [Test]
        public void TestMultipleSettings()
        {
            var fixture = new FlywayInfoFixture();
            fixture.FlywayConfiguration.AddFilesystemLocation(Location1);
            fixture.FlywayConfiguration.AddClasspathLocation(Classpath1);
            fixture.FlywayConfiguration.SqlMigrationPrefix = MigrationPrefix;
            fixture.FlywayConfiguration.RepeatableSqlMigrationPrefix = RepeatablePrefix;
            fixture.FlywayConfiguration.SqlMigrationSeparator = MigrationSeparator;
            fixture.FlywayConfiguration.SqlMigrationSuffix = MigrationSuffix;
            fixture.FlywayConfiguration.Encoding = Encoding;
            fixture.FlywayConfiguration.PlaceholderReplacement = false;
            fixture.FlywayConfiguration.Placeholders.Add(PlaceholderKey1, PlaceholderValue1);
            fixture.FlywayConfiguration.PlaceholderPrefix = PlaceholderPrefix;
            fixture.FlywayConfiguration.PlaceholderSuffix = PlaceholderSuffix;
            fixture.FlywayConfiguration.Resolvers.Add(Resolver1);
            fixture.FlywayConfiguration.SkipDefaultResolvers = false;
            fixture.FlywayConfiguration.Target = Target;
            fixture.FlywayConfiguration.OutOfOrder = false;

            var result = fixture.Run();
            result.Args.ShouldBe(
                "info " + 
                $"-locations=filesystem:{Location1},classpath:{Classpath1} " +
                $"-sqlMigrationPrefix={MigrationPrefix} " +
                $"-repeatableSqlMigrationPrefix={RepeatablePrefix} " +
                $"-sqlMigrationSeparator={MigrationSeparator} " +
                $"-sqlMigrationSuffix={MigrationSuffix} " +
                $"-encoding={Encoding} " + 
                $"-placeholderReplacement=false " +
                $"-placeholders.{PlaceholderKey1}=\"{PlaceholderValue1}\" " +
                $"-placeholderPrefix={PlaceholderPrefix} " +
                $"-placeholderSuffix={PlaceholderSuffix} " +
                $"-resolvers={Resolver1} " +
                $"-skipDefaultResolvers=false " +
                $"-target={Target} " +
                $"-outOfOrder=false");
        }
    }
}