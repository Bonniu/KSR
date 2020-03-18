// ReSharper disable CommentTypo

using System;
using System.Collections.Generic;

namespace Zadanie1_KSR
{
    public class Features
    {
        private List<string> ConvertTextToArray(string text)
        {
            char[] delimiters = {' ', '\t', '\n'};
            string[] tmp = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            List<string> returnList = new List<string>();
            foreach (var s in tmp)
            {
                returnList.Add(s);
            }

            return returnList;
        }

        // Stosunek słów kluczowych do wszystkich słów w pierwszych 10% tekstu
        public double F1(Article article, KeyWords keyWords)
        {
            List<string> tmpList = ConvertTextToArray(article.GetRefactoredText());
            int firstWordsIndex = article.GetWordCount() / 10;
            int counter = 0;
            for (int i = 0; i < firstWordsIndex; i++)
            {
                for (int j = 0; j < keyWords.GetKeywords().Count; j++)
                {
                    if (tmpList[i].Equals(keyWords.GetKeywords()[j]))
                    {
                        counter++;
                        break;
                    }
                }
            }

            return (double) counter / firstWordsIndex;
        }

        // Stosunek słów kluczowych do wszystkich słów w ostatnich 10% tekstu
        public double F2(Article article, KeyWords keyWords)
        {
            List<string> tmpList = ConvertTextToArray(article.GetRefactoredText());
            int wordsCount = article.GetWordCount() / 10;
            int lastWordsIndex = tmpList.Count - wordsCount;
            int counter = 0;
            for (int i = tmpList.Count - 1; i >= lastWordsIndex; i--)
            {
                for (int j = 0; j < keyWords.GetKeywords().Count; j++)
                {
                    if (tmpList[i].Equals(keyWords.GetKeywords()[j]))
                    {
                        counter++;
                        break;
                    }
                }
            }

            return (double) counter / wordsCount;
        }


        // Stosunek słów kluczowych do wszystkich słów w całym dokumencie
        public double F3(Article article, KeyWords keyWords)
        {
            List<string> tmpList = ConvertTextToArray(article.GetRefactoredText());
            int counter = 0;
            for (int i = 0; i < tmpList.Count; i++)
            {
                for (int j = 0; j < keyWords.GetKeywords().Count; j++)
                {
                    if (tmpList[i].Equals(keyWords.GetKeywords()[j]))
                    {
                        counter++;
                        break;
                    }
                }
            }

            return (double) counter / tmpList.Count;
        }

        // Stosunek słów kluczowych gdzie ilość liter (0,4] do wszystkich słów
        public double F4(Article article, KeyWords keyWords)
        {
            List<string> tmpList = ConvertTextToArray(article.GetRefactoredText());
            int counter = 0;
            for (int i = 0; i < tmpList.Count; i++)
            {
                for (int j = 0; j < keyWords.GetKeywords().Count; j++)
                {
                    if (tmpList[i].Equals(keyWords.GetKeywords()[j]) && keyWords.GetKeywords()[j].Length <= 4)
                    {
                        counter++;
                        break;
                    }
                }
            }

            return (double) counter / tmpList.Count;
        }

        // Stosunek słów kluczowych gdzie ilość liter 8+ do wszystkich słów
        public double F5(Article article, KeyWords keyWords)
        {
            var tmpList = ConvertTextToArray(article.GetRefactoredText());
            var counter = 0;
            foreach (var tStr in tmpList)
            {
                for (var j = 0; j < keyWords.GetKeywords().Count; j++)
                {
                    if (tStr.Equals(keyWords.GetKeywords()[j]) && keyWords.GetKeywords()[j].Length > 8)
                    {
                        counter++;
                        break;
                    }
                }
            }

            return (double) counter / tmpList.Count;
        }

        // Stosunek linii do ilości akapitów
        public double F6(Article article)
        {
            var linesCounter = article.GetOriginalText().Split("\n").Length - 1;
            var paragraphsCounter = article.GetOriginalText().Split("    ").Length;
            return (double) linesCounter / paragraphsCounter;
        }

        // Stosunek słów o długości >6 do wszystkich słów
        public double F7(Article article)
        {
            var tmpList = ConvertTextToArray(article.GetRefactoredText());
            var counter = 0;
            foreach (var tStr in tmpList)
            {
                if (tStr.Length > 6)
                {
                    counter++;
                }
            }

            return (double) counter / tmpList.Count;
        }

        // Stosunek słów o długości <=6 do wszystkich słów
        public double F8(Article article)
        {
            var tmpList = ConvertTextToArray(article.GetRefactoredText());
            var counter = 0;
            foreach (var tStr in tmpList)
            {
                if (tStr.Length <= 6)
                {
                    counter++;
                }
            }

            return (double) counter / tmpList.Count;
        }

        // Ilość słów unikalnych
        public double F9(Article article)
        {
            var tmpList = ConvertTextToArray(article.GetRefactoredText());
            return WordCounter.CountWords(tmpList);
        }

        // Ilość słów, których długość wynosi [5,8]
        public double F10(Article article)
        {
            var tmpList = ConvertTextToArray(article.GetRefactoredText());
            var counter = 0;
            foreach (var tStr in tmpList)
            {
                if (tStr.Length >= 5 && tStr.Length <= 8)
                {
                    counter++; 
                }
            }

            return counter;
        }
    }
}