using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Zadanie2_KSR.Fuzzy;
using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR
{
    public partial class MainWindow : Window
    {
        private const int M = 18728;
        public static readonly List<FifaPlayer> FifaPlayers = new CsvReader().ReadCsvFile();
        public readonly OneSubjectSummaries Oss = new OneSubjectSummaries(FifaPlayers);
        public readonly MultiSubjectSummaries Mss = new MultiSubjectSummaries(FifaPlayers);

        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxes();

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


        // Combo Boxes ---------------
        private void InitializeComboBoxes()
        {
            // Quantifier
            foreach (var s in Quantifiers.GetAllQuantifiers())
            {
                QuantifierComboBox.Items.Add(s.Text);
            }

            // TypeComboBox 
            TypeComboBox.Items.Add("One-subject summaries");
            TypeComboBox.Items.Add("Two-subject summaries");

            // Qualifiers and Summarizers ComboBoxes
            var listCb = new List<ComboBox>
            {
                Qualifier1ComboBox, Qualifier2ComboBox, Qualifier3ComboBox, Qualifier4ComboBox, Qualifier5ComboBox,
                Summarizer1ComboBox, Summarizer2ComboBox, Summarizer3ComboBox, Summarizer4ComboBox, Summarizer5ComboBox
            };
            foreach (var s in Summarizers.GetAllVariables())
            foreach (var cb in listCb)
                cb.Items.Add(NewItem(s));

            // P1 and P2 ComboBoxes
            var subjects = new List<string> {"Attackers", "Midfielders", "Defenders", "Goalkeepers"};
            foreach (var subject in subjects)
            {
                P1ComboBox.Items.Add(subject);
                P2ComboBox.Items.Add(subject);
            }
        }

        [SuppressMessage("ReSharper", "ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator")]
        private List<LinguisticVariable> GetQualifiersFromComboBoxes()
        {
            var listCb = new List<ComboBox>
                {Qualifier1ComboBox, Qualifier2ComboBox, Qualifier3ComboBox, Qualifier4ComboBox, Qualifier5ComboBox};
            var list = new List<LinguisticVariable>();
            foreach (var cb in listCb)
            {
                if (cb.SelectedItem != null)
                    list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) cb.SelectedItem).Content
                        .ToString()));
            }

            return list.Count != 0 ? list : null;
        }

        [SuppressMessage("ReSharper", "ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator")]
        private List<LinguisticVariable> GetSummarizersFromComboBoxes()
        {
            var listCb = new List<ComboBox>
            {
                Summarizer1ComboBox, Summarizer2ComboBox, Summarizer3ComboBox, Summarizer4ComboBox, Summarizer5ComboBox
            };
            var list = new List<LinguisticVariable>();
            foreach (var cb in listCb)
            {
                if (cb.SelectedItem != null)
                    list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) cb.SelectedItem).Content
                        .ToString()));
            }

            return list.Count != 0 ? list : null;
        }

        private static ComboBoxItem NewItem(LinguisticVariable s)
        {
            var n = new ComboBoxItem {Content = s.Text};
            switch (s.AttributeName)
            {
                case "Age":
                    n.Background = Brushes.Aqua;
                    return n;
                case "Height":
                    n.Background = Brushes.Coral;
                    return n;
                case "Weight":
                    n.Background = Brushes.Khaki;
                    return n;
                case "Overall":
                    n.Background = Brushes.Chocolate;
                    return n;
                case "Finishing":
                    n.Background = Brushes.Chartreuse;
                    return n;
                case "Dribbling":
                    n.Background = Brushes.Pink;
                    return n;
                case "Curve":
                    n.Background = Brushes.BlueViolet;
                    return n;
                case "LongPassing":
                    n.Background = Brushes.PowderBlue;
                    return n;
                case "Sprint":
                    n.Background = Brushes.PaleGreen;
                    return n;
                case "ShotPower":
                default:
                    return n;
            }
        }

        private void TypeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (TypeComboBox.SelectedItem.ToString().Contains("Two"))
            {
                P1ComboBox.Visibility = Visibility.Visible;
                P1Label.Visibility = Visibility.Visible;
                P2ComboBox.Visibility = Visibility.Visible;
                P2Label.Visibility = Visibility.Visible;

                QuantifierComboBox.Items.Clear();
                foreach (var s in Quantifiers.GetRelativeQuantifiers())
                {
                    QuantifierComboBox.Items.Add(s.Text);
                }
            }

            else
            {
                P1ComboBox.Visibility = Visibility.Hidden;
                P1Label.Visibility = Visibility.Hidden;
                P2ComboBox.Visibility = Visibility.Hidden;
                P2Label.Visibility = Visibility.Hidden;

                QuantifierComboBox.Items.Clear();
                foreach (var s in Quantifiers.GetAllQuantifiers())
                {
                    QuantifierComboBox.Items.Add(s.Text);
                }
            }
        }

        // Buttons ----------------
        private void LoadDataSummarizers_OnClick(object sender, RoutedEventArgs e)
        {
            //var summarizers = FileLoader.LoadSummarizers();
            //SummarizersLabel.Content = summarizers.Count;
            SummarizersLabel.Content = "True";
        }

        private void LoadDataQualifiers_OnClick(object sender, RoutedEventArgs e)
        {
            //var qualifiers = FileLoader.LoadQualifiers();
            //QualifiersLabel.Content = qualifiers.Count;
            QualifiersLabel.Content = "True";
        }

        private void LoadDataQuantifier_OnClick(object sender, RoutedEventArgs e)
        {
            //var qualifier = FileLoader.LoadQualifiers();
            //QuantifierLabel.Content = (qualifier != null);
            QualifiersLabel.Content = "True";
        }
        //Main Button ----------------------------------------------------
        private void GenerateSummaries_OnClick(object sender, RoutedEventArgs e)
        {
            var qualifiers = GetQualifiersFromComboBoxes();

            var summarizers = GetSummarizersFromComboBoxes();

            List<double> weights = null;
            if (IfWeights.IsChecked != null && (bool) IfWeights.IsChecked)
                weights = GetWeightsFromTextBoxes();

            LinguisticVariable quantifier = null;
            if (QuantifierComboBox.SelectedItem != null)
                quantifier = Quantifiers.GetQuantifierFromString(QuantifierComboBox.SelectedItem.ToString());


            var type = 1;
            if (TypeComboBox.SelectedItem != null && TypeComboBox.SelectedItem.ToString() == "Multi Subject")
                type = 2;

            //checks and generate
            if (summarizers == null || quantifier == null)
                Console.WriteLine("ALERT - NIE MA WSZYSTKICH");
            else
            {
                Console.WriteLine("Qualifiers: " + qualifiers != null);
                Console.WriteLine(summarizers);
                Console.WriteLine(quantifier);
                Console.WriteLine(type);
                Console.WriteLine(weights);
            }
        }

        // others ------------
        private void IfWeights_OnFocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var weightBoxes = new List<TextBox> {Tb1, Tb2, Tb3, Tb4, Tb5, Tb6, Tb7, Tb8, Tb9, Tb10, Tb11};
            var labelsWeights = new List<Label> {T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11};
            if (IfWeights.IsChecked != null && (bool) IfWeights.IsChecked)
            {
                foreach (var tb in weightBoxes)
                    tb.Visibility = Visibility.Hidden;
                foreach (var lw in labelsWeights)
                    lw.Visibility = Visibility.Hidden;
            }
            else
            {
                foreach (var tb in weightBoxes)
                    tb.Visibility = Visibility.Visible;
                foreach (var lw in labelsWeights)
                    lw.Visibility = Visibility.Visible;
            }
        }

        private List<double> GetWeightsFromTextBoxes()
        {
            var weightBoxes = new List<TextBox> {Tb1, Tb2, Tb3, Tb4, Tb5, Tb6, Tb7, Tb8, Tb9, Tb10, Tb11};
            var list = new List<double>();
            var sum = 0d;
            foreach (var weight in weightBoxes)
            {
                try
                {
                    var number = double.Parse(weight.Text.Replace(".", ","));
                    sum += number;
                    list.Add(number);
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return list.Count == 11 && Math.Abs(sum - 1) < 0.00001 ? list : null;
        }


//  ---------------------------------------------------------------- DO TESTÓW -----------------------------
        private void GuiLike()
        {
            // pick quantifier
            var quantifier =
                new LinguisticVariable("About one third", "Quantifier", false,
                    new TrapezoidalFunction(0.25, 0.28, 0.32, 0.35));

            //pick qualifiers or null            
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
    }
}