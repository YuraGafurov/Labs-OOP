namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;

public class ImpulseEngineC : BaseImpulseEngine
{
    private const int FuelStartCost = 10;
    private const int DefaultFuelConsumption = 1;

    public ImpulseEngineC()
    {
        FuelConsumption = DefaultFuelConsumption;
    }

    public override int FuelCost(int dist)
    {
        return (FuelConsumption * dist) + FuelStartCost;
    }
}