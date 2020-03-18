using System.Collections.Generic;

// ReSharper disable CommentTypo

namespace Zadanie1_KSR.Features
{
    public class Feature4 : Feature
    {
        public Feature4(Article article, KeyWords keyWords)
        {
            value = CountValue(article, keyWords);
        }

        // Stosunek słów kluczowych gdzie ilość liter (0,4] do wszystkich słów
        private double CountValue(Article article, KeyWords keyWords)
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

            value = (double) counter / tmpList.Count;
            return value;
        }
    }
}

