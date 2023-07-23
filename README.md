# \*Unofficial\* Temporal 101 dotnet code solutions

This repo contains my unofficial .NET code solutions for the temporal 101 typescript course.

At the time of writing no dotnet course exists (as its still in alpha) but I've ported this course as a learning exercise. To the best of my knowledge the solutions are correct.

Typescript course link - https://learn.temporal.io/courses/temporal_101/typescript

## Prerequisites

- Temporal CLI - https://docs.temporal.io/cli
- .NET 7 - https://dotnet.microsoft.com/en-us/download/dotnet/7.0
- Install the course .NET template (see below)

## Installing the course template

I've created a minimal .NET template which will be used to scaffold projects for the exercises. In order to use the template you'll need to follow the series of steps below.

First, package the template using the following commands:

```command
dotnet pack ./template/nuget.csproj
```

This should produce a `.nupkg` file we can then install as a template:

```command
dotnet new -i ./template/TemporalDotnetStarter.0.1.0.nupkg
```

You can then check the template is installed by running:

```command
dotnet new --list | grep Temporal
```

## Repo structure

/exercises - contains the individual exercises from the course, each exercise has its own README.md and the directory is split into `/solution` and `/practice`

`/solution` will contain a working example of the exercise, `/practice` will initially be empty, but will be the working directory for your solution.

## Running the temporal-server

```sh
temporal server start-dev
```

## Exercises

1 - [Hello Workflow](exercises/helloworkflow/README.md)
