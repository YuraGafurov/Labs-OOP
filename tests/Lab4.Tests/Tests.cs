using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Disconnect;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeList;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Fact]
    public void CheckConnectHandler()
    {
        var parser = new Parser();
        ICommand? command = parser.Parse("connect C:\\Users\\79630 -m local");
        Assert.Equal(typeof(Connect), command?.GetType());
    }

    [Fact]
    public void CheckDisconnectHandler()
    {
        var parser = new Parser();
        ICommand? command = parser.Parse("disconnect");
        Assert.Equal(typeof(Disconnect), command?.GetType());
    }

    [Fact]
    public void CheckTreeListHandler()
    {
        var parser = new Parser();
        ICommand? command = parser.Parse("tree list -d 2");
        Assert.Equal(typeof(TreeList), command?.GetType());
    }
}