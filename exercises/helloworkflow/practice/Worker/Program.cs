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

        services.AddHostedTemporalWorker("hello-world")
            .AddWorkflow(typeof(Workflow))
            .AddStaticActivities(typeof(Activities));
    })
    .Build();

host.Run();
