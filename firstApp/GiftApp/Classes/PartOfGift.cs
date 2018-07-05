using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftApp.Classes
{
  public abstract  class PartOfGift : Interfaces.IPartOfGift
    {
        protected Guid _id;
        protected string _name;
        protected int _weight, _sugarCount;
        protected bool _inChocolate;

      public PartOfGift(string name, IDictionary<string,string> dict)
        {
            
            _id = new Guid();
            _name = name;
            dict.TryGetValue("weight", out string weight);
            _weight =Convert.ToInt32( weight);
            dict.TryGetValue("sugarCount", out string sugarCount);
            _sugarCount = Convert.ToInt32(sugarCount);
            dict.TryGetValue("inChocolate", out string inChocolate);
            _inChocolate =Convert.ToBoolean( inChocolate); 

        }

        public Guid GetId()
        {
            return _id;
        }

        public bool GetInChocolate()
        {
            return _inChocolate;
        }

        public string GetName()
        {
            return _name;
        }

        public override string ToString()
        {
            string s = "";
            if (_inChocolate != false)
            {
                s =" в шоколаде";
            }
            return String.Format("{0} вес-{1} содержание сахара-{2} {3} ",_name, _weight,_sugarCount,s);
        }

        public int GetSugarCount()
        {
            return _sugarCount;
        }

        public int GetWeight()
        {
            return _weight;
        }
    }
}
