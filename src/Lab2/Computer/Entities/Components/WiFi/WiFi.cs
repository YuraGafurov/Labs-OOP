using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.WiFi;

public class WiFi
{
    public WiFi(string name, WiFiStandarts wifiStandardVersion, bool bluetooth, int versionOfPci, int powerConsumption)
    {
        Name = name;
        WiFiStandardVersion = wifiStandardVersion;
        HasBluetoothModule = bluetooth;
        VersionOfPCI = versionOfPci;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public WiFiStandarts WiFiStandardVersion { get; set; }
    public bool HasBluetoothModule { get; }
    public int VersionOfPCI { get; set; }
    public int PowerConsumption { get; set; }

    public WiFiBuilder Direct(WiFiBuilder builder)
    {
        if (HasBluetoothModule)
        {
            builder.WithBluetooth();
        }

        builder.WithName(Name)
            .WithWiFiStandard(WiFiStandardVersion)
            .WithPCIVersion(VersionOfPCI)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}