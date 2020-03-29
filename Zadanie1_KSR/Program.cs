using System;
using System.Collections.Generic;
using Annytab.Stemmer;
using Zadanie1_KSR.Features;
using Zadanie1_KSR.Metrics;

namespace Zadanie1_KSR
{
    class Program
    {
        static void Main(string[] args)
        {
            ArticleGenerator ag = new ArticleGenerator(22);
            List<Article> list = ag.ReadAllFiles();

            KeyWords keyWords = new KeyWords(100);
            keyWords.FindKeyWords(list);
            //keyWords.PrintKeyWords();

            foreach (var article in list)
            {
                article.GetFeaturesVector().Add(new Feature1(article, keyWords));
                article.GetFeaturesVector().Add(new Feature2(article, keyWords));
                article.GetFeaturesVector().Add(new Feature3(article, keyWords));
                article.GetFeaturesVector().Add(new Feature4(article, keyWords));
                article.GetFeaturesVector().Add(new Feature5(article, keyWords));
                article.GetFeaturesVector().Add(new Feature6(article));
                article.GetFeaturesVector().Add(new Feature7(article));
                article.GetFeaturesVector().Add(new Feature8(article));
                article.GetFeaturesVector().Add(new Feature9(article));
                article.GetFeaturesVector().Add(new Feature10(article));
            }

            NormalizeVectors(list, keyWords);
            KNN knn = new KNN(20, 85, 15, list, new ManhattanMetric());
            knn.Classify();
            // for (int k = 2; k < 26; k++)
            // {
            //     if (k != 2 && k != 3 && k != 4 && k != 5 && k != 7 && k != 10 && k != 13 && k != 15 && k != 20 &&
            //         k != 25)
            //         continue;
            //     Console.WriteLine("k: " + k);
            //     knn.SetK(k);
            //     knn.Classify();
            // }
        }

        static void StemmerTestingTmpFunction()
        {
            Stemmer stemmer = new Stemmer();
            Console.WriteLine(stemmer.StemText("symbols"));
            Console.WriteLine(stemmer.StemText("prices"));
            Console.WriteLine(stemmer.StemText("said"));
            Console.WriteLine(stemmer.StemText("expiring"));
            Console.WriteLine(stemmer.StemText("magnetometer"));
            Console.WriteLine(stemmer.StemText("december"));
            EnglishStemmer es = new EnglishStemmer();
            Console.WriteLine(es.GetSteamWord("symbols"));
            Console.WriteLine(es.GetSteamWord("prices"));
            Console.WriteLine(es.GetSteamWord("said"));
            Console.WriteLine(es.GetSteamWord("expiring"));
            Console.WriteLine(es.GetSteamWord("magnetometer"));
            Console.WriteLine(es.GetSteamWord("december"));
        }

        static void NormalizeVectors(List<Article> list, KeyWords keyWords)
        {
            for (int i = 0;
                i < list[0].GetFeaturesVector().Count;
                i++)
            {
                double max = 0;
                double min = 1;
                foreach (var article in list)
                {
                    if (article.GetFeaturesVector()[i].GetValue() > max)
                        max = article.GetFeaturesVector()[i].GetValue();
                    if (article.GetFeaturesVector()[i].GetValue() < min)
                        min = article.GetFeaturesVector()[i].GetValue();
                }

                //Console.WriteLine("cecha " + (i + 1) + ": min=" + min + " max=" + max);
                //https://en.wikipedia.org/wiki/Unit_vector
                //https://stackoverflow.com/questions/10011687/c-sharp-normalize-like-a-vector
                double distance = Math.Round(max - min, 4);
                foreach (var article in list)
                {
                    var tmp = article.GetFeaturesVector()[i].GetValue();
                    article.GetFeaturesVector()[i].SetValue(tmp / distance - min / distance);
                }
            }
        }
    }
}