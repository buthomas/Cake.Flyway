using Cake.Testing.Fixtures;
using System;

namespace Cake.Flyway.Tests
{
    public abstract class FlywayFixtureBase<T> : ToolFixture<T>, IFlywayFixture where T : FlywaySettingsBase, new()
    {
        public FlywayFixtureBase() : base("flyway.cmd") { }

        public FlywayConfiguration FlywayConfiguration { get { return Settings.Configuration; } }

        public string Command { get { return Settings.Command; } }

        protected abstract Action<IFlywayRunnerCommands> RunToolAction { get; }

        protected override void RunTool()
        {
            var tool = new FlywayRunner(FileSystem, Environment, ProcessRunner, Tools);
            RunToolAction(tool);
        }
    }
}