using Cake.Core;
using Cake.Core.IO;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway migrate settings
    /// </summary>
    public class FlywayMigrateSettings : FlywayValidateSettings
    {
        /// <summary>
        /// Flyway migrate settings
        /// </summary>
        public FlywayMigrateSettings()
            : base("migrate") { }

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
            if (Configuration.CleanDisabled != null)
            {
                args.Append($"-cleanDisabled={Configuration.CleanDisabled.ToLowerString()}");
            }
            if (Configuration.BaselineOnMigrate != null)
            {
                args.Append($"-baselineOnMigrate={Configuration.BaselineOnMigrate.ToLowerString()}");
            }
            if (Configuration.BaselineVersion != null)
            {
                args.Append($"-baselineVersion=\"{Configuration.BaselineVersion}\"");
            }
            if (Configuration.BaselineDescription != null)
            {
                args.Append($"-baselineDescription=\"{Configuration.BaselineDescription}\"");
            }
            if (!string.IsNullOrEmpty(Configuration.InstalledBy))
            {
                args.Append($"-installedBy={Configuration.InstalledBy}");
            }
            base.EvaluateCore(args);
        }
    }
}