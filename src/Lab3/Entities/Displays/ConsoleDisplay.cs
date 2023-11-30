using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class ConsoleDisplay : IDisplay
{
    private IDisplayDriver _driver;

    public ConsoleDisplay(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void ReceiveMessage(string message)
    {
        _driver.ReceiveMessage(message);
    }

    public void PrintTextWithColor(string color)
    {
        _driver.ChangeTextColor(color);
        Console.WriteLine(_driver.Text);
        _driver.Clear();
    }
}