using System;

namespace Zadanie1_KSR.Measures
{
    public class GeneralizedNGramsMeasure : Measure
    {
        public override double CountSimilarity(string trainStr, string testStr)
        {
            if (trainStr.Length == 0 || testStr.Length == 0)
                return 0;
            int N = trainStr.Length > testStr.Length ? trainStr.Length : testStr.Length;
            double frac = (double) 2 / (N * N + N);
            double sum = 0;
            for (int i = 1; i <= trainStr.Length; i++)
            {
                for (int j = 0; j < trainStr.Length - i + 1; j++)
                {
                    if (testStr.Contains(trainStr.Substring(j, i)))
                    {
                        sum += 1;
                    }
                }
            }

            // if (sum * frac >= 0.001)
            // {
            //     Console.WriteLine(trainStr);
            //     Console.WriteLine(testStr);
            //     Console.WriteLine(sum);
            //     Console.WriteLine(sum * frac);
            // }

            //odwrocenie wyniku, poniewaz 1 w tekstach to takie same slowa, a w metryce im blizej 0 tym lepiej
            return 1 - sum * frac;
        }
    }
}