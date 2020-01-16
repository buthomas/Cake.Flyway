using System;
using NUnit.Framework;
using Shouldly;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    class FlywayRunnerAliasesTests
    {
        [Test]
        public void TestThatExceptionIsThrownIfContextIsNull()
        {
            Should.Throw<ArgumentNullException>(() => FlywayRunnerAliases.FlywayBaseline(null));
            Should.Throw<ArgumentNullException>(() => FlywayRunnerAliases.FlywayClean(null));
            Should.Throw<ArgumentNullException>(() => FlywayRunnerAliases.FlywayInfo(null));
            Should.Throw<ArgumentNullException>(() => FlywayRunnerAliases.FlywayMigrate(null));
            Should.Throw<ArgumentNullException>(() => FlywayRunnerAliases.FlywayRepair(null));
            Should.Throw<ArgumentNullException>(() => FlywayRunnerAliases.FlywayValidate(null));
        }
    }
}
