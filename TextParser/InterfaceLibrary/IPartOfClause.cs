using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLibrary
{
    public interface IPartOfClause
    {
        bool IsWord();
        string ToString();
        int GetLenght();
    }
}