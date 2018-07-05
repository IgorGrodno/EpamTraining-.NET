using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLibrary
{
    public interface IClause
    {
        bool getQuestion();
        IEnumerator<IPartOfClause> GetEnumerator();
    }
}
