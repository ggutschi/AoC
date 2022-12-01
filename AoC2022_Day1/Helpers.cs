using AoC2022.Days;

namespace AoC2022;

public static class Helpers
{    
    public static async Task WriteOutputAsync(IDay day)
    {
        Console.WriteLine($"""
       Day {day.Number}
       =====

       Part One
       --------
       Answer is {await day.CalculatePartOne()}
       
       Part Two
       --------
       Answer is {await day.CalculatePartTwo()}

       """);
    }
}
