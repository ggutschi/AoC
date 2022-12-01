using AoC2022.Services;
using Microsoft.Extensions.Configuration;

namespace AoC2022.Days;

abstract class DayBase : IDay
{
    protected readonly IConfiguration configuration;
    protected readonly IAoCWebService aocWebService;

    protected readonly string NewLine = Environment.NewLine;

    public DayBase(
        IConfiguration configuration,
        IAoCWebService aocWebService)
    {
        this.configuration = configuration;
        this.aocWebService = aocWebService;

        NewLine = configuration["NewLine"] ?? Environment.NewLine;
    }

    public abstract int Number { get; }

    private string _input;
    public async Task<string> GetInputAsync()
    {
        if (_input == null)
        {
            _input = await LoadInput();
        }

        return _input;
    }

    public abstract Task<string> CalculatePartOne();
    public abstract Task<string> CalculatePartTwo();

    protected async Task<string> LoadInput()
    {
        return (await aocWebService.GetInputAsync($"/2022/day/{Number}/input"))
            .Trim(NewLine.ToCharArray());
    }
}
