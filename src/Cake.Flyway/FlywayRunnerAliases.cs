using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Flyway
{
    /// <summary>
    /// Provides a wrapper around Flyway functionality within a Cake build script
    /// </summary>
    [CakeAliasCategory("Flyway")]
    [CakeAliasCategory("Database")]
    public static class FlywayRunnerAliases
    {
        /// <summary>
        /// Execute 'flyway migrate' with options
        /// </summary>
        /// <example>
        /// <para>Run 'flyway migrate'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Migrate)
        ///     .Does(() =>
        ///     {
        ///         FlywayMigrate();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway migrate'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Migrate)
        ///     .Does(() =>
        ///     {
        ///         FlywayMigrate(new FlywayMigrateSettings
        ///             {
        ///                 Configuration = new FlywayConfiguration
        ///                 {
        ///                     OutOfOrder = true
        ///                 }
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        [CakePropertyAlias]
        public static void FlywayMigrate(this ICakeContext context, FlywayMigrateSettings settings = null)
        {
            Run(context, settings);
        }

        /// <summary>
        /// Execute 'flyway clean' with options
        /// </summary>
        /// <example>
        /// <para>Run 'flyway clean'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Clean)
        ///     .Does(() =>
        ///     {
        ///         FlywayClean();
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public static void FlywayClean(this ICakeContext context, FlywayCleanSettings settings = null)
        {
            Run(context, settings);
        }

        /// <summary>
        /// Execute 'flyway info' with options
        /// </summary>
        /// <example>
        /// <para>Run 'flyway info'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Info)
        ///     .Does(() =>
        ///     {
        ///         FlywayInfo();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway info'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Info)
        ///     .Does(() =>
        ///     {
        ///         FlywayInfo(new FlywayInfoSettings
        ///             {
        ///                 Configuration = new FlywayConfiguration
        ///                 {
        ///                     OutOfOrder = true
        ///                 }
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public static void FlywayInfo(this ICakeContext context, FlywayInfoSettings settings = null)
        {
            Run(context, settings);
        }

        /// <summary>
        /// Execute 'flyway validate' with options
        /// </summary>
        /// <example>
        /// <para>Run 'flyway validate'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Validate)
        ///     .Does(() =>
        ///     {
        ///         FlywayValidate();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway validate'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Validate)
        ///     .Does(() =>
        ///     {
        ///         FlywayValidate(new FlywayValidateSettings
        ///             {
        ///                 Configuration = new FlywayConfiguration
        ///                 {
        ///                     OutOfOrder = true
        ///                 }
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public static void FlywayValidate(this ICakeContext context, FlywayValidateSettings settings = null)
        {
            Run(context, settings);
        }

        /// <summary>
        /// Execute 'flyway baseline' with options
        /// </summary>
        /// <example>
        /// <para>Run 'flyway baseline'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Baseline)
        ///     .Does(() =>
        ///     {
        ///         FlywayBaseline();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway baseline'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Baseline)
        ///     .Does(() =>
        ///     {
        ///         FlywayBaseline(new FlywayBaselineSettings
        ///             {
        ///                 Configuration = new FlywayConfiguration
        ///                 {
        ///                     BaselineVersion = "1.0.0.0"
        ///                 }
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public static void FlywayBaseline(this ICakeContext context, FlywayBaselineSettings settings = null)
        {
            Run(context, settings);
        }

        /// <summary>
        /// Execute 'flyway repair' with options
        /// </summary>
        /// <example>
        /// <para>Run 'flyway repair'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Repair)
        ///     .Does(() =>
        ///     {
        ///         FlywayRepair();
        ///     });
        /// ]]>
        /// </code>
        /// <para>Run 'flyway repair'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Flyway-Repair)
        ///     .Does(() =>
        ///     {
        ///         FlywayRepair(new FlywayRepairSettings
        ///             {
        ///                 Configuration = new FlywayConfiguration
        ///                 {
        ///                     SqlMigrationPrefix = "M_"
        ///                 }
        ///             }
        ///         );
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        public static void FlywayRepair(this ICakeContext context, FlywayRepairSettings settings = null)
        {
            Run(context, settings);
        }

        private static void Run(ICakeContext context, FlywaySettingsBase settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var runner = new FlywayRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }
    }
}