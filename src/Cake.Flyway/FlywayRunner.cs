using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Flyway
{
    /// <summary>
    /// A wrapper around the Flyway command line tool
    /// </summary>
    public class FlywayRunner : Tool<FlywayRunnerSettings>, IFlywayRunnerCommands
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
        /// Execute 'flyway info' with options
        /// </summary>
        /// <param name="configuration"></param>
        /// <example>
        /// <para>Run 'flyway info'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Info)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Info();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway info'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Info)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Info(new FlywayConfiguration
        ///             {
        ///                 OutOfOrder = true
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public IFlywayRunnerCommands Info(FlywayConfiguration configuration = null)
        {
            var settings = new FlywayInfoSettings(configuration);
            return Run(settings);
        }

        /// <summary>
        /// Execute 'flyway migrate' with options
        /// </summary>
        /// <param name="configuration"></param>
        /// <example>
        /// <para>Run 'flyway migrate'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Info)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Migrate();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway migrate'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Info)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Migrate(new FlywayConfiguration
        ///             {
        ///                 OutOfOrder = true
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public IFlywayRunnerCommands Migrate(FlywayConfiguration configuration = null)
        {
            var settings = new FlywayMigrateSettings(configuration);
            return Run(settings);
        }

        /// <summary>
        /// Execute 'flyway baseline' with options
        /// </summary>
        /// <param name="configuration"></param>
        /// <example>
        /// <para>Run 'flyway baseline'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Info)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Migrate();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway baseline'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Info)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Migrate(new FlywayConfiguration
        ///             {
        ///                 BaselineVersion = "1.0.0.0"
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public IFlywayRunnerCommands Baseline(FlywayConfiguration configuration = null)
        {
            var settings = new FlywayBaselineSettings(configuration);
            return Run(settings);
        }
        
        /// <summary>
        /// Generic runner using settings
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="settings"></param>
        /// <returns></returns>
        private IFlywayRunnerCommands Run<TSettings>(TSettings settings) 
            where TSettings : FlywayRunnerSettings
        {
            var args = GetFlywaySettingsArguments(settings);
            Run(settings, args);
            return this;
        }

        private static ProcessArgumentBuilder GetFlywaySettingsArguments(FlywayRunnerSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings?.Evaluate(args);
            return args;
        }
    }
}