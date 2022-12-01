namespace AoC2022.Days;

internal class Day1 : IDay
{
    public int Number => 1;

    public async Task<string> CalculatePartOne(string inputFileName = IDay.DefaultInputFilename)
    {
        var input = await File.ReadAllTextAsync(inputFileName);

        var maxCalories = input
            .Split(Environment.NewLine + Environment.NewLine)
            .Max(caloriesPerElf => caloriesPerElf
                .Split(Environment.NewLine)
                .Sum(caloriesPerFood => int.Parse(caloriesPerFood)));

        return maxCalories.ToString();
    }

    public async Task<string> CalculatePartTwo(string inputFileName = IDay.DefaultInputFilename)
    {
        var input = await File.ReadAllTextAsync(inputFileName);

        var sumTop3Calories = input
            .Split(Environment.NewLine + Environment.NewLine)
            .Select(caloriesPerElf => caloriesPerElf
                .Split(Environment.NewLine)
                .Sum(caloriesPerFood => int.Parse(caloriesPerFood)))
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

        return sumTop3Calories.ToString();
    }
}
