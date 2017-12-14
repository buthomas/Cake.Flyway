namespace Cake.Flyway
{
    /// <summary>
    /// Flyway baseline settings
    /// </summary>
    public class FlywayBaselineSettings : FlywayRunnerSettings
    {
        /// <summary>
        /// Flyway baseline settings
        /// </summary>
        public FlywayBaselineSettings()
            : this(new FlywayConfiguration()) { }

        /// <summary>
        /// Flyway baseline settings
        /// </summary>
        /// <param name="configuration"></param>
        public FlywayBaselineSettings(FlywayConfiguration configuration) 
            : base("baseline", configuration) { }
    }
}