namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;

public class JumpEngineGamma : BaseJumpEngine
{
    private const int DefaultFuelConsumption = 3;
    private const int DefaultRangeOfTravel = 200;

    public JumpEngineGamma()
    {
        FuelConsumption = DefaultFuelConsumption;
        RangeOfTravel = DefaultRangeOfTravel;
    }

    public override int FuelCost(int dist)
    {
        return FuelConsumption * dist;
    }
}