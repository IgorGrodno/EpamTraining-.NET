using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLibrary
{
    public interface IPunctuationMark : IPartOfClause
    {
        bool GetQuestion();
    }
}
