using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Mocks;

public class DisplayDriverMock : IDisplayDriver
{
    public string Text { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;

    public void Clear()
    {
        Text = string.Empty;
    }

    public void ChangeTextColor(string color)
    {
        Color = color;
    }

    public void ReceiveMessage(string text)
    {
        Text = text;
    }
}