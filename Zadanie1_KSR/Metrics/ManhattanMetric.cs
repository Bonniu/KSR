using System;

namespace Zadanie1_KSR.Metrics
{
    public class ManhattanMetric : Metric
    {
        public override double CountValue(Article trainArticle, Article testArticle)
        {
            double sum = 0;
            for (int i = 0; i < trainArticle.GetFeaturesVector().Count; i++)
            {
                sum += Math.Abs(trainArticle.GetFeaturesVector()[i].GetValue() - testArticle.GetFeaturesVector()[i].GetValue());
            }
            return sum;
        }
    }
}