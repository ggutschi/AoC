using AoC2022.Days;
using Microsoft.Extensions.DependencyInjection;

namespace AoC2022.Utils.Helper;

public class ReflectionHelper
{
    internal static IList<IDay> GetImplementingClasses(IServiceProvider serviceProvider, Type type)
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IDay).IsAssignableFrom(t) &&
                        !t.IsAbstract &&
                        !t.IsInterface)
            .Select(o => (IDay)ActivatorUtilities.CreateInstance(serviceProvider, o))
            .ToList();
    }
}
