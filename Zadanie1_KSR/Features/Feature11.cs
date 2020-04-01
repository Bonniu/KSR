// ReSharper disable CommentTypo

using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1_KSR.Measures;

namespace Zadanie1_KSR.Features
{
    public class Feature11 : Feature
    {
        public Feature11(Article article, KeyWords keyWords, Measure measure)
        {
            valueStr = CountValue(article, keyWords, measure);
        }

        // Najczęściej występujące słowo kluczowe w artykule
        public string CountValue(Article article, KeyWords keyWords, Measure measure)
        {
            var tmp = article.GetRefactoredText().Split(" ");
            var dict = countKeyWordsInArticle(tmp, keyWords);
            if (dict.Count == 0)
                return "null";
            int max = 0;
            int index = 0;
            for (int i = 0; i < dict.Count; i++)
            {
                if (i == 0)
                {
                    max = dict.ElementAt(i).Value;
                    continue;
                }

                if (dict.ElementAt(i).Value > max)
                {
                    max = dict.ElementAt(i).Value;
                    index = i;
                }
            }

            // Console.WriteLine(dict.ElementAt(index).Key + " " + dict.ElementAt(index).Value);
            // Console.WriteLine(article);
            return dict.ElementAt(index).Key;
        }

        private Dictionary<string, int> countKeyWordsInArticle(string[] tmp, KeyWords keyWords)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();
            for (int i = 0; i < tmp.Length; i++)
            {
                for (int j = 0; j < keyWords.GetKeywords().Count; j++)
                {
                    if (keyWords.GetKeywords()[j].Equals(tmp[i]))
                    {
                        if (counter.ContainsKey(tmp[i]))
                        {
                            counter[tmp[i]] += 1;
                        }
                        else
                        {
                            counter.Add(tmp[i], 1);
                        }
                    }
                }
            }

            return counter;
        }
    }
}