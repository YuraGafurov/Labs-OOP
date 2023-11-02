using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPUCooler;

public class CPUCooler
{
    public CPUCooler(string name, Size size, ICollection<Sockets> supportedSockets, int thermalDesignPower)
    {
        Name = name;
        Size = size;
        SupportedSockets = supportedSockets;
        ThermalDesignPower = thermalDesignPower;
    }

    public string Name { get; set; }
    public Size Size { get; set; }
    public ICollection<Sockets> SupportedSockets { get; }
    public int ThermalDesignPower { get; set; }

    public CPUCoolerBuilder Direct(CPUCoolerBuilder builder)
    {
        builder.WithName(Name)
            .WithSize(Size)
            .WithTDP(ThermalDesignPower);
        foreach (Sockets socket in SupportedSockets)
        {
            builder.AddSocket(socket);
        }

        return builder;
    }
}