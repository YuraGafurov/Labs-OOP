namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Meteor : BaseObstacle
{
    private const int DefaultDamage = 25;

    public Meteor()
    {
        PhysDamage = DefaultDamage;
    }
}