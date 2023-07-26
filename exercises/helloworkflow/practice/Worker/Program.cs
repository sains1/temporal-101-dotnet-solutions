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

        services.AddHostedTemporalWorker("hello-world")
            .AddWorkflow(typeof(Workflow))
            .AddStaticActivities(typeof(Activities));
    })
    .Build();

host.Run();
