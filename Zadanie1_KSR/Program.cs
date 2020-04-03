using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Annytab.Stemmer;
using Zadanie1_KSR.Features;
using Zadanie1_KSR.Measures;
using Zadanie1_KSR.Metrics;

namespace Zadanie1_KSR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading files...");
            ArticleGenerator ag = new ArticleGenerator(22);
            List<Article> list = ag.ReadAllFiles();

            Console.WriteLine("Creating keywords...");
            KeyWords keyWords = new KeyWords(100);
            keyWords.FindKeyWords2(list);

            Console.WriteLine("Adding features...");
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
                 article.GetFeaturesVector().Add(new Feature11(article, keyWords, new NGramsMeasure()));
            }
            Console.WriteLine("Normalizing vectors...");
            NormalizeVectors(list, keyWords);
            KNN knn = new KNN(25, 85, 15, list, new EuclideanMetric());
            Console.WriteLine("Classifying...");
            knn.Classify();
            knn.PrintAllProperties();
            Console.WriteLine("Accuracy: " + knn.GetResultPercent() + "%");
            
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
        
        static void NormalizeVectors(List<Article> list, KeyWords keyWords)
        {
            for (int i = 0;
                i < list[0].GetFeaturesVector().Count;
                i++)
            {
                if (list[0].GetFeaturesVector()[i].GetValue() < 0) //pomijanie optymalizacji gdy string
                {
                    continue;
                }

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