using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.ConnectHandler;

public class BaseConnectFlagHandler : IConnectFlagHandler
{
    private IConnectFlagHandler? _nextHandler;

    public IConnectFlagHandler SetNext(IConnectFlagHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual ConnectBuilder? Handle(Iterator request, ConnectBuilder builder)
    {
        if (_nextHandler is not null)
        {
            return _nextHandler.Handle(request, builder);
        }
        else
        {
            return null;
        }
    }
}