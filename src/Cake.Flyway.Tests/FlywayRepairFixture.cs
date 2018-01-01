using System;

namespace Cake.Flyway.Tests
{
    public class FlywayRepairFixture : FlywayFixtureBase<FlywayRepairSettings>
    {
        protected override Action<IFlywayRunnerCommands> RunToolAction => tool => tool.Repair(FlywayConfiguration);
    }
}