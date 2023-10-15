using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipArmor;

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