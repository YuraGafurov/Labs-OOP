using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Motherboard;

public class MotherboardBuilder
{
    private string? _name;
    private Sockets? _socket;
    private int? _pciECount;
    private int? _sataCount;
    private Chipset.Chipset? _chipset;
    private DDRStandarts? _ddrStandart;
    private int? _ramSlots;
    private MotherboardFormFactors? _formFactor;
    private BIOS.BIOS? _bios;

    public MotherboardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public MotherboardBuilder WithSocket(Sockets socket)
    {
        _socket = socket;
        return this;
    }

    public MotherboardBuilder WithPciCount(int count)
    {
        _pciECount = count;
        return this;
    }

    public MotherboardBuilder WithSataCount(int count)
    {
        _sataCount = count;
        return this;
    }

    public MotherboardBuilder WithChipset(Chipset.Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder WithDDRStandart(DDRStandarts standart)
    {
        _ddrStandart = standart;
        return this;
    }

    public MotherboardBuilder WithRAMSlots(int slots)
    {
        _ramSlots = slots;
        return this;
    }

    public MotherboardBuilder WithFormFactor(MotherboardFormFactors formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder WithBIOS(BIOS.BIOS bios)
    {
        _bios = bios;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _name ?? throw new ArgumentNullException(),
            _socket ?? throw new ArgumentNullException(),
            _pciECount ?? throw new ArgumentNullException(),
            _sataCount ?? throw new ArgumentNullException(),
            _chipset ?? throw new ArgumentNullException(),
            _ddrStandart ?? throw new ArgumentNullException(),
            _ramSlots ?? throw new ArgumentNullException(),
            _formFactor ?? throw new ArgumentNullException(),
            _bios ?? throw new ArgumentNullException());
    }
}