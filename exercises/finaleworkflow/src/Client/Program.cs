using Client;
using Temporalio.Client;

var client = await TemporalClient.ConnectAsync(new()
{
    TargetHost = "localhost:7233",
});

// TODO: Change 'Maxim Fateev' to your name
var handle = await client.StartWorkflowAsync((ICertificateGeneratorWorkflow x) => x.RunAsync("Maxim Fateev"),
    new WorkflowOptions
    {
        TaskQueue = "generate-certificate-taskqueue", ID = "cert-generator-workflow-" + Guid.NewGuid()
    });

Console.WriteLine("Started workflow {0}", handle.ID);
Console.WriteLine("You can find your certificate of completion here: " + await handle.GetResultAsync());
