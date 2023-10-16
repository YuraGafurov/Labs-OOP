using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;

public abstract class BaseShip
{
    protected BaseShip(BaseImpulseEngine impulseEngine, BaseJumpEngine? jumpEngine, ShipArmor.ShipArmor armor, Deflector? deflector)
    {
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        Armor = armor;
        Deflector = deflector;
    }

    public BaseImpulseEngine ImpulseEngine { get; }
    public BaseJumpEngine? JumpEngine { get; }
    public ShipArmor.ShipArmor Armor { get; }
    public Deflector? Deflector { get; private set; }
    public bool? IsAntiNitrino { get; protected set; }
    public int FuelUsed { get; set; }

    public abstract Results Move(Collection<BaseSpace> route);

    public Results TakeDamage(Collection<BaseObstacle> obstacles)
    {
        foreach (BaseObstacle obstacle in obstacles)
        {
            if (obstacle.EnergyDamage.HasValue)
            {
                if (Deflector is not null && Deflector.PhotonDeflector is not null)
                {
                    Deflector.TakeDamage(obstacle);
                }
                else
                {
                    return Results.CrewDeath;
                }
            }
            else
            {
                if (IsAntiNitrino.HasValue && obstacle is CosmoWhale)
                {
                    continue;
                }

                if (Deflector is not null && Deflector.Hp > obstacle.PhysDamage)
                {
                    Deflector.TakeDamage(obstacle);
                }
                else if (Deflector is not null && Deflector.Hp <= obstacle.PhysDamage)
                {
                    if (Deflector.Hp < obstacle.PhysDamage)
                    {
                        obstacle.PhysDamage -= Deflector.Hp;
                    }

                    Deflector = null;
                    if (Armor.Hp > obstacle.PhysDamage)
                    {
                        Armor.TakeDamage(obstacle);
                    }
                    else
                    {
                        return Results.SpaceShipDestroyed;
                    }
                }
            }
        }

        return Results.Success;
    }
}