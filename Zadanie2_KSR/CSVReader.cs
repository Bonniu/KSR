using System;
using System.Collections.Generic;
using System.IO;

namespace Zadanie2_KSR
{
    public class CsvReader
    {
        public List<FifaPlayer> ReadCsvFile()
        {
            using var reader = new StreamReader(@"..\..\..\data\players_10.csv");
            var list = new List<FifaPlayer>();
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

                list.Add(CreatePlayer(attributes));
            }

            return list;
        }

        private FifaPlayer CreatePlayer(List<int> values)
        {
            var fifaPlayerBuilder = new FifaPlayerBuilder();
            var fp = fifaPlayerBuilder.AddAge(values[0]).AddHeight(values[1]).AddWeight(values[2])
                .AddOverall(values[3]).AddFinishing(values[4]).AddDribbling(values[5]).AddCurve(values[6])
                .AddPassing(values[7]).AddSprintSpeed(values[8]).AddShotPower(values[9]).Build();
            return fp;
        }
    }
}