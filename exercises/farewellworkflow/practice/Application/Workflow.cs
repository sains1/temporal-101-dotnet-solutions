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

// TODO write a farewell workflow that returns the response from the farewell activity
// TODO remember to add the workflow and activity to the Worker and Client applications

/*
 * [Workflow]
 * public class FarewellWorkflow
 * { ....
 */
