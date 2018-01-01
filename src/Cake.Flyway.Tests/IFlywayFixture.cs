using Cake.Testing.Fixtures;

namespace Cake.Flyway.Tests
{
    public interface IFlywayFixture
    {
        FlywayConfiguration FlywayConfiguration { get; }

        string Command { get; }

        ToolFixtureResult Run();
    }
}
