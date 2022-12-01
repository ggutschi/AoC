using AoC2022.Services;
using Microsoft.Extensions.Configuration;

namespace AoC2022.Days;

internal class Day1 : DayBase
{
    public Day1(IConfiguration configuration, IAoCWebService aocWebService) : base(configuration, aocWebService) { }

    public override int Number => 1;

    public override async Task<string> CalculatePartOne()
    {
        var maxCalories = (await GetInputAsync())
            .Split(NewLine + NewLine)
            .Max(caloriesPerElf => caloriesPerElf
                .Split(NewLine)
                .Sum(caloriesPerFood => int.Parse(caloriesPerFood)));

        return maxCalories.ToString();
    }

    public override async Task<string> CalculatePartTwo()
    {
        var sumTop3Calories = (await GetInputAsync())
            .Split(NewLine + NewLine)
            .Select(caloriesPerElf => caloriesPerElf
                .Split(NewLine)
                .Sum(caloriesPerFood => int.Parse(caloriesPerFood)))
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

        return sumTop3Calories.ToString();
    }
}
