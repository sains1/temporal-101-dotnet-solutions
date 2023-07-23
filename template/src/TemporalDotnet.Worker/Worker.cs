using TemporalDotnet.Application;
using Temporalio.Client;
using Temporalio.Worker;

namespace TemporalDotnet.Worker;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;


    public Worker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var client = await scope.ServiceProvider.GetRequiredService<Task<TemporalClient>>();

            using var worker = new TemporalWorker(client,
                new TemporalWorkerOptions { TaskQueue = "hello-world"}
                    .AddActivity(Activities.Greet)
                    .AddWorkflow<Workflow>());

            await worker.ExecuteAsync(stoppingToken);
        }
    }
}