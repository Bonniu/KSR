using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace Zadanie2_KSR
{
    public class CSVReader
    {
        public void intr()
        {
            using var reader = new StreamReader(@"..\..\..\data\players_10.csv");
            while (!reader.EndOfStream)
            {
                var attributes = new List<int>();
                var line = reader.ReadLine();
                if (line == null) continue;
                var lineValues = line.Split(';');
                if (lineValues[0] == "age") continue;
                for (var i = 0; i < 10; i++)
                {
                    attributes.Add(Convert.ToInt32(lineValues[i]));
                }
                CreatePlayer(attributes);
            }
        }

        private void CreatePlayer(List<int> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                Console.Write(values[i] + " ");
            }
            Console.WriteLine("\n");
        }
    }
}