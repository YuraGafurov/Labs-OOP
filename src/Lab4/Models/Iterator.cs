using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class Iterator
{
    private IList<string> _request;
    private int _curIndex;

    public Iterator(string request)
    {
        _request = request.Split(' ');
        _curIndex = 0;
    }

    public string Current()
    {
        return _request[_curIndex];
    }

    public bool MoveNext()
    {
        _curIndex++;
        if (_curIndex < _request.Count)
        {
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _curIndex = 0;
    }
}