# Exercise 4: Finale Workflow

> Note: This readme was ported from the official typescript tutorial [finale-workflow/README.md](https://github.com/temporalio/edu-101-typescript-code/blob/main/exercises/finale-workflow/README.md).

This exercise demonstrates invoking workflows written in other languages.

Our Workflow and Activity are written in Java. The implementation is able to use a Java graphics
library that would otherwise be would be incompatible with a typical .NET program.

You'll notice the file `java-activity-and-worker.jar` which is the Java Worker. As our .NET solution doesn't implement a Worker, a Workflow, or an activity itself, we only need the `Client` project in order to invoke the Workflow.

# Start the Worker (Java)

In one terminal, run the following command:

```sh
java -classpath \
./exercises/finaleworkflow/java-activity-and-worker.jar \
io.temporal.training.PdfCertWorker
```

You should see some output to indicate the Worker is running.

# Start the Workflow (dotnet)

Open the [Program.cs](./src/Client/Program.cs) file, and change the argument passed to the Workflow from 'Maxim Fateev' to your name.

If you take a look at [Workflow.cs](./src/Client/Workflow.cs) you'll see that we're using an interface so that we retain type safety, but we don't need to implement the Workflow ourselves as its handled by the Java Worker.

The Workflow name in this example defaults to the type name of the interface but with the preceding `I` removed. (see the [Temporal .NET SDK](https://github.com/temporalio/sdk-dotnet#workflows) Workflow section for details on naming conventions)

Run the command below from another terminal to start the Workflow:

```sh
dotnet run --project ./exercises/finaleworkflow/src/Client/Client.csproj
```

If the above works, you should find see output like the following:

```
Started workflow cert-generator-workflow-d0cad313-91f5-4ada-9c0c-ae8eca84f22b
You can find your certificate of completion here: /projects/other/temporal_dotnet_101/101_certificate_sains1.pdf
```

And hopefully a certificate at the file path indicated above!
