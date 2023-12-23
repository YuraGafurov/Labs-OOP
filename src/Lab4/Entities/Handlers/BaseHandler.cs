using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers;

public abstract class BaseHandler : IHandler
{
    private IHandler? _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual ICommand? Handle(Iterator request)
    {
        if (_nextHandler is not null)
        {
            request.Reset();
            return _nextHandler.Handle(request);
        }
        else
        {
            return null;
        }
    }
}