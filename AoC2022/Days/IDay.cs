namespace AoC2022.Days;

public interface IDay
{
    int Number { get; }

    Task<(string answerPartOne, string answerPartTwo)> CalculateAllParts();

    Task<string> CalculatePartOne();
    Task<string> CalculatePartTwo();
}
