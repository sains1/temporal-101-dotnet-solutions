using Application;
using Temporalio.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTemporalClient(x =>
        {
            x.TargetHost = "localhost:7233";
        });

        services.AddHostedTemporalWorker("hello-world")
            .AddStaticActivities(typeof(Activities))
            .AddWorkflow<Workflow>();

    })
    .Build();

host.Run();
