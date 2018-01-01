# Cake.Flyway
A set of aliases for Cake to run Flyway commands

## Information

### Build Status

Branch | Status
--- | ---
Master | [![Build status](https://ci.appveyor.com/api/projects/status/8kqq1fvxgxb665c1/branch/master?svg=true)](https://ci.appveyor.com/project/buthomas/cake-flyway/branch/master)
Develop | [![Build status](https://ci.appveyor.com/api/projects/status/8kqq1fvxgxb665c1/branch/develop?svg=true)](https://ci.appveyor.com/project/buthomas/cake-flyway/branch/develop)

## Code Coverage
Branch | codecov | coveralls
--- | --- | ---
Master | [![codecov](https://codecov.io/gh/buthomas/Cake.Flyway/branch/master/graph/badge.svg)](https://codecov.io/gh/buthomas/Cake.Flyway) | [![Coverage Status](https://coveralls.io/repos/github/buthomas/Cake.Flyway/badge.svg?branch=master)](https://coveralls.io/github/buthomas/Cake.Flyway?branch=master)
Develop | [![codecov](https://codecov.io/gh/buthomas/Cake.Flyway/branch/develop/graph/badge.svg)](https://codecov.io/gh/buthomas/Cake.Flyway) | [![Coverage Status](https://coveralls.io/repos/github/buthomas/Cake.Flyway/badge.svg?branch=develop)](https://coveralls.io/github/buthomas/Cake.Flyway?branch=develop)

### Nuget
[![NuGet](https://img.shields.io/nuget/v/Cake.Flyway.svg)](https://www.nuget.org/packages/Cake.Flyway/) 

### Licence
[![License](http://img.shields.io/:license-mit-blue.svg)](http://cake-contrib.mit-license.org)

## Usage
Build the Cake.Flyway.dll then use as follows

```c#
    #addin "Cake.Flyway"

    Task("Flyway")
        .Does(() => {
            // new Flyway configuration
            var configuration = new FlywayConfiguration {
                Url = "jdbc:sqlserver:////<host>:<port>;databaseName=<database>",
                User = "<user>",
                Password = "<password>"
            }

            // flyway info
            Flyway.Info(configuration);

            // flyway migrate
            Flyway.Migrate(configuration);
        });
```

## Scope
Cake.Flyway currently supports the following commands of Flyway v4.2.0:

* ```flyway migrate```
* ```flyway clean```
* ```flaway info```
* ```flaway validate```
* ```flyway baseline```
* ```flaway repair```

The Flyway Pro features of version 5 are currently not supported.