namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class Meteor : IPhysObstacle
{
    private const int DefaultDamage = 25;

    public int Damage { get; set; } = DefaultDamage;
}