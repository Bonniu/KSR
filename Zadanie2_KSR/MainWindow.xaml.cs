using System;
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
        public readonly List<FifaPlayer> FifaPlayers = new CsvReader().ReadCsvFile();

        public MainWindow()
        {
            InitializeComponent();
            CheckPositions();
            //GuiLike();
            GenerateSentencesSecond(Summarizers.GetAllDribblingVariables(),
                Quantifier.GetRelativeQuantifiers(),
                new LinguisticVariable("quite high", "Height", true,
                    new TrapezoidalFunction(180, 182, 188, 190)));
        }

        private void GenerateSentencesSecond(List<LinguisticVariable> attributes, List<LinguisticVariable> quantifiers,
            LinguisticVariable qualifier)
        {
            foreach (var q in quantifiers)
            {
                foreach (var y in attributes)
                {
                    BuildOneSubjectSentence(q, qualifier, new List<LinguisticVariable>() {y}, null);
                }
            }
        }


        private void BuildOneSubjectSentence(LinguisticVariable quantifier, LinguisticVariable qualifier,
            List<LinguisticVariable> features, string connector)
        {
            var startText = quantifier.Text + " of ";
            if (qualifier == null)
                startText += " football players ";

            else
                startText += qualifier.Text + " football players ";


            startText += features[0].Type + " " + features[0].Text;
            for (var i = 1; i < features.Count; i++)
            {
                startText += connector + features[i].Type + " " + features[i].Text;
            }

            startText += ".";
            Console.WriteLine(startText);
            Measures.CountMeasures(quantifier, qualifier, features, connector, FifaPlayers);
        }


        //  ---------------------------------------------------------------- DO TESTÓW -----------------------------
        private void GuiLike()
        {
            // pick quantifier
            LinguisticVariable quantifier =
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

            // pick AND or OR
            var connector = " and ";
            if (nrOfS == 2)
                connector = " or "; // można zmienić jak nrOfS == 2

            BuildOneSubjectSentence(quantifier, qualifier, summarizers, connector);
        }

        // sprawdzenie, czy pozycje sa all
        private void CheckPositions()
        {
            var gk = FifaPlayers.FindAll(x => x.GetPosition() == "Goalkeeper").Count;
            var md = FifaPlayers.FindAll(x => x.GetPosition() == "Midfielder").Count;
            var df = FifaPlayers.FindAll(x => x.GetPosition() == "Defender").Count;
            var at = FifaPlayers.FindAll(x => x.GetPosition() == "Attacker").Count;
            Console.WriteLine(gk + df + md + at == FifaPlayers.Count);
        }
    }
}