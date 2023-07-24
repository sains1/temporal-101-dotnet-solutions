using Temporalio.Activities;

namespace Application;

public static class Activities
{
    private static readonly HttpClient _client = new();

    [Activity]
    public static async Task<string> GetSpanishGreeting(string name)
    {
        var response = await _client.GetAsync($"http://localhost:9999/get-spanish-greeting?name={name}");
        return await response.Content.ReadAsStringAsync();
    }

    // TODO write a GetSpanishFarewell Activity that returns a farewell message.
    // -> It will be identical to the greet activity except the path will be /get-spanish-farewell
}
