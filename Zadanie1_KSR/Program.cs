using System;
using System.Collections.Generic;

namespace Zadanie1_KSR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArticleGenerator ag = new ArticleGenerator(22);
            List<Article> list = ag.ReadAllFiles();
            Console.WriteLine(list[^1].ToString());
            WordCounter wc = new WordCounter(list);
            //wc.CountWords();
            Console.WriteLine(wc.ToString());
            Stemmer stemmer = new Stemmer();
            stemmer.xdxdxd("nationalize");
            stemmer.xdxdxd("symbols");
            stemmer.xdxdxd("prices");
        }
    }
}