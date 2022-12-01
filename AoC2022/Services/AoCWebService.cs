using Microsoft.Extensions.Configuration;
using System.Net;

namespace AoC2022.Services;

public class AoCWebService : IAoCWebService
{
    private readonly IConfiguration configuration;

    public AoCWebService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<string> GetInputAsync(string relativePath)
    {
        var baseAddress = new Uri(configuration["BaseUrl"]);
        var cookieContainer = new CookieContainer();

        using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
        using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
        {
            cookieContainer.Add(baseAddress, new Cookie("session", configuration["SessionString"]));

            var result = await client.GetAsync(relativePath);
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsStringAsync();
        }
    }
}
