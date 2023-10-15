using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class HighDensitySpaceNebulae : BaseSpace
{
    public HighDensitySpaceNebulae(int length, Collection<BaseObstacle> obstacles)
        : base(length)
    {
        foreach (BaseObstacle obstacle in obstacles)
        {
            if (obstacle is AntimatterFlash)
            {
                Obstacles.Add(obstacle);
            }
        }
    }
}