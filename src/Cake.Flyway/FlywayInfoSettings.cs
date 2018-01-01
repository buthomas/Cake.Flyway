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
            : this(new FlywayConfiguration()) { }

        /// <summary>
        /// Flyway info settings
        /// </summary>
        /// <param name="configuration"></param>
        public FlywayInfoSettings(FlywayConfiguration configuration) 
            : base("info", configuration) { }

        /// <summary>
        /// Flyway settings ctor for derived classes
        /// </summary>
        /// <param name="command"></param>
        /// <param name="configuration"></param>
        protected FlywayInfoSettings(string command, FlywayConfiguration configuration)
            : base(command, configuration) { }

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