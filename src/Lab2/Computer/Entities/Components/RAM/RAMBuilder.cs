using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.RAM;

public class RAMBuilder
{
    private readonly ICollection<JedecVoltagePairs>? _supportedJedecAndVoltagePairs;
    private readonly ICollection<XMP.XMP>? _availableXMPProfiles;
    private string? _name;
    private int? _availableMemorySize;
    private RAMFormFactors? _formFactor;
    private DDRStandarts? _ddrStandart;
    private int? _powerConsumption;

    public RAMBuilder()
    {
        _supportedJedecAndVoltagePairs = new List<JedecVoltagePairs>();
        _availableXMPProfiles = new List<XMP.XMP>();
    }

    public RAMBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public RAMBuilder WithAvailableMemorySize(int size)
    {
        _availableMemorySize = size;
        return this;
    }

    public RAMBuilder WithFormFactor(RAMFormFactors formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RAMBuilder WithDDRStandart(DDRStandarts standart)
    {
        _ddrStandart = standart;
        return this;
    }

    public RAMBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public RAMBuilder AddJedecVoltagePair(JedecVoltagePairs pair)
    {
        _supportedJedecAndVoltagePairs?.Add(pair);
        return this;
    }

    public RAMBuilder AddXMPProfile(XMP.XMP profile)
    {
        _availableXMPProfiles?.Add(profile);
        return this;
    }

    public RAM Build()
    {
        return new RAM(
            _name ?? throw new ArgumentNullException(),
            _availableMemorySize ?? throw new ArgumentNullException(),
            _supportedJedecAndVoltagePairs ?? throw new ArgumentNullException(),
            _availableXMPProfiles ?? throw new ArgumentNullException(),
            _formFactor ?? throw new ArgumentNullException(),
            _ddrStandart ?? throw new ArgumentNullException(),
            _powerConsumption ?? throw new ArgumentNullException());
    }
}