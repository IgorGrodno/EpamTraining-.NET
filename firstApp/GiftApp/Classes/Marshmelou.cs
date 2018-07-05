using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftApp.Classes
{
    class Marshmelou:Classes.Candy,Interfaces.IForm,Interfaces.IColor
    {
        string _color, _form;

        public Marshmelou(string name, IDictionary<string, string> dict) 
            : base(name, dict)
        {
            dict.TryGetValue("color", out string color);
            _color = color;
            dict.TryGetValue("form", out string form);
            _form = form;
        }

        public string GetForm()
        {
            return _form;
        }
        public string GetColor()
        {
            return _color;
        }
        public override string ToString()
        {
            return base.ToString()+ String.Format(" цвет зефирки- {0} форма- {1}", _color, _form);
        }
    }
}
