using System;
using System.Collections.Generic;
using System.Text;
using InterfaceLibrary;

namespace ClassLibrary
{
    public class PunctuationMark : Character, IPunctuationMark, IPartOfClause
    {
        bool _question = false;
        public PunctuationMark(string value) : base(value)
        {
            if (_value == "?")
            {
                _question = true;
            }
        }

        public void AddValue(string value)
        {
            _value = _value + value;
        }

        public int GetLenght()
        {
            return _value.Length;
        }

        public bool GetQuestion()
        {
            return _question;
        }

        public bool IsWord()
        {
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
