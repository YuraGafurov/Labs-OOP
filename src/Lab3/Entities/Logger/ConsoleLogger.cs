using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Logger;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}