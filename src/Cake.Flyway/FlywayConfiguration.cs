using System;
using System.Collections.Generic;
using Cake.Core.IO;

namespace Cake.Flyway
{
    /// <summary>
    /// Flyway configuration object
    /// </summary>
    public class FlywayConfiguration
    {
        /// <summary>
        /// Path to the Flyway configuration files to be used 
        /// (default: &lt;&lt;INSTALL-DIR&gt;&gt;/conf/flyway.conf)
        /// </summary>
        [Obsolete("This was removed in Flyway 6.0.0 and upwards, use ConfigurationFiles instead.")]
        public string ConfigurationFile { get; set; }

        /// <summary>
        /// Path to the Flyway configuration files to be used.
        /// </summary>
        public ISet<FilePath> ConfigurationFiles { get; } = new HashSet<FilePath>();

        /// <summary>
        /// Jdbc url to use to connect to the database
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Fully qualified classname of the jdbc driver 
        /// (autodetected by default based on <see cref="Url"/>)
        /// </summary>
        public string Driver { get; set; }

        /// <summary>
        /// User to use to connect to the database
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Password to use to connect to the database
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// <para>List of schemas managed by Flyway. 
        /// These schema names are case-sensitive.
        /// (default: The default schema for the datasource connection)</para>
        /// Consequences:
        /// <list type="bullet">
        ///   <item>
        ///     <descriptions>The first schema in the list will be automatically set as 
        ///     the default one during the migration.</descriptions>
        ///   </item>
        ///   <item>
        ///     <descriptions>The first schema in the list will also be the one 
        ///     containing the metadata table.</descriptions>
        ///   </item>
        ///   <item>
        ///     <descriptions>The schemas will be cleaned in the order of this list.</descriptions>
        ///   </item>
        /// </list>
        /// </summary>
        public IList<string> Schemas { get; } = new List<string>();

        /// <summary>
        /// <para>Name of Flyway's metadata table (default: schema_version)</para>
        /// <para>By default (single-schema mode) the metadata table is placed in the 
        /// default schema for the connection provided by the datasource.
        /// When the flyway.schemas property is set (multi-schema mode), the metadata 
        /// table is placed in the first schema of the list.</para>
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// <para>List of locations to scan recursively for migrations. 
        /// (default: filesystem:&lt;&lt;INSTALL-DIR&gt;&gt;/sql)</para>
        /// <para>The location type is determined by its prefix.
        /// Unprefixed locations or locations starting with classpath: point to a package 
        /// on the classpath and may contain both sql and java-based migrations.
        /// Locations starting with filesystem: point to a directory on the filesystem 
        /// and may only contain sql migrations.</para>
        /// </summary>
        public IList<string> Locations { get; } = new List<string>();

        /// <summary>
        /// List of fully qualified class names of custom MigrationResolver 
        /// to use for resolving migrations.
        /// </summary>
        public IList<string> Resolvers { get; } = new List<string>();

        /// <summary>
        /// If set to true, default built-in resolvers (jdbc, spring-jdbc and sql) are 
        /// skipped and only custom resolvers as defined by 'flyway.resolvers' are used.
        /// (default: false)
        /// </summary>
        public bool? SkipDefaultResolvers { get; set; }

        /// <summary>
        /// List of directories containing JDBC drivers and Java-based migrations. 
        /// (default: &lt;&lt;INSTALL-DIR&gt;&gt;/jars)
        /// </summary>
        public IList<DirectoryPath> JarDirs { get; } = new List<DirectoryPath>();

        /// <summary>
        /// <para>File name prefix for sql migrations (default: V )</para>
        /// <para>Sql migrations have the following file name structure: 
        /// prefixVERSIONseparatorDESCRIPTIONsuffix,
        /// which using the defaults translates to V1_1__My_description.sql</para>
        /// </summary>
        public string SqlMigrationPrefix { get; set; }

        /// <summary>
        /// <para>File name prefix for repeatable sql migrations (default: R )</para>
        /// <para>Repeatable sql migrations have the following file name structure: 
        /// prefixSeparatorDESCRIPTIONsuffix, which using the defaults translates 
        /// to R__My_description.sql</para>
        /// </summary>
        public string RepeatableSqlMigrationPrefix { get; set; }

        /// <summary>
        /// <para>File name separator for Sql migrations (default: __)</para>
        /// <para>Sql migrations have the following file name structure: 
        /// prefixVERSIONseparatorDESCRIPTIONsuffix, which using the defaults 
        /// translates to V1_1__My_description.sql</para>
        /// </summary>
        public string SqlMigrationSeparator { get; set; }

        /// <summary>
        /// <para>File name suffix for Sql migrations (default: .sql)</para>
        /// <para>Sql migrations have the following file name structure: 
        /// prefixVERSIONseparatorDESCRIPTIONsuffix, which using the defaults 
        /// translates to V1_1__My_description.sql</para>
        /// </summary>
        public string SqlMigrationSuffix { get; set; }

        /// <summary>
        /// Encoding of Sql migrations (default: UTF8)
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// Whether placeholders should be replaced. (default: true)
        /// </summary>
        public bool? PlaceholderReplacement { get; set; }

        /// <summary>
        /// Prefix of every placeholder (default: ${ )
        /// </summary>
        public string PlaceholderPrefix { get; set; }

        /// <summary>
        /// Suffix of every placeholder (default: } )
        /// </summary>
        public string PlaceholderSuffix { get; set; }

        /// <summary>
        /// Placeholders to replace in Sql migrations
        /// </summary>
        public IDictionary<string, string> Placeholders { get; } = new Dictionary<string, string>();

        /// <summary>
        /// <para>Target version up to which Flyway should consider migrations.</para>
        /// The special value 'current' designates the current version of the schema. 
        /// (default: latest version)
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Whether to automatically call validate or not when running migrate. (default: true)
        /// </summary>
        public bool? ValidateOnMigrate { get; set; }

        /// <summary>
        /// <para>Whether to automatically call clean or not when a validation error occurs. 
        /// (default: false)</para>
        /// <para>This is exclusively intended as a convenience for development. Even tough we 
        /// strongly recommend not to change migration scripts once they have been checked 
        /// into SCM and run, this provides a way of dealing with this case in a smooth 
        /// manner. The database will be wiped clean automatically, ensuring that the 
        /// next migration will bring you back to the state checked into SCM.</para>
        /// <para>Warning ! Do not enable in production !</para>
        /// </summary>
        public bool? CleanOnValidationError { get; set; }

        /// <summary>
        /// <para>Whether to disabled clean. (default: false)</para>
        /// This is especially useful for production environments where running clean can 
        /// be quite a career limiting move.
        /// </summary>
        public bool? CleanDisabled { get; set; }

        /// <summary>
        /// The version to tag an existing schema with when executing baseline. (default: 1)
        /// </summary>
        public string BaselineVersion { get; set; }

        /// <summary>
        /// The description to tag an existing schema with when executing baseline. 
        /// (default: &lt;&lt; Flyway Baseline &gt;&gt;)
        /// </summary>
        public string BaselineDescription { get; set; }

        /// <summary>
        /// <para>Whether to automatically call baseline when migrate is executed against a non-empty 
        /// schema with no metadata table. (default: false)</para>
        /// This schema will then be initialized with the baselineVersion before executing the migrations.
        /// Only migrations above baselineVersion will then be applied.
        /// This is useful for initial Flyway production deployments on projects with an existing DB.
        /// Be careful when enabling this as it removes the safety net that ensures
        /// Flyway does not migrate the wrong database in case of a configuration mistake! 
        /// </summary>
        public bool? BaselineOnMigrate { get; set; }

        /// <summary>
        /// <para>Allows migrations to be run "out of order". (default: false)</para>
        /// If you already have versions 1 and 3 applied, and now a version 2 is found,
        /// it will be applied too instead of being ignored.
        /// </summary>
        public bool? OutOfOrder { get; set; }

        /// <summary>
        /// <para>This allows you to tie in custom code and logic to the Flyway lifecycle notifications 
        /// (default: empty).</para>
        /// Set this to a list of fully qualified FlywayCallback class name implementations
        /// </summary>
        public IList<string> Callbacks { get; } = new List<string>();

        /// <summary>
        /// If set to true, default built-in callbacks (sql) are skipped and only custom callback as
        /// defined by 'flyway.callbacks' are used. (default: false)
        /// </summary>
        public bool? SkipDefaultCallbacks { get; set; }

        /// <summary>
        /// <para>Ignore missing migrations when reading the metadata table. (default: false)</para>
        /// These are migrations that were performed by an older deployment of the application 
        /// that are no longer available in this version. For example: we have migrations available 
        /// on the classpath with versions 1.0 and 3.0. The metadata table indicates that a migration 
        /// with version 2.0 (unknown to us) has also been applied. Instead of bombing out (fail fast) 
        /// with an exception, a warning is logged and Flyway continues normally. This is useful for 
        /// situations where one must be able to deploy a newer version of the application even 
        /// though it doesn't contain migrations included with an older one anymore. true to continue 
        /// normally and log a warning, false to fail fast with an exception.
        /// </summary>
        public bool? IgnoreMissingMigrations { get; set; }

        /// <summary>
        /// <para>Ignore future migrations when reading the metadata table. (default: true)</para>
        /// These are migrations that were performed by a newer deployment of the application that 
        /// are not yet available in this version. For example: we have migrations available on the 
        /// classpath up to version 3.0. The metadata table indicates that a migration to version 4.0
        /// (unknown to us) has already been applied. Instead of bombing out (fail fast) with an 
        /// exception, a warning is logged and Flyway continues normally. This is useful for situations
        /// where one must be able to redeploy an older version of the application after the database 
        /// has been migrated by a newer one. true to continue normally and log a warning, false to 
        /// fail fast with an exception. 
        /// </summary>
        public bool? IgnoreFutureMigrations { get; set; }

        /// <summary>
        /// Whether to allow mixing transactional and non-transactional statements within the same 
        /// migration. true if mixed migrations should be allowed. false if an error should be thrown 
        /// instead. (default: false)
        /// </summary>
        public bool? Mixed { get; set; }

        /// <summary>
        /// Whether to group all pending migrations together in the same transaction when applying 
        /// them (only recommended for databases with support for DDL transactions). true if migrations
        /// should be grouped. false if they should be applied individually instead. (default: false)
        /// </summary>
        public bool? Group { get; set; }

        /// <summary>
        /// The username that will be recorded in the metadata table as having applied the migration.
        /// &lt;&lt;blank&gt;&gt; for the current database user of the connection. 
        /// (default: &lt;&lt;blank&gt;&gt;).
        /// </summary>
        public string InstalledBy { get; set; }

        /// <summary>
        /// Adds <paramref name="location"/> as a filesystem location to <see cref="Locations"/>.
        /// The method automatically adds the required "filesystem:" in front of 
        /// <paramref name="location"/>
        /// </summary>
        /// <param name="location">Path to the filesystem location</param>
        public FlywayConfiguration AddFilesystemLocation(string location)
        {
            Locations.Add($"filesystem:{location}");
            return this;
        }

        /// <summary>
        /// Adds <paramref name="location"/> as a classpath location to <see cref="Locations"/>.
        /// The method automatically adds the required "classpath:" in front of 
        /// <paramref name="location"/>
        /// </summary>
        /// <param name="location">Path to the classpath location</param>
        public FlywayConfiguration AddClasspathLocation(string location)
        {
            Locations.Add($"classpath:{location}");
            return this;
        }
    }
}
