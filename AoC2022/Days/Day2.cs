using AoC2022.Services;
using Microsoft.Extensions.Configuration;

namespace AoC2022.Days;

public class Day2 : DayBase
{
    public Day2(IConfiguration configuration, IAoCWebService aocWebService) : base(configuration, aocWebService) { }

    public override int Number => 2;

    // +1 for column shift
    // + 3 to not get negative
    // % 3 to normalize
    // * 3 for point multiplication
    public static int GetRoundPoints(char handMine, char handOpponent) => ((handMine - 'X') + 1 - (handOpponent - 'A') + 3) % 3 * 3;

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
