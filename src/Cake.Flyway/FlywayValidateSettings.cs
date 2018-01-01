using Cake.Core;
using Cake.Core.IO;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway validate settings
    /// </summary>
    public class FlywayValidateSettings : FlywayInfoSettings
    {
        /// <summary>
        /// Flyway validate settings
        /// </summary>
        public FlywayValidateSettings()
            : this(new FlywayConfiguration()) { }

        /// <summary>
        /// Flyway validate settings
        /// </summary>
        /// <param name="configuration"></param>
        public FlywayValidateSettings(FlywayConfiguration configuration) 
            : base("validate", configuration) { }

        /// <summary>
        /// Flyway settings ctor for derived classes
        /// </summary>
        /// <param name="command"></param>
        /// <param name="configuration"></param>
        protected FlywayValidateSettings(string command, FlywayConfiguration configuration)
            : base(command, configuration) { }

        /// <summary>
        /// Evaluate <see cref="FlywaySettingsBase.Configuration"/>
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
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
            base.EvaluateCore(args);
        }
    }
}
