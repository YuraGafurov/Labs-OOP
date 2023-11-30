using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class Message : IEquatable<Message>
{
    public Message(string title, string body, ImportanceLevel importanceLevel)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public string Title { get; set; }
    public string Body { get; set; }
    public ImportanceLevel ImportanceLevel { get; set; }

    public bool Equals(Message? other)
    {
        if (other == null)
            return false;

        return Title == other.Title &&
               Body == other.Body &&
               ImportanceLevel == other.ImportanceLevel;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return Equals(obj as Message);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Body, ImportanceLevel);
    }
}