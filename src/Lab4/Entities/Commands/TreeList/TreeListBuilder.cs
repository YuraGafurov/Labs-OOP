using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeList;

public class TreeListBuilder
{
    private int? _depth;

    public TreeListBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public TreeList Build()
    {
        return new TreeList(
            _depth ?? throw new ArgumentNullException());
    }
}