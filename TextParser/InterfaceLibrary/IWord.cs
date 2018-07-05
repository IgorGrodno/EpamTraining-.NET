using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLibrary
{
    public interface IWord : IPartOfClause
    {
       IEnumerable<ClassLibrary.Letter> GetCharacters();
    }
}
