using Cake.Core;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;

namespace Cake.Flyway.Tests
{
    [TestFixture]
    class FlywayRunnerAliasesTests
    {
        [Test]
        public void TestThatExceptionIsThrownIfContextIsNull()
        {
            Should.Throw<ArgumentNullException>(() => FlywayRunnerAliases.Flyway(null));
        }

        [Test]
        public void Test()
        {
            var context = Substitute.For<ICakeContext>();
            var flyway = context.Flyway();
            flyway.ShouldNotBeNull();
        }
    }
}
