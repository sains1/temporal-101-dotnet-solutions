using Application;
using Temporalio.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTemporalClient(x =>
        {
            x.TargetHost = "localhost:7233";
            // In production, pass options to configure TLS and other settings
        });

        // TODO register the FarewellWorkflow on the worker
        services.AddHostedTemporalWorker("translation-tasks")
            .AddStaticActivities(typeof(Activities))
            .AddWorkflow<GreetingWorkflow>();
    })
    .Build();

host.Run();
