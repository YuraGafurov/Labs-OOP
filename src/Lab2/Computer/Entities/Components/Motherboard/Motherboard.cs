using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Motherboard;

public class Motherboard
{
    public Motherboard(string name, Sockets socket, int pciECount, int sataCount, Chipset.Chipset chipset, DDRStandarts ddrStandart, int ramSlots, MotherboardFormFactors formFactor, BIOS.BIOS bios)
    {
        Name = name;
        Socket = socket;
        PciECount = pciECount;
        SataCount = sataCount;
        Chipset = chipset;
        DDRStandart = ddrStandart;
        RAMSlots = ramSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public string Name { get; set; }
    public Sockets Socket { get; set; }
    public int PciECount { get; set; }
    public int SataCount { get; set; }
    public Chipset.Chipset Chipset { get; set; }
    public DDRStandarts DDRStandart { get; set; }
    public int RAMSlots { get; set; }
    public MotherboardFormFactors FormFactor { get; set; }
    public BIOS.BIOS Bios { get; set; }

    public MotherboardBuilder Direct(MotherboardBuilder builder)
    {
        builder.WithName(Name)
            .WithChipset(Chipset)
            .WithBIOS(Bios)
            .WithSocket(Socket)
            .WithPciCount(PciECount)
            .WithSataCount(SataCount)
            .WithDDRStandart(DDRStandart)
            .WithRAMSlots(RAMSlots)
            .WithFormFactor(FormFactor);

        return builder;
    }
}