using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie1_KSR
{
    public class WordCounter
    {
        private Dictionary<string, int> wordCountDictionary;

        public WordCounter()
        {
            this.wordCountDictionary = new Dictionary<string, int>();
        }

        public Dictionary<string, int> GetWordCount()
        {
            return this.wordCountDictionary;
        }

        public bool CountWords(List<Article> articleList)
        {
            this.wordCountDictionary = new Dictionary<string, int>();
            foreach (var article in articleList)
            {
                parseText(article.GetRefactoredText().ToLower());
            }

            SortWordCountDictionary();
            foreach (var pair in wordCountDictionary)
            {
                if (pair.Value < 3)
                {
                    wordCountDictionary.Remove(pair.Key);
                }
            }

            return true;
        }
        // for features to count unique words
        public static int CountUniqueWords(List<string> text)
        {
            return CountWords(text).Count;
        }

        public static Dictionary<string, int> CountWords(List<string> text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var str in text)
            {
                if (dictionary.ContainsKey(str))
                {
                    dictionary[str] += 1;
                }
                else
                {
                    dictionary.Add(str, 1);
                }
            }

            return dictionary;
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
            if (wordCountDictionary.ContainsKey(word))
            {
                wordCountDictionary[word] += 1;
            }
            else
            {
                wordCountDictionary.Add(word, 1);
            }

            return true;
        }

        public override string ToString()
        {
            string tmp = "";
            foreach (var value in wordCountDictionary)
            {
                tmp += value.Key + " " + value.Value + "\n";
            }


            return tmp;
        }

        //sortowanie wordCountDictionary od najmniej wystepujacych do najczesciej wystepujacych
        public void SortWordCountDictionary()
        {
            //var sorted = from entry in wordCount orderby entry.Value descending select entry;
            var sorted = from entry in wordCountDictionary orderby entry.Value select entry;
            this.wordCountDictionary = new Dictionary<string, int>();
            foreach (var valuePair in sorted)
            {
                this.wordCountDictionary.Add(valuePair.Key, valuePair.Value);
            }
        }
    }
}