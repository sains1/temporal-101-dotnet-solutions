# Exercise 3: Farewell Workflow

> Note: This readme was ported from the official typescript tutorial [farewell-workflow/README.md](https://github.com/temporalio/edu-101-typescript-code/blob/main/exercises/farewell-workflow/README.md).

This exercise contains the following projects:

- `Client` - A .NET console application that interacts with the temporal server to start a workflow.
- `Worker` - A .NET application with a background service that runs our temporal worker.
- `Application` - A .NET class library with our workflow business logic.
- `Api` - A .NET API with two endpoints `/get-spanish-greeting?name={name}` and `/get-spanish-farewell?name={name}`

## Part A: Run the Api, Worker, and Client services

Our workflow activities will be calling to the external API under the Api project. To run this service, run the following command:

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

Next, run the worker:

```sh
dotnet watch --project ./exercises/farewellworkflow/practice/Worker/Worker.csproj
```

> Note: using the watch command above will automatically restart the worker when you make changes to the code.

Finally, you can run the client with the commands below. The client can start either the farewell or the greeting workflows by passing a positional argument at the end of the command:

Start the greeting workflow:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Client/Client.csproj -- greeting
```

Start the farewell workflow:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Client/Client.csproj -- farewell
```

> Note: The farewell client command above will fail because we haven't implemented it yet.

## Part B: Write the activity function

- Open [Activities.cs](./practice/Application/Activities.cs) and write an activity GetSpanishFarewell that calls our API endpoint `/get-spanish-farewell?name={name}`. The activity should return a string.

- Open [BackgroundWorker.cs](./practice/Worker/BackgroundWorker.cs) and register the activity with the worker.

## Part C: Write the workflow

- Open [Workflow.cs](./practice/Application/Workflow.cs) and write a workflow that calls the activity function you wrote in the previous step. The workflow should return a string.

- Open [BackgroundWorker.cs](./practice/Worker/BackgroundWorker.cs) and register the workflow with the worker.

## Part D: Modify the client to invoke the farewell workflow

- Open [Program.cs](./practice/Client/Program.cs) and modify the application to call the farewell workflow when the farewell argument is passed.

## Part E: Run the farewell workflow

- Run the client with the farewell argument:

```sh
dotnet run --project ./exercises/farewellworkflow/practice/Client/Client.csproj -- farewell
```

If everything is working correctly, you should see the message `¡Adiós, Temporal!`.
