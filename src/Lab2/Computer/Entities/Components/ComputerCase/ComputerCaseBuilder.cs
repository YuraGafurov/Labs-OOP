using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.ComputerCase;

public class ComputerCaseBuilder
{
    private readonly ICollection<MotherboardFormFactors>? _supportedMotherboardFormFactors;
    private string? _name;
    private CaseSizes? _size;
    private int? _maximumLengthOfVideocard;
    private int? _maximumWidthOfVideocard;

    public ComputerCaseBuilder()
    {
        _supportedMotherboardFormFactors = new List<MotherboardFormFactors>();
    }

    public ComputerCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ComputerCaseBuilder WithSize(CaseSizes size)
    {
        _size = size;
        return this;
    }

    public ComputerCaseBuilder WithMaximumVideocardLength(int length)
    {
        _maximumLengthOfVideocard = length;
        return this;
    }

    public ComputerCaseBuilder WithMaximumVideocardWidth(int width)
    {
        _maximumWidthOfVideocard = width;
        return this;
    }

    public ComputerCaseBuilder AddMotherboardFormFactor(MotherboardFormFactors formFactor)
    {
        _supportedMotherboardFormFactors?.Add(formFactor);
        return this;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(
            _name ?? throw new ArgumentNullException(),
            _size ?? throw new ArgumentNullException(),
            _maximumLengthOfVideocard ?? throw new ArgumentNullException(),
            _maximumWidthOfVideocard ?? throw new ArgumentNullException(),
            _supportedMotherboardFormFactors ?? throw new ArgumentNullException());
    }
}