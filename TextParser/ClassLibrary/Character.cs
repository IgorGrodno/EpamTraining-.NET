using System;
using InterfaceLibrary;



namespace ClassLibrary
{
    public abstract class Character : ICharacter
    {
        protected string _value;
        protected bool _isLetter = false;

        string letters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

        public Character(string value)
        {
            _value = value;
            if (letters.Contains(_value))
            {
                _isLetter = true;
            }
        }
        
        public bool GetIsLetter()
        {
            return _isLetter;
        }
        
        public override string ToString()
        {
            return _value;
        }
     }
}
