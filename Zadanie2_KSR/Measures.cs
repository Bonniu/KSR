using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace Zadanie2_KSR
{
    public class Measures
    {
        private static double CountMembershipValue(List<LinguisticVariable> list, string connector,
            FifaPlayer fifaPlayer)
        {
            //Console.WriteLine(list[0].CountMembership(fifaPlayer));
            if (connector == null || list.Count == 1)
                return list[0].CountMembership(fifaPlayer);
            if (connector.Contains("and"))
            {
                double min = 2;
                foreach (var summarizer in list)
                {
                    var t = summarizer.CountMembership(fifaPlayer);
                    if (t < min)
                        min = t;
                }
                return min;
            }
            // if (connector.Contains("or"))
            double max = -2;
            foreach (var summarizer in list)
            {
                var t = summarizer.CountMembership(fifaPlayer);
                if (t > max)
                    max = t;
            }

            return max;
        }

        // p. 156  - T1
        public static double DegreeOfTruth(List<FifaPlayer> fifaPlayers, LinguisticVariable quantifier,
            List<LinguisticVariable> summarizers, LinguisticVariable qualifier, string connector)
        {
            if (qualifier != null)
            {
                double d = 0;
                double u = 0;
                foreach (var x in fifaPlayers)
                {
                    u += Math.Min(qualifier.CountMembership(x), CountMembershipValue(summarizers, connector, x));
                    d += qualifier.CountMembership(x);
                }

                return quantifier.QuantifierAbsolute
                    ? quantifier.MembershipFunction.CountValue(u)
                    : quantifier.MembershipFunction.CountValue(u / d);
            }

            var r = fifaPlayers.Sum(x => CountMembershipValue(summarizers, connector, x));
            return quantifier.QuantifierAbsolute
                ? quantifier.MembershipFunction.CountValue(r)
                : quantifier.MembershipFunction.CountValue(r / fifaPlayers.Count);
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
                    var miS = CountMembershipValue(summarizers, "and", fp);
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
                    var miS = CountMembershipValue(summarizers, "and", fp);
                    var miW = qualifier.CountMembership(fp);
                    if (miW > 0)
                    {
                        sumh++;
                        if (miS > 0)
                            sumt++;
                    }
                }
                return sumt / sumh;
            }
        }
    }
}