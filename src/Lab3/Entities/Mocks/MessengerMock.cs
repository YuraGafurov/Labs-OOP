using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Mocks;

public class MessengerMock : IMessenger
{
    private readonly IList<string> _messages = new List<string>();

    public void ReceiveMessage(string message)
    {
        _messages.Add(message);
    }

    public void DisplayMessages()
    {
        foreach (string message in _messages)
        {
            Console.WriteLine(message);
        }
    }

    public string GetLast()
    {
        return _messages[0];
    }
}