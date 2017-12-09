using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    public class FlywayBaselineTests
    {
        private const string ConfigPath = "path/to/config";
        private const string Url = "a.test.url";
        private const string Driver = "aDriver";
        private const string User = "aUser";
        private const string Password = "aPassword";
        private const string Schema1 = "dbs1";
        private const string Schema2 = "dbs2";
        private const string Table = "TestSchemaVersion";
        private const string JarDir1 = "path/to/jar1";
        private const string JarDir2 = "path/to/jar2";
        private const string Callback1 = "com.foo.bar1";
        private const string Callback2 = "com.foo.bar2";
        private const string BaselineVersion = "1.2.3.99";
        private const string BaselineDescription = "Lorem ipsum dolor sit ament";

        [Test]
        public void TestWithoutSettings()
        {
            var fixture = new FlywayBaselineFixture();
            var result = fixture.Run();
            result.Args.ShouldBe("baseline");
        }

        [Test]
        public void TestConfig()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.ConfigurationFile = ConfigPath;
            
            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -configFile=\"{ConfigPath}\"");
        }

        [Test]
        public void TestUrl()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.Url = Url;

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -url={Url}");
        }

        [Test]
        public void TestDriver()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.Driver = Driver;

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -driver={Driver}");
        }

        [Test]
        public void TestCredentials()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.User = User;
            fixture.FlywayConfiguration.Password = Password;

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -user=\"{User}\" -password=\"{Password}\"");
        }

        [Test]
        public void TestEmptyCredentials()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.User = string.Empty;
            fixture.FlywayConfiguration.Password = string.Empty;

            var result = fixture.Run();
            result.Args.ShouldBe("baseline -user=\"\" -password=\"\"");
        }

        [Test]
        public void TestSchemas()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.Schemas.Add(Schema1);
            fixture.FlywayConfiguration.Schemas.Add(Schema2);

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -schemas={Schema1},{Schema2}");
        }

        [Test]
        public void TestTable()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.Table = Table;

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -table={Table}");
        }

        [Test]
        public void TestJarDirs()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.JarDirs.Add(JarDir1);
            fixture.FlywayConfiguration.JarDirs.Add(JarDir2);

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -jarDirs=\"{JarDir1}\",\"{JarDir2}\"");
        }

        [Test]
        public void TestCallbacks()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.Callbacks.Add(Callback1);
            fixture.FlywayConfiguration.Callbacks.Add(Callback2);

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -callbacks={Callback1},{Callback2}");
        }

        [Test]
        public void TestSkipDefaultCallbacks()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.SkipDefaultCallbacks = true;

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -skipDefaultCallbacks=true");
        }

        [Test]
        public void TestBaselineVersion()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.BaselineVersion = BaselineVersion;

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -baselineVersion=\"{BaselineVersion}\"");
        }

        [Test]
        public void TestBaselineDescription()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.BaselineDescription = BaselineDescription;

            var result = fixture.Run();
            result.Args.ShouldBe($"baseline -baselineDescription=\"{BaselineDescription}\"");
        }

        [Test]
        public void TestMultipleSettings()
        {
            var fixture = new FlywayBaselineFixture();
            fixture.FlywayConfiguration.ConfigurationFile = ConfigPath;
            fixture.FlywayConfiguration.Url = Url;
            fixture.FlywayConfiguration.Driver = Driver;
            fixture.FlywayConfiguration.User = User;
            fixture.FlywayConfiguration.Password = Password;
            fixture.FlywayConfiguration.Schemas.Add(Schema1);
            fixture.FlywayConfiguration.Table = Table;
            fixture.FlywayConfiguration.JarDirs.Add(JarDir1);
            fixture.FlywayConfiguration.Callbacks.Add(Callback1);
            fixture.FlywayConfiguration.SkipDefaultCallbacks = false;
            fixture.FlywayConfiguration.BaselineVersion = BaselineVersion;
            fixture.FlywayConfiguration.BaselineDescription = BaselineDescription;
            
            var result = fixture.Run();
            result.Args.ShouldBe(
                "baseline " + 
                $"-configFile=\"{ConfigPath}\" " +
                $"-url={Url} " +
                $"-driver={Driver} " +
                $"-user=\"{User}\" " +
                $"-password=\"{Password}\" " +
                $"-schemas={Schema1} " +
                $"-table={Table} " +
                $"-jarDirs=\"{JarDir1}\" " +
                $"-callbacks={Callback1} " +
                $"-skipDefaultCallbacks=false " + 
                $"-baselineVersion=\"{BaselineVersion}\" " + 
                $"-baselineDescription=\"{BaselineDescription}\"");
        }
    }
}