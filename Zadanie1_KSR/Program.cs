using System;
using System.Collections.Generic;
using Annytab.Stemmer;

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

            Console.WriteLine();
            Features.Feature f = new Features.Feature1(list[^14], keyWords);
            Console.WriteLine(f.GetValue());

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