
namespace Cake.Flyway
{
    /// <summary>
    /// Flyway runner commonds interface
    /// </summary>
    public interface IFlywayRunnerCommands
    {
        /// <summary>
        /// Execute 'flyway info' with options
        /// </summary>
        IFlywayRunnerCommands Info(FlywayConfiguration configuration = null);

        /// <summary>
        /// Execute 'flyway migrate' with options
        /// </summary>
        IFlywayRunnerCommands Migrate(FlywayConfiguration configuration = null);

        /// <summary>
        /// Execute 'flyway baseline' with options
        /// </summary>
        IFlywayRunnerCommands Baseline(FlywayConfiguration configuration = null);
        
    }
}