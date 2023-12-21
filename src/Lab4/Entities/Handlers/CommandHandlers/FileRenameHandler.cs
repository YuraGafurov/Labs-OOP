using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileRename;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;

public class FileRenameHandler : BaseHandler
{
    public override ICommand? Handle(Iterator request)
    {
        string tmpRequest = request.Current() + " ";
        if (!request.MoveNext()) return base.Handle(request);
        tmpRequest += request.Current();
        if (tmpRequest is not "file rename" || !request.MoveNext()) return base.Handle(request);

        string path = request.Current();
        if (!request.MoveNext()) return base.Handle(request);
        string name = request.Current();

        return new FileRename(path, name);
    }
}