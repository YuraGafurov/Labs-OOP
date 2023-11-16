using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.WiFi;

public class WiFiBuilder
{
    private string? _name;
    private WiFiStandarts? _wifiStandardVersion;
    private bool? _hasBluetoothModule;
    private int? _versionOfPCI;
    private int? _powerConsumption;

    public WiFiBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public WiFiBuilder WithWiFiStandard(WiFiStandarts standard)
    {
        _wifiStandardVersion = standard;
        return this;
    }

    public WiFiBuilder WithBluetooth()
    {
        _hasBluetoothModule = true;
        return this;
    }

    public WiFiBuilder WithPCIVersion(int version)
    {
        _versionOfPCI = version;
        return this;
    }

    public WiFiBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public WiFi Build()
    {
        return new WiFi(
            _name ?? throw new ArgumentNullException(),
            _wifiStandardVersion ?? throw new ArgumentNullException(),
            _hasBluetoothModule ?? throw new ArgumentNullException(),
            _versionOfPCI ?? throw new ArgumentNullException(),
            _powerConsumption ?? throw new ArgumentNullException());
    }
}