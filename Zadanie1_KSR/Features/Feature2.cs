using System.Collections.Generic;

// ReSharper disable CommentTypo

namespace Zadanie1_KSR.Features
{
    public class Feature2 : Feature
    {
        public Feature2(Article article, KeyWords keyWords)
        {
            value = CountValue(article, keyWords);
        }

        // Stosunek słów kluczowych do wszystkich słów w ostatnich 10% tekstu
        private double CountValue(Article article, KeyWords keyWords)
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

            value = (double) counter / wordsCount;
            return value;
        }
    }
}
