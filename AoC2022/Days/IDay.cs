namespace AoC2022.Days;

public interface IDay
{
    public const string DefaultInputFilename = "input.txt";

    int Number { get; }

    Task<string> CalculatePartOne();
    Task<string> CalculatePartTwo();
}
