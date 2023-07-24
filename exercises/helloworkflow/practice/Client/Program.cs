using Application;
using Temporalio.Client;

// Connect to the default Server location (localhost:7233)
var client = await TemporalClient.ConnectAsync(new()
{
    TargetHost = "localhost:7233",
    // In production, pass options to configure TLS and other settings
});

var handle = await client.StartWorkflowAsync((Workflow x) => x.RunAsync("Temporal"), new WorkflowOptions
{
    TaskQueue = "hello-world",
    // in practice, use a meaningful business id, eg customerId or transactionId
    Id = "workflow-" + Guid.NewGuid()
});

Console.WriteLine("Started workflow {0}", handle.Id); // Started workflow workflow-84382273-5863-468c-bd81-08cd12f29057

// optional: wait for client result
Console.WriteLine(await handle.GetResultAsync()); // Hello, Temporal!
