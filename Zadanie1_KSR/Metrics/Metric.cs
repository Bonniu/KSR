namespace Zadanie1_KSR.Metrics
{
    public abstract class Metric
    {
        public abstract double CountValue(Article trainArticle, Article testArticle);
    }
}