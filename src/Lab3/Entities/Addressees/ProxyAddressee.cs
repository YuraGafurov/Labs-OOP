using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class ProxyAddressee : IAddressee
{
    private IAddressee _addressee;

    public ProxyAddressee(IAddressee addressee, ImportanceLevel requiredImportanceLevel)
    {
        _addressee = addressee;
        RequiredImportanceLevel = requiredImportanceLevel;
    }

    public ImportanceLevel RequiredImportanceLevel { get; set; }

    public void ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel >= RequiredImportanceLevel)
        {
            _addressee.ReceiveMessage(message);
        }
    }
}