using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Mocks;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    [Fact]
    public void MessageToUserSendingMessageShouldBeUnread()
    {
        var user = new UserAddressee();
        var message = new Message("Hello", "Hello, world", ImportanceLevel.Common);
        var topic = new Topic("test", user);

        topic.SendMessage(message);

        Assert.False(user.Messages[message]);
    }

    [Fact]
    public void ReadUnreadMessageMessageShouldBeRead()
    {
        var user = new UserAddressee();
        var message = new Message("Hello", "Hello, world", ImportanceLevel.Common);
        var topic = new Topic("test", user);

        topic.SendMessage(message);
        user.ReadMessage(message);

        Assert.True(user.Messages[message]);
    }

    [Fact]
    public void ReadAlreadyReadMessageExceptionShouldBeReturned()
    {
        var user = new UserAddressee();
        var message = new Message("Hello", "Hello, world", ImportanceLevel.Common);
        var topic = new Topic("test", user);

        topic.SendMessage(message);
        user.ReadMessage(message);

        Exception? actual = null;
        try
        {
            user.ReadMessage(message);
        }
        catch (InvalidDataException e)
        {
            actual = e;
        }

        Assert.IsType<InvalidDataException>(actual);
    }

    [Fact]
    public void SendingMessageWithHighImportanceToAddresseeWithConfiguredFilterMessageShouldNotReach()
    {
        var displayDriverMock = new DisplayDriverMock();
        var display = new ConsoleDisplay(displayDriverMock);
        var displayAdapter = new DisplayAdapter(display);
        var addressee = new ProxyAddressee(displayAdapter, ImportanceLevel.Important);
        var message = new Message("Hello", "Hello, world", ImportanceLevel.Common);
        var topic = new Topic("test", addressee);

        topic.SendMessage(message);
        string actual = displayDriverMock.Text;

        Assert.Empty(actual);
    }

    [Fact]
    public void SendingMessageToAddresseeWithConfiguredLoggerLogShouldBeWritten()
    {
        var messenger = new Messenger();
        var messengerAdapter = new MessengerAdapter(messenger);
        var loggerMock = new LoggerMock();
        var loggerDecorator = new LoggerDecorator(messengerAdapter, loggerMock);
        var message = new Message("Hello", "Hello, world", ImportanceLevel.Common);
        var topic = new Topic("test", loggerDecorator);

        topic.SendMessage(message);
        string expected = $"{message.Title}\n{message.Body}";
        string actual = loggerMock.LoggedMessage;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SendingMessageToMessengerMessengerShouldReceiveMessage()
    {
        var messengerMock = new MessengerMock();
        var messengerAdapter = new MessengerAdapter(messengerMock);
        var message = new Message("Hello", "Hello, world", ImportanceLevel.Common);
        var topic = new Topic("test", messengerAdapter);
        topic.SendMessage(message);
        string expected = $"{message.Title}\n{message.Body}";
        string actual = messengerMock.GetLast();

        Assert.Equal(expected, actual);
    }
}