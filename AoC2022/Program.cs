using AoC2022.Days;
using AoC2022.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton<IAoCWebService, AoCWebService>();
        services.AddSingleton<IAppService, AppService>();
        services.AddSingleton<IDay, Day1>();
    }).Build();

var appService = host.Services.GetRequiredService<IAppService>();

await appService.RunAsync();