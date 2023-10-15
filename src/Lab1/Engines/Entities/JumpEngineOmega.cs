namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class JumpEngineOmega : BaseJumpEngine
{
    private const int DefaultFuelConsumption = 5;
    private const int DefaultRangeOfTravel = 300;

    public JumpEngineOmega()
    {
        FuelConsumption = DefaultFuelConsumption;
        RangeOfTravel = DefaultRangeOfTravel;
    }

    public override int FuelCost(int dist)
    {
        return FuelConsumption * dist;
    }
}