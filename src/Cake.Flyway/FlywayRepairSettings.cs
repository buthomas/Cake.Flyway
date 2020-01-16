using Cake.Core;
using Cake.Core.IO;
using System.Linq;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway repair settings
    /// </summary>
    public class FlywayRepairSettings : FlywaySettingsBase
    {
        /// <summary>
        /// Flyway repair settings
        /// </summary>
        public FlywayRepairSettings() 
            : base("repair") { }

        /// <summary>
        /// Flyway settings ctor for derived classes
        /// </summary>
        protected FlywayRepairSettings(string command)
            : base(command) { }

        /// <summary>
        /// Evaluate <see cref="FlywaySettingsBase.Configuration"/>
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (Configuration.Table != null)
            {
                args.Append($"-table={Configuration.Table}");
            }
            if (Configuration.Locations.Any())
            {
                args.Append($"-locations={string.Join(",", Configuration.Locations)}");
            }
            if (Configuration.SqlMigrationPrefix != null)
            {
                args.Append($"-sqlMigrationPrefix={Configuration.SqlMigrationPrefix}");
            }
            if (Configuration.RepeatableSqlMigrationPrefix != null)
            {
                args.Append($"-repeatableSqlMigrationPrefix={Configuration.RepeatableSqlMigrationPrefix}");
            }
            if (Configuration.SqlMigrationSeparator != null)
            {
                args.Append($"-sqlMigrationSeparator={Configuration.SqlMigrationSeparator}");
            }
            if (Configuration.SqlMigrationSuffix != null)
            {
                args.Append($"-sqlMigrationSuffix={Configuration.SqlMigrationSuffix}");
            }
            if (Configuration.Encoding != null)
            {
                args.Append($"-encoding={Configuration.Encoding}");
            }
            if (Configuration.PlaceholderReplacement != null)
            {
                args.Append($"-placeholderReplacement={Configuration.PlaceholderReplacement.ToLowerString()}");
            }
            foreach (var placeholder in Configuration.Placeholders)
            {
                args.Append($"-placeholders.{placeholder.Key}=\"{placeholder.Value}\"");
            }
            if (Configuration.PlaceholderPrefix != null)
            {
                args.Append($"-placeholderPrefix={Configuration.PlaceholderPrefix}");
            }
            if (Configuration.PlaceholderSuffix != null)
            {
                args.Append($"-placeholderSuffix={Configuration.PlaceholderSuffix}");
            }
            if (Configuration.Resolvers.Any())
            {
                args.Append($"-resolvers={string.Join(",", Configuration.Resolvers)}");
            }
            if (Configuration.SkipDefaultResolvers != null)
            {
                args.Append($"-skipDefaultResolvers={Configuration.SkipDefaultResolvers.ToLowerString()}");
            }
            base.EvaluateCore(args);
        }
    }
}
