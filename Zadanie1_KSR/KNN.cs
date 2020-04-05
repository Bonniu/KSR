using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1_KSR.Metrics;

// ReSharper disable CommentTypo

namespace Zadanie1_KSR
{
    public class KNN
    {
        private readonly int _trainingNr;
        private readonly int _testNr;
        private int _k;
        private readonly List<Article> _testArticles;
        private readonly List<Article> _trainingArticles;
        private readonly Metric _metric;
        private double _accuracy;
        private List<List<int>> _matrix;

        public KNN(int k, int trainingNr, int testNr, List<Article> articleList, Metric metric)
        {
            this._k = k;
            this._trainingNr = trainingNr;
            this._testNr = testNr;
            this._metric = metric;
            _testArticles = new List<Article>();
            _trainingArticles = new List<Article>();
            SplitArticlesAndSave(articleList);
        }

        public void Classify()
        {
            ResetMatrix();
            for (int x = 0; x < _testArticles.Count; x++)
            {
                List<Neighbor> closestNeighbors = new List<Neighbor>();
                for (int i = 0; i < _trainingArticles.Count; i++)
                {
                    double tmp = _metric.CountValue(_trainingArticles[i], _testArticles[x]);
                    if (closestNeighbors.Count < _k)
                    {
                        closestNeighbors.Add(new Neighbor(_trainingArticles[i].GetPlace(), tmp));
                        continue;
                    }

                    //sortowanie - ostatni najgorszy
                    closestNeighbors = closestNeighbors.OrderBy(test => test.GetKnnValue()).ToList();

                    // wstarczy sprawdzic ostatni - jezeli ostatni jest mniejszy to zamiana
                    if (closestNeighbors[^1].GetKnnValue() > tmp)
                    {
                        closestNeighbors[^1].SetPlace(_trainingArticles[i].GetPlace());
                        closestNeighbors[^1].SetKnnValue(tmp);
                    }
                }

                var classifiedPlace = GetPlaceFromNeighbors(closestNeighbors);
                //sprawdzenie jaki place
                AddToMatrix(_matrix, _testArticles[x].GetPlace(), classifiedPlace);
            }

            double correctSum = _matrix[0][0] + _matrix[1][1] + _matrix[2][2] + _matrix[3][3] + _matrix[4][4] +
                                _matrix[5][5];
            _accuracy = correctSum / _testArticles.Count * 100;
        }

        public void SetK(int k)
        {
            this._k = k;
        }

        private void ResetMatrix()
        {
            _matrix = new List<List<int>>(6);
            for (int i = 0; i < 6; i++)
            {
                _matrix.Add(new List<int>(6));
                for (int j = 0; j < 6; j++)
                {
                    _matrix[i].Add(0);
                }
            }
        }

        private void AddToMatrix(List<List<int>> matrix, string realPlace, string classifiedPlace)
        {
            matrix[GetIndexFromString(classifiedPlace)][GetIndexFromString(realPlace)]++;
        }

        private void SplitArticlesAndSave(List<Article> articleList)
        {
            var articles = articleList;
            for (int i = 0; i < articles.Count; i++)
            {
                if (i < articles.Count / 100 * _trainingNr)
                    _trainingArticles.Add(articles[i]);
                else
                {
                    _testArticles.Add(articles[i]);
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

            //zwróć ten, którego jest najwięcej
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
            return _accuracy;
        }

        public void PrintMatrix()
        {
            Console.WriteLine("\nusa canada france japan west-germany uk");
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < _matrix.Count; i++)
            {
                for (var j = 0; j < _matrix[i].Count; j++)
                    Console.Write(_matrix[i][j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void PrintAccPreRec()
        {
            Console.WriteLine("\n Place  Precision  Recall");
            for (int i = 0; i < 6; i++)
            {
                var sumCol = 0;
                var sumRow = 0;
                for (var j = 0; j < 6; j++)
                {
                    sumCol += _matrix[i][j];
                    sumRow += _matrix[j][i];
                }

                var recall = sumCol == 0 ? 0 : Math.Round((double) _matrix[i][i] / sumCol * 100000) / 1000;
                var precision = sumRow == 0 ? 0 : Math.Round((double) _matrix[i][i] / sumRow * 100000) / 1000;
                Console.WriteLine(GetStringFromIndex(i) + "  " + recall + "  " + precision);
            }

            Console.WriteLine("Accuracy: " + Math.Round(_accuracy * 1000) / 1000);
        }

        public void PrintAllProperties()
        {
            Console.WriteLine("Settings: k=" + _k + " , training=" + _trainingNr + "%, test=" + _testNr + "%, metric=" +
                              _metric.GetType().ToString().Split(".")[^1]);
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
                                    |
                                    V
                                    recall
 */