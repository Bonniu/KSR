using System;

namespace Zadanie1_KSR.Metrics
{
    public class EuclideanMetric : Metric
    {
        public override double CountValue(Article trainArticle, Article testArticle)
        {
            double sum = 0;
            for (int i = 0; i < trainArticle.GetFeaturesVector().Count; i++)
            {
                sum += Math.Pow(trainArticle.GetFeaturesVector()[i].GetValue() - testArticle.GetFeaturesVector()[i].GetValue(), 2);
            }
            
            return Math.Sqrt(sum);
        }
    }
}