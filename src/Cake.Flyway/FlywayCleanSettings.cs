using Cake.Core.IO;
using Cake.Core;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway clean settings
    /// </summary>
    public class FlywayCleanSettings : FlywaySettingsBase
    {
        /// <summary>
        /// Flyway clean settings
        /// </summary>
        public FlywayCleanSettings() 
            : base("clean") { }

        /// <summary>
        /// Evaluate <see cref="FlywaySettingsBase.Configuration"/>
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (Configuration.CleanDisabled != null)
            {
                args.Append($"-cleanDisabled={Configuration.CleanDisabled.ToLowerString()}");
            }
            base.EvaluateCore(args);
        }
    }
}
