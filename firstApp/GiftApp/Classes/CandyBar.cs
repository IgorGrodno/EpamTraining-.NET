using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftApp.Classes
{
    class CandyBar:Classes.Candy
    {
        bool _withNuts, _withCaramel;

        public CandyBar(string name, IDictionary<string, string> dict) 
            : base(name, dict)
        {
            dict.TryGetValue("withCaramel", out string withCaramel);
            _withCaramel = Convert.ToBoolean(withCaramel);
            dict.TryGetValue("withNuts", out string withNuts);
            _withNuts = Convert.ToBoolean(withNuts);
        }

        public bool GetWithNuts()
        {
            return _withNuts;
        }

        public bool GetWithCaramel()
        {
            return _withCaramel;
        }
        public override string ToString()
        {
            string s = "";
            if (GetWithNuts() == true)
            {
                s = s + " с орешками";
            }
            if (GetWithCaramel() == true)
            {
                s = s + " c карамелью";
            }
            return base.ToString()+s;
        }
    }
}
