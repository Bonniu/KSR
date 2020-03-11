using System;
using System.Collections.Generic;

namespace Zadanie1_KSR
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileParser fp = new FileParser();
            List<Article> list = new List<Article>();
            ArticleGenerator ag = new ArticleGenerator(22);
            list = ag.ReadAllFiles();
            // for (int i = 0; i < list.Count; i++)
            // {
            //     Console.WriteLine(list[i].ToString());
            // }
            Console.WriteLine(list[^1].ToString());
            Console.WriteLine(list.Count);
        }
    }
}