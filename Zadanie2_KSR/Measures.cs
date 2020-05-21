using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace Zadanie2_KSR
{
    public class Measures
    {
        public static double DegreeOfTruth(List<FifaPlayer> fifaPlayers, LinguisticVariable quantifier,
            LinguisticVariable summarizer)
        {
            double r = fifaPlayers.Sum(x => summarizer.CountMembership(x));
            return quantifier.QuantifierAbsolute
                ? quantifier.MembershipFunction.CountValue(r)
                : quantifier.MembershipFunction.CountValue(r / fifaPlayers.Count);
        }

        // p. 156  - T1 - Stopień prawdziwości
        public static double DegreeOfTruthSecond(List<FifaPlayer> fifaPlayers, LinguisticVariable quantifier,
            LinguisticVariable summarizer, LinguisticVariable qualifier)
        {
            double d = 0;
            double u = 0;
            foreach (var x in fifaPlayers)
            {
                u += Math.Min(qualifier.CountMembership(x), summarizer.CountMembership(x));
                d += qualifier.CountMembership(x);
            }
            return quantifier.QuantifierAbsolute
                ? quantifier.MembershipFunction.CountValue(u)
                : quantifier.MembershipFunction.CountValue(u / d);
        }
    }
}