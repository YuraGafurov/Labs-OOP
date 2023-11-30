using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class UserGroupAddressee : IAddressee
{
    private readonly ICollection<UserAddressee> _users = new List<UserAddressee>();

    public void AddUser(UserAddressee user)
    {
        _users.Add(user);
    }

    public void RemoveUser(UserAddressee user)
    {
        _users.Remove(user);
    }

    public void ReceiveMessage(Message message)
    {
        foreach (UserAddressee user in _users)
        {
            user.ReceiveMessage(message);
        }
    }
}