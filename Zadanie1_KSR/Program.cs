using System;
using System.Collections.Generic;
using Annytab.Stemmer;
using Zadanie1_KSR.Features;

namespace Zadanie1_KSR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArticleGenerator ag = new ArticleGenerator(22);
            List<Article> list = ag.ReadAllFiles();
            Console.WriteLine(list[^14].ToString());

            KeyWords keyWords = new KeyWords(100);
            keyWords.FindKeyWords(list);
            keyWords.PrintKeyWords();

            foreach (var article in list)
            {
                article.GetFeaturesVector().AddFeature(new Feature1(article, keyWords));
                article.GetFeaturesVector().AddFeature(new Feature2(article, keyWords));
                article.GetFeaturesVector().AddFeature(new Feature3(article, keyWords));
                article.GetFeaturesVector().AddFeature(new Feature4(article, keyWords));
                article.GetFeaturesVector().AddFeature(new Feature5(article, keyWords));
                article.GetFeaturesVector().AddFeature(new Feature6(article));
                article.GetFeaturesVector().AddFeature(new Feature7(article));
                article.GetFeaturesVector().AddFeature(new Feature8(article));
                article.GetFeaturesVector().AddFeature(new Feature9(article));
                article.GetFeaturesVector().AddFeature(new Feature10(article));
            }

            foreach (var f in list[^14].GetFeaturesVector().GetFeatures())
            {
                Console.Write(f.GetValue() + " ");
            }
            
            Console.WriteLine("end");

            // TmpFunction();
        }

        static void TmpFunction()
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
    }
}