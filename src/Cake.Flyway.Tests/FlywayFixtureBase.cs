using Cake.Testing.Fixtures;

namespace Cake.Flyway.Tests
{
    internal class FlywayFixture<T> : ToolFixture<T>, IFlywayFixture where T : FlywaySettingsBase, new()
    {
        internal FlywayFixture() : base("flyway.cmd") { }

        public FlywayConfiguration FlywayConfiguration => Settings.Configuration;

        public string Command => Settings.Command;

        protected override void RunTool()
        {
            var tool = new FlywayRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}