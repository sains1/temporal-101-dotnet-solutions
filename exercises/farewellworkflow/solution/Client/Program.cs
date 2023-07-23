using Application;
using Temporalio.Client;

// Connect to the default Server location (localhost:7233)
var client = await TemporalClient.ConnectAsync(new()
{
    TargetHost = "localhost:7233",
    // In production, pass options to configure TLS and other settings
});


switch (args[0])
{
    case "greeting":
        await Greeting();
        break;
    case "farewell":
        await Farewell();
        break;
    default:
        throw new InvalidOperationException(
            $"Unexpected argument at position 0, expected one of 'greeting' or 'farewell' but got '{args[0]}'");
}

async Task Greeting()
{
    var handle = await client.StartWorkflowAsync((GreetingWorkflow x) => x.Greeting("Temporal"), new WorkflowOptions
    {
        TaskQueue = "translation-tasks",
        // in practice, use a meaningful business id, eg customerId or transactionId
        ID = "workflow-" + Guid.NewGuid()
    });
    Console.WriteLine("Started workflow {0}", handle.ID);

    // optional: wait for client result
    Console.WriteLine(await handle.GetResultAsync());

}

async Task Farewell()
{
    var handle = await client.StartWorkflowAsync((FarewellWorkflow x) => x.Farewell("Temporal"), new WorkflowOptions
    {
        TaskQueue = "translation-tasks",
        // in practice, use a meaningful business id, eg customerId or transactionId
        ID = "workflow-" + Guid.NewGuid()
    });
    Console.WriteLine("Started workflow {0}", handle.ID);

    // optional: wait for client result
    Console.WriteLine(await handle.GetResultAsync());
}
