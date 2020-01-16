using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    public abstract class FlywayTestsBase
    {
        private const string ConfigPath = "path/to/config";
        private readonly List<string> ConfigPaths = new List<string> { "path/to/config1", "path/to/config2", "path/to/config1" };
        private const string Url = "a.test.url";
        private const string Driver = "aDriver";
        private const string User = "aUser";
        private const string Password = "aPassword";
        private const string Schema1 = "dbs1";
        private const string Schema2 = "dbs2";
        private const string JarDir1 = "path/to/jar1";
        private const string JarDir2 = "path/to/jar2";
        private const string Callback1 = "com.foo.bar1";
        private const string Callback2 = "com.foo.bar2";

        public abstract IFlywayFixture CreateFixture();

        protected string Command => Fixture?.Command;

        protected IFlywayFixture Fixture { get; set; }

        [SetUp]
        public void Setup()
        {
            Fixture = CreateFixture();
        }

        [Test]
        public void TestWithoutSettings()
        {
            var result = Fixture.Run();
            result.Args.ShouldBe(Command);
        }

        [Test]
        public void TestConfigFile()
        {
            Fixture.FlywayConfiguration.ConfigurationFile = ConfigPath;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -configFile={ConfigPath.Quote()}");
        }

        [Test]
        public void TestConfigFiles()
        {
            Fixture.FlywayConfiguration.ConfigurationFiles.UnionWith(ConfigPaths.Select(FilePath.FromString));

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -configFiles={string.Join(",", ConfigPaths.Select(x => x.Quote()))}");
        }

        [Test]
        public void TestUrl()
        {
            Fixture.FlywayConfiguration.Url = Url;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -url={Url}");
        }

        [Test]
        public void TestDriver()
        {
            Fixture.FlywayConfiguration.Driver = Driver;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -driver={Driver}");
        }

        [Test]
        public void TestCredentials()
        {
            Fixture.FlywayConfiguration.User = User;
            Fixture.FlywayConfiguration.Password = Password;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -user=\"{User}\" -password=\"{Password}\"");
        }

        [Test]
        public void TestEmptyCredentials()
        {
            Fixture.FlywayConfiguration.User = string.Empty;
            Fixture.FlywayConfiguration.Password = string.Empty;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -user=\"\" -password=\"\"");
        }

        [Test]
        public void TestSchemas()
        {
            Fixture.FlywayConfiguration.Schemas.Add(Schema1);
            Fixture.FlywayConfiguration.Schemas.Add(Schema2);

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -schemas={Schema1},{Schema2}");
        }

        [Test]
        public void TestJarDirs()
        {
            Fixture.FlywayConfiguration.JarDirs.Add(JarDir1);
            Fixture.FlywayConfiguration.JarDirs.Add(JarDir2);

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -jarDirs=\"{JarDir1}\",\"{JarDir2}\"");
        }

        [Test]
        public void TestCallbacks()
        {
            Fixture.FlywayConfiguration.Callbacks.Add(Callback1);
            Fixture.FlywayConfiguration.Callbacks.Add(Callback2);

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -callbacks={Callback1},{Callback2}");
        }

        [Test]
        public void TestSkipDefaultCallbacks()
        {
            Fixture.FlywayConfiguration.SkipDefaultCallbacks = true;

            var result = Fixture.Run();
            result.Args.ShouldBe($"{Command} -skipDefaultCallbacks=true");
        }
    }
}
