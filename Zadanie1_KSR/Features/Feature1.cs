using System.Collections.Generic;
// ReSharper disable CommentTypo

namespace Zadanie1_KSR.Features
{
    public class Feature1 : Feature
    {
        public Feature1(Article article, KeyWords keyWords)
        {
            value = CountValue(article,  keyWords);
        }

        // Stosunek słów kluczowych do wszystkich słów w pierwszych 10% tekstu
        private double CountValue(Article article, KeyWords keyWords)
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

            value = (double) counter / firstWordsIndex;
            return value;
        }
    }
}