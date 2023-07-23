using Application;
using Temporalio.Client;
using Temporalio.Worker;

namespace Worker;

public class BackgroundWorker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;


    public BackgroundWorker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var client = await scope.ServiceProvider.GetRequiredService<Task<TemporalClient>>();

            // TODO register the farewell activity and workflow with the worker

            using var worker = new TemporalWorker(client,
                new TemporalWorkerOptions { TaskQueue = "translation-tasks"}
                    .AddActivity(Activities.GetSpanishGreeting)
                    .AddWorkflow<GreetingWorkflow>());

            await worker.ExecuteAsync(stoppingToken);
        }
    }
}
