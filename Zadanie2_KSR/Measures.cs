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

        // p. 156  - T1
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

        // p. 156  - T2
        public static double DegreeOfImprecision(List<FifaPlayer> fifaPlayers, List<LinguisticVariable> summarizers)
        {
            double mul = 1;
            foreach (var summarizer in summarizers)
            {
                FuzzySet fuzzySet = new FuzzySet(summarizer.AttributeName, summarizer.MembershipFunction);
                mul *= fuzzySet.DegreeOfFuzziness(fifaPlayers);
            }

            return 1 - Math.Pow(mul, (double) 1 / summarizers.Count);
        }

        // p. 157  - T3
        public static double DegreeOfCovering(List<FifaPlayer> fifaPlayers,
            List<LinguisticVariable> summarizers, LinguisticVariable qualifier)
        {
            if (qualifier == null) // 8.44 8.47 8.48
            {
                double sumh = fifaPlayers.Count;
                double sumt = 0;
                foreach (var fp in fifaPlayers)
                {
                    var miS = FuzzySet.CountMembershipAnd(summarizers, fp);
                    if (miS > 0)
                        sumt++;
                }

                return sumt / sumh;
            }
            else // 8.44 8.45 8.46
            {
                double sumh = 0;
                double sumt = 0;
                foreach (var fp in fifaPlayers)
                {
                    double miS = FuzzySet.CountMembershipAnd(summarizers, fp);
                    double miW = FuzzySet.CountMembershipAnd(new List<LinguisticVariable>() {qualifier}, fp);
                    if (miW > 0)
                    {
                        sumh++;
                        if (miS > 0)
                        {
                            sumt++;
                        }
                    }
                }

                return sumt / sumh;
            }
        }
    }
}