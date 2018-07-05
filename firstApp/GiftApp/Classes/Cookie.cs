using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftApp.Classes
{ 
    class Cookie:Classes.PartOfGift,Interfaces.ITypeOfBatter,Interfaces.IForm
    {
        string _typeOfBatter, _form;

        public Cookie(string name, IDictionary<string, string> dict) 
            : base(name, dict)
        {
            dict.TryGetValue("form", out string form);
            _form = form;
            dict.TryGetValue("typeOfBatter", out string typeOfBatter);
            _typeOfBatter = typeOfBatter;
    }

        public string GetForm()
        {
            return _form;
        }

        public string GetTypeOfBatter()
        {
            return _typeOfBatter;
        }
        public override string ToString()
        {
            return base.ToString() + string.Format("тесто- {0} форма- {1}",_typeOfBatter, _form);
        }
    }
}
