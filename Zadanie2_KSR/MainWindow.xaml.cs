using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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

        public ObservableCollection<LinguisticVariable> LinguisticVariables;


        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxes();
            //GuiQuantifierComboBox_OnSelectedcVariables = new ObservableCollection<LinguisticVariable>(Summarizers.GetAllVariables());

            Mss.GenerateAllFormsSentence(Mss.FifaPlayersAttackers, Mss.FifaPlayersDefenders, Quantifiers.AlmostAll,
                new List<LinguisticVariable> {Summarizers.AverageFinishing},
                new List<LinguisticVariable> {Summarizers.ShortHeight});
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

        // on click Generate Summaries
        private void GenerateSummaries_OnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("GIT");
            Console.WriteLine("+" + HowManyQualifiersComboBox.SelectedItem + "+");
            Console.WriteLine("+" + HowManySummarizersComboBox.SelectedItem + "+");
        }

        private void InitializeComboBoxes()
        {
            // Quantifier
            foreach (var s in Quantifiers.GetAllQuantifiers())
            {
                QuantifierComboBox.Items.Add(s.Text);
            }

            // TypeComboBox 
            TypeComboBox.Items.Add("Multi Subject");
            TypeComboBox.Items.Add("One Subject");

            // HowMany ComboBoxes
            for (var i = 0; i < 5; i++)
            {
                HowManyQualifiersComboBox.Items.Add(i + 1);
                HowManySummarizersComboBox.Items.Add(i + 1);
            }
        }


        private void QuantifierComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(QuantifierComboBox.SelectedItem.ToString());
        }

        private void TypeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("+" + TypeComboBox.SelectedItem.ToString() + "+");
            if (TypeComboBox.SelectedItem.ToString().Contains("Multi Subject"))
                Console.WriteLine("MULTI");
            else
            {
                Console.WriteLine("SINGLE");
            }
        }

        private void HowManyQualifiersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Qualifiers");
            Console.WriteLine("+" + HowManyQualifiersComboBox.SelectedItem + "+");
        }

        private void HowManySummarizersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Summarizers");
            Console.WriteLine("+" + HowManySummarizersComboBox.SelectedItem + "+");
        }
    }
}