// ReSharper disable CommentTypo

namespace Zadanie1_KSR.Features
{
    public class Feature10 : Feature
    {
        public Feature10(Article article)
        {
            value = CountValue(article);
        }

        // Ilość słów, których długość wynosi [5,8]
        private double CountValue(Article article)
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

            value = counter;
            return value;
        }
    }
}