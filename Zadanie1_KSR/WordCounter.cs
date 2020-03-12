using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie1_KSR
{
    public class WordCounter
    {
        private Dictionary<string, int> wordCount;
        private List<Article> articleList;

        public WordCounter(List<Article> articleList)
        {
            this.wordCount = new Dictionary<string, int>();
            this.articleList = articleList;
        }

        public Dictionary<string, int> GetWordCount()
        {
            return this.wordCount;
        }

        public bool CountWords()
        {
            this.wordCount = new Dictionary<string, int>();
            foreach (var article in articleList)
            {
                parseText(article.GetRefactoredText().ToLower());
            }

            return true;
        }

        public bool parseText(string text)
        {
            foreach (var s in text.Split(null))
            {
                AddWordCount(s);
            }

            return true;
        }

        public bool AddWordCount(string word)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word] += 1;
            }
            else
            {
                wordCount.Add(word, 1);
            }

            return true;
        }

        public override string ToString()
        {
            string tmp = "";

            SortWordCountDictionary();
            foreach (var value in wordCount)
            {
                tmp += value.Key + " " + value.Value + "\n";
            }


            return tmp;
        }

        public void SortWordCountDictionary()
        {
            //var sorted = from entry in wordCount orderby entry.Value descending select entry;
            var sorted = from entry in wordCount orderby entry.Value select entry;
            this.wordCount = new Dictionary<string, int>();
            foreach (var valuePair in sorted)
            {
                this.wordCount.Add(valuePair.Key, valuePair.Value);
            }
        }
    }
}