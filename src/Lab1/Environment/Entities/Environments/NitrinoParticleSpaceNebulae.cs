using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;

public class NitrinoParticleSpaceNebulae : BaseSpace
{
    public NitrinoParticleSpaceNebulae(int length, Collection<BaseObstacle> obstacles)
        : base(length)
    {
        foreach (BaseObstacle obstacle in obstacles)
        {
            if (obstacle is CosmoWhale)
            {
                Obstacles.Add(obstacle);
            }
        }
    }
}