using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Logger;

public class LoggerDecorator : IAddressee
{
    public LoggerDecorator(IAddressee addressee, ILogger logger)
    {
        Addressee = addressee;
        Logger = logger;
    }

    public IAddressee Addressee { get; }
    public ILogger Logger { get; }

    public void ReceiveMessage(Message message)
    {
        Logger.Log($"{message.Title}\n{message.Body}");
        Addressee.ReceiveMessage(message);
    }
}