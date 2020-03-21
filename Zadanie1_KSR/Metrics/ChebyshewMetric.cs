using System;

namespace Zadanie1_KSR.Metrics
{
    public class ChebyshewMetric : Metric
    {
        public override double CountValue(Article trainArticle, Article testArticle)
        {
            double max = 0;
            for (int i = 0; i < trainArticle.GetFeaturesVector().Count; i++)
            {
                var tmp = Math.Abs(trainArticle.GetFeaturesVector()[i].GetValue() -
                                   testArticle.GetFeaturesVector()[i].GetValue());
                if (tmp > max)
                {
                    max = tmp;
                }

                //    Console.WriteLine(" cecha " + i + ": " + tmp);
            }

            return max;
        }
    }
}