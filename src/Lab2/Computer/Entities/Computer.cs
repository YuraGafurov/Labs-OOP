using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPUCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Memory;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

public class Computer
{
    public Computer(Motherboard motherboard, CPU cpu, BIOS bios, CPUCooler cooler, Collection<RAM> ram, XMP xmp, Videocard? videocard, Collection<BaseMemory> memory, ComputerCase computerCase, Components.PowerSupply.PowerSupply powerSupply, WiFi? wifi)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        Bios = bios;
        CpuCooler = cooler;
        Ram = ram;
        Xmp = xmp;
        Videocard = videocard;
        Memory = memory;
        ComputerCase = computerCase;
        PowerSupply = powerSupply;
        WiFi = wifi;
    }

    public Motherboard Motherboard { get; set; }
    public CPU Cpu { get; set; }
    public BIOS Bios { get; set; }
    public CPUCooler CpuCooler { get; set; }
    public Collection<RAM> Ram { get; }
    public XMP? Xmp { get; set; }
    public Videocard? Videocard { get; set; }
    public Collection<BaseMemory> Memory { get; }
    public ComputerCase ComputerCase { get; set; }
    public Components.PowerSupply.PowerSupply PowerSupply { get; set; }
    public WiFi? WiFi { get; set; }
}