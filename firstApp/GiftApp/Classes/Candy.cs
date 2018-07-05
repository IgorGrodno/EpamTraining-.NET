using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftApp.Classes
{
    class Candy:Classes.PartOfGift,Interfaces.IFilling, Interfaces.ICoverType
    {
        string _coverType;
        string _filling;

        public Candy(string name,IDictionary<string,string> dict) 
            : base(name, dict)
        {
            dict.TryGetValue("coverType", out string coverType);
            _coverType = coverType;
            dict.TryGetValue("filling", out string filling);
            _filling = filling;
        }

        public string GetFilling()
        {
            return _filling;
        }

        public string GetCoverType()
        {
            return _coverType;
        }

        public override string  ToString()
        {
            return base.ToString()+String.Format(" обертка- {0} начинка- {1}",_coverType,_filling);
        }
    }
}
