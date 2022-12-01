namespace AoC2022.Services;

internal interface IAoCWebService
{
    Task<string> GetInputAsync(string relativePath);
}
