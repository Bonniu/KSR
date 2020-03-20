using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1_KSR.Metrics;

namespace Zadanie1_KSR
{
    public class KNN
    {
        private int trainingNr;
        private int testNr;
        private int k;
        private List<Article> testArticles;
        private List<Article> trainingArticles;
        private Metric metric;

        public KNN(int k, int trainingNr, int testNr, List<Article> articleList, Metric metric)
        {
            this.k = k;
            this.trainingNr = trainingNr;
            this.testNr = testNr;
            this.metric = metric;
            testArticles = new List<Article>();
            trainingArticles = new List<Article>();
            SplitArticlesAndSave(articleList);
        }

        private void SplitArticlesAndSave(List<Article> articleList)
        {
            var articles = articleList.OrderBy(x => Guid.NewGuid()).ToList(); //GUID - globally unique ID
            for (int i = 0; i < articles.Count; i++)
            {
                if (i < articles.Count / 100 * trainingNr)
                    trainingArticles.Add(articleList[i]);
                else
                {
                    testArticles.Add(articleList[i]);
                }
            }

            Console.WriteLine(trainingArticles.Count);
            Console.WriteLine(testArticles.Count);
        }
    }
}