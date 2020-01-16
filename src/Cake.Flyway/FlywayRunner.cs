using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Flyway
{
    /// <summary>
    /// A wrapper around the Flyway command line tool
    /// </summary>
    internal class FlywayRunner : Tool<FlywaySettingsBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlywayRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system</param>
        /// <param name="environment">The environment</param>
        /// <param name="processRunner">The process runner</param>
        /// <param name="toolLocator">The tool locator</param>
        public FlywayRunner(
            IFileSystem fileSystem, 
            ICakeEnvironment environment, 
            IProcessRunner processRunner,
            IToolLocator toolLocator)
            : base(fileSystem, environment, processRunner, toolLocator) { }

        /// <summary>
        /// Gets the name of the tool
        /// </summary>
        /// <returns>the name of the tool</returns>
        protected override string GetToolName() => "Flyway Runner";

        /// <summary>
        /// Gets the name of the tool executable
        /// </summary>
        /// <returns>The tool executable name</returns>
        protected override IEnumerable<string> GetToolExecutableNames() => new[] { "flyway.cmd", "flyway" };

        /// <summary>
        /// Generic runner using settings
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="settings"></param>
        /// <returns></returns>
        internal void Run<TSettings>(TSettings settings) 
            where TSettings : FlywaySettingsBase
        {
            var args = GetFlywaySettingsArguments(settings);
            Run(settings, args);
        }

        private static ProcessArgumentBuilder GetFlywaySettingsArguments(FlywaySettingsBase settings)
        {
            var args = new ProcessArgumentBuilder();
            settings?.Evaluate(args);
            return args;
        }
    }
}