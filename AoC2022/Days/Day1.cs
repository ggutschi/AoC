using AoC2022.Services;
using Microsoft.Extensions.Configuration;

namespace AoC2022.Days;

internal class Day1 : IDay
{
    private readonly IConfiguration configuration;
    private readonly IAoCWebService aocWebService;

    private readonly string NewLine = Environment.NewLine;

    private string? _input;

    public Day1(
        IConfiguration configuration,
        IAoCWebService aocWebService)
    {
        this.configuration = configuration;
        this.aocWebService = aocWebService;

        NewLine = configuration["NewLine"];
    }

    public int Number => 1;

    public async Task<string> CalculatePartOne()
    {
        await AssertInputLoaded();

        var maxCalories = _input
            .Split(NewLine + NewLine)
            .Max(caloriesPerElf => caloriesPerElf
                .Split(NewLine)
                .Sum(caloriesPerFood => int.Parse(caloriesPerFood)));

        return maxCalories.ToString();
    }

    public async Task<string> CalculatePartTwo()
    {
        await AssertInputLoaded();

        var sumTop3Calories = _input
            .Split(NewLine + NewLine)
            .Select(caloriesPerElf => caloriesPerElf
                .Split(NewLine)
                .Sum(caloriesPerFood => int.Parse(caloriesPerFood)))
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

        return sumTop3Calories.ToString();
    }

    private async Task AssertInputLoaded()
    {
        _input ??= (await aocWebService.GetInputAsync("/2022/day/1/input"))
            .Trim(NewLine.ToCharArray());
    }
}
