using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftApp.Classes
{
    class Wafle:Classes.PartOfGift,Interfaces.IFilling,Interfaces.ITypeOfBatter
    {
        string _filling, _typeOfBatter;

        public Wafle(string name, IDictionary<string, string> dict)
            : base(name, dict)
        {
            dict.TryGetValue("filling", out string filling);
            _filling = filling;
            dict.TryGetValue("typeOfBatter", out string typeOfBatter);
            _typeOfBatter = typeOfBatter;
        }

        public string GetTypeOfBatter()
        {
            return _typeOfBatter;
        }

        public string GetFilling()
        {
            return _filling;
        }
        public override string ToString()
        {
            return base.ToString()+String.Format("начинка- {0} тесто- {1}", _filling, _typeOfBatter);
        }
    }
}
