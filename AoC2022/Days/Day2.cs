using AoC2022.Services;
using Microsoft.Extensions.Configuration;

namespace AoC2022.Days;

public class Day2 : DayBase
{
    public Day2(IConfiguration configuration, IAoCWebService aocWebService) : base(configuration, aocWebService) { }

    public override int Number => 2;

    private static readonly int[,] WinMatrix = new[,]
    {
        { 1, 0, 2 },
        { 2, 1, 0 },
        { 0, 2, 1 }
    };

    public static int GetRoundPoints(char handMine, char handOpponent) => WinMatrix[handMine - 'X', handOpponent - 'A'] * 3;

    public static int GetHandPoints(char hand) => (hand - 'X') + 1;

    public override async Task<string> CalculatePartOne()
    {
        var input = await GetInputAsync();
        var points = input
            .Split(NewLine)
            .Sum(x => x is [var opponent, ' ', var mine] ? GetHandPoints(mine) + GetRoundPoints(mine, opponent) : 0);

        return points.ToString();
    }

    public override async Task<string> CalculatePartTwo()
    {
        var input = await GetInputAsync();
        var points = input
            .Split(NewLine)
            .Sum(x => x is [var opponent, ' ', var mine] ? GetHandPoints(mine) + GetRoundPoints(mine, opponent) : 0);

        return points.ToString();
    }
}
