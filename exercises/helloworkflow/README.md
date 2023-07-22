# Exercise 1: Hello Workflow

## Part A: Set up a new project

🚧

Template structure:

- `HelloWorkflow.Application` - A .NET class library with our workflow business logic. The other two projects below reference this project.
- `HelloWorkflow.Client` - A .NET console application.
- `HelloWorkflow.Worker` - A .NET application with a single background service that runs our temporal worker.

## Part B: Review the Workflow Business Logic

- [HelloWorkflow.Application/Activities.cs](HelloWorkflow.Application/Activities.cs)
- [HelloWorkflow.Application/Workflow.cs](HelloWorkflow.Application/Workflow.cs)

## Part C: Change the Task Queue Name for the Worker

- [HelloWorkflow.Worker/Worker.cs](HelloWorkflow.Worker/Worker.cs)
- [HelloWorkflow.Client/Program.cs](HelloWorkflow.Client/Program.cs)

## Part D: Start the Worker

> Note: Ensure your temporal server is running first, see instructions in root [README.md](../../README.md)

Either run the worker project direct from your IDE or use the .NET command below:

```sh
dotnet run --project ./exercises/helloworkflow/HelloWorkflow.Worker/HelloWorkflow.Worker.csproj
```

After the build, you should see some output like below:

```
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /temporal_dotnet_101/exercises/helloworkflow/HelloWorkflow.Worker
```

## Part E: Start the Client

> Note - run from a different terminal as we'll need the worker running in the background

```sh
dotnet run --project ./exercises/helloworkflow/HelloWorkflow.Client/HelloWorkflow.Client.csproj
```

After the build, you should see some output like below:

```
Started workflow workflow-a9c73146-c296-4673-a99b-3d112677c831
Hello, Temporal!
```

## Part F (Optional): Display the Result

Make sure to substitue the workflow ID below for the one outputted in the previous step.

```sh
temporal workflow show --workflow-id <your-workflow-id-from-preview-output>
```

You should see some output like below:

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
