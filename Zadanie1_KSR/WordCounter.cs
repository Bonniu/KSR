using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Zadanie1_KSR
{
    public class WordCounter
    {
        public Dictionary<string, int> wordCountDictionary;
        public Dictionary<string, int> wordCountDictionaryUSA;
        public Dictionary<string, int> wordCountDictionaryFrance;
        public Dictionary<string, int> wordCountDictionaryJapan;
        public Dictionary<string, int> wordCountDictionaryCanada;
        public Dictionary<string, int> wordCountDictionaryWestGermany;
        public Dictionary<string, int> wordCountDictionaryUK;

        public WordCounter()
        {
            this.wordCountDictionary = new Dictionary<string, int>();
            this.wordCountDictionaryUSA = new Dictionary<string, int>();
            this.wordCountDictionaryFrance = new Dictionary<string, int>();
            this.wordCountDictionaryJapan = new Dictionary<string, int>();
            this.wordCountDictionaryCanada = new Dictionary<string, int>();
            this.wordCountDictionaryWestGermany = new Dictionary<string, int>();
            this.wordCountDictionaryUK = new Dictionary<string, int>();
        }

        public Dictionary<string, int> GetWordCount()
        {
            return this.wordCountDictionary;
        }

        public bool CountWords(List<Article> articleList)
        {
            foreach (var article in articleList)
            {
                ParseText(article.GetRefactoredText().ToLower(), article.GetPlace());
            }

            SortWordCountDictionary();
            // foreach (var pair in wordCountDictionary)
            // {
            //     if (pair.Value < 3)
            //     {
            //         wordCountDictionary.Remove(pair.Key);
            //     }
            // }

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

        private void ParseText(string text, string place)
        {
            foreach (var s in text.Split(null))
            {
                if (place == "usa")
                    AddWordCount(s, wordCountDictionaryUSA);
                else if (place == "uk")
                    AddWordCount(s, wordCountDictionaryUK);
                else if (place == "west-germany")
                    AddWordCount(s, wordCountDictionaryWestGermany);
                else if (place == "france")
                    AddWordCount(s, wordCountDictionaryFrance);
                else if (place == "japan")
                    AddWordCount(s, wordCountDictionaryJapan);
                else if (place == "canada")
                    AddWordCount(s, wordCountDictionaryCanada);
                else throw new EvaluateException("asddddddddddddddddddddddddddddddddddddddddddddd");
            }
        }

        private void AddWordCount(string word, Dictionary<string, int> wordCountDictCountry)
        {
            if (wordCountDictCountry.ContainsKey(word))
            {
                wordCountDictCountry[word] += 1;
                wordCountDictionary[word] += 1;
            }
            else if (wordCountDictionary.ContainsKey(word))
            {
                wordCountDictCountry.Add(word, 1);
                wordCountDictionary[word] += 1;
            }
            else
            {
                wordCountDictionary.Add(word, 1);
            }
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
            var sorted = from entry in wordCountDictionary orderby entry.Value select entry;
            wordCountDictionary = new Dictionary<string, int>();
            foreach (var valuePair in sorted)
            {
                this.wordCountDictionary.Add(valuePair.Key, valuePair.Value);
            }
        }
    }
}