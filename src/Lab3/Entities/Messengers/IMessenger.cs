namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public interface IMessenger
{
    public void ReceiveMessage(string message);
    public void DisplayMessages();
    public string GetLast();
}