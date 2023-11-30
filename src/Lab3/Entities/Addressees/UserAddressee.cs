using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class UserAddressee : IAddressee
{
    public Dictionary<Message, bool> Messages { get; } = new();

    public void ReceiveMessage(Message message)
    {
        Messages.Add(message, false);
    }

    public void ReadMessage(Message message)
    {
        if (Messages[message])
        {
            throw new InvalidDataException();
        }

        Messages[message] = true;
    }
}