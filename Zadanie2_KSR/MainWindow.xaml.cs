using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Zadanie2_KSR.Fuzzy;

namespace Zadanie2_KSR
{
    public partial class MainWindow
    {
        public static readonly List<FifaPlayer> FifaPlayers = new CsvReader().ReadCsvFile();
        public readonly OneSubjectSummaries Oss = new OneSubjectSummaries(FifaPlayers);
        public readonly MultiSubjectSummaries Mss = new MultiSubjectSummaries(FifaPlayers);
        private List<LinguisticVariable> _qualifiers;
        private List<LinguisticVariable> _quantifiers;
        private List<LinguisticVariable> _summarizers;

        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }


        // Combo Boxes ---------------
        private void InitializeComboBoxes()
        {
            // TypeComboBox 
            TypeComboBox.Items.Add("One-subject summaries");
            TypeComboBox.Items.Add("Two-subject summaries");
            TypeComboBox.SelectedIndex = 0;

            // Qualifiers and Summarizers ComboBoxes
            var listCb = new List<ComboBox>
            {
                Qualifier1ComboBox, Qualifier2ComboBox, Qualifier3ComboBox, Qualifier4ComboBox, Qualifier5ComboBox,
                Summarizer1ComboBox, Summarizer2ComboBox, Summarizer3ComboBox, Summarizer4ComboBox, Summarizer5ComboBox
            };
            foreach (var cb in listCb)
                cb.Items.Clear();
            foreach (var s in Summarizers.GetAllVariables())
            foreach (var cb in listCb)
                cb.Items.Add(NewItem(s));

            // P1 and P2 ComboBoxes
            var subjects = new List<string> {"Attackers", "Midfielders", "Defenders", "Goalkeepers"};
            P1ComboBox.Items.Clear();
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
                    n.Background = Brushes.LightSteelBlue;
                    return n;
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
            }

            else
            {
                P1ComboBox.Visibility = Visibility.Hidden;
                P1Label.Visibility = Visibility.Hidden;
                P2ComboBox.Visibility = Visibility.Hidden;
                P2Label.Visibility = Visibility.Hidden;
            }
        }

        // Buttons ----------------
        private void LoadDataSummarizers_OnClick(object sender, RoutedEventArgs e)
        {
            var loadedSummarizers = FileLoader.LoadDataFromFile("summarizers.txt");
            if (loadedSummarizers != null)
                SummarizersLabel.Content = loadedSummarizers.Count;
            else
                SummarizersLabel.Content = "0";
            _summarizers = loadedSummarizers;
        }

        private void LoadDataQualifiers_OnClick(object sender, RoutedEventArgs e)
        {
            var loadedQualifiers = FileLoader.LoadDataFromFile("qualifiers.txt");
            if (loadedQualifiers != null)
                QualifiersLabel.Content = loadedQualifiers.Count;
            else
                QualifiersLabel.Content = "0";
            _qualifiers = loadedQualifiers;
        }

        private void LoadDataQuantifiers_OnClick(object sender, RoutedEventArgs e)
        {
            var loadedQuantifiers = FileLoader.LoadDataFromFile("quantifiers.txt");
            if (loadedQuantifiers != null)
                QuantifierLabel.Content = loadedQuantifiers.Count;
            else
                QuantifierLabel.Content = "0";
            _quantifiers = loadedQuantifiers;
        }
        
        private void FillGridView(List<List<string>> results)
        {
            List<GridItem> list = new List<GridItem>();
            foreach (var result in results)
            {
                list.Add(new GridItem()
                {
                    Sentence = result[0],
                    T1 = result[1],
                    T2 = result[2],
                    T3 = result[3],
                    T4 = result[4],
                    T5 = result[5],
                    T6 = result[6],
                    T7 = result[7],
                    T8 = result[8],
                    T9 = result[9],
                    T10 = result[10],
                    T11 = result[11],
                    T = result[12]
                });
            }

            DataG.ItemsSource = list;
        }

        private void Reset_OnClick(object sender, RoutedEventArgs e)
        {
            QuantifierLabel.Content = "";
            QualifiersLabel.Content = "";
            SummarizersLabel.Content = "";
            _qualifiers = null;
            _quantifiers = null;
            _summarizers = null;
            TypeComboBox.SelectedIndex = 0;
            P1ComboBox.SelectedIndex = -1;
            P2ComboBox.SelectedIndex = -1;
            var weightBoxes = new List<TextBox> {Tb1, Tb2, Tb3, Tb4, Tb5, Tb6, Tb7, Tb8, Tb9, Tb10, Tb11};
            foreach (var tb in weightBoxes)
            {
                tb.Text = "";
            }

            var listCb = new List<ComboBox>
            {
                Qualifier1ComboBox, Qualifier2ComboBox, Qualifier3ComboBox, Qualifier4ComboBox, Qualifier5ComboBox,
                Summarizer1ComboBox, Summarizer2ComboBox, Summarizer3ComboBox, Summarizer4ComboBox, Summarizer5ComboBox
            };
            foreach (var cb in listCb)
            {
                cb.SelectedIndex = -1;
            }
        }


        //Main Button ----------------------------------------------------


        private void GenerateSummaries_OnClick(object sender, RoutedEventArgs e)
        {
            var list = GetQws();
            var quantifiersToUse = list[0];
            var qualifiersToUse = list[1];
            var summarizersToUse = list[2];

            List<double> weights = null;
            if (IfWeights.IsChecked != null && (bool) IfWeights.IsChecked)
                weights = GetWeightsFromTextBoxes();

            var type = 1;
            if (TypeComboBox.SelectedItem != null && TypeComboBox.SelectedItem.ToString().Contains("Two"))
                type = 2;

            //checks and generate
            if (summarizersToUse == null || quantifiersToUse == null)
                Console.WriteLine("ALERT - NIE MA WSZYSTKICH");
            else
            {
                List<List<string>> results;
                if (type == 1)
                {
                    results = Oss.GenerateOneSubjectSentences(summarizersToUse, quantifiersToUse, qualifiersToUse,
                        weights);
                }
                else
                {
                    results = Mss.GenerateAllFormsSentences(P1ComboBox.Text, P2ComboBox.Text,
                        quantifiersToUse, summarizersToUse, qualifiersToUse);
                    var resultsWithoutDuplicates = new List<List<string>>();
                    foreach (var x in results.Distinct())
                    {
                        if (!resultsWithoutDuplicates.Exists(t => t[0].Equals(x[0])))
                            resultsWithoutDuplicates.Add(x);
                    }
                    results = resultsWithoutDuplicates;
                }
                FillGridView(results);
                SaveResultsToFile(results);
            }
        }


        // others ------------
        private List<List<LinguisticVariable>> GetQws()
        {
            var qualifiersToUse = DecideWhichItemsUse(QualifiersLabel)
                ? _qualifiers
                : GetQualifiersFromComboBoxes();
            
            var summarizersToUse = DecideWhichItemsUse(SummarizersLabel)
                ? _summarizers
                : GetSummarizersFromComboBoxes();
            
            List<LinguisticVariable> quantifiersToUse;
            if (DecideWhichItemsUse(QuantifierLabel))
            {
                quantifiersToUse = _quantifiers;
            }
            else if (TypeComboBox.SelectedItem.ToString().Contains("Two") || qualifiersToUse != null)
            {
                quantifiersToUse = Quantifiers.GetRelativeQuantifiers();
            }
            else
            {
                quantifiersToUse = Quantifiers.GetAllQuantifiers();
            }

            
            
            return new List<List<LinguisticVariable>> {quantifiersToUse, qualifiersToUse, summarizersToUse};
        }

        private static bool DecideWhichItemsUse(ContentControl label)
        {
            if (label?.Content == null)
            {
                return false;
            }

            if (label.Content.ToString().Contains("0"))
            {
                return false;
            }

            if (label.Content.ToString().Equals(""))
            {
                return false;
            }

            return true;
        }

        private void PrintResults(List<List<string>> results)
        {
            foreach (var sentence in results)
            {
                foreach (var s in sentence)
                {
                    Console.Write(s + " ");
                }

                Console.WriteLine();
            }
        }

        private void SaveResultsToFile(List<List<string>> results)
        {
            var toSave = "";
            foreach (var sentence in results)
            {
                var text = "";
                foreach (var t in sentence)
                {
                    text += t + " ";
                }
                text += "\n";
                toSave += (text);
            }

            System.IO.File.WriteAllText("..\\..\\..\\generated_sentences.txt", toSave);
        }
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
    }
}