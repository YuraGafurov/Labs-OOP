namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplay
{
    public void PrintTextWithColor(string color);
    public void ReceiveMessage(string message);
}