using Cake.Testing.Fixtures;

namespace Cake.Flyway.Tests
{
    public class FlywayMigrateFixture : ToolFixture<FlywayMigrateSettings>
    {
        public FlywayMigrateFixture() : base("flyway.cmd") { }

        public FlywayConfiguration FlywayConfiguration { get; } = new FlywayConfiguration();

        protected override void RunTool()
        {
            var tool = new FlywayRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Migrate(FlywayConfiguration);
        }
    }
}