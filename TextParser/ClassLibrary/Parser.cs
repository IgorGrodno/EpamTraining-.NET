using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using InterfaceLibrary;

namespace ClassLibrary
{
    public class Parser
    {
        string tmpString,
                letters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM",
                wordSeparators = ",;:()-+/",
                clauseSeparators = ".!?";
        List<Letter> tmpWord = new List<Letter>();
        List<IPartOfClause> tmpClayse = new List<IPartOfClause>();
        StreamReader reader;
        List<Clause> parsedText = new List<Clause>();

        public Parser()
        {
        }

        public List<Clause> FileParse(string path)
        {
            try
            {
                reader = new StreamReader(path);
                while (reader.EndOfStream == false)
                {
                    tmpString = Convert.ToChar(reader.Read()).ToString();

                    if (letters.Contains(tmpString))
                    {
                        tmpWord.Add(new Letter(tmpString));
                    }

                    if (wordSeparators.Contains(tmpString))
                    {
                        tmpClayse.Add(new Word(tmpWord));
                        tmpWord.Clear();
                        tmpClayse.Add(new PunctuationMark(tmpString));
                    }

                    if (clauseSeparators.Contains(tmpString))
                    {
                        if (tmpWord.Count > 0)
                        {
                            tmpClayse.Add(new Word(tmpWord));
                        }
                        tmpWord.Clear();
                        tmpClayse.Add(new PunctuationMark(tmpString));

                        if (tmpClayse.Count > 0)
                        {
                            parsedText.Add(new Clause(tmpClayse));
                        }
                        tmpClayse.Clear();
                    }

                    if (tmpString == " ")
                    {
                        if (tmpWord.Count > 0)
                        {
                            tmpClayse.Add(new Word(tmpWord));

                            tmpWord.Clear();
                        }
                    }
                }
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex + "Жмите any key");
                Console.ReadKey();
                Environment.Exit(0);
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
            return parsedText;
        }


    }
}