using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class UserGroupAddressee : IAddressee
{
    private readonly ICollection<IAddressee> _addressees = new List<IAddressee>();

    public void AddAddressee(IAddressee addressee)
    {
        _addressees.Add(addressee);
    }

    public void RemoveAddressee(IAddressee addressee)
    {
        _addressees.Remove(addressee);
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}