using System;

namespace Cake.Flyway.Tests
{
    public class FlywayBaselineFixture : FlywayFixtureBase<FlywayBaselineSettings>
    {
        protected override Action<IFlywayRunnerCommands> RunToolAction => tool => tool.Baseline(FlywayConfiguration);
    }
}