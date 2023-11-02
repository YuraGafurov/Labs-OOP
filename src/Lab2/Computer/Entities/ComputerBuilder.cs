using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPUCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

public class ComputerBuilder
{
    private readonly Collection<RAM> _ram;
    private readonly Collection<SSD> _ssd;
    private readonly Collection<HDD> _hdd;
    private Motherboard? _motherboard;
    private CPU? _cpu;
    private BIOS? _bios;
    private CPUCooler? _cpuCooler;
    private XMP? _xmp;
    private Videocard? _videocard;
    private ComputerCase? _computerCase;
    private Components.PowerSupply.PowerSupply? _powerSupply;
    private WiFi? _wifi;

    public ComputerBuilder()
    {
        _ram = new Collection<Components.RAM.RAM>();
        _ssd = new Collection<Components.SSD.SSD>();
        _hdd = new Collection<HDD>();
    }

    public ComputerBuilder WithMotherboard(Motherboard? motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ComputerBuilder WithCpu(CPU? cpu)
    {
        _cpu = cpu;
        return this;
    }

    public ComputerBuilder WithBios(BIOS? bios)
    {
        _bios = bios;
        return this;
    }

    public ComputerBuilder WithCpuCooler(CPUCooler? cooler)
    {
        _cpuCooler = cooler;
        return this;
    }

    public ComputerBuilder WithXmp(XMP? xmp)
    {
        _xmp = xmp;
        return this;
    }

    public ComputerBuilder WithVideocard(Videocard videocard)
    {
        _videocard = videocard;
        return this;
    }

    public ComputerBuilder WithComputerCase(ComputerCase? computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public ComputerBuilder WithPowerSupply(PowerSupply? supply)
    {
        _powerSupply = supply;
        return this;
    }

    public ComputerBuilder WithWiFi(WiFi wifi)
    {
        _wifi = wifi;
        return this;
    }

    public ComputerBuilder AddRam(RAM? ram)
    {
        if (ram != null) _ram?.Add(ram);
        return this;
    }

    public ComputerBuilder AddSsd(SSD? ssd)
    {
        if (ssd != null) _ssd?.Add(ssd);
        return this;
    }

    public ComputerBuilder AddHdd(HDD hdd)
    {
        _hdd?.Add(hdd);
        return this;
    }

    public Computer Build()
    {
        return new Computer(
            _motherboard ?? throw new ArgumentNullException(),
            _cpu ?? throw new ArgumentNullException(),
            _bios ?? throw new ArgumentNullException(),
            _cpuCooler ?? throw new ArgumentNullException(),
            _ram ?? throw new ArgumentNullException(),
            _xmp ?? throw new ArgumentNullException(),
            _videocard,
            _ssd,
            _hdd,
            _computerCase ?? throw new ArgumentNullException(),
            _powerSupply ?? throw new ArgumentNullException(),
            _wifi);
    }
}