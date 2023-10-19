namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Deflectors;

public class PhotonDeflector
{
    private const int DefaultHp = 3;

    public int Hp { get; private set; } = DefaultHp;

    public void TakeDamage()
    {
        Hp--;
    }
}