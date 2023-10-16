using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;

public abstract class BaseSpace
{
    protected BaseSpace(int length)
    {
        Length = length;
        Obstacles = new Collection<BaseObstacle>();
    }

    public int Length { get; }
    public Collection<BaseObstacle> Obstacles { get; }
}