using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Adapters;

public class MessengerAdapter : IAddressee
{
    private IMessenger _messenger;

    public MessengerAdapter(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        string strMessage = $"{message.Title}\n{message.Body}";
        _messenger.ReceiveMessage(strMessage);
    }
}