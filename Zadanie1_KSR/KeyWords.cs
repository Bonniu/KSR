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
        
        public KeyWords()
        {
            keywords = new List<string>();
            this._nrOfKeywords = 100;
        }

        /**
         * Znajduje słowa kluczowe
         * Z listy wszystich artykułów zlicza wszystkie słowa, a następonie bierze 100 słów, które nie są liczbami
         * pomijając pierwsze 25% listy najczęściej występującychn słów
         */
        public void FindKeyWordsOld(List<Article> articles)
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
                catch (Exception)
                {
                    keywords.Add(wc.GetWordCount().ElementAt(i).Key);
                    i++;
                    continue;
                }

                i++;
            }
            Console.WriteLine(wc.wordCountDictionary.Count);
            // foreach (var VARIABLE in wc.wordCountDictionary)
            // {
            //     Console.WriteLine(VARIABLE.Key + " " +  VARIABLE.Value);
            // }
        }

        public void FindKeyWords(List<Article> articles)
        {
            WordCounter wc = new WordCounter();
            wc.CountWords(articles);
            
            Dictionary<string, List<string>> wordListDict = new Dictionary<string, List<string>>();
            wordListDict.Add("usa", new List<string>());
            wordListDict.Add("japan", new List<string>());
            wordListDict.Add("france", new List<string>());
            wordListDict.Add("west-germany", new List<string>());
            wordListDict.Add("uk", new List<string>());
            wordListDict.Add("canada", new List<string>());
            foreach (var key in wordListDict.Keys)
            {
                int startIndex = wc.GetWordCount().Count * 8 / 10;
                int i = startIndex;
                while (wordListDict[key].Count < 18)
                {
                    try
                    {
                        int y = int.Parse(wc.GetWordCount().ElementAt(i).Key);
                    }
                    catch (Exception)
                    {
                        if (AddOrNot(wc, i, key))
                        {
                            wordListDict[key].Add(wc.GetWordCount().ElementAt(i).Key);
                            i--;
                            continue;
                        }
                    }
                    i--;
                }
            }


            foreach (var v in wordListDict.Keys)
            {
               // Console.WriteLine(v);
                foreach (var word in wordListDict[v])
                {
                   // Console.WriteLine(word);  
                    keywords.Add(word);
                }
                
            }
            // Console.WriteLine(wc.wordCountDictionary.Count);
            // Console.WriteLine(wc.wordCountDictionaryUSA.Count);
            // Console.WriteLine(wc.wordCountDictionaryUK.Count);
            // Console.WriteLine(wc.wordCountDictionaryFrance.Count);
            // Console.WriteLine(wc.wordCountDictionaryWestGermany.Count);
            // Console.WriteLine(wc.wordCountDictionaryJapan.Count);
            // Console.WriteLine(wc.wordCountDictionaryCanada.Count);
            // Console.WriteLine(" ");
            // Console.WriteLine(wordListDict["usa"].Count);
            // Console.WriteLine(wordListDict["uk"].Count);
            // Console.WriteLine(wordListDict["france"].Count);
            // Console.WriteLine(wordListDict["west-germany"].Count);
            // Console.WriteLine(wordListDict["japan"].Count);
            // Console.WriteLine(wordListDict["canada"].Count);
            
            //
            // Console.WriteLine(tmpList.Count);
        }

        private bool AddOrNot(WordCounter wc, int i, string key)
        {
            // Console.WriteLine(wc.wordCountDictionary.ElementAt(i).Key + " " +
            //                   wc.wordCountDictionary.ElementAt(i).Value);

            int counter = 0;
            if (wc.wordCountDictionaryCanada.Contains(wc.wordCountDictionary.ElementAt(i).Key))
            {
                counter += 1;
            }
            if (wc.wordCountDictionaryUSA.Contains(wc.wordCountDictionary.ElementAt(i).Key))
            {
                counter += 10;
            }
            if (wc.wordCountDictionaryUK.Contains(wc.wordCountDictionary.ElementAt(i).Key))
            {
                counter += 100;
            }
            if (wc.wordCountDictionaryWestGermany.Contains(wc.wordCountDictionary.ElementAt(i).Key))
            {
                counter += 1000;
            }
            if (wc.wordCountDictionaryJapan.Contains(wc.wordCountDictionary.ElementAt(i).Key))
            {
                counter += 10000;
            }
            if (wc.wordCountDictionaryFrance.Contains(wc.wordCountDictionary.ElementAt(i).Key))
            {
                counter += 100000;
            }

            // Console.Write(counter + " ");
            switch (key)
            {
                case "canada":
                    return counter == 1;
                case "usa":
                    return counter == 10;
                case "uk":
                    return counter == 100;
                case "west-germany":
                    return counter == 1000;
                case "japan":
                    return counter == 10000;
                case "france":
                    return counter == 100000;
                default:
                    return false;
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