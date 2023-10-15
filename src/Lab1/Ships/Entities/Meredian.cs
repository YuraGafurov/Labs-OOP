using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipArmor;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Meredian : BaseShip
{
    public Meredian(bool isPhotonDeflector)
        : base(new ImpulseEngineE(), null, new ShipArmor(TypesOfArmor.ArmorClass2), new Deflector(TypesOfDeflectors.DeflectorClass2, isPhotonDeflector))
    {
        IsAntiNitrino = true;
    }

    public override Results Move(Collection<BaseSpace> route)
    {
        foreach (BaseSpace space in route)
        {
            switch (space)
            {
                case NormalSpace:
                    FuelUsed += ImpulseEngine.FuelCost(space.Length);
                    break;
                case HighDensitySpaceNebulae:
                    return Results.SpaceShipLost;
                case NitrinoParticleSpaceNebulae:
                    FuelUsed += ImpulseEngine.FuelCost(space.Length);
                    break;
            }

            if (TakeDamage(space.Obstacles) != Results.Success)
            {
                return TakeDamage(space.Obstacles);
            }
        }

        return Results.Success;
    }
}