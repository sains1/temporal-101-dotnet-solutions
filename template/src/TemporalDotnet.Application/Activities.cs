using Temporalio.Activities;

namespace TemporalDotnet.Application;

public static class Activities
{
    [Activity]
    public static Task<string> Greet(string name)
    {
        return Task.FromResult($"Hello, {name}!");
    }
}
