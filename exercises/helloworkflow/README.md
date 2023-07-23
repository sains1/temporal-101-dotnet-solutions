# Exercise 1: Hello Workflow

## Part A: Set up a new project

Before beginning, make sure you have the template project installed by following the instructions in the main README

Once done, create a new project using the template:

```command
dotnet new temporal-dotnet-starter -n HelloWorkflow -o ./exercises/helloworkflow/practice
```

This will create a hello-world template under the practice directory of the first exercise

The template solution should look something like this:

- `HelloWorkflow.Client` - A .NET console application that interacts with the temporal server to start a workflow.
- `HelloWorkflow.Worker` - A .NET application with a background service that runs our temporal worker.
- `HelloWorkflow.Application` - A .NET class library with our workflow business logic. The other two projects reference this project.

<br />

## Part B: Review the Workflow Business Logic

- [HelloWorkflow.Application/Activities.cs](./practice/HelloWorkflow.Application/Activities.cs)
- [HelloWorkflow.Application/Workflow.cs](./practice/HelloWorkflow.Application/Workflow.cs)

<br />

## Part C: Change the Task Queue Name for the Worker

- [HelloWorkflow.Worker/Worker.cs](./practice/HelloWorkflow.Worker/Worker.cs)
- [HelloWorkflow.Client/Program.cs](./practice/HelloWorkflow.Client/Program.cs)

<br />

## Part D: Start the Worker

> Note: Ensure your temporal server is running first, see instructions in root [README.md](../../README.md)

Either run the worker project direct from your IDE or use the .NET command below:

```command
dotnet run --project ./exercises/helloworkflow/practice/HelloWorkflow.Worker/HelloWorkflow.Worker.csproj
```

<details>
      <summary>After the build, you should see some output like the collpased section below:</summary>
      
      ```
      info: Microsoft.Hosting.Lifetime[0]
            Application started. Press Ctrl+C to shut down.
      info: Microsoft.Hosting.Lifetime[0]
            Hosting environment: Development
      info: Microsoft.Hosting.Lifetime[0]
            Content root path: /temporal_dotnet_101/exercises/helloworkflow/HelloWorkflow.Worker
      ```
</details>

<br />

## Part E: Start the Client

> Note - run from a different terminal as we'll need the worker running in the background

```command
dotnet run --project ./exercises/helloworkflow/practice/HelloWorkflow.Client/HelloWorkflow.Client.csproj
```

<details>
      <summary>After the build, you should see some output like the collpased section below:</summary>
      
      ```
      Started workflow workflow-a9c73146-c296-4673-a99b-3d112677c831
      Hello, Temporal!
      ```
</details>

<br />

## Part F (Optional): Display the Result

Make sure to substitue the workflow ID below for the one outputted in the previous step.

```command
temporal workflow show --workflow-id <your-workflow-id-from-previous-output>
```

<details>
      <summary>You should see some output like the collpased section below:</summary>
      
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
</details>
