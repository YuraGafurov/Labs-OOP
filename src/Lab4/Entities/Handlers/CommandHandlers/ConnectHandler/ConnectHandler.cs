using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.ConnectHandler;

public class ConnectHandler : BaseHandler
{
    private ConnectModeHandler _modeHandler;

    public ConnectHandler(ConnectModeHandler modeHandler)
    {
        _modeHandler = modeHandler;
    }

    public override ICommand? Handle(Iterator request)
    {
        if (request.Current() is not "connect" || !request.MoveNext()) return base.Handle(request);
        var builder = new ConnectBuilder();
        builder = builder.WithPath(request.Current());
        if (!request.MoveNext()) return base.Handle(request);
        builder = _modeHandler.Handle(request, builder);
        while (request.MoveNext())
        {
            if (builder != null) builder = _modeHandler.Handle(request, builder);
        }

        return builder?.Build();
    }
}