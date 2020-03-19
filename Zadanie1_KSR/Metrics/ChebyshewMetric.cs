using System;

namespace Zadanie1_KSR.Metrics
{
    public class ChebyshewMetric : Metric
    {
        public override double CountValue(Article article1, Article article2)
        {
            double max = 0;
            for (int i = 0; i < article1.GetFeaturesVector().Count; i++)
            {
                var tmp = Math.Abs(article1.GetFeaturesVector()[i].GetValue() -
                                   article2.GetFeaturesVector()[i].GetValue());
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