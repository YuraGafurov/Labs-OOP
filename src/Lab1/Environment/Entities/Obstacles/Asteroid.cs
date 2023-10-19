namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class Asteroid : IPhysObstacle
{
    private const int DefaultDamage = 10;

    public int Damage { get; set; } = DefaultDamage;
}