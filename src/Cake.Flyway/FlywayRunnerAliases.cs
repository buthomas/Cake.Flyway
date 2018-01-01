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
        /// Get a FlywayRunner
        /// </summary>
        /// <param name="context"></param>
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
        [CakePropertyAlias]
        public static IFlywayRunnerCommands Flyway(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            return new FlywayRunner(
                context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
        }
    }
}