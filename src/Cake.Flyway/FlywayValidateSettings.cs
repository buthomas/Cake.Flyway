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
            : base("validate") { }

        /// <summary>
        /// Flyway settings ctor for derived classes
        /// </summary>
        protected FlywayValidateSettings(string command)
            : base(command) { }

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
