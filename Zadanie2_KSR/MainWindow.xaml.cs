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


            var cs = new CsvReader();
            var fifaPlayers = cs.ReadCsvFile();
            for (int i = 0; i < fifaPlayers.Count; i++)
            {
                Console.WriteLine(fifaPlayers[i].ToString());
            }
        }
    }
}