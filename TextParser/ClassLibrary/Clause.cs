using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using InterfaceLibrary;

namespace ClassLibrary
{
    public class Clause : IClause
    {
        List<IPartOfClause> _partOfClause = new List<IPartOfClause>();

        public Clause(List<IPartOfClause> partOfClaus)
        {
            _partOfClause.AddRange(partOfClaus);
        }
        
        public bool getQuestion()
        {

            string s = _partOfClause[_partOfClause.Count - 1].ToString();

            if (s == "?")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (IPartOfClause item in _partOfClause)
            {
                if (item.IsWord() == true)
                {
                    Word item1 = (Word)item;
                    s = s + " " + item1.ToString();
                }
                else
                {
                    PunctuationMark item1 = (PunctuationMark)item;
                    s = s + item1.ToString();
                }
            }
            return s;
        }

        public int GetWordCount()
        {
            int i = 0;
            foreach (IPartOfClause item in _partOfClause)
            {
                if (item.IsWord())
                {
                    i++;

                }
            }
            return i;
        }

        public IEnumerator<IPartOfClause> GetEnumerator()
        {
            return _partOfClause.GetEnumerator();
        }
    }
}
