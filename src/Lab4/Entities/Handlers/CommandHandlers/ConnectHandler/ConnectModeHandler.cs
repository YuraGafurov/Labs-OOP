using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.ConnectHandler;

public class ConnectModeHandler : BaseConnectFlagHandler
{
    public override ConnectBuilder? Handle(Iterator request, ConnectBuilder builder)
    {
        if (request.Current() is not "-m" || !request.MoveNext()) return base.Handle(request, builder);
        builder.WithMode(request.Current());
        return builder;
    }
}
