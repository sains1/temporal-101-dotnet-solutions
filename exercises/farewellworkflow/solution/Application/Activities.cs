using Temporalio.Activities;

namespace Application;

public static class Activities
{
    private static HttpClient _client = new();

    [Activity]
    public static async Task<string> GetSpanishGreeting(string name)
    {
        var response = await _client.GetAsync($"http://localhost:9999/get-spanish-greeting?name={name}");
        return await response.Content.ReadAsStringAsync();
    }

    [Activity]
    public static async Task<string> GetSpanishFarewell(string name)
    {
        var response = await _client.GetAsync($"http://localhost:9999/get-spanish-farewell?name={name}");
        return await response.Content.ReadAsStringAsync();
    }
}
