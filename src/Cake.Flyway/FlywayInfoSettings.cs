using Cake.Core;
using Cake.Core.IO;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway info settings
    /// </summary>
    public class FlywayInfoSettings : FlywayRepairSettings
    {
        /// <summary>
        /// Flyway info settings
        /// </summary>
        public FlywayInfoSettings() 
            : base("info") { }

        /// <summary>
        /// Flyway settings ctor for derived classes
        /// </summary>
        protected FlywayInfoSettings(string command)
            : base(command) { }

        /// <summary>
        /// Evaluate <see cref="FlywaySettingsBase.Configuration"/>
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (Configuration.Target != null)
            {
                args.Append($"-target={Configuration.Target}");
            }
            if (Configuration.OutOfOrder != null)
            {
                args.Append($"-outOfOrder={Configuration.OutOfOrder.ToLowerString()}");
            }
            base.EvaluateCore(args);
        }
    }
}