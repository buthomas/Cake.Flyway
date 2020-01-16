using Cake.Core;
using Cake.Core.IO;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway baseline settings
    /// </summary>
    public class FlywayBaselineSettings : FlywaySettingsBase
    {
        /// <summary>
        /// Flyway baseline settings
        /// </summary>
        public FlywayBaselineSettings() 
            : base("baseline") { }

        /// <summary>
        /// Evaluate <see cref="FlywaySettingsBase.Configuration"/>
        /// </summary>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (Configuration.Table != null)
            {
                args.Append($"-table={Configuration.Table}");
            }
            if (Configuration.BaselineVersion != null)
            {
                args.Append($"-baselineVersion=\"{Configuration.BaselineVersion}\"");
            }
            if (Configuration.BaselineDescription != null)
            {
                args.Append($"-baselineDescription=\"{Configuration.BaselineDescription}\"");
            }
            base.EvaluateCore(args);
        }
    }
}