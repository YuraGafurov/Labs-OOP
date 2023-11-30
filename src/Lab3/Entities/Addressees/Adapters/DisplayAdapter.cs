using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Adapters;

public class DisplayAdapter : IAddressee
{
    private IDisplay _display;

    public DisplayAdapter(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        string strMessage = $"{message.Title}\n{message.Body}";
        _display.ReceiveMessage(strMessage);
    }
}