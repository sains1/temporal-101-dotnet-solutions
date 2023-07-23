using Temporalio.Workflows;

namespace TemporalDotnet.Application;

[Workflow]
public class Workflow
{
    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        return await Temporalio.Workflows.Workflow.ExecuteActivityAsync(
            () => Activities.Greet(name),
            new ActivityOptions { ScheduleToCloseTimeout = TimeSpan.FromMinutes(1) });
    }
}
