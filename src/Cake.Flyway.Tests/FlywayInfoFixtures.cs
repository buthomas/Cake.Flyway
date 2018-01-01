using System;

namespace Cake.Flyway.Tests
{
    public class FlywayInfoFixture : FlywayFixtureBase<FlywayInfoSettings>
    {
        protected override Action<IFlywayRunnerCommands> RunToolAction => tool => tool.Info(FlywayConfiguration);
    }
}