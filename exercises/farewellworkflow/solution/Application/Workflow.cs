using Temporalio.Workflows;

namespace Application;

[Workflow]
public class GreetingWorkflow
{
    [WorkflowRun]
    public async Task<string> Greeting(string name)
    {
        return await Workflow.ExecuteActivityAsync(
            () => Activities.GetSpanishGreeting(name),
            new ActivityOptions { StartToCloseTimeout = TimeSpan.FromSeconds(10) });
    }
}

[Workflow]
public class FarewellWorkflow
{
    [WorkflowRun]
    public async Task<string> Farewell(string name)
    {
        return await Workflow.ExecuteActivityAsync(
            () => Activities.GetSpanishFarewell(name),
            new ActivityOptions { StartToCloseTimeout = TimeSpan.FromSeconds(10) });
    }
}
