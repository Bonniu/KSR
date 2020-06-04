using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Zadanie2_KSR.Fuzzy
{
    public class MultiSubjectSummaries
    {
        public static List<FifaPlayer> FifaPlayers;
        public static List<FifaPlayer> FifaPlayersGoalkeepers;
        public static List<FifaPlayer> FifaPlayersDefenders;
        public static List<FifaPlayer> FifaPlayersMidfielders;
        public static List<FifaPlayer> FifaPlayersAttackers;
        public string generatedSentence;

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
            generatedSentence = text;
            return text;
        }

        // Q P1 w porównaniu do tych P2, które są W, ma S
        public string GenerateSentenceSecondForm(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            if (quantifier.QuantifierAbsolute || qualifiers == null)
                return "err";
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = quantifier.Text + " of " + p1Plural + " in comparision to those " + p2Plural + ", who ";
            text += ListToStringConverter.ConvertSummarizersToString(qualifiers) + ", ";
            text += ListToStringConverter.ConvertSummarizersToString(summarizers) + ".";
            generatedSentence = text;
            return text;
        }

        // Q P1, które są W, w porównaniu P2, ma S
        public string GenerateSentenceThirdForm(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            if (quantifier.QuantifierAbsolute || qualifiers == null)
                return "err";
            var p1Plural = ConvertToPluralForm(p1[0].GetPosition());
            var p2Plural = ConvertToPluralForm(p2[0].GetPosition());
            var text = quantifier.Text + " of those " + p1Plural + ", who ";
            text += ListToStringConverter.ConvertSummarizersToString(qualifiers) + ", ";
            text += "in comparision to " + p2Plural + ", ";
            text += ListToStringConverter.ConvertSummarizersToString(summarizers) + ".";
            generatedSentence = text;
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
            generatedSentence = text;
            return text;
        }

        public List<List<string>> GenerateAllFormsSentence(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            var returnList = new List<List<string>>();
            Measures measures;
            for (int t = 1; t <= 4; t++)
            {
                var sentence = new List<string>();
                measures = new Measures(quantifier, qualifiers, summarizers, p1, p2, null, t);
                switch (t)
                {
                    case 1:
                        sentence.Add(GenerateSentenceFirstForm(p1, p2, quantifier, summarizers));
                        break;
                    case 2:
                        sentence.Add(GenerateSentenceSecondForm(p1, p2, quantifier, summarizers, qualifiers));
                        break;
                    case 3:
                        sentence.Add(GenerateSentenceThirdForm(p1, p2, quantifier, summarizers, qualifiers));
                        break;
                    case 4:
                        sentence.Add(GenerateSentenceFourthForm(p1, p2, summarizers));
                        break;
                }

                if (sentence[^1] != "err")
                {
                    sentence.Add(measures.CountMeasuresMultiSubject().ToString(CultureInfo.InvariantCulture));
                    for (var i = 2; i <= 11; i++)
                        sentence.Add("-");
                    sentence.Add(sentence[1]);
                    returnList.Add(sentence);
                }
            }
            return returnList;
        }

        public List<List<string>> GenerateAllFormsSentences(string p1Text, string p2Text,
            List<LinguisticVariable> quantifiers, List<LinguisticVariable> summarizers,
            List<LinguisticVariable> qualifiers)
        {
            var p1 = GetPlayersByString(p1Text);
            var p2 = GetPlayersByString(p2Text);
            var allSentences = new List<List<string>>();
            List<string> indexesQualifiers = null;
            if (qualifiers != null)
                indexesQualifiers = GetIndexes(qualifiers.Count);

            var indexesSummarizers = GetIndexes(summarizers.Count);
            foreach (var quantifier in quantifiers)
            {
                for (var s = 0; s < indexesSummarizers.Count; s++)
                {
                    var oneSentenceSummarizers = GetElementsFromIndex(indexesSummarizers[s], summarizers);
                    if (indexesQualifiers == null)
                        allSentences.AddRange(
                            GenerateAllFormsSentence(p1, p2, quantifier, oneSentenceSummarizers, null));
                    else
                    {
                        for (int w = 0; w < indexesQualifiers.Count; w++)
                        {
                            var oneSentenceQualifiers = GetElementsFromIndex(indexesQualifiers[w], qualifiers);
                            allSentences.AddRange(GenerateAllFormsSentence(p1, p2, quantifier, oneSentenceSummarizers,
                                oneSentenceQualifiers));
                        }
                    }
                }
            }

            return allSentences;
        }

        private static string ConvertToPluralForm(string pos)
        {
            return pos.Substring(0, 1).ToLower() + pos.Substring(1) + "s";
        }

        private static List<string> GetIndexes(int listSize)
        {
            var previous = new List<string>();
            for (var i = 0; i < listSize; i++)
            {
                var current = new List<string>();
                current.AddRange(previous); // dodanie poprzedniej listy
                current.Add(i.ToString()); // dodanie biezacego elementu
                foreach (var s in previous) // dodanie biezacego elementu do kazdego elementu z poprzeniej listy
                    current.Add(s + i);
                previous = current;
            }

            return previous;
        }

        private static List<LinguisticVariable> GetElementsFromIndex(string index, List<LinguisticVariable> list)
        {
            var returnList = new List<LinguisticVariable>();
            foreach (var c in index.ToCharArray())
                returnList.Add(list[int.Parse(c.ToString())]);

            return returnList;
        }

        private static List<FifaPlayer> GetPlayersByString(string text)
        {
            return text switch
            {
                "Defenders" => FifaPlayersDefenders,
                "Attackers" => FifaPlayersAttackers,
                "Goalkeepers" => FifaPlayersGoalkeepers,
                "Midfielders" => FifaPlayersMidfielders,
                _ => FifaPlayers
            };
        }
    }
}