namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class AntimatterFlash : BaseObstacle
{
    private const int DefaultDamage = 1;

    public AntimatterFlash()
    {
        EnergyDamage = DefaultDamage;
    }
}