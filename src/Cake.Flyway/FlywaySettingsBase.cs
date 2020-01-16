using System;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway runner settings
    /// </summary>
    public abstract class FlywaySettingsBase : ToolSettings
    {
        /// <summary>
        /// The command to run
        /// </summary>
        internal readonly string Command;

        /// <summary>
        /// The <see cref="FlywayConfiguration"/>
        /// </summary>
        public FlywayConfiguration Configuration { get; set; } = new FlywayConfiguration();

        /// <summary>
        /// Flyway runner settings
        /// </summary>
        protected FlywaySettingsBase(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentNullException(nameof(command));
            }
            Command = command;
        }

        internal void Evaluate(ProcessArgumentBuilder args)
        {
            args.Append(Command);
            EvaluateCore(args);
        }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            if (Configuration.ConfigurationFile != null)
            {
                args.Append($"-configFile={Configuration.ConfigurationFile.Quote()}");
            }
#pragma warning restore CS0618 // Type or member is obsolete
            if (Configuration.ConfigurationFiles.Any())
            {
                args.Append($"-configFiles={string.Join(",", Configuration.ConfigurationFiles.Select(x => x.ToString().Quote()))}");
            }
            if (!string.IsNullOrEmpty(Configuration.Url))
            {
                args.Append($"-url={Configuration.Url}");
            }
            if (!string.IsNullOrEmpty(Configuration.Driver))
            {
                args.Append($"-driver={Configuration.Driver}");
            }
            if (Configuration.User != null)
            {
                args.Append($"-user={Configuration.User.Quote()}");
            }
            if (Configuration.Password != null)
            {
                args.Append($"-password={Configuration.Password.Quote()}");
            }
            if (Configuration.Schemas.Any())
            {
                args.Append($"-schemas={string.Join(",", Configuration.Schemas)}");
            }
            if (Configuration.JarDirs.Any())
            {
                args.Append($"-jarDirs={string.Join(",", Configuration.JarDirs.Select(x => x.ToString().Quote()))}");
            }
            if (Configuration.Callbacks.Any())
            {
                args.Append($"-callbacks={string.Join(",", Configuration.Callbacks)}");
            }
            if (Configuration.SkipDefaultCallbacks != null)
            {
                args.Append($"-skipDefaultCallbacks={Configuration.SkipDefaultCallbacks.ToLowerString()}");
            }
        }
    }
}