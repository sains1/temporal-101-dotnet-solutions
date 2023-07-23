# Exercise 1: Hello Workflow

> Note: This readme was ported from the official typescript tutorial [hello-workflow/README.md](https://github.com/temporalio/edu-101-typescript-code/blob/main/exercises/hello-workflow/README.md).

> Note: This exercise contains a notable difference to the typescript reference solution it was ported from. The typescript solution starts by scaffolding your own project using the CLI, but as I haven't created a templating solution I've just created a blank starter solution under the /practice folder instead.

## Part A: Set up a new project

The exercise is split into 2 top level folders

`./solution` contains a complete reference solution for the exercise.
`./practice` contains a partially complete solution for the exercise which we will modify.

The practice folder should look something like:

![hello workflow project structure](../../docs/helloworkflow/hello-workflow-project-structure.png)

Our practice solution contains the following projets:

- `Application` - A .NET class library where we'll add our workflow and activities.
- `Client` - A .NET console application that interacts with the temporal server to start a workflow.
- `Worker` - A .NET application with a background service that runs our temporal worker.

## Part B: Review the Workflow Business Logic

- [Application/Activities.cs](./practice/Application/Activities.cs)
- [Application/Workflow.cs](./practice/Application/Workflow.cs)

## Part C: Change the Task Queue Name for the Worker

- [Worker/Worker.cs](./practice/Worker/Worker.cs)
- [Client/Program.cs](./practice/Client/Program.cs)

## Part D: Start the Worker

> Note: Ensure your temporal server is running first, see instructions in root [README.md](../../README.md)

Either run the worker project direct from your IDE or use the .NET command below:

```command
dotnet run --project ./exercises/helloworkflow/practice/Worker/Worker.csproj
```

The above command should yield the following output, indicating the worker is running

```
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /temporal_dotnet_101/exercises/helloworkflow/Worker
```

## Part E: Start the Client

> Note - run from a different terminal as we'll need the worker running in the background

```command
dotnet run --project ./exercises/helloworkflow/practice/Client/Client.csproj
```

The above command should yield the following output:

```
Started workflow workflow-a9c73146-c296-4673-a99b-3d112677c831
Hello, Temporal!
```

## Part F (Optional): Display the Result from temporal-cli

Run the command below to display the workflow execution result from the temporal-cli. Make sure to substitue the workflow ID below for the one outputted in the previous step.

```command
temporal workflow show --workflow-id <your-workflow-id-from-previous-output>
```

The above command should yield the following output:

```
Progress:
      ID          Time                     Type
      1  2023-07-22T18:57:06Z  WorkflowExecutionStarted
      2  2023-07-22T18:57:06Z  WorkflowTaskScheduled
      3  2023-07-22T18:57:06Z  WorkflowTaskStarted
      4  2023-07-22T18:57:07Z  WorkflowTaskCompleted
      5  2023-07-22T18:57:07Z  ActivityTaskScheduled
      6  2023-07-22T18:57:07Z  ActivityTaskStarted
      7  2023-07-22T18:57:07Z  ActivityTaskCompleted
      8  2023-07-22T18:57:07Z  WorkflowTaskScheduled
      9  2023-07-22T18:57:07Z  WorkflowTaskStarted
      10  2023-07-22T18:57:07Z  WorkflowTaskCompleted
      11  2023-07-22T18:57:07Z  WorkflowExecutionCompleted

Result:
      Status: COMPLETED
      Output: ["Hello, Temporal!"]
```
