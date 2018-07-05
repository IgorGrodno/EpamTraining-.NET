using System;
using InterfaceLibrary;
using ClassLibrary;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace TextRarseFinaly
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Clause> clauses = new List<Clause>();
            clauses = new Parser().FileParse(ConfigurationManager.AppSettings.Get("fileToRead"));
            
            foreach (Clause item in LinqClass.SortByWordCount(clauses))
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            foreach (string item in LinqClass.GetWordsIquestionClause(4, clauses))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (Clause item in LinqClass.DeleteWords(4, clauses))
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            IEnumerator<Clause> enumerator = clauses.GetEnumerator();
            enumerator.MoveNext();
            Clause clause = enumerator.Current;

            Console.WriteLine(LinqClass.ChangeWords(4, clause, "NEWWORD").ToString());

            LinqClass.ToFile(ConfigurationManager.AppSettings.Get("fileToWrite"), clauses);

            Console.ReadKey();
        }
    }
}
