using System;
using ParsingLevel.PL;

namespace Managers
{
    class Program
    {
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            
            ShowDataBase.Show();

            Console.ReadKey();
        }
    }
}
