namespace AoC2022.Days;

internal class Day1 : IDay
{
    private string? _input;

    public int Number => 1;

    public async Task<string> CalculatePartOne()
    {
        await ReadInput();

        var maxCalories = _input
            .Split(Environment.NewLine + Environment.NewLine)
            .Max(caloriesPerElf => caloriesPerElf
                .Split(Environment.NewLine)
                .Sum(caloriesPerFood => int.Parse(caloriesPerFood)));

        return maxCalories.ToString();
    }

    public async Task<string> CalculatePartTwo()
    {
        await ReadInput();

        var sumTop3Calories = _input
            .Split(Environment.NewLine + Environment.NewLine)
            .Select(caloriesPerElf => caloriesPerElf
                .Split(Environment.NewLine)
                .Sum(caloriesPerFood => int.Parse(caloriesPerFood)))
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

        return sumTop3Calories.ToString();
    }

    private async Task ReadInput()
    {
        _input ??= await File.ReadAllTextAsync(IDay.DefaultInputFilename);
    }
}
