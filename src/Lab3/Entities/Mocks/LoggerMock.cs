using Itmo.ObjectOrientedProgramming.Lab3.Entities.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Mocks;

public class LoggerMock : ILogger
{
    public string LoggedMessage { get; private set; } = string.Empty;

    public void Log(string message)
    {
        LoggedMessage = message;
    }
}