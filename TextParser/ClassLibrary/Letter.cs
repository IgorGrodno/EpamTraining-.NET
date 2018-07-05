using System;
using System.Collections.Generic;
using System.Text;
using InterfaceLibrary;

namespace ClassLibrary
{
    public class Letter : Character, ILetter
    {
        bool _vocalic = false;
        string vocalic = "eyuioaEYUIOA";
        public Letter(string value) : base(value)
        {
            if (vocalic.Contains(_value))
            {
                _vocalic = true;
            }
        }

        public bool GetVocalic()
        {
            return _vocalic;
        }
    }
}
