namespace AoC2022.Days;

public interface IDay
{
    public const string DefaultInputFilename = "input.txt";

    int Number { get; }

    Task<string> CalculatePartOne(string inputFilename = DefaultInputFilename);
    Task<string> CalculatePartTwo(string inputFilename = DefaultInputFilename);
}
