﻿using System;

namespace Zadanie1_KSR.Metrics
{
    public class ManhattanMetric : Metric
    {
        public override double CountValue(Article article1, Article article2)
        {
            double sum = 0;
            for (int i = 0; i < article1.GetFeaturesVector().Count; i++)
            {
                sum += Math.Abs(article1.GetFeaturesVector()[i].GetValue() - article2.GetFeaturesVector()[i].GetValue());
            }
            return sum;
        }
    }
}