using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;

public class Vaklas : BaseShip
{
    public Vaklas(bool isPhotonDeflector)
        : base(new ImpulseEngineE(), new JumpEngineGamma(), new ShipArmor.ShipArmor(TypesOfArmor.ArmorClass2), new Deflector(TypesOfDeflectors.DeflectorClass1, isPhotonDeflector))
    {
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
                    if (JumpEngine?.RangeOfTravel >= space.Length)
                    {
                        FuelUsed += JumpEngine.FuelCost(space.Length);
                    }
                    else
                    {
                        return Results.SpaceShipLost;
                    }

                    break;
                case NitrinoParticleSpaceNebulae:
                    FuelUsed += ImpulseEngine.FuelCost(space.Length);
                    break;
            }

            Results result = TakeDamage(space.Obstacles);
            if (result != Results.Success)
            {
                return result;
            }
        }

        return Results.Success;
    }
}