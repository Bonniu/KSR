using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Zadanie1_KSR
{
    public class WordCounter
    {
        private Dictionary<string, int> wordCountDictionary;
        public readonly List<string> WordCountUsa;
        public readonly List<string> WordCountFrance;
        public readonly List<string> WordCountJapan;
        public readonly List<string> WordCountCanada;
        public readonly List<string> WordCountWestGermany;
        public readonly List<string> WordCountUk;

        public WordCounter()
        {
            wordCountDictionary = new Dictionary<string, int>();
            WordCountUsa = new List<string>();
            WordCountFrance = new List<string>();
            WordCountJapan = new List<string>();
            WordCountCanada = new List<string>();
            WordCountWestGermany = new List<string>();
            WordCountUk = new List<string>();
        }
        
        public Dictionary<string, int> GetWordCountDictionary()
        {
            return wordCountDictionary;
        }
        public void CountWords(List<Article> articleList)
        {
            foreach (var article in articleList)
            {
                CountWordsFromText(article.GetRefactoredText().ToLower(), article.GetPlace());
            }
            SortWordCountDictionary();
        }

        // zlicza slowa unikalne
        public static int CountUniqueWords(List<string> text)
        {
            return CountWords(text).Count;
        }

        private static Dictionary<string, int> CountWords(List<string> text)
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

        // zlicza wszystkie slowa
        private void CountWordsFromText(string text, string place)
        {
            foreach (var s in text.Split(null))
            {
                switch (place)
                {
                    case "usa":
                        AddToPlace(s, WordCountUsa);
                        break;
                    case "uk":
                        AddToPlace(s, WordCountUk);
                        break;
                    case "west-germany":
                        AddToPlace(s, WordCountWestGermany);
                        break;
                    case "france":
                        AddToPlace(s, WordCountFrance);
                        break;
                    case "japan":
                        AddToPlace(s, WordCountJapan);
                        break;
                    case "canada":
                        AddToPlace(s, WordCountCanada);
                        break;
                    default:
                        throw new EvaluateException("Nieprawidlowa dana place!");
                }
            }
        }

        // zliczanie slow dla konkretnych krajow
        private void AddToPlace(string word, List<string> wordCountPlace)
        {
            if (wordCountPlace.Contains(word))
            {
                wordCountDictionary[word] += 1;
            }
            else if (wordCountDictionary.ContainsKey(word))
            {
                wordCountPlace.Add(word);
                wordCountDictionary[word] += 1;
            }
            else
            {
                wordCountDictionary.Add(word, 1);
            }
        }

        public override string ToString()
        {
            var tmp = "";
            foreach (var value in wordCountDictionary)
            {
                tmp += value.Key + " " + value.Value + "\n";
            }
            return tmp;
        }

        //sortowanie wordCountDictionary od najmniej wystepujacych do najczesciej wystepujacych
        private void SortWordCountDictionary()
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