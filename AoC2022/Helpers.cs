using AoC2022.Days;
using Pastel;
using System.Drawing;

namespace AoC2022;

public static class Helpers
{    
    public static async Task WriteOutputAsync(IDay day)
    {
        var answerPartOne = await day.CalculatePartOne();
        var answerPartTwo = await day.CalculatePartTwo();

        Console.WriteLine($"""
            {("Day " + day.Number).Pastel(Color.Yellow)}

            Part One
            {"Answer is".Pastel(Color.Gray)} {answerPartOne.Pastel(Color.Lime)}
           
            Part Two
            {"Answer is".Pastel(Color.Gray)} {answerPartTwo.Pastel(Color.Lime)}

            """);
    }
}
