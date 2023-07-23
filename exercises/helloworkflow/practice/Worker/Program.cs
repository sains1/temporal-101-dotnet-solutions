using Worker;
using Temporalio.Client;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<BackgroundWorker>();
        services.AddSingleton(ctx =>
            TemporalClient.ConnectAsync(new()
            {
                TargetHost = "localhost:7233",
                LoggerFactory = ctx.GetRequiredService<ILoggerFactory>(),
            }));
    })
    .Build();

host.Run();
