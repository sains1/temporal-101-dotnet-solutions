using Temporalio.Workflows;

namespace HelloWorkflow.Application;

[Workflow]
public class GreetingWorkflow
{
    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        return await Workflow.ExecuteActivityAsync(
            () => Activities.Greet(name),
            new ActivityOptions { ScheduleToCloseTimeout = TimeSpan.FromMinutes(1) });
    }
}
