using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Flyway
{
    /// <summary>
    /// A wrapper around the Flyway command line tool
    /// </summary>
    internal class FlywayRunner : Tool<FlywaySettingsBase>, IFlywayRunnerCommands
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
        /// Execute 'flyway clean' with options
        /// </summary>
        /// <param name="configuration"></param>
        /// <example>
        /// <para>Run 'flyway clean'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Clean)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Clean();
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public IFlywayRunnerCommands Clean(FlywayConfiguration configuration = null)
        {
            var settings = new FlywayCleanSettings(configuration);
            return Run(settings);
        }

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
        /// Execute 'flyway validate' with options
        /// </summary>
        /// <param name="configuration"></param>
        /// <example>
        /// <para>Run 'flyway validate'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Validate)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Validate();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway validate'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Validate)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Validate(new FlywayConfiguration
        ///             {
        ///                 OutOfOrder = true
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public IFlywayRunnerCommands Validate(FlywayConfiguration configuration = null)
        {
            var settings = new FlywayValidateSettings(configuration);
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
        /// Execute 'flyway repair' with options
        /// </summary>
        /// <param name="configuration"></param>
        /// <example>
        /// <para>Run 'flyway repair'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Repair)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Repair();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway repair'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Repair)
        ///     .Does(() =>
        ///     {
        ///         Flyway.Repair(new FlywayConfiguration
        ///             {
        ///                 SqlMigrationPrefix = "M_"
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public IFlywayRunnerCommands Repair(FlywayConfiguration configuration = null)
        {
            var settings = new FlywayRepairSettings(configuration);
            return Run(settings);
        }

        /// <summary>
        /// Generic runner using settings
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="settings"></param>
        /// <returns></returns>
        private IFlywayRunnerCommands Run<TSettings>(TSettings settings) 
            where TSettings : FlywaySettingsBase
        {
            var args = GetFlywaySettingsArguments(settings);
            Run(settings, args);
            return this;
        }

        private static ProcessArgumentBuilder GetFlywaySettingsArguments(FlywaySettingsBase settings)
        {
            var args = new ProcessArgumentBuilder();
            settings?.Evaluate(args);
            return args;
        }
    }
}