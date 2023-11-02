using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPUCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public static class Configurator
{
    public static Result Validate(Entities.Computer computer)
    {
        Collection<RAM>? ram = computer.Ram;
        Collection<Entities.Components.SSD.SSD>? ssd = computer.Ssd;
        Collection<HDD>? hdd = computer.Hdd;
        CPU cpu = computer.Cpu;
        Motherboard motherboard = computer.Motherboard;
        PowerSupply powerSupply = computer.PowerSupply;
        ComputerCase computerCase = computer.ComputerCase;
        CPUCooler cpuCooler = computer.CpuCooler;
        BIOS bios = motherboard.Bios;
        Videocard? videocard = computer.Videocard;
        XMP? xmp = computer.Xmp;
        WiFi? wifi = computer.WiFi;

        if (bios.SupportedProcessors.All(p => p != cpu))
        {
            return new Result(false, "Invalid cpu");
        }

        if (cpuCooler.SupportedSockets.All(p => p != cpu.Socket))
        {
            return new Result(false, "Invalid Socket");
        }

        if (cpu.Socket != motherboard.Socket)
        {
            return new Result(false, "Invalid Socket");
        }

        if (ram != null && ram.Count > motherboard.RAMSlots)
        {
            return new Result(false, "Too much ram");
        }

        if (computerCase.SupportedMotherboardFormFactors.All(p => p != motherboard.FormFactor))
        {
            return new Result(false, "Invalid Motherboard");
        }

        if (videocard is not null)
        {
            if (videocard.Length > computerCase.MaximumLengthOfVideocard ||
                videocard.Width > computerCase.MaximumWidthOfVideocard)
            {
                return new Result(false, "Invalid Videocard");
            }
        }

        if (cpu.ThermalDesignPower > cpuCooler.ThermalDesignPower)
        {
            return new Result(true, "The system TDP is slightly higher than the maximum, the assembly is not recommended for use");
        }

        int maxConsumption = 0;
        maxConsumption += cpu.PowerConsumption;
        if (ram != null)
        {
            foreach (RAM? r in ram)
            {
                if (r != null) maxConsumption += r.PowerConsumption;
            }
        }

        if (ssd is not null)
        {
            foreach (Entities.Components.SSD.SSD r in ssd)
            {
                maxConsumption += r.PowerConsumption;
            }
        }

        if (hdd is not null)
        {
            foreach (HDD h in hdd)
            {
                maxConsumption += h.PowerConsumption;
            }
        }

        if (videocard is not null) maxConsumption += videocard.PowerConsumption;

        if (wifi is not null)
        {
            maxConsumption += wifi.PowerConsumption;
        }

        switch (maxConsumption - powerSupply.PeakLoad)
        {
            case > 20:
                return new Result(false, "Too big consumption");
            case > 0 and <= 20:
                return new Result(true, "The system power consumption is slightly higher than the maximum, the assembly is not recommended for use");
        }

        return new Result(true, "All good");
    }
}