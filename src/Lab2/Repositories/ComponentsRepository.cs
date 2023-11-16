using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Chipset;
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

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class ComponentsRepository
{
    private static ComponentsRepository? _instance;
    private Collection<BIOS> _biosRepository = new Collection<BIOS>();
    private Collection<Chipset> _chipsetRepository = new Collection<Chipset>();
    private Collection<ComputerCase> _computerCasetRepository = new Collection<ComputerCase>();
    private Collection<CPUCooler> _cpuCooperRepository = new Collection<CPUCooler>();
    private Collection<CPU> _cpuRepository = new Collection<CPU>();
    private Collection<HDD> _hddRepository = new Collection<HDD>();
    private Collection<Motherboard> _motherboardRepository = new Collection<Motherboard>();
    private Collection<PowerSupply> _powerSupplyRepository = new Collection<PowerSupply>();
    private Collection<RAM> _ramRepository = new Collection<RAM>();
    private Collection<SSD> _ssdRepository = new Collection<SSD>();
    private Collection<Videocard> _videocardRepository = new Collection<Videocard>();
    private Collection<WiFi> _wifiRepository = new Collection<WiFi>();
    private Collection<XMP> _xmpRepository = new Collection<XMP>();
    private ComponentsRepository() { }

    public static ComponentsRepository Instance
    {
        get
        {
            if (_instance is not null)
            {
                return _instance;
            }

            return _instance = new ComponentsRepository();
        }
    }

    public BIOS? GetBios(string name)
    {
        return _biosRepository.FirstOrDefault(p => p.Name == name);
    }

    public Chipset? GetChipset(string name)
    {
        return _chipsetRepository.FirstOrDefault(p => p.Name == name);
    }

    public ComputerCase? GetComputerCase(string name)
    {
        return _computerCasetRepository.FirstOrDefault(p => p.Name == name);
    }

    public CPUCooler? GetCpuCooler(string name)
    {
        return _cpuCooperRepository.FirstOrDefault(p => p.Name == name);
    }

    public CPU? GetCpu(string name)
    {
        return _cpuRepository.FirstOrDefault(p => p.Name == name);
    }

    public HDD? GetHdd(string name)
    {
        return _hddRepository.FirstOrDefault(p => p.Name == name);
    }

    public Motherboard? GetMotherboard(string name)
    {
        return _motherboardRepository.FirstOrDefault(p => p.Name == name);
    }

    public PowerSupply? GetPowerSupply(string name)
    {
        return _powerSupplyRepository.FirstOrDefault(p => p.Name == name);
    }

    public RAM? GetRam(string name)
    {
        return _ramRepository.FirstOrDefault(p => p.Name == name);
    }

    public SSD? GetSsd(string name)
    {
        return _ssdRepository.FirstOrDefault(p => p.Name == name);
    }

    public Videocard? GetVideocard(string name)
    {
        return _videocardRepository.FirstOrDefault(p => p.Name == name);
    }

    public WiFi? GetWiFi(string name)
    {
        return _wifiRepository.FirstOrDefault(p => p.Name == name);
    }

    public XMP? GetXmp(string name)
    {
        return _xmpRepository.FirstOrDefault(p => p.Name == name);
    }

    public void AddBios(BIOS bios)
    {
        _biosRepository.Add(bios);
    }

    public void AddChipset(Chipset chipset)
    {
        _chipsetRepository.Add(chipset);
    }

    public void AddComputerCase(ComputerCase computerCase)
    {
        _computerCasetRepository.Add(computerCase);
    }

    public void AddCpuCooler(CPUCooler cpuCooler)
    {
        _cpuCooperRepository.Add(cpuCooler);
    }

    public void AddCpu(CPU cpu)
    {
        _cpuRepository.Add(cpu);
    }

    public void AddHdd(HDD hdd)
    {
        _hddRepository.Add(hdd);
    }

    public void AddMotherboard(Motherboard motherboard)
    {
        _motherboardRepository.Add(motherboard);
    }

    public void AddPowerSupply(PowerSupply powerSupply)
    {
        _powerSupplyRepository.Add(powerSupply);
    }

    public void AddRam(RAM ram)
    {
        _ramRepository.Add(ram);
    }

    public void AddSsd(SSD ssd)
    {
        _ssdRepository.Add(ssd);
    }

    public void AddVideocard(Videocard videocard)
    {
        _videocardRepository.Add(videocard);
    }

    public void AddXmp(XMP xmp)
    {
        _xmpRepository.Add(xmp);
    }

    public void DeleteBios(string name)
    {
        BIOS bios = _biosRepository.FirstOrDefault(p => p.Name == name) ?? throw new InvalidOperationException();
        _biosRepository.Remove(bios);
    }

    public void DeleteChipset(string name)
    {
        Chipset chipset = _chipsetRepository.FirstOrDefault(p => p.Name == name) ??
                          throw new InvalidOperationException();
        _chipsetRepository.Remove(chipset);
    }

    public void DeleteComputerCase(string name)
    {
        ComputerCase computerCase = _computerCasetRepository.FirstOrDefault(p => p.Name == name) ??
                                    throw new InvalidOperationException();
        _computerCasetRepository.Remove(computerCase);
    }

    public void DeleteCpuCooler(string name)
    {
        CPUCooler cpuCooler = _cpuCooperRepository.FirstOrDefault(p => p.Name == name) ??
                              throw new InvalidOperationException();
        _cpuCooperRepository.Remove(cpuCooler);
    }

    public void DeleteCpu(string name)
    {
        CPU cpu = _cpuRepository.FirstOrDefault(p => p.Name == name) ?? throw new InvalidOperationException();
        _cpuRepository.Remove(cpu);
    }

    public void DeleteHdd(string name)
    {
        HDD hdd = _hddRepository.FirstOrDefault(p => p.Name == name) ?? throw new InvalidOperationException();
        _hddRepository.Remove(hdd);
    }

    public void DeleteMotherboard(string name)
    {
        Motherboard motherboard = _motherboardRepository.FirstOrDefault(p => p.Name == name) ??
                                  throw new InvalidOperationException();
        _motherboardRepository.Remove(motherboard);
    }

    public void DeletePowerSupply(string name)
    {
        PowerSupply powerSupply = _powerSupplyRepository.FirstOrDefault(p => p.Name == name) ??
                                                                           throw new InvalidOperationException();
        _powerSupplyRepository.Remove(powerSupply);
    }

    public void DeleteRam(string name)
    {
        RAM ram = _ramRepository.FirstOrDefault(p => p.Name == name) ?? throw new InvalidOperationException();
        _ramRepository.Remove(ram);
    }

    public void DeleteSsd(string name)
    {
        SSD ssd = _ssdRepository.FirstOrDefault(p => p.Name == name) ?? throw new InvalidOperationException();
        _ssdRepository.Remove(ssd);
    }

    public void DeleteVideocard(string name)
    {
        Videocard videocard = _videocardRepository.FirstOrDefault(p => p.Name == name) ??
                              throw new InvalidOperationException();
        _videocardRepository.Remove(videocard);
    }

    public void AddWiFi(WiFi wifi)
    {
        _wifiRepository.Add(wifi);
    }

    public void DeleteWiFi(string name)
    {
        WiFi wifi = _wifiRepository.FirstOrDefault(p => p.Name == name) ?? throw new InvalidOperationException();
        _wifiRepository.Remove(wifi);
    }

    public void DeleteXmp(string name)
    {
        XMP xmp = _xmpRepository.FirstOrDefault(p => p.Name == name) ?? throw new InvalidOperationException();
        _xmpRepository.Remove(xmp);
    }
}