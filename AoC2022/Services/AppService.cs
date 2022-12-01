using AoC2022.Days;
using Pastel;
using System.Drawing;

namespace AoC2022.Services;

public class AppService : IAppService
{
    private readonly IDay day;

    public AppService(IDay day)
    {
        this.day = day;
    }

    public async Task RunAsync()
    {
        (var answerPartOne, var answerPartTwo) = await CalculateAnswers();

        PrintAnswers(answerPartOne, answerPartTwo);
    }

    public async Task<(string, string)> CalculateAnswers() => (await day.CalculatePartOne(), await day.CalculatePartTwo());

    public void PrintAnswers(string answerPartOne, string answerPartTwo)
    {
        Console.WriteLine($"""
            {("Day " + day.Number).Pastel(Color.Yellow)}

            Part One
            {"Answer is".Pastel(Color.Gray)} {answerPartOne.Pastel(Color.Lime)}
           
            Part Two
            {"Answer is".Pastel(Color.Gray)} {answerPartTwo.Pastel(Color.Lime)}

            """);
    }
}
