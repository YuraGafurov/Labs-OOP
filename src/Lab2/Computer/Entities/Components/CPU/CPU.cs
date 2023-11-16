using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPU;

public class CPU
{
    public CPU(string name, int coreFrequency, int coreCount, Sockets socket, bool videocore, ICollection<int> supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption)
    {
        Name = name;
        CoreFrequency = coreFrequency;
        CoreCount = coreCount;
        Socket = socket;
        HasVideocore = videocore;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        ThermalDesignPower = thermalDesignPower;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public int CoreFrequency { get; set; }
    public int CoreCount { get; set; }
    public Sockets Socket { get; set; }
    public bool HasVideocore { get; set; }
    public ICollection<int> SupportedMemoryFrequencies { get; }
    public int ThermalDesignPower { get; set; }
    public int PowerConsumption { get; set; }

    public CPUBuilder Direct(CPUBuilder builder)
    {
        builder.WithName(Name)
            .WithCoreFrequency(CoreFrequency)
            .WithCoreCount(CoreCount)
            .WithSocket(Socket)
            .WithTDP(ThermalDesignPower)
            .WithPowerConsumption(PowerConsumption);

        if (HasVideocore)
        {
            builder.WithVideocore();
        }

        foreach (int frequency in SupportedMemoryFrequencies)
        {
            builder.AddMemoryFrequency(frequency);
        }

        return builder;
    }
}