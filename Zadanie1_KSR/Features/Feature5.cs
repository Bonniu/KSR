// ReSharper disable CommentTypo

namespace Zadanie1_KSR.Features
{
    public class Feature5 : Feature
    {
        public Feature5(Article article, KeyWords keyWords)
        {
            value = CountValue(article,  keyWords);
        }

        // Stosunek słów kluczowych gdzie ilość liter 8+ do wszystkich słów
        private double CountValue(Article article, KeyWords keyWords)
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

            value = (double) counter / tmpList.Count;
            return value;
        }
    }
}