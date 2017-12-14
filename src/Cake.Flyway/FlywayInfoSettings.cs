namespace Cake.Flyway
{
    /// <summary>
    /// Flyway info settings
    /// </summary>
    public class FlywayInfoSettings : FlywayInfoOrMigrateSettings
    {
        /// <summary>
        /// Flyway info settings
        /// </summary>
        public FlywayInfoSettings()
            : this(new FlywayConfiguration()) { }

        /// <summary>
        /// Flyway info settings
        /// </summary>
        /// <param name="configuration"></param>
        public FlywayInfoSettings(FlywayConfiguration configuration) 
            : base("info", configuration) { }
    }
}