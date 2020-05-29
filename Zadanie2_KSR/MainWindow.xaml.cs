using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            var qualifiers = getQualifiersFromComboBoxes();
            var summarizers = getSummarizersFromComboBoxes();
            LinguisticVariable quantifier = null;
            if (QuantifierComboBox.SelectedItem != null)
            {
                quantifier = Quantifiers.GetQuantifierFromString(QuantifierComboBox.SelectedItem.ToString());
            }

            var type = 1;
            if (TypeComboBox.SelectedItem != null && TypeComboBox.SelectedItem.ToString() == "Multi Subject")
                type = 2;
            Console.WriteLine(qualifiers);
            Console.WriteLine(summarizers);
            Console.WriteLine(quantifier);
            Console.WriteLine(type);
        }

        private List<LinguisticVariable> getQualifiersFromComboBoxes()
        {
            var list = new List<LinguisticVariable>();
            if (Qualifier1ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Qualifier2ComboBox.SelectedItem).Content
                    .ToString()));
            if (Qualifier2ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Qualifier2ComboBox.SelectedItem).Content
                    .ToString()));
            if (Qualifier3ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Qualifier3ComboBox.SelectedItem).Content
                    .ToString()));
            if (Qualifier4ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Qualifier4ComboBox.SelectedItem).Content
                    .ToString()));
            if (Qualifier5ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Qualifier5ComboBox.SelectedItem).Content
                    .ToString()));
            return list.Count != 0 ? list : null;
        }

        private List<LinguisticVariable> getSummarizersFromComboBoxes()
        {
            var list = new List<LinguisticVariable>();
            if (Summarizer1ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Summarizer2ComboBox.SelectedItem).Content
                    .ToString()));
            if (Summarizer2ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Summarizer2ComboBox.SelectedItem).Content
                    .ToString()));
            if (Summarizer3ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Summarizer3ComboBox.SelectedItem).Content
                    .ToString()));
            if (Summarizer4ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Summarizer4ComboBox.SelectedItem).Content
                    .ToString()));
            if (Summarizer5ComboBox.SelectedItem != null)
                list.Add(Summarizers.GetVariableFromString(((ComboBoxItem) Summarizer5ComboBox.SelectedItem).Content
                    .ToString()));
            return list.Count != 0 ? list : null;
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


            // Qualifiers and Summarizers ComboBoxes
            foreach (var s in Summarizers.GetAllVariables())
            {
                Qualifier1ComboBox.Items.Add(newItem(s));
                Qualifier2ComboBox.Items.Add(newItem(s));
                Qualifier3ComboBox.Items.Add(newItem(s));
                Qualifier4ComboBox.Items.Add(newItem(s));
                Qualifier5ComboBox.Items.Add(newItem(s));
                Summarizer1ComboBox.Items.Add(newItem(s));
                Summarizer2ComboBox.Items.Add(newItem(s));
                Summarizer3ComboBox.Items.Add(newItem(s));
                Summarizer4ComboBox.Items.Add(newItem(s));
                Summarizer5ComboBox.Items.Add(newItem(s));
            }
        }

        private ComboBoxItem newItem(LinguisticVariable s)
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
            // Console.WriteLine("+" + TypeComboBox.SelectedItem.ToString() + "+");
            // if (TypeComboBox.SelectedItem.ToString().Contains("Multi Subject"))
            // {
            //     Console.WriteLine("MULTI");
            // }
            //
            // else
            // {
            //     Console.WriteLine("SINGLE");
            // }
        }
    }
}