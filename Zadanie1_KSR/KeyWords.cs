using System;
using System.Collections.Generic;
using System.Linq;

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

        public void FindKeyWords(List<Article> articles)
        {
            WordCounter wc = new WordCounter();
            wc.CountWords(articles);

            int index = wc.GetWordCount().Count * 3 / 4;
            for (int i = index; i < index + _nrOfKeywords; i++)
            {
                keywords.Add(wc.GetWordCount().ElementAt(i).Key);
            }
        }
    }
}