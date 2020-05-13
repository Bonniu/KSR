using System;
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


            foreach (var t in fifaPlayers)
            {
                Console.WriteLine(t.ToString());
            }

            foreach (var x in Attributes.Attributes.GetAllVariables())
            {
                Console.WriteLine(x.ToString());
            }

            
        }
    }
}