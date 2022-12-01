using AoC2022.Services;
using Microsoft.Extensions.Configuration;

namespace AoC2022.Days;

abstract class DayBase : IDay
{
    protected readonly IConfiguration configuration;
    protected readonly IAoCWebService aocWebService;

    protected readonly string NewLine = Environment.NewLine;

    protected string? _input;

    public DayBase(
        IConfiguration configuration,
        IAoCWebService aocWebService)
    {
        this.configuration = configuration;
        this.aocWebService = aocWebService;

        NewLine = configuration["NewLine"] ?? Environment.NewLine;
    }

    public abstract int Number { get; }

    public abstract Task<string> CalculatePartOne();
    public abstract Task<string> CalculatePartTwo();

    protected async Task AssertInputLoaded()
    {
        _input ??= (await aocWebService.GetInputAsync($"/2022/day/{Number}/input"))
            .Trim(NewLine.ToCharArray());
    }
}
