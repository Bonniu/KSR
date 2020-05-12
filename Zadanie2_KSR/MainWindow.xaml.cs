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
            FifaPlayerBuilder fpb = new FifaPlayerBuilder();
            fpb.addCurve(22);
            Console.WriteLine(fpb.ToString());
            Console.WriteLine(fpb.build().ToString());
            InitializeComponent();
            Console.WriteLine("Hello world!");
            CSVReader cs = new CSVReader();
            cs.intr();
        }
    }
}