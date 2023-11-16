using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Memory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.SSD;

public class SSD : BaseMemory
{
    public SSD(string name, string connection, int capacity, int maximumOperatingSpeed, int powerConsumption)
        : base(name, capacity, maximumOperatingSpeed, powerConsumption)
    {
        Connection = connection;
    }

    public string Connection { get; set; }

    public SSDBuilder Direct(SSDBuilder builder)
    {
        builder.WithName(Name)
            .WithConnection(Connection)
            .WithCapacity(Capacity)
            .WithMaximumOperatingSpeed(OperatingSpeed)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}