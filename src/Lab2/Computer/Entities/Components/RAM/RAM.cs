using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.RAM;

public class RAM
{
    public RAM(string name, int availableMemorySize, ICollection<JedecVoltagePairs> supportedJedecAndVoltagePairs, ICollection<XMP.XMP> availableXmpProfiles, RAMFormFactors formFactor, DDRStandarts ddrStandart, int powerConsumption)
    {
        Name = name;
        AvailableMemorySize = availableMemorySize;
        SupportedJedecAndVoltagePairs = supportedJedecAndVoltagePairs;
        AvailableXMPProfiles = availableXmpProfiles;
        FormFactor = formFactor;
        DDRStandart = ddrStandart;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public int AvailableMemorySize { get; set; }
    public ICollection<JedecVoltagePairs> SupportedJedecAndVoltagePairs { get; }
    public ICollection<XMP.XMP> AvailableXMPProfiles { get; }
    public RAMFormFactors FormFactor { get; set; }
    public DDRStandarts DDRStandart { get; set; }
    public int PowerConsumption { get; set; }

    public RAMBuilder Direct(RAMBuilder builder)
    {
        builder.WithName(Name)
            .WithAvailableMemorySize(AvailableMemorySize)
            .WithFormFactor(FormFactor)
            .WithDDRStandart(DDRStandart)
            .WithPowerConsumption(PowerConsumption);

        foreach (JedecVoltagePairs pair in SupportedJedecAndVoltagePairs)
        {
            builder.AddJedecVoltagePair(pair);
        }

        foreach (XMP.XMP xmp in AvailableXMPProfiles)
        {
            builder.AddXMPProfile(xmp);
        }

        return builder;
    }
}