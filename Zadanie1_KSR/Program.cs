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

            Features f = new Features();
             Console.WriteLine();
             Console.WriteLine(f.F1(list[^14], keyWords));
             Console.WriteLine(f.F2(list[^14], keyWords));
             Console.WriteLine(f.F3(list[^14], keyWords));
             Console.WriteLine(f.F4(list[^14], keyWords));
             Console.WriteLine(f.F5(list[^14], keyWords));
             Console.WriteLine(f.F6(list[^14]));
             Console.WriteLine(f.F7(list[^14]));
             Console.WriteLine(f.F8(list[^14]));
             Console.WriteLine(f.F9(list[^14]));
             Console.WriteLine(f.F10(list[^14]));

            // foreach (var i in list)
            // {
            //     Console.Write(f.F5(i, keyWords) + " ");
            // }

            
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