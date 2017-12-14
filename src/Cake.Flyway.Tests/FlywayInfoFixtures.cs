using Cake.Testing.Fixtures;

namespace Cake.Flyway.Tests
{
    public class FlywayInfoFixture : ToolFixture<FlywayInfoSettings>
    {
        public FlywayInfoFixture() : base("flyway.cmd") { }

        public FlywayConfiguration FlywayConfiguration { get; } = new FlywayConfiguration();

        protected override void RunTool()
        {
            var tool = new FlywayRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Info(FlywayConfiguration);
        }
    }
}