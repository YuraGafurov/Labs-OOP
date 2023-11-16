using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Memory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.HDD;

public class HDD : BaseMemory
{
    public HDD(string name, int capacity, int spindleRotationSpeed, int powerConsumption)
        : base(name, capacity, spindleRotationSpeed, powerConsumption)
    {
    }

    public HDDBuilder Direct(HDDBuilder builder)
    {
        builder.WithName(Name)
            .WithCapacity(Capacity)
            .WithSpindleRotationSpeed(OperatingSpeed)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}