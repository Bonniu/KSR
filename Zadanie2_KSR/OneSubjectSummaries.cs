using System;
using System.Collections.Generic;

namespace Zadanie2_KSR
{
    public class OneSubjectSummaries
    {
        public readonly List<FifaPlayer> FifaPlayers;

        public OneSubjectSummaries(List<FifaPlayer> fifaPlayers)
        {
            FifaPlayers = fifaPlayers;
        }

        // private void GenerateOneSubjectSentences(List<LinguisticVariable> attributes,
        //     List<LinguisticVariable> quantifiers,
        //     LinguisticVariable qualifier)
        // {
        //     foreach (var q in quantifiers)
        //     {
        //         foreach (var y in attributes)
        //         {
        //             GenerateOneSubjectSentence(q, qualifier, new List<LinguisticVariable>() {y}, null);
        //         }
        //     }
        // }


        public void GenerateOneSubjectSentence(LinguisticVariable quantifier, List<LinguisticVariable> qualifiers,
            List<LinguisticVariable> features)
        {
            var startText = quantifier.Text + " of football players";
            if (qualifiers != null)
                startText += ", which " + ListToStringConverter.ConvertSummarizersToString(qualifiers) + ", ";

            startText += ListToStringConverter.ConvertSummarizersToString(features) + ".";
            Console.WriteLine(startText);
            var measures = new Measures(quantifier, qualifiers, features, FifaPlayers, null);
            measures.CountMeasuresOneSubject();
        }
    }
}