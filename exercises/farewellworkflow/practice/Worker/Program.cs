using Application;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Temporalio.Client;
using Temporalio.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.TryAddSingleton<ITemporalClient>(provider =>
            TemporalClient.CreateLazy(new TemporalClientConnectOptions
            {
                TargetHost = "localhost:7233",
                LoggerFactory = provider.GetRequiredService<ILoggerFactory>()
            }));

        // TODO register the FarewellWorkflow on the worker
        services.AddHostedTemporalWorker("translation-tasks")
            .AddStaticActivities(typeof(Activities))
            .AddWorkflow<GreetingWorkflow>();
    })
    .Build();

host.Run();
