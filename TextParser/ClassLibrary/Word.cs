using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using InterfaceLibrary;

namespace ClassLibrary
{
    public class Word : IWord, IPartOfClause
    {
        List<Letter> _word = new List<Letter>();

        public Word(List<Letter> characters)
        {
            _word.AddRange(characters);
        }

        public int GetLenght()
        {
            return _word.Count;
        }

        public IEnumerable<Letter> GetCharacters()
        {
            return _word;
        }

        public bool IsWord()
        {
            return true;
        }

        public override string ToString()
        {
            string s = "";
            foreach (Letter item in _word)
            {
                s = s + item.ToString();
            }
            return s;
        }
    }
}
