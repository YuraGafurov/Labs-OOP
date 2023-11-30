namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplayDriver
{
    public string Text { get; set; }
    public string Color { get; set; }

    public void Clear();
    public void ChangeTextColor(string color);
    public void ReceiveMessage(string text);
}