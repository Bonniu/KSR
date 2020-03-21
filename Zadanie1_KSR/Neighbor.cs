namespace Zadanie1_KSR
{
    public class Neighbor
    {
        private Article article;
        private double knnValue;

        public Neighbor(Article article, double knnValue)
        {
            this.article = article;
            this.knnValue = knnValue;
        }

        public string GetPlace()
        {
            return article.GetPlace();
        }

        public Article GetArticle()
        {
            return article;
        }

        public void SetArticle(Article article)
        {
            this.article = article;
        }

        public double GetKnnValue()
        {
            return knnValue;
        }

        public void SetPlace(string place)
        {
            this.article.SetClassifiedPlace(place);
        }

        public void SetKnnValue(double knnValue)
        {
            this.knnValue = knnValue;
        }
    }
}