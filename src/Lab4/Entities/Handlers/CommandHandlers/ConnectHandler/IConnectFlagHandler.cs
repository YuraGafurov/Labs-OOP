using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.ConnectHandler;

public interface IConnectFlagHandler
{
    IConnectFlagHandler SetNext(IConnectFlagHandler handler);

    ConnectBuilder? Handle(Iterator request, ConnectBuilder builder);
}