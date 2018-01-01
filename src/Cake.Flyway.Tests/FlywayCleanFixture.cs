using System;

namespace Cake.Flyway.Tests
{
    public class FlywayCleanFixture : FlywayFixtureBase<FlywayCleanSettings>
    {
        protected override Action<IFlywayRunnerCommands> RunToolAction => tool => tool.Clean(FlywayConfiguration);
    }
}