# Exercise 4: Finale Workflow

This readme was ported from the official typescript tutorial [finale-workflow/README.md](https://github.com/temporalio/edu-101-typescript-code/blob/main/exercises/finale-workflow/README.md).

One of the benefits of Temporal is that it provides SDKs for several languages and you can use multiple languages in the context of a single Workflow. For example, you might write your Workflow in TypeScript but use Java or Go for an Activity in that workflow.

The last exercise in this workshop does exactly that. The Workflow itself is written in TypeScript, but the Activity that is executed as part of this Workflow is written in Java, as is the Worker that runs it. Since the Activity is written in Java, it's able to use a Java graphics library that would otherwise be would be incompatible with a typical TypeScript program.

## Start the Worker (Java)

In one terminal, run the following command:

```sh
java -classpath \
./exercises/finaleworkflow/java-activity-and-worker.jar \
io.temporal.training.PdfCertWorker
```

## Edit the Workflow (dotnet)

Open the [Program.cs](./src/Client/Program.cs) file, and change the argument passed to the Workflow from 'Maxim Fateev' to your name.

If you take a look at [Workflow.cs](./src/Client/Workflow.cs) you'll see that we're using an interface so that we retain type safety, but we don't need to implement the Workflow ourselves as its handled by the Java Worker.

The Workflow name in this example defaults to the type name of the interface but with the preceding `I` removed. (see the [Temporal .NET SDK](https://github.com/temporalio/sdk-dotnet#workflows) Workflow section for details on naming conventions)

## Start the Workflow

Run the command below from another terminal to start the Workflow:

```sh
dotnet run --project ./exercises/finaleworkflow/src/Client/Client.csproj
```

- Once the workflow is complete, use the explorer view on the left side of the exercise environment to locate the file created by this workflow. It will have a name similar to `101_certificate_maxim_fateev.pdf`, only with your name in place of `maxim_fateev`.
- Right-click its icon in the explorer view and choose
  **Download...**.
- After you've downloading it to your computer, open it with your preferred PDF viewer.
