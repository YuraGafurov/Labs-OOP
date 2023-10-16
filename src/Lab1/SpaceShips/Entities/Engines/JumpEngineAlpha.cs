namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;

public class JumpEngineAlpha : BaseJumpEngine
{
    private const int DefaultFuelConsumption = 1;
    private const int DefaultRangeOfTravel = 100;

    public JumpEngineAlpha()
    {
        FuelConsumption = DefaultFuelConsumption;
        RangeOfTravel = DefaultRangeOfTravel;
    }

    public override int FuelCost(int dist)
    {
        return FuelConsumption * dist;
    }
}