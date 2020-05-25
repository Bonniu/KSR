using System;
using System.Collections.Generic;
using System.IO;

namespace Zadanie2_KSR
{
    public class CsvReader
    {
        public List<FifaPlayer> ReadCsvFile()
        {
            using var reader = new StreamReader(@"..\..\..\data\players_10_positions.csv");
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

                var position = GetPositionFromString(lineValues[11].Split(" ")[0]);

                list.Add(CreatePlayer(attributes, position));
            }

            return list;
        }

        private FifaPlayer CreatePlayer(List<int> values, string position)
        {
            var fifaPlayerBuilder = new FifaPlayerBuilder();
            var fp = fifaPlayerBuilder.AddAge(values[0]).AddHeight(values[1]).AddWeight(values[2])
                .AddOverall(values[3]).AddFinishing(values[4]).AddDribbling(values[5]).AddCurve(values[6])
                .AddPassing(values[7]).AddSprintSpeed(values[8]).AddShotPower(values[9]).AddPosition(position).Build();
            return fp;
        }

        private string GetPositionFromString(string position)
        {
            switch (position)
            {
                case "GK":
                    return "Goalkeeper";
                case "CB":
                case "LB":
                case "RB":
                case "RWB":
                case "LWB":
                    return "Defender";
                case "CAM":
                case "CM":
                case "LM":
                case "RM":
                case "CDM":
                    return "Midfielder";
                case "ST":
                case "CF":
                case "LW":
                case "RW":
                    return "Attacker";
                default:
                    return "null";
            }
        }
    }
}