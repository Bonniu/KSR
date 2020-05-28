﻿using System;
using System.Collections.Generic;
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
        public static readonly List<FifaPlayer> FifaPlayers = new CsvReader().ReadCsvFile();
        public readonly OneSubjectSummaries Oss = new OneSubjectSummaries(FifaPlayers);
        public readonly MultiSubjectSummaries Mss = new MultiSubjectSummaries(FifaPlayers);


        public MainWindow()
        {
            InitializeComponent();
            MultiSubjectSummariesTests();
            //GuiLike();
            Oss.GenerateOneSubjectSentence(Quantifiers.LessThan3000,
                new List<LinguisticVariable>
                {
                    new LinguisticVariable("quite high", "Height", true,
                        new TrapezoidalFunction(180, 182, 188, 190))
                }, new List<LinguisticVariable>
                    {Summarizers.GoodOverall, Summarizers.AverageSprint});
        }


//  ---------------------------------------------------------------- DO TESTÓW -----------------------------
        private void GuiLike()
        {
            // pick quantifier
            var quantifier =
                new LinguisticVariable("About one third", "Quantifier", false,
                    new TrapezoidalFunction(0.25, 0.28, 0.32, 0.35));

            //pick qualifier or null            
            LinguisticVariable qualifier = null;
            qualifier = new LinguisticVariable("about 28 years old", "Age", false,
                new TriangularFunction(27, 28, 29));

            //pick summarizers
            const int nrOfS = 4;

            var summarizers = new List<LinguisticVariable>(nrOfS);
            foreach (var sum in Summarizers.GetAllVariables())
            {
                if (summarizers.Count >= nrOfS)
                    break;
                summarizers.Add(sum);
            }

            Oss.GenerateOneSubjectSentence(quantifier, new List<LinguisticVariable> {qualifier}, summarizers);
        }

        private void MultiSubjectSummariesTests()
        {
            Mss.GenerateAllFormsSentence(Mss.FifaPlayersAttackers, Mss.FifaPlayersDefenders, Quantifiers.AlmostAll,
                new List<LinguisticVariable> {Summarizers.AverageFinishing},
                new List<LinguisticVariable> {Summarizers.ShortHeight});

            // var measures = new Measures(Quantifiers.AlmostAll,
            //     new List<LinguisticVariable> {Summarizers.ShortHeight},
            //     new List<LinguisticVariable> {Summarizers.AverageFinishing}, Mss.FifaPlayersAttackers,
            //     Mss.FifaPlayersDefenders, null, 1);
            // measures.CountMeasuresMultiSubject();
            
        }
    }
}