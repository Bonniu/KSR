using System;
using System.Collections.Generic;
using System.Globalization;

namespace Zadanie2_KSR.Fuzzy
{
    public class OneSubjectSummaries
    {
        private readonly List<FifaPlayer> _fifaPlayers;

        public OneSubjectSummaries(List<FifaPlayer> fifaPlayers)
        {
            _fifaPlayers = fifaPlayers;
        }

        public List<List<string>> GenerateOneSubjectSentences(List<LinguisticVariable> summarizers,
            LinguisticVariable quantifier, List<LinguisticVariable> qualifiers, List<double> weights)
        {
            var allSentences = new List<List<string>>();
            List<string> indexesQualifiers = null;
            if (qualifiers != null)
                indexesQualifiers = GetIndexes(qualifiers.Count);

            var indexesSummarizers = GetIndexes(summarizers.Count);
            for (var s = 0; s < indexesSummarizers.Count; s++)
            {
                var oneSentenceSummarizers = GetElementsFromIndex(indexesSummarizers[s], summarizers);
                if (indexesQualifiers == null)
                    allSentences.Add(GenerateOneSubjectSentence(quantifier, null, oneSentenceSummarizers, weights));
                else
                {
                    for (int w = 0; w < indexesQualifiers.Count; w++)
                    {
                        var oneSentenceQualifiers = GetElementsFromIndex(indexesQualifiers[w], qualifiers);
                        allSentences.Add(GenerateOneSubjectSentence(quantifier, oneSentenceQualifiers,
                            oneSentenceSummarizers, weights));
                    }
                }
            }

            return allSentences;
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

        // 0 - sentence, 1-11 - t1-t11 , 12 - sumT
        public List<string> GenerateOneSubjectSentence(LinguisticVariable quantifier,
            List<LinguisticVariable> qualifiers,
            List<LinguisticVariable> summarizers, List<double> weights)
        {
            var startText = quantifier.Text + " of football players ";
            if (qualifiers != null)
                startText += ", which " + ListToStringConverter.ConvertSummarizersToString(qualifiers) + ", ";

            startText += ListToStringConverter.ConvertSummarizersToString(summarizers) + ".";

            var returnList = new List<string> {startText};
            var measures = new Measures(quantifier, qualifiers, summarizers, _fifaPlayers, weights);
            foreach (var m in measures.CountMeasuresOneSubject())
            {
                returnList.Add(m.ToString(CultureInfo.InvariantCulture));
            }

            return returnList;
        }
    }
}