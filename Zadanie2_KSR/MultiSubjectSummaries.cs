using System;
using System.Collections.Generic;

namespace Zadanie2_KSR
{
    public class MultiSubjectSummaries
    {
        public readonly List<FifaPlayer> FifaPlayers;
        public readonly List<FifaPlayer> FifaPlayersGoalkeepers;
        public readonly List<FifaPlayer> FifaPlayersDefenders;
        public readonly List<FifaPlayer> FifaPlayersMidfielders;
        public readonly List<FifaPlayer> FifaPlayersAttackers;

        public MultiSubjectSummaries(List<FifaPlayer> fifaPlayers)
        {
            FifaPlayers = fifaPlayers;
            FifaPlayersGoalkeepers = FifaPlayers.FindAll(x => x.GetPosition() == "Goalkeeper");
            FifaPlayersDefenders = FifaPlayers.FindAll(x => x.GetPosition() == "Defender");
            FifaPlayersMidfielders = FifaPlayers.FindAll(x => x.GetPosition() == "Midfielder");
            FifaPlayersAttackers = FifaPlayers.FindAll(x => x.GetPosition() == "Attacker");
        }


        // Q P1 w porównaniu do P2 ma S
        public string GenerateSentenceFirst(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers)
        {
            if (quantifier.QuantifierAbsolute)
                return "err";
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = quantifier.Text + " of " + p1Plural + " in comparision to " + p2Plural + " ";
            text += ConvertListToString(summarizers) + ".";
            Console.WriteLine(text);
            return text;
        }

        // Q P1 w porównaniu do tych P2, które są W, ma S
        public string GenerateSentenceSecond(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            if (quantifier.QuantifierAbsolute)
                return "err";
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = quantifier.Text + " of " + p1Plural + " in comparision to those " + p2Plural + ", who ";
            text += ConvertListToString(qualifiers) + ", ";
            text += ConvertListToString(summarizers) + ".";
            Console.WriteLine(text);
            return text;
        }

        // Q P1, które są W, w porównaniu P2, ma S
        public string GenerateSentenceThird(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            if (quantifier.QuantifierAbsolute)
                return "err";
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = quantifier.Text + " of those " + p1Plural + ", who ";
            text += ConvertListToString(qualifiers) + ", ";
            text += "in comparision to " + p2Plural + ", ";
            text += ConvertListToString(summarizers) + ".";
            Console.WriteLine(text);
            return text;
        }

        // Więcej P1 niż P2 ma S
        public string GenerateSentenceFourth(List<FifaPlayer> p1, List<FifaPlayer> p2,
            List<LinguisticVariable> summarizers)
        {
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = "More " + p1Plural + " than " + p2Plural + " ";
            text += ConvertListToString(summarizers) + ".";
            Console.WriteLine(text);
            return text;
        }

        private string ConvertToPluralForm(string pos)
        {
            return pos.Substring(0, 1).ToLower() + pos.Substring(1) + "s";
        }

        public static string ConvertListToString(IReadOnlyList<LinguisticVariable> list)
        {
            var text = list[0].Type + " " + list[0].Text;
            for (var i = 1; i < list.Count; i++)
            {
                text += " and " + list[i].Type + " " + list[i].Text;
            }

            return text;
        }
    }
}