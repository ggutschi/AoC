using AoC2022.Services;
using Microsoft.Extensions.Configuration;

namespace AoC2022.Days;

public class Day2 : DayBase
{
    public Day2(IConfiguration configuration, IAoCWebService aocWebService) : base(configuration, aocWebService) { }

    public override int Number => 2;

    public static int GetPoints(char handMine, char handOpponent) => GetHandPoints(handMine) + GetRoundPoints(handMine, handOpponent);

    //private static readonly int[,] WinMatrix = new[,]
    //{
    //    { 1, 0, 2 },
    //    { 2, 1, 0 },
    //    { 0, 2, 1 }
    //};

    // + 1 for column shift
    // + 3 to not get negative
    // % 3 to normalize
    // * 3 for point multiplication
    public static int GetRoundPoints(char handMine, char handOpponent) => ((handMine - 'X') - (handOpponent - 'A') + 1 + 3) % 3 * 3;

    public static int GetHandPoints(char hand) => (hand - 'X') + 1;

    // output matrix is traversed win matrix
    //private static readonly int[,] OutputMatrix = new[,]
    //{
    //    { 2, 0, 1 },
    //    { 0, 1, 2 },
    //    { 1, 2, 0 }
    //};

    // + 2 for shift
    // % 3 to normalize
    // + 'X' to get my hand
    public static char GetMine(char handOpponent, char output) => (char)(((handOpponent - 'A') + (output - 'X') + 2) % 3 + 'X');

    public override async Task<string> CalculatePartOne()
    {
        var input = await GetInputAsync();
        var points = input
            .Split(NewLine)
            .Sum(x => x is [var opponent, ' ', var mine] ? GetPoints(mine, opponent) : 0);

        return points.ToString();
    }

    public override async Task<string> CalculatePartTwo()
    {
        var input = await GetInputAsync();
        var points = input
            .Split(NewLine)
            .Sum(x => x is [var opponent, ' ', var output] ? GetPoints(GetMine(opponent, output), opponent) : 0);

        return points.ToString();
    }
}
