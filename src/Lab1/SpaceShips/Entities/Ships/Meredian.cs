using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;

public class Meredian : BaseShip
{
    public Meredian(bool isPhotonDeflector)
        : base(new ImpulseEngineE(), null, new ShipArmor.ShipArmor(TypesOfArmor.ArmorClass2), new Deflector(TypesOfDeflectors.DeflectorClass2, isPhotonDeflector))
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