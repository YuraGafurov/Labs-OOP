using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipArmor;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Avgur : BaseShip
{
    public Avgur(bool isPhotonDeflector)
        : base(new ImpulseEngineE(), new JumpEngineAlpha(), new ShipArmor(TypesOfArmor.ArmorClass3), new Deflector(TypesOfDeflectors.DeflectorClass3, isPhotonDeflector))
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