using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NormalSpace : BaseSpace
{
    public NormalSpace(int length, Collection<BaseObstacle> obstacles)
    : base(length)
    {
        foreach (BaseObstacle obstacle in obstacles)
        {
            if (obstacle is Asteroid || obstacle is Meteor)
            {
                Obstacles.Add(obstacle);
            }
        }
    }
}