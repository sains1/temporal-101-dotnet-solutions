# \*Unofficial\* Temporal 101 dotnet code solutions

This repo contains my unofficial .NET code solutions for the temporal 101 typescript course.

At the time of writing no dotnet course exists (as its still in alpha) but I've ported this course as a learning exercise. To the best of my knowledge the solutions are correct.

Typescript course link - https://learn.temporal.io/courses/temporal_101/typescript

## Prerequisites

- Temporal CLI - https://docs.temporal.io/cli
- .NET 7 - https://dotnet.microsoft.com/en-us/download/dotnet/7.0

## Repo structure

./exercises contains the exercises from the course, some of the exercises are split into /practice and /solution folders. The /practice folder contains a partially complete solution which you can complete yourself. The /solution folder contains a complete solution.

## Running the temporal-server

```sh
temporal server start-dev
```

> Note - when using the temporal CLI the server will be available at `localhost:7233` and the webUI at `http://localhost:8233/`

## Exercises

1 - [Hello Workflow](exercises/helloworkflow/README.md)
