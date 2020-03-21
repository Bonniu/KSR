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
                    trainingArticles.Add(articles[i]);
                else
                {
                    testArticles.Add(articles[i]);
                }
            }
        }

        public void Classify()
        {
            int counter = 0;
            for (int x = 0; x < testArticles.Count; x++)
            {
                List<Neighbor> closestNeighbors = new List<Neighbor>();
                for (int i = 0; i < trainingArticles.Count; i++)
                {
                    double tmp = metric.CountValue(trainingArticles[i], testArticles[x]);
                    if (closestNeighbors.Count < k)
                    {
                        closestNeighbors.Add(new Neighbor(trainingArticles[i], tmp));
                        continue;
                    }

                    //sortowanie - ostatni najgorszy
                    closestNeighbors = closestNeighbors.OrderBy(test => test.GetKnnValue()).ToList();

                    // wstarczy sprawdzic ostatni - jezeli ostatni jest mniejszy to zamiana
                    if (closestNeighbors[^1].GetKnnValue() > tmp)
                    {
                        closestNeighbors[^1].SetArticle(trainingArticles[i]);
                        closestNeighbors[^1].SetKnnValue(tmp);
                    }
                }

                string classifiedPlace = GetPlaceFromNeighbors(closestNeighbors);
                //sprawdzenie jaki place
                if (classifiedPlace.Equals(testArticles[x].GetPlace()))
                {
                    counter++;
                }
                else
                {
                    Console.Write(classifiedPlace);
                    Console.WriteLine(x + testArticles[x].GetPlace());
                }
            }

            Console.WriteLine(counter + " poprawnie");
            Console.WriteLine((double)counter / testArticles.Count + " %");
        }

        public string GetPlaceFromNeighbors(List<Neighbor> closestNeighbors)
        {
            Dictionary<string, double> neighborsMap = new Dictionary<string, double>();
            foreach (var closestNeighbor in closestNeighbors)
            {
                if (neighborsMap.ContainsKey(closestNeighbor.GetPlace()))
                    neighborsMap[closestNeighbor.GetPlace()]++;
                else
                {
                    neighborsMap[closestNeighbor.GetPlace()] = 1;
                }
            }

            //zwróć ten, którego jest najwięcej
            KeyValuePair<double, string> max = new KeyValuePair<double, string>();
            foreach (var (place, counter) in neighborsMap)
            {
                if (counter >= max.Key)
                    max = new KeyValuePair<double, string>(counter, place);
            }

            return max.Value;
        }
    }
}