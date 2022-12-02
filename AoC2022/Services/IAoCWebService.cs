namespace AoC2022.Services;

public interface IAoCWebService
{
    Task<string> GetInputAsync(string relativePath);
}
