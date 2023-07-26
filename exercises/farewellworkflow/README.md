# Exercise 3: Farewell Workflow

This readme was ported from the official typescript tutorial [farewell-workflow/README.md](https://github.com/temporalio/edu-101-typescript-code/blob/main/exercises/farewell-workflow/README.md).

During this exercise, you will create an Activity function, register it with the Worker, and modify a Workflow to execute it.

Before continuing, kill any Worker instances still running from any previous exercises (you can do this by pressing Ctrl-C in the terminals where they are running).

As with other exercises, you should make your changes in the `practice` directory. Look for "TODO" comments, which will provide hints about what you'll need to change. If you get stuck and need additional hints, or if you want to check your work, look at the completed example in the `solution` directory.

We've added an additional project for this exercise:

- `Api` - A .NET API with two endpoints `/get-spanish-greeting?name={name}` and `/get-spanish-farewell?name={name}`

## Part A: Write an Activity Function

The [Application/Activities.cs](./practice/Application/Activities.cs) file contains a function (`GetSpanishGreeting`) that uses a microservice to get a customized greeting in Spanish.

1. Open the [Application/Activities.cs](./practice/Application/Activities.cs) file
1. Create a new Activity that will get a custom farewell message from the microservice.
   1. Copy the `GetSpanishGreeting` function
   1. Rename the new function (use any valid name you like)
   1. Change the path in the URL from `get-spanish-greeting` to `get-spanish-farewell`
   1. Save your changes to this file

## Part B: Modify the Workflow to Execute Your New Activity

- Open [Workflow.cs](./practice/Application/Workflow.cs) and write a Workflow that calls the Activity you wrote in the previous step. The Workflow should return a string.

- Open [Worker/Program.cs](./practice/Worker/Program.cs) and register the Workflow with the Worker.

## Part C:

- Open [Client/Program.cs](./practice/Client/Program.cs) and modify the application to call the FarewellWorkflow when the farewell argument is passed.

## Part D: Run the Api, Worker, and Client services

1. Start the microservice by running:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Api/Api.csproj
```

2. In another terminal, start your Worker by running:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Worker/Worker.csproj
```

3. In a third terminal, execute your Workflow by running:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Client/Client.csproj farewell
```

If there is time remaining, experiment with Activity failures and retries by stopping the microservice (press Ctrl-C in its terminal) and re-running the Workflow. Look at the Web UI to see the status of the Workflow and its Activities. After a few seconds, restart the microservice by running the same command used to start it earlier. You should find that the Workflow will now complete successfully following the next Activity retry.
