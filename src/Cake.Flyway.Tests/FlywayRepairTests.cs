using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    public class FlywayRepairTests : FlywayTestsBase
    {
        private const string Table = "TestSchemaVersion";
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
        private const string PlaceholderPrefix = "�[";
        private const string PlaceholderSuffix = "]";
        private const string Resolver1 = "com.foo.res1";
        private const string Resolver2 = "com.foo.res2";

        public override IFlywayFixture CreateFixture()
        {
            return new FlywayFixture<FlywayRepairSettings>();
        }
        
        [Test]
        public void TestTable()
        {
            Fixture.FlywayConfiguration.Table = Table;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -table={Table}");
        }

        [Test]
        public void TestLocations()
        {
            Fixture.FlywayConfiguration.AddFilesystemLocation(Location1);
            Fixture.FlywayConfiguration.AddFilesystemLocation(Location2);
            Fixture.FlywayConfiguration.AddClasspathLocation(Classpath1);
            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -locations=filesystem:{Location1},filesystem:{Location2},classpath:{Classpath1}");
        }

        [Test]
        public void TestSqlMigrationPrefix()
        {
            Fixture.FlywayConfiguration.SqlMigrationPrefix = MigrationPrefix;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -sqlMigrationPrefix={MigrationPrefix}");
        }

        [Test]
        public void TestRepeatableSqlMigrationPrefix()
        {
            Fixture.FlywayConfiguration.RepeatableSqlMigrationPrefix = RepeatablePrefix;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -repeatableSqlMigrationPrefix={RepeatablePrefix}");
        }

        [Test]
        public void TestSqlMigrationSeparator()
        {
            Fixture.FlywayConfiguration.SqlMigrationSeparator = MigrationSeparator;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -sqlMigrationSeparator={MigrationSeparator}");
        }

        [Test]
        public void TestMigrationSuffix()
        {
            Fixture.FlywayConfiguration.SqlMigrationSuffix = MigrationSuffix;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -sqlMigrationSuffix={MigrationSuffix}");
        }

        [Test]
        public void TestEncoding()
        {
            Fixture.FlywayConfiguration.Encoding = Encoding;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -encoding={Encoding}");
        }

        [Test]
        public void TestPlaceholderReplacement()
        {
            Fixture.FlywayConfiguration.PlaceholderReplacement = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -placeholderReplacement=true");
        }

        [Test]
        public void TestPlaceholders()
        {
            Fixture.FlywayConfiguration.Placeholders.Add(PlaceholderKey1, PlaceholderValue1);
            Fixture.FlywayConfiguration.Placeholders.Add(PlaceholderKey2, PlaceholderValue2);

            var result = Fixture.Run();
            result.Args.ShouldBe(
                $"{Command} -placeholders.{PlaceholderKey1}=\"{PlaceholderValue1}\" " +
                $"-placeholders.{PlaceholderKey2}=\"{PlaceholderValue2}\"");
        }

        [Test]
        public void TestPlaceholderPrefix()
        {
            Fixture.FlywayConfiguration.PlaceholderPrefix = PlaceholderPrefix;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -placeholderPrefix={PlaceholderPrefix}");
        }

        [Test]
        public void TestPlaceholderSiffix()
        {
            Fixture.FlywayConfiguration.PlaceholderSuffix = PlaceholderSuffix;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -placeholderSuffix={PlaceholderSuffix}");
        }

        [Test]
        public void TestResolvers()
        {
            Fixture.FlywayConfiguration.Resolvers.Add(Resolver1);
            Fixture.FlywayConfiguration.Resolvers.Add(Resolver2);

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -resolvers={Resolver1},{Resolver2}");
        }

        [Test]
        public void TestSkipDefaultResolvers()
        {
            Fixture.FlywayConfiguration.SkipDefaultResolvers = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -skipDefaultResolvers=true");
        }
    }
}
