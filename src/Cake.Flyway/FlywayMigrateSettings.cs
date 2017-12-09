using Cake.Core;
using Cake.Core.IO;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway migrate settings
    /// </summary>
    public class FlywayMigrateSettings : FlywayInfoOrMigrateSettings
    {
        /// <summary>
        /// Flyway migrate settings
        /// </summary>
        public FlywayMigrateSettings()
            : this(new FlywayConfiguration()) { }

        /// <summary>
        /// Flyway migrate settings
        /// </summary>
        /// <param name="configuration"></param>
        public FlywayMigrateSettings(FlywayConfiguration configuration)
            : base("migrate", configuration) { }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (Configuration.Mixed != null)
            {
                args.Append($"-mixed={Configuration.Mixed.ToLowerString()}");
            }
            if (Configuration.Group != null)
            {
                args.Append($"-group={Configuration.Group.ToString().ToLower()}");
            }
            if (Configuration.ValidateOnMigrate != null)
            {
                args.Append($"-validateOnMigrate={Configuration.ValidateOnMigrate.ToLowerString()}");
            }
            if (Configuration.CleanOnValidationError != null)
            {
                args.Append($"-cleanOnValidationError={Configuration.CleanOnValidationError.ToLowerString()}");
            }
            if (Configuration.IgnoreMissingMigrations != null)
            {
                args.Append($"-ignoreMissingMigrations={Configuration.IgnoreMissingMigrations.ToLowerString()}");
            }
            if (Configuration.IgnoreFutureMigrations != null)
            {
                args.Append($"-ignoreFutureMigrations={Configuration.IgnoreFutureMigrations.ToLowerString()}");
            }
            if (Configuration.CleanDisabled != null)
            {
                args.Append($"-cleanDisabled={Configuration.CleanDisabled.ToLowerString()}");
            }
            if (Configuration.BaselineOnMigrate != null)
            {
                args.Append($"-baselineOnMigrate={Configuration.BaselineOnMigrate.ToLowerString()}");
            }
            if (!string.IsNullOrEmpty(Configuration.InstalledBy))
            {
                args.Append($"-installedBy={Configuration.InstalledBy}");
            }
            base.EvaluateCore(args);
        }
    }
}