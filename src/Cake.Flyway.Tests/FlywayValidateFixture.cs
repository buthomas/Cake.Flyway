using System;

namespace Cake.Flyway.Tests
{
    public class FlywayValidateFixture : FlywayFixtureBase<FlywayValidateSettings>
    {
        protected override Action<IFlywayRunnerCommands> RunToolAction => tool => tool.Validate(FlywayConfiguration);
    }
}