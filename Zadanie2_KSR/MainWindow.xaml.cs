using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Zadanie2_KSR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Hello world!");


            var fifaPlayers = new CsvReader().ReadCsvFile();


            // foreach (var t in fifaPlayers)
            // {
            //     Console.WriteLine(t.ToString());
            // }

            GenerateSentencesOne(fifaPlayers);
            GenerateSentencesTwo(fifaPlayers);
        }

        private void GenerateSentencesOne(List<FifaPlayer> fifaPlayers)
        {
            foreach (var x in Quantifier.GetAllQuantifiers())
            {
                foreach (var y in Attributes.GetAllVariables())
                {
                    var T = CountDegreeOfTruth(fifaPlayers, x, y);
                    string text = x.Text + " of footballers " + y.Type + " " + y.Text + ". [" + T + "]";
                    if (T > 0)
                        Console.WriteLine(text);
                }
            }
        }


        private static double CountDegreeOfTruth(IEnumerable<FifaPlayer> fifaPlayers, LinguisticVariable quantifier,
            LinguisticVariable summarizer)
        {
            double r = fifaPlayers.Sum(x => summarizer.CountMembership(x));

            return quantifier.MembershipFunction.CountValue(r);
        }

        private void GenerateSentencesTwo(List<FifaPlayer> fifaPlayers)
        {
            foreach (var q in Quantifier.GetAllQuantifiers())
            {
                foreach (var x in Attributes.GetAllVariables())
                {
                    foreach (var y in Attributes.GetAllVariables())
                    {
                        if (x.AttributeName != y.AttributeName)
                        {
                            var T = CountDegreeOfTruth2(fifaPlayers, q, x, y);
                            string text = q.Text + " of footballers " + x.Type + " " + x.Text + " and " + y.Type + " " +
                                          y.Text +
                                          ". [" + T + "]";
                            if (T > 0)
                                Console.WriteLine(text);
                        }
                    }
                }
            }
        }

        private static double CountDegreeOfTruth2(IEnumerable<FifaPlayer> fifaPlayers, LinguisticVariable quantifier,
            LinguisticVariable summarizer1, LinguisticVariable summarizer2)
        {
            double r = fifaPlayers.Sum(x => Math.Min(summarizer1.CountMembership(x), summarizer2.CountMembership(x)));

            return quantifier.MembershipFunction.CountValue(r);
        }
    }
}