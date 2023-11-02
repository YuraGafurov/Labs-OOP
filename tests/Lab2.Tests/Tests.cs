using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPUCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    private ComponentsRepository repository = ComponentsRepository.Instance;

    public Tests()
    {
        CPU cpu1 = new CPUBuilder().WithName("Intel Core I5")
            .WithCoreFrequency(40)
            .WithCoreCount(3)
            .WithSocket(Sockets.LGA1700)
            .WithVideocore()
            .WithTDP(10)
            .WithPowerConsumption(10)
            .AddMemoryFrequency(20)
            .Build();
        CPU cpu2 = new CPUBuilder().WithName("Intel Core I4")
            .WithCoreFrequency(40)
            .WithCoreCount(3)
            .WithSocket(Sockets.LGA1700)
            .WithVideocore()
            .WithTDP(10)
            .WithPowerConsumption(100)
            .AddMemoryFrequency(20)
            .Build();
        CPU cpu3 = new CPUBuilder().WithName("Intel Core I3")
            .WithCoreFrequency(40)
            .WithCoreCount(3)
            .WithSocket(Sockets.LGA1700)
            .WithVideocore()
            .WithTDP(500)
            .WithPowerConsumption(10)
            .AddMemoryFrequency(20)
            .Build();
        XMP xmp = new XMPBuilder().WithName("XMP")
            .WithTiming("6-6-8-8")
            .WithFrequency(40)
            .WithVoltage(60)
            .Build();
        Chipset chipset = new ChipsetBuilder().WithName("Intel H610")
            .WithXMP()
            .AddMemoryFrequency(40)
            .Build();
        BIOS bios = new BIOSBuilder().WithName("Bios2.21g")
            .WithType(BIOSType.Intel)
            .WithVersion(2)
            .AddProcessor(cpu1)
            .AddProcessor(cpu2)
            .AddProcessor(cpu3)
            .Build();
        Motherboard motherboard = new MotherboardBuilder().WithName("Gigabyte H610I")
            .WithSocket(Sockets.LGA1700)
            .WithPciCount(4)
            .WithSataCount(4)
            .WithChipset(chipset)
            .WithDDRStandart(DDRStandarts.DDR4)
            .WithRAMSlots(4)
            .WithFormFactor(MotherboardFormFactors.ATX)
            .WithBIOS(bios)
            .Build();
        Motherboard motherboard2 = new MotherboardBuilder().WithName("Gigabyte H610")
            .WithSocket(Sockets.AM4)
            .WithPciCount(4)
            .WithSataCount(4)
            .WithChipset(chipset)
            .WithDDRStandart(DDRStandarts.DDR4)
            .WithRAMSlots(4)
            .WithFormFactor(MotherboardFormFactors.ATX)
            .WithBIOS(bios)
            .Build();
        CPUCooler cooler = new CPUCoolerBuilder().WithName("Cooler")
            .WithSize(new Size(5, 6, 5))
            .WithTDP(100)
            .AddSocket(Sockets.LGA1700)
            .Build();
        ComputerCase computerCase = new ComputerCaseBuilder().WithName("Case")
            .WithSize(CaseSizes.FullTower)
            .WithMaximumVideocardLength(30)
            .WithMaximumVideocardWidth(30)
            .AddMotherboardFormFactor(MotherboardFormFactors.ATX)
            .Build();
        var powerSupply = new PowerSupply("Supply", 100);
        RAM ram = new RAMBuilder().WithName("Ram")
            .WithAvailableMemorySize(1000)
            .WithFormFactor(RAMFormFactors.DIMM)
            .WithDDRStandart(DDRStandarts.DDR4)
            .WithPowerConsumption(5)
            .AddJedecVoltagePair(new JedecVoltagePairs(5, 5))
            .AddXMPProfile(xmp)
            .Build();
        SSD ssd = new SSDBuilder().WithName("SSD")
            .WithConnection("cool")
            .WithCapacity(10000)
            .WithMaximumOperatingSpeed(1000)
            .WithPowerConsumption(3)
            .Build();
        repository.AddCpu(cpu1);
        repository.AddCpu(cpu2);
        repository.AddCpu(cpu3);
        repository.AddXmp(xmp);
        repository.AddChipset(chipset);
        repository.AddBios(bios);
        repository.AddMotherboard(motherboard);
        repository.AddMotherboard(motherboard2);
        repository.AddCpuCooler(cooler);
        repository.AddComputerCase(computerCase);
        repository.AddPowerSupply(powerSupply);
        repository.AddRam(ram);
        repository.AddSsd(ssd);
    }

    [Fact]
    public void WorkingComputerAssembly()
    {
        Computer.Entities.Computer computer = new ComputerBuilder()
            .WithMotherboard(repository.GetMotherboard("Gigabyte H610I"))
            .WithCpu(repository.GetCpu("Intel Core I5"))
            .WithBios(repository.GetBios("Bios2.21g"))
            .WithCpuCooler(repository.GetCpuCooler("Cooler"))
            .WithXmp(repository.GetXmp("XMP"))
            .WithComputerCase(repository.GetComputerCase("Case"))
            .WithPowerSupply(repository.GetPowerSupply("Supply"))
            .AddRam(repository.GetRam("Ram"))
            .AddMemory(repository.GetSsd("SSD") ?? throw new InvalidOperationException())
            .Build();
        Result result = Configurator.Validate(computer);
        Assert.Equal(result, new Result(true, "All good"));
    }

    [Fact]
    public void WorkingWithConsumptionWarning()
    {
        Computer.Entities.Computer computer = new ComputerBuilder()
            .WithMotherboard(repository.GetMotherboard("Gigabyte H610I"))
            .WithCpu(repository.GetCpu("Intel Core I4"))
            .WithBios(repository.GetBios("Bios2.21g"))
            .WithCpuCooler(repository.GetCpuCooler("Cooler"))
            .WithXmp(repository.GetXmp("XMP"))
            .WithComputerCase(repository.GetComputerCase("Case"))
            .WithPowerSupply(repository.GetPowerSupply("Supply"))
            .AddRam(repository.GetRam("Ram"))
            .AddMemory(repository.GetSsd("SSD") ?? throw new InvalidOperationException())
            .Build();
        Result result = Configurator.Validate(computer);
        Assert.Equal(result, new Result(true, "The system power consumption is slightly higher than the maximum, the assembly is not recommended for use"));
    }

    [Fact]
    public void WorkingWithTDPWarning()
    {
        Computer.Entities.Computer computer = new ComputerBuilder()
            .WithMotherboard(repository.GetMotherboard("Gigabyte H610I"))
            .WithCpu(repository.GetCpu("Intel Core I3"))
            .WithBios(repository.GetBios("Bios2.21g"))
            .WithCpuCooler(repository.GetCpuCooler("Cooler"))
            .WithXmp(repository.GetXmp("XMP"))
            .WithComputerCase(repository.GetComputerCase("Case"))
            .WithPowerSupply(repository.GetPowerSupply("Supply"))
            .AddRam(repository.GetRam("Ram"))
            .AddMemory(repository.GetSsd("SSD") ?? throw new InvalidOperationException())
            .Build();
        Result result = Configurator.Validate(computer);
        Assert.Equal(result, new Result(true, "The system TDP is slightly higher than the maximum, the assembly is not recommended for use"));
    }

    [Fact]
    public void NotWorking()
    {
        Computer.Entities.Computer computer = new ComputerBuilder()
            .WithMotherboard(repository.GetMotherboard("Gigabyte H610"))
            .WithCpu(repository.GetCpu("Intel Core I3"))
            .WithBios(repository.GetBios("Bios2.21g"))
            .WithCpuCooler(repository.GetCpuCooler("Cooler"))
            .WithXmp(repository.GetXmp("XMP"))
            .WithComputerCase(repository.GetComputerCase("Case"))
            .WithPowerSupply(repository.GetPowerSupply("Supply"))
            .AddRam(repository.GetRam("Ram"))
            .AddMemory(repository.GetSsd("SSD") ?? throw new InvalidOperationException())
            .Build();
        Result result = Configurator.Validate(computer);
        Assert.Equal(result, new Result(false, "Invalid Socket"));
    }
}