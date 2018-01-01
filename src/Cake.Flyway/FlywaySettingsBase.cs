using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Linq;

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
        internal readonly FlywayConfiguration Configuration;

        /// <summary>
        /// Flyway runner settings
        /// </summary>
        /// <param name="command"></param>
        /// <param name="configuration"></param>
        internal FlywaySettingsBase(string command, FlywayConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentNullException(nameof(command));
            }
            Command = command;
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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
            if (Configuration.ConfigurationFile != null)
            {
                args.Append($"-configFile=\"{Configuration.ConfigurationFile}\"");
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
                args.Append($"-user=\"{Configuration.User}\"");
            }
            if (Configuration.Password != null)
            {
                args.Append($"-password=\"{Configuration.Password}\"");
            }
            if (Configuration.Schemas.Any())
            {
                args.Append($"-schemas={string.Join(",", Configuration.Schemas)}");
            }
            if (Configuration.JarDirs.Any())
            {
                args.Append($"-jarDirs=\"{string.Join("\",\"", Configuration.JarDirs)}\"");
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