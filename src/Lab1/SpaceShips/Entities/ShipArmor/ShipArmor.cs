using System.Runtime.CompilerServices;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.ShipArmor;

public class ShipArmor
{
    public ShipArmor(TypesOfArmor type)
    {
        switch (type)
        {
            case TypesOfArmor.ArmorClass1:
                Hp = 10;
                break;
            case TypesOfArmor.ArmorClass2:
                Hp = 50;
                break;
            case TypesOfArmor.ArmorClass3:
                Hp = 150;
                break;
            default:
                throw new SwitchExpressionException("Invalid type of armor");
        }
    }

    public int Hp { get; private set; }

    public void TakeDamage(BaseObstacle obstacle)
    {
        if (obstacle.PhysDamage.HasValue)
        {
            Hp -= obstacle.PhysDamage.Value;
        }
    }
}