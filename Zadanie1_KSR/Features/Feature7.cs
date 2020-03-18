// ReSharper disable CommentTypo

namespace Zadanie1_KSR.Features
{
    public class Feature7 : Feature
    {
        public Feature7(Article article)
        {
            value = CountValue(article);
        }

        // Stosunek słów o długości >6 do wszystkich słów
        private double CountValue(Article article)
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

            value = (double) counter / tmpList.Count;
            return value;
        }
    }
}