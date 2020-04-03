using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1_KSR.Metrics;

// ReSharper disable CommentTypo

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
        private double resultPercent;

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

        public void SetK(int k)
        {
            this.k = k;
        }

        public double GetResultPercent()
        {
            return resultPercent;
        }

        public void PrintAllProperties()
        {
            Console.WriteLine("Settings: k=" + k + " , training=" + trainingNr + "%, test=" + testNr + "%, metric=" +
                          metric.GetType().ToString().Split(".")[^1]);
        }

        private void SplitArticlesAndSave(List<Article> articleList)
        {
            List<Article> articles;

            //mieszanie danych
            //articles = articleList.OrderBy(x => Guid.NewGuid()).ToList(); //GUID - globally unique ID

            articles = articleList;
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
                    counter++;
            }

            resultPercent = (double) counter / testArticles.Count * 100;
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