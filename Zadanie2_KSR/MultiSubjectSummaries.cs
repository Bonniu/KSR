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
        public string sentence;

        public MultiSubjectSummaries(List<FifaPlayer> fifaPlayers)
        {
            FifaPlayers = fifaPlayers;
            FifaPlayersGoalkeepers = FifaPlayers.FindAll(x => x.GetPosition() == "Goalkeeper");
            FifaPlayersDefenders = FifaPlayers.FindAll(x => x.GetPosition() == "Defender");
            FifaPlayersMidfielders = FifaPlayers.FindAll(x => x.GetPosition() == "Midfielder");
            FifaPlayersAttackers = FifaPlayers.FindAll(x => x.GetPosition() == "Attacker");
        }


        // Q P1 w porównaniu do P2 ma S
        public string GenerateSentenceFirstForm(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers)
        {
            if (quantifier.QuantifierAbsolute)
                return "err";
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = quantifier.Text + " of " + p1Plural + " in comparision to " + p2Plural + " ";
            text += ListToStringConverter.ConvertSummarizersToString(summarizers) + ".";
            sentence = text;
            return text;
        }

        // Q P1 w porównaniu do tych P2, które są W, ma S
        public string GenerateSentenceSecondForm(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            if (quantifier.QuantifierAbsolute)
                return "err";
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = quantifier.Text + " of " + p1Plural + " in comparision to those " + p2Plural + ", who ";
            text += ListToStringConverter.ConvertSummarizersToString(qualifiers) + ", ";
            text += ListToStringConverter.ConvertSummarizersToString(summarizers) + ".";
            sentence = text;
            return text;
        }

        // Q P1, które są W, w porównaniu P2, ma S
        public string GenerateSentenceThirdForm(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            if (quantifier.QuantifierAbsolute)
                return "err";
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = quantifier.Text + " of those " + p1Plural + ", who ";
            text += ListToStringConverter.ConvertSummarizersToString(qualifiers) + ", ";
            text += "in comparision to " + p2Plural + ", ";
            text += ListToStringConverter.ConvertSummarizersToString(summarizers) + ".";
            sentence = text;
            return text;
        }

        // Więcej P1 niż P2 ma S
        public string GenerateSentenceFourthForm(List<FifaPlayer> p1, List<FifaPlayer> p2,
            List<LinguisticVariable> summarizers)
        {
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = "More " + p1Plural + " than " + p2Plural + " ";
            text += ListToStringConverter.ConvertSummarizersToString(summarizers) + ".";
            sentence = text;
            return text;
        }

        public void GenerateAllFormsSentence(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            Console.WriteLine(GenerateSentenceFirstForm(p1, p2, quantifier, summarizers));
            Console.WriteLine(GenerateSentenceSecondForm(p1, p2, quantifier, summarizers, qualifiers));
            Console.WriteLine(GenerateSentenceThirdForm(p1, p2, quantifier, summarizers, qualifiers));
            Console.WriteLine(GenerateSentenceFourthForm(p1, p2, summarizers));
        }

        private static string ConvertToPluralForm(string pos)
        {
            return pos.Substring(0, 1).ToLower() + pos.Substring(1) + "s";
        }
    }
}