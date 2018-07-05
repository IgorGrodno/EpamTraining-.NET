using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftApp.Classes
{
    class IniClass
    {
        

        public IniClass()
        {
           
        }

        public Dictionary<string, string> IniDictionarySet0()
        {
            Dictionary<string, string> iniDictionary = new Dictionary<string, string>();
            iniDictionary.Add("weight", "100");
            iniDictionary.Add("sugarCount", "10");
            iniDictionary.Add("inChocolate", "true");
            iniDictionary.Add("coverType", "зеленая");
            iniDictionary.Add("filling", "шоколадная");
            iniDictionary.Add("withCaramel", "true");
            iniDictionary.Add("withNuts", "true");
            iniDictionary.Add("form", "круглая");
            iniDictionary.Add("typeOfBatter", "шоколадное");
            iniDictionary.Add("color", "черный");
            return iniDictionary;
        }

        public Dictionary<string, string> IniDictionarySet1()
        {
            Dictionary<string, string> iniDictionary = new Dictionary<string, string>();
            iniDictionary.Add("weight", "110");
            iniDictionary.Add("sugarCount", "15");
            iniDictionary.Add("inChocolate", "false");
            iniDictionary.Add("coverType", "красная");
            iniDictionary.Add("filling", "ванильная");
            iniDictionary.Add("withCaramel", "false");
            iniDictionary.Add("withNuts", "true");
            iniDictionary.Add("form", "как жирафик");
            iniDictionary.Add("typeOfBatter", "кокосовое");
            iniDictionary.Add("color", "белый");
            return iniDictionary;
        }

        public Dictionary<string, string> IniDictionarySet2()
        {
            Dictionary<string, string> iniDictionary = new Dictionary<string, string>();
            iniDictionary.Add("weight", "90");
            iniDictionary.Add("sugarCount", "20");
            iniDictionary.Add("inChocolate", "false");
            iniDictionary.Add("coverType", "прозрачная");
            iniDictionary.Add("filling", "фруктовая");
            iniDictionary.Add("withCaramel", "true");
            iniDictionary.Add("withNuts", "false");
            iniDictionary.Add("form", "квадратная");
            iniDictionary.Add("typeOfBatter", "ванильное");
            iniDictionary.Add("color", "розовый");
            return iniDictionary;
        }

        public Dictionary<string, string> IniDictionarySet3()
        {
            Dictionary<string, string> iniDictionary = new Dictionary<string, string>();
            iniDictionary.Add("weight", "95");
            iniDictionary.Add("sugarCount", "5");
            iniDictionary.Add("inChocolate", "true");
            iniDictionary.Add("coverType", "черная");
            iniDictionary.Add("filling", "фруктовая");
            iniDictionary.Add("withCaramel", "false");
            iniDictionary.Add("withNuts", "false");
            iniDictionary.Add("form", "как бегемотик");
            iniDictionary.Add("typeOfBatter", "ванильное");
            iniDictionary.Add("color", "красный");
            return iniDictionary;
        }
    }
}
