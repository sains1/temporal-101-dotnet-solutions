# Exercise 3: Farewell Workflow

> Note: This readme was ported from the official typescript tutorial [farewell-workflow/README.md](https://github.com/temporalio/edu-101-typescript-code/blob/main/exercises/farewell-workflow/README.md).

This exercise contains the following projects:

- `Application` - A .NET class library where we'll add our Workflows and Activities.
- `Client` - A .NET console application that interacts with the temporal server to start a Workflow.
- `Worker` - A .NET application with a background service that runs our temporal Worker.
- `Api` - A .NET API with two endpoints `/get-spanish-greeting?name={name}` and `/get-spanish-farewell?name={name}`

## Part A: Run the Api, Worker, and Client services

Our Activities will be calling to an Http Api located under the Api folder. To run this service, run this command:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Api/Api.csproj
```

You should see some output like below indicating the API is running on port 9999

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:9999
```

To check the API is working you can issue the following curl commands

```sh
curl "http://localhost:9999/get-spanish-greeting?name=tina"
curl "http://localhost:9999/get-spanish-farewell?name=tina"
```

Next, run the Worker:

```sh
dotnet watch --no-hot-reload --project ./exercises/farewellworkflow/practice/Worker/Worker.csproj
```

> Note: using the watch command above will automatically restart the Worker when you make changes to the code.

Finally, you can run the client with the commands below. The client can start either the farewell or the greeting Workflows by passing a positional argument at the end of the command:

Start the greeting Workflow:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Client/Client.csproj -- greeting
```

Start the farewell Workflow:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Client/Client.csproj -- farewell
```

> Note: The farewell client command above will fail because we haven't implemented it yet.

## Part B: Write the Activity

- Open [Activities.cs](./practice/Application/Activities.cs) and write an Activity GetSpanishFarewell that calls our API endpoint `/get-spanish-farewell?name={name}`. The Activity should return a string.

- If the activity was added to the same static class as our greeting Activity then it will be automatically registered with the worker, otherwise if its on a seperate class be sure to register it in [Worker/Program.cs](./practice/Worker/Program.cs).

## Part C: Write the Workflow

- Open [Workflow.cs](./practice/Application/Workflow.cs) and write a Workflow that calls the Activity you wrote in the previous step. The Workflow should return a string.

- Open [Worker/Program.cs](./practice/Worker/Program.cs) and register the Workflow with the Worker.

> Note - the Worker should have automatically restarted when you register the Workflow, but if for some reason it doesn't just restart it manually.

## Part D: Modify the client to invoke the FarewellWorkflow

- Open [Client/Program.cs](./practice/Client/Program.cs) and modify the application to call the FarewellWorkflow when the farewell argument is passed.

## Part E: Invoke the FarewellWorkflow

- Run the client with the farewell argument:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Client/Client.csproj -- farewell
```

If everything is working correctly, you should see the message `¡Adiós, Temporal!`.
