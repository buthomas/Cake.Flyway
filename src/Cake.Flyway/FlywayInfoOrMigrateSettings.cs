using Cake.Core;
using Cake.Core.IO;
using System.Linq;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway info or migration settings
    /// </summary>
    public abstract class FlywayInfoOrMigrateSettings : FlywayRunnerSettings
    {
        /// <summary>
        /// Flyway info or migration settings
        /// </summary>
        /// <param name="command"></param>
        /// <param name="configuration"></param>
        protected FlywayInfoOrMigrateSettings(string command, FlywayConfiguration configuration)
            : base(command, configuration) { }

        /// <summary>
        /// Evaluate <see cref="FlywayRunnerSettings.Configuration"/>
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
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