using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Interfaces.IPartOfGift> list = new List<Interfaces.IPartOfGift>();
            Classes.IniClass dict =new Classes.IniClass();
            

            list.Add(new Classes.Wafle("вафелька 0",dict.IniDictionarySet0()));
            list.Add(new Classes.Wafle("вафелька 1", dict.IniDictionarySet1()));
            list.Add(new Classes.Wafle("вафелька 2", dict.IniDictionarySet2()));

            list.Add(new Classes.Cookie("Печеька 0", dict.IniDictionarySet3()));
            list.Add(new Classes.Cookie("Печеька 1", dict.IniDictionarySet0()));
            list.Add(new Classes.Cookie("Печеька 2", dict.IniDictionarySet1()));

            list.Add(new Classes.Candy("Конфетка 0", dict.IniDictionarySet2()));
            list.Add(new Classes.Candy("Конфетка 1", dict.IniDictionarySet3()));
            list.Add(new Classes.Candy("Конфетка 2", dict.IniDictionarySet0()));

            list.Add(new Classes.CandyBar("батончик 0", dict.IniDictionarySet1()));
            list.Add(new Classes.CandyBar("батончик 1", dict.IniDictionarySet2()));
            list.Add(new Classes.CandyBar("батончик 2", dict.IniDictionarySet3()));

            

            list.Add(new Classes.Marshmelou("зефирка 0", dict.IniDictionarySet0()));
            list.Add(new Classes.Marshmelou("зефирка 1", dict.IniDictionarySet1()));
            list.Add(new Classes.Marshmelou("зефирка 2", dict.IniDictionarySet2()));


            Classes.Gift TestGift = new Classes.Gift(list,"Подарок для детского сада №1");

            Console.WriteLine(TestGift.GetNameOfGift());
            Console.WriteLine("Вес-"+TestGift.GetGiftWeight());
            Console.WriteLine();

            foreach (Interfaces.IPartOfGift item in TestGift)
            {
              Console.WriteLine( item.ToString());
                
            }

            Console.WriteLine();
            Console.WriteLine("Для сортировки по весу жмите any kay");
            Console.ReadKey();

            foreach (Interfaces.IPartOfGift item in TestGift.SortByWeight())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Для выборки по содержанию сахара от 9 до 19 жмите any kay");
            Console.ReadKey();

            foreach (Interfaces.IPartOfGift item in TestGift.FindBySugarCount(9, 19))
            {
                Console.WriteLine(item.ToString());
            }


           Console.ReadKey();
        }   
    }
}
