using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.BIOS;

public class BIOS
{
    public BIOS(string name, BIOSType type, int version, ICollection<CPU.CPU> supportedProcessors)
    {
        Name = name;
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
    }

    public string Name { get; set; }
    public BIOSType Type { get; set; }
    public int Version { get; set; }
    public ICollection<CPU.CPU> SupportedProcessors { get; }

    public BIOSBuilder Direct(BIOSBuilder builder)
    {
        builder.WithName(Name)
            .WithType(Type)
            .WithVersion(Version);
        foreach (CPU.CPU processor in SupportedProcessors)
        {
            builder.AddProcessor(processor);
        }

        return builder;
    }
}