namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.SSD;

public class SSD
{
    public SSD(string name, string connection, int capacity, int maximumOperatingSpeed, int powerConsumption)
    {
        Name = name;
        Connection = connection;
        Capacity = capacity;
        MaximumOperatingSpeed = maximumOperatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public string Connection { get; set; }
    public int Capacity { get; set; }
    public int MaximumOperatingSpeed { get; set; }
    public int PowerConsumption { get; set; }

    public SSDBuilder Direct(SSDBuilder builder)
    {
        builder.WithName(Name)
            .WithConnection(Connection)
            .WithCapacity(Capacity)
            .WithMaximumOperatingSpeed(MaximumOperatingSpeed)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}