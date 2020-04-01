// ReSharper disable CommentTypo

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
                double tmp;
                if (trainArticle.GetFeaturesVector()[i].GetValue() < 0) // jezeli cecha zawiera tekst
                {
                    string trainStrValue = trainArticle.GetFeaturesVector()[i].GetStrValue();
                    string testStrValue = testArticle.GetFeaturesVector()[i].GetStrValue();
                    tmp = trainArticle.GetFeaturesVector()[i].GetMeasure().CountSimilarity(trainStrValue, testStrValue);
                }
                else
                {
                    tmp = Math.Abs(trainArticle.GetFeaturesVector()[i].GetValue() -
                                   testArticle.GetFeaturesVector()[i].GetValue());
                }

                if (tmp > max)
                    max = tmp;
            }

            return max;
        }
    }
}