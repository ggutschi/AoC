using AoC2022.Services;
using Microsoft.Extensions.Configuration;

namespace AoC2022.Days;

internal class Day1 : DayBase
{
    public Day1(IConfiguration configuration, IAoCWebService aocWebService) : base(configuration, aocWebService) { }

    public override int Number => 1;

    public override async Task<string> CalculatePartOne()
    {
        await AssertInputLoaded();

        var maxCalories = _input
            .Split(NewLine + NewLine)
            .Max(caloriesPerElf => caloriesPerElf
                .Split(NewLine)
                .Sum(caloriesPerFood => int.Parse(caloriesPerFood)));

        return maxCalories.ToString();
    }

    public override async Task<string> CalculatePartTwo()
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
}
