using AoC2022.Days;
using Microsoft.Extensions.DependencyInjection;
using Pastel;
using System.Drawing;

namespace AoC2022.Services;

public class AppService : IAppService
{
    private readonly IList<IDay> days;
    private readonly IServiceProvider serviceProvider;

    public AppService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;

        days = GetAllImplementedDays();
    }

    private IList<IDay> GetAllImplementedDays() => AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(a => a.GetTypes())
        .Where(t => typeof(IDay).IsAssignableFrom(t) &&
                    !t.IsAbstract &&
                    !t.IsInterface)
        .Select(o => (IDay)ActivatorUtilities.CreateInstance(serviceProvider, o))
        .ToList();

    public async Task RunAsync()
    {
        foreach (var day in days)
        {
            (var answerPartOne, var answerPartTwo) = await day.CalculateAllParts();

            PrintAnswers(day.Number, answerPartOne, answerPartTwo);
        }
    }

    public void PrintAnswers(int numberOfDay, string answerPartOne, string answerPartTwo)
    {
        Console.WriteLine($"""
            {("Day " + numberOfDay).Pastel(Color.Yellow)}

            Part One
            {"Answer is".Pastel(Color.Gray)} {answerPartOne.Pastel(Color.Lime)}
           
            Part Two
            {"Answer is".Pastel(Color.Gray)} {answerPartTwo.Pastel(Color.Lime)}

            """);
    }
}
