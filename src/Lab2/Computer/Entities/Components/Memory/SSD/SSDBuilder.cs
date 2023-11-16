using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.SSD;

public class SSDBuilder
{
    private string? _name;
    private string? _connection;
    private int? _capacity;
    private int? _operatingSpeed;
    private int? _powerConsumption;

    public SSDBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public SSDBuilder WithConnection(string connection)
    {
        _connection = connection;
        return this;
    }

    public SSDBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public SSDBuilder WithMaximumOperatingSpeed(int speed)
    {
        _operatingSpeed = speed;
        return this;
    }

    public SSDBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public SSD Build()
    {
        return new SSD(
            _name ?? throw new ArgumentNullException(),
            _connection ?? throw new ArgumentNullException(),
            _capacity ?? throw new ArgumentNullException(),
            _operatingSpeed ?? throw new ArgumentNullException(),
            _powerConsumption ?? throw new ArgumentNullException());
    }
}