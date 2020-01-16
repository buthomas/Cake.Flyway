using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    public class FlywayBaselineTests : FlywayTestsBase
    {
        private const string Table = "TestSchemaVersion";
        private const string BaselineVersion = "1.2.3.99";
        private const string BaselineDescription = "Lorem ipsum dolor sit ament";

        public override IFlywayFixture CreateFixture()
        {
            return new FlywayFixture<FlywayBaselineSettings>();
        }
        
        [Test]
        public void TestTable()
        {
            Fixture.FlywayConfiguration.Table = Table;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -table={Table}");
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
    }
}