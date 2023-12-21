using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileDelete;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;

public class FileDeleteHandler : BaseHandler
{
    public override ICommand? Handle(Iterator request)
    {
        string tmpRequest = request.Current() + " ";
        if (!request.MoveNext()) return base.Handle(request);
        tmpRequest += request.Current();
        if (tmpRequest is not "file delete" || !request.MoveNext()) return base.Handle(request);

        return new FileDelete(request.Current());
    }
}