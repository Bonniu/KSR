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
                if (trainArticle.GetFeaturesVector()[i].GetValue() < 0) // jezeli cecha zawiera tekst
                {
                    string trainStrValue = trainArticle.GetFeaturesVector()[i].GetStrValue();
                    string testStrValue = testArticle.GetFeaturesVector()[i].GetStrValue();
                    sum += trainArticle.GetFeaturesVector()[i].GetMeasure()
                        .CountSimilarity(trainStrValue, testStrValue);
                }

                sum += Math.Abs(trainArticle.GetFeaturesVector()[i].GetValue() -
                                testArticle.GetFeaturesVector()[i].GetValue());
            }

            return sum;
        }
    }
}