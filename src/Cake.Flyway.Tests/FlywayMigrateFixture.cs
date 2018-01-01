using System;

namespace Cake.Flyway.Tests
{
    public class FlywayMigrateFixture : FlywayFixtureBase<FlywayMigrateSettings>
    {
        protected override Action<IFlywayRunnerCommands> RunToolAction => tool => tool.Migrate(FlywayConfiguration);
    }
}