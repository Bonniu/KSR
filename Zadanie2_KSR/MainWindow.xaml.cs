using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int M = 18728;

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Hello world!");


            var fifaPlayers = new CsvReader().ReadCsvFile();

            // List<LinguisticVariable> list = new List<LinguisticVariable>();
            // foreach (var allFinishingVariable in Attributes.GetAllFinishingVariables()) list.Add(allFinishingVariable);
            // foreach (var allDribblingVariable in Attributes.GetAllDribblingVariables()) list.Add(allDribblingVariable);
            List<LinguisticVariable> list = Attributes.GetAllVariables();
            GenerateSentencesSecond(fifaPlayers, list);
        }

        private void GenerateSentencesOne(List<FifaPlayer> fifaPlayers)
        {
            foreach (var x in Quantifier.GetAllQuantifiers())
            {
                foreach (var y in Attributes.GetAllVariables())
                {
                    var T = Measures.DegreeOfTruth(fifaPlayers, x, y);
                    string text = x.Text + " of footballers " + y.Type + " " + y.Text + ". [" + T + "]";
                    if (T > 0)
                        Console.WriteLine(text);
                }
            }
        }

        private void GenerateSentencesSecond(List<FifaPlayer> fifaPlayers, List<LinguisticVariable> attributes)
        {
            LinguisticVariable qualifier =
                new LinguisticVariable("25 years old", "Age", true,
                    new TriangularFunction(25, 25, 25));
            foreach (var x in Quantifier.GetAbsoluteQuantifiers())
            {
                foreach (var y in attributes)
                {
                    var t1 = Measures.DegreeOfTruthSecond(fifaPlayers, x, y, qualifier);
                    var t2 = Measures.DegreeOfImprecision(fifaPlayers, new List<LinguisticVariable>() {y});
                    var t3 = Measures.DegreeOfCovering(fifaPlayers, new List<LinguisticVariable>() {y}, qualifier);
                    var t4 = 1d; //Measures.DegreeOfCovering(fifaPlayers,new List<LinguisticVariable>() {y}, qualifier);
                    var t5 = 1d; //Measures.DegreeOfCovering(fifaPlayers,new List<LinguisticVariable>() {y}, qualifier);
                    var t6 = 1d; //Measures.DegreeOfCovering(fifaPlayers,new List<LinguisticVariable>() {y}, qualifier);
                    string text = x.Text + " of " + qualifier.Text + " footballers " + y.Type + " " + y.Text + ". ";
                    string measures16 = Math.Round(t1, 3) + " " + Math.Round(t2, 3) + " " + Math.Round(t3, 3) + " " +
                                        Math.Round(t4, 3) + " " + Math.Round(t5, 3) + " " + Math.Round(t6, 3) + " ";
                    Console.WriteLine(text + "[" + measures16 + "]");
                }
            }
        }


        /*private void GenerateSentencesTwo(List<FifaPlayer> fifaPlayers)
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
                                          y.Text;//+
                                          //". [" + T + "]";
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

            return quantifier.MembershipFunction.CountValue(r / M);
        }*/
    }
}