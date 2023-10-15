namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class PhotonDeflector
{
    private const int DefaultHp = 3;

    public PhotonDeflector()
    {
        Hp = DefaultHp;
    }

    public int Hp { get; private set; }

    public void TakeDamage()
    {
        Hp--;
    }
}