using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Zadanie1_KSR.Metrics;

// ReSharper disable CommentTypo

namespace Zadanie1_KSR
{
    public class KNN
    {
        private readonly int trainingNr;
        private readonly int testNr;
        private int k;
        private readonly List<Article> testArticles;
        private readonly List<Article> trainingArticles;
        private readonly Metric metric;
        private double accuracy;
        private double precision;
        private double recall;
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

        //klasyfikacja tkestu do jego kraju
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
                        closestNeighbors.Add(new Neighbor(trainingArticles[i].GetPlace(), tmp));
                        continue;
                    }

                    //sortowanie - ostatni najgorszy
                    closestNeighbors = closestNeighbors.OrderBy(test => test.GetKnnValue()).ToList();

                    // wstarczy sprawdzic ostatni - jezeli ostatni jest mniejszy to zamiana
                    if (closestNeighbors[^1].GetKnnValue() > tmp)
                    {
                        closestNeighbors[^1].SetPlace(trainingArticles[i].GetPlace());
                        closestNeighbors[^1].SetKnnValue(tmp);
                    }
                }

                var classifiedPlace = GetPlaceFromNeighbors(closestNeighbors);
                //sprawdzenie jaki place
                AddToMatrix(matrix, testArticles[x].GetPlace(), classifiedPlace);
            }

            //countAccuracyPrecisionRecall();

            double correctSum = matrix[0][0] + matrix[1][1] + matrix[2][2] + matrix[3][3] + matrix[4][4] +
                                matrix[5][5];
            accuracy = Math.Round((double) correctSum / testArticles.Count * 100000) / 1000; 
        }

        public void SetK(int k)
        {
            this.k = k;
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

        //dodanie do macierzy pomylek
        private void AddToMatrix(List<List<int>> matrix, string realPlace, string classifiedPlace)
        {
            matrix[GetIndexFromString(classifiedPlace)][GetIndexFromString(realPlace)]++;
        }

        private void SplitArticlesAndSave(List<Article> articleList)
        {
            var articles = articleList;
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

        private int GetIndexFromString(string country)
        {
            return country switch
            {
                "usa" => 0,
                "canada" => 1,
                "france" => 2,
                "japan" => 3,
                "west-germany" => 4,
                "uk" => 5,
                _ => -1
            };
        }

        private string GetStringFromIndex(int index)
        {
            return index switch
            {
                0 => "usa",
                1 => "canada",
                2 => "france",
                3 => "japan",
                4 => "west-germany",
                5 => "uk",
                _ => "err"
            };
        }

        //zwraca kraj do ktorego zakwalifikowal dany tekst
        private string GetPlaceFromNeighbors(List<Neighbor> closestNeighbors)
        {
            var neighborsMap = new Dictionary<string, double>();
            foreach (var closestNeighbor in closestNeighbors)
            {
                if (neighborsMap.ContainsKey(closestNeighbor.GetPlace()))
                    neighborsMap[closestNeighbor.GetPlace()]++;
                else
                {
                    neighborsMap[closestNeighbor.GetPlace()] = 1;
                }
            }

            //zwróć ten, którego jest najwięcej czyli ten do ktorego przypisujemy tekst
            var max = new KeyValuePair<double, string>();
            foreach (var (place, counter) in neighborsMap)
            {
                if (counter >= max.Key)
                    max = new KeyValuePair<double, string>(counter, place);
            }

            return max.Value;
        }

        public double GetAccuracy()
        {
            return accuracy;
        }

        public void PrintMatrix()
        {
            Console.WriteLine("\nusa canada france japan west-germany uk");
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < matrix.Count; i++)
            {
                for (var j = 0; j < matrix[i].Count; j++)
                    Console.Write(matrix[i][j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void PrintAccPreRecAllClasses()
        {
            Console.WriteLine("\n Place  Precision  Recall");
            for (int i = 0; i < 6; i++)
            {
                var sumCol = 0;
                var sumRow = 0;
                for (var j = 0; j < 6; j++)
                {
                    sumCol += matrix[i][j];
                    sumRow += matrix[j][i];
                }

                recall = sumCol == 0 ? 0 : Math.Round((double) matrix[i][i] / sumCol * 100000) / 1000;
                precision = sumRow == 0 ? 0 : Math.Round((double) matrix[i][i] / sumRow * 100000) / 1000;
                Console.WriteLine(GetStringFromIndex(i) + "  " + recall + "  " + precision);
            }

            Console.WriteLine("Accuracy: " + Math.Round(accuracy * 1000) / 1000);
        }

        public void countAccuracyPrecisionRecall()
        {
            var tp = matrix[0][0];
            var tn = matrix[1][1] + matrix[2][2] + matrix[3][3] + matrix[4][4] + matrix[5][5];
            var fp = 0;
            var fn = 0;
            // var tn = matrix[0][0];
            // var tp = matrix[1][1] + matrix[2][2] + matrix[3][3] + matrix[4][4] + matrix[5][5];
            // var fn = 0;
            // var fp = 0;
            for (var i = 0; i < 6; i++)
            {
                for (var j = i + 1; j < 6; j++)
                {
                    fp += matrix[i][j];
                    fn += matrix[j][i];
                }
            }

            // Console.WriteLine("tp: " + tp + " tn: " + tn + " fp: " + fp + " fn: " + fn);
            recall = tp + fn == 0 ? 0 : Math.Round((double) tp / (tp + fn) * 100000) / 1000;
            precision = tp + fp == 0 ? 0 : Math.Round((double) tp / (tp + fp) * 100000) / 1000;
            accuracy = tn + tp + fn + fp == 0
                ? 0
                : Math.Round((double) (tn + tp) / (tn + tp + fn + fp) * 100000) / 1000;
            // Console.WriteLine(accuracy + "  " + precision + "  " + recall);
        }

        public void PrintAllProperties()
        {
            Console.WriteLine("{Settings: k=" + k + " , training=" + trainingNr + "%, test=" + testNr + "%, metric=" +
                              metric.GetType().ToString().Split(".")[^1]);
            //  Console.WriteLine("a: " + accuracy + " p: " + precision + " r: " + recall + "    }");
        }
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
                                    |                                       a
                                    V                                          c    
                                    recall                                        c
                                                                                     u
                                                                                        r
                                                                                           a 
                                                                                              c
                                                                                                 y
                  real                              
 p               usa     i 
 r   usa        6079    1235         tn fn 
 e   i           555     62          fp tp
 d   
               recall = 62 / 62+1235
               precision = 62 / 62+555
               accuracy = 6079+62 / 1235+555
 */