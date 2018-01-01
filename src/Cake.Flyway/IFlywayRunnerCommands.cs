
namespace Cake.Flyway
{
    /// <summary>
    /// Flyway runner commands interface
    /// </summary>
    public interface IFlywayRunnerCommands
    {
        /// <summary>
        /// Execute 'flyway migrate' with options
        /// </summary>
        /// <param name="configuration"></param>
        IFlywayRunnerCommands Migrate(FlywayConfiguration configuration = null);

        /// <summary>
        /// Execute 'flyway clean' with options
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        IFlywayRunnerCommands Clean(FlywayConfiguration configuration = null);

        /// <summary>
        /// Execute 'flyway info' with options
        /// </summary>
        /// <param name="configuration"></param>
        IFlywayRunnerCommands Info(FlywayConfiguration configuration = null);

        /// <summary>
        /// Execute 'flyway validate' with options
        /// </summary>
        /// <param name="configuration"></param>
        IFlywayRunnerCommands Validate(FlywayConfiguration configuration = null);

        /// <summary>
        /// Execute 'flyway baseline' with options
        /// </summary>
        /// <param name="configuration"></param>
        IFlywayRunnerCommands Baseline(FlywayConfiguration configuration = null);

        /// <summary>
        /// Execute 'flyway repair' with options
        /// </summary>
        /// <param name="configuration"></param>
        IFlywayRunnerCommands Repair(FlywayConfiguration configuration = null);
    }
}