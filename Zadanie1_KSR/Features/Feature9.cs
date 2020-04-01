// ReSharper disable CommentTypo

namespace Zadanie1_KSR.Features
{
    public class Feature9 : Feature
    {
        public Feature9(Article article)
        {
            value = CountValue(article);
        }

        // Ilość słów unikalnych
        private double CountValue(Article article)
        {
            var tmpList = ConvertTextToArray(article.GetRefactoredText());
            
            value = WordCounter.CountUniqueWords(tmpList);
            return value;
        }
    }
}