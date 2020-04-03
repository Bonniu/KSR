using System;

namespace Zadanie1_KSR.Measures
{
    public class NGramsMeasure : Measure
    {
        private static int n = 3;

        public override double CountSimilarity(string trainStr, string testStr)
        {
            if (trainStr.Length == 0 || testStr.Length == 0)
                return 0;
            int N = trainStr.Length > testStr.Length ? trainStr.Length : testStr.Length;
            double frac = (double) 1 / (N - n + 1);
            double sum = 0;
            for (int i = 0; i < N - n + 1; i++)
            {
                if (trainStr.Length < i + n || testStr.Length < i + n)
                    break;
                if (testStr.Contains(trainStr.Substring(i, n)))
                {
                    sum += 1;
                }
            }

            // if (sum * frac >= 0.001)
            // {
            //     Console.WriteLine(trainStr);
            //     Console.WriteLine(testStr);
            //     Console.WriteLine(sum * frac);
            // }

            //odwrocenie wyniku, poniewaz 1 w tekstach to takie same slowa, a w metryce im blizej 0 tym lepiej
            return 1 - sum * frac;
        }
    }
}