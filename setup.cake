#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.Flyway",
                            repositoryOwner: "buthomas",
                            repositoryName: "Cake.Flyway",
                            appVeyorAccountName: "buthomas",
                            shouldRunDupFinder: false,
                            shouldRunInspectCode: false,
                            shouldPostToGitter: false,
                            shouldPostToSlack: false,
                            shouldPostToTwitter: false,
                            shouldDeployGraphDocumentation: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
    context: Context,
    testCoverageFilter: "+[*]* -[nunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[Shouldly]*",
    testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
    testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();