using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Disconnect;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;

public class DisconnectHandler : BaseHandler
{
    public override ICommand? Handle(Iterator request)
    {
        if (request.Current() is not "disconnect") return base.Handle(request);

        return new Disconnect();
    }
}