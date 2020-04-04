using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private double accuracy;
        private List<List<int>> matrix;

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

        public double GetAccuracy()
        {
            return accuracy;
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
            ResetMatrix();
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

                var classifiedPlace = GetPlaceFromNeighbors(closestNeighbors);
                //sprawdzenie jaki place
                AddToMatrix(matrix, testArticles[x].GetPlace(), classifiedPlace);
            }

            double correctSum = matrix[0][0] + matrix[1][1] + matrix[2][2] + matrix[3][3] + matrix[4][4] + matrix[5][5];
            accuracy = correctSum / testArticles.Count * 100;
        }

        public void PrintAccPreRec()
        {
            Console.WriteLine("\n Place  Precision  Recall");
            for (int i = 0; i < 6; i++)
            {
                int sumCol = 0;
                int sumRow = 0;
                for (int j = 0; j < 6; j++)
                {
                    sumCol += matrix[i][j];
                    sumRow += matrix[j][i];
                }
                double recall = sumCol == 0 ? 0 : Math.Round((double) matrix[i][i] / sumCol * 100000) / 1000;
                double precision = sumRow == 0 ? 0 : Math.Round((double) matrix[i][i] / sumRow * 100000) / 1000;
                Console.WriteLine(GetStringFromIndex(i) + "  " + recall + "  " + precision);
            }

            Console.WriteLine("Accuracy: " + Math.Round(accuracy * 1000) / 1000);
        }

        private void AddToMatrix(List<List<int>> matrix, string realPlace, string classifiedPlace)
        {
            matrix[GetIndexFromString(classifiedPlace)][GetIndexFromString(realPlace)]++;
        }

        private void ResetMatrix()
        {
            matrix = new List<List<int>>(6);
            for (int i = 0; i < 6; i++)
            {
                matrix.Add(new List<int>(6));
                for (int j = 0; j < 6; j++)
                {
                    matrix[i].Add(0);
                }
            }
        }

        private int GetIndexFromString(string country)
        {
            switch (country)
            {
                case "usa":
                    return 0;
                case "canada":
                    return 1;
                case "france":
                    return 2;
                case "japan":
                    return 3;
                case "west-germany":
                    return 4;
                case "uk":
                    return 5;
                default:
                    return -1;
            }
        }

        private string GetStringFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return "usa";
                case 1:
                    return "canada";
                case 2:
                    return "france";
                case 3:
                    return "japan";
                case 4:
                    return "west-germany";
                case 5:
                    return "uk";
                default:
                    return "err";
            }
        }

/*                                                real
                                    usa canada france japan west-germany  uk
                        usa        6079    416    124   247          190 459 -> precision
                        canada      555     62     10    21           11  36
         predicted      france      117     12      1     7            8  16
                        japan       192     10     13    21           10  19
                        west-germany 95      8      5    13           14  13
                        uk          450     30     15    44           18  80
                                    |
                                    V
                                    recall
 */
        public void PrintMatrix()
        {
            Console.WriteLine("\nusa canada france japan west-germany uk");
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
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