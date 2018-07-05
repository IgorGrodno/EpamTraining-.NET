using System;
using System.Collections.Generic;
using System.Text;
using InterfaceLibrary;
using System.Linq;
using System.IO;

namespace ClassLibrary
{
    public static class LinqClass
    {
        public static IEnumerable<Clause> SortByWordCount(IEnumerable<Clause> list)
        {
            var _sortedlist = from a in list
                              orderby a.GetWordCount()
                              select a;

            return _sortedlist;
        }

        public static Clause ChangeWords(int lenght, Clause clause, string newWord)
        {
            List<IPartOfClause> resultClause = new List<IPartOfClause>();
            List<Letter> word = new List<Letter>();
            char[] arr = newWord.ToCharArray(0, newWord.Length);

            foreach (char item in arr)
            {
                string s;
                s = Convert.ToString(item);
                word.Add(new Letter(s));
            }

            foreach (IPartOfClause item in clause)
            {
                if (item.IsWord() && item.GetLenght() == lenght)
                {
                    resultClause.Add(new Word(word));
                }
                else
                {
                    resultClause.Add(item);

                }
            }
            return new Clause(resultClause);
        }

        public static List<Clause> DeleteWords(int lenght, IEnumerable<Clause> listOfClauses)
        {
            List<Clause> clauses = new List<Clause>();
            List<Clause> clausesResult = new List<Clause>();
            List<IPartOfClause> tmpclause = new List<IPartOfClause>();

            foreach (Clause clause in listOfClauses)
            {
                foreach (IPartOfClause partOfClause in clause)
                {

                    if (partOfClause.IsWord() == false || partOfClause.GetLenght() != lenght)
                    {
                        tmpclause.Add(partOfClause);
                    }
                    else
                    {
                        if (partOfClause.IsWord() && partOfClause.GetLenght() == lenght)
                        {
                            Word tmpWord = (Word)partOfClause;
                            Letter letter = tmpWord.GetCharacters().First();
                            if (letter.GetVocalic() == true)
                            { tmpclause.Add(partOfClause); }

                        }
                    }
                }
                clauses.Add(new Clause(tmpclause));
                clausesResult.AddRange(clauses);
                tmpclause.Clear();
                clauses.Clear();
            }
            return clausesResult;
        }

        public static IEnumerable<string> GetWordsIquestionClause(int lenght, List<Clause> list)
        {
            List<Word> words = new List<Word>();

            var _questionList = from a in list
                                where a.getQuestion()
                                select a;

            foreach (IClause item in _questionList)
            {
                foreach (IPartOfClause item1 in item)
                {
                    if (item1.IsWord() == true && item1.GetLenght() == lenght)
                    {
                        words.Add((Word)item1);
                    }
                }
            }
            var _resultList = words.Select(x => x.ToString()).Distinct();
            return _resultList;
        }

        public static void ToFile(string path, List<Clause> clauses)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(path);
                foreach (Clause item in clauses)
                {
                    sw.WriteLine(item.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
