using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CommentTypo

namespace Zadanie1_KSR
{
    public class KeyWords
    {
        private List<string> keywords;
        private readonly int _nrOfKeywords;

        public List<string> GetKeywords()
        {
            return keywords;
        }

        public KeyWords(int nrOfKeywords)
        {
            keywords = new List<string>();
            this._nrOfKeywords = nrOfKeywords;
        }

        /**
         * Znajduje słowa kluczowe
         * Z listy wszystich artykułów zlicza wszystkie słowa, a następonie bierze 100 słów, które nie są liczbami
         * pomijając pierwsze 25% listy najczęściej występującychn słów
         */
        public void FindKeyWords(List<Article> articles)
        {
            WordCounter wc = new WordCounter();
            wc.CountWords(articles);

            int index = wc.GetWordCount().Count * 3 / 4;
            int i = index;
            while (keywords.Count < 100)
            {
                try
                {
                    int y = int.Parse(wc.GetWordCount().ElementAt(i).Key);
                }
                catch (Exception e)
                {
                    keywords.Add(wc.GetWordCount().ElementAt(i).Key);
                    i++;
                    continue;
                }

                i++;
            }
        }

        public void PrintKeyWords()
        {
            Console.WriteLine();
            foreach (var str in GetKeywords())
            {
                Console.WriteLine(str);
            }
        }
    }
}