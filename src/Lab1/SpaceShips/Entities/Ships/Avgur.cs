using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;

public class Avgur : BaseShip
{
    public Avgur(bool isPhotonDeflector)
        : base(new ImpulseEngineE(), new JumpEngineAlpha(), new ShipArmor.ShipArmor(TypesOfArmor.ArmorClass3), new Deflector(TypesOfDeflectors.DeflectorClass3, isPhotonDeflector))
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

            if (TakeDamage(space.Obstacles) != Results.Success)
            {
                return TakeDamage(space.Obstacles);
            }
        }

        return Results.Success;
    }
}