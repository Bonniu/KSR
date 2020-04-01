using System;
using Zadanie1_KSR.Measures;

namespace Zadanie1_KSR.Metrics
{
    public class EuclideanMetric : Metric
    {
        public override double CountValue(Article trainArticle, Article testArticle)
        {
            double sum = 0;
            for (int i = 0; i < trainArticle.GetFeaturesVector().Count; i++)
            {
                if (trainArticle.GetFeaturesVector()[i].GetValue() < 0) // jezeli cecha zawiera tekst
                {
                    string trainStrValue = trainArticle.GetFeaturesVector()[i].GetStrValue();
                    string testStrValue = testArticle.GetFeaturesVector()[i].GetStrValue();
                    // sum += new NGramsMeasure().CountSimilarity(trainStrValue, testStrValue);
                    sum += trainArticle.GetFeaturesVector()[i].GetMeasure()
                        .CountSimilarity(trainStrValue, testStrValue);
                    Console.WriteLine(trainArticle.GetFeaturesVector()[i].GetMeasure()
                        .CountSimilarity(trainStrValue, testStrValue));
                }

                sum += Math.Pow(
                    trainArticle.GetFeaturesVector()[i].GetValue() - testArticle.GetFeaturesVector()[i].GetValue(), 2);
            }

            return Math.Sqrt(sum);
        }
    }
}