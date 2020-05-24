using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie2_KSR
{
    public class Measures
    {
        public static double CountMeasures(LinguisticVariable quantifier, LinguisticVariable qualifier,
            List<LinguisticVariable> summarizers, string connector, List<FifaPlayer> fifaPlayers)
        {
            var t1 = DegreeOfTruth(fifaPlayers, quantifier, summarizers, qualifier, connector);
            var t2 = DegreeOfImprecision(fifaPlayers, summarizers);
            var t3 = DegreeOfCovering(fifaPlayers, summarizers, qualifier, connector);
            var t4 = DegreeOfAppropriateness(fifaPlayers, summarizers, t3);
            var t5 = LengthOfASummary(summarizers);
            var t6 = DegreeOfQuantifierImprecision(quantifier, fifaPlayers);
            var t7 = DegreeOfQuantifierCardinality(quantifier, fifaPlayers);
            var t8 = DegreeOfSummarizerCardinality(summarizers);
            var t9 = DegreeOfQualifierImprecision(qualifier, fifaPlayers);
            var t10 = DegreeOfQualifierCardinality(qualifier, fifaPlayers);
            var t11 = LengthOfQualifier(new List<LinguisticVariable> {qualifier});

            var measures16 = Math.Round(t1, 3) + " " + Math.Round(t2, 3) + " " + Math.Round(t3, 3) + " " +
                             Math.Round(t4, 3) + " " + Math.Round(t5, 3) + " " + Math.Round(t6, 3) + " " +
                             Math.Round(t7, 3) + " " + Math.Round(t8, 3) + " " + Math.Round(t9, 3) + " " +
                             Math.Round(t10, 3) + " " + Math.Round(t11, 3);

            var t =
                0.4 * t1 +
                0.06 * t2 +
                0.06 * t3 +
                0.06 * t4 +
                0.06 * t5 +
                0.06 * t6 +
                0.06 * t7 +
                0.06 * t8 +
                0.06 * t9 +
                0.06 * t10 +
                0.06 * t11;
            Console.WriteLine("[" + measures16 + "]" + " T = " + t);
            return t;
        }

        // counts value from all Linguistic variables with connector ( f.e. miS(di))
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

        // T1
        public static double DegreeOfTruth(List<FifaPlayer> fifaPlayers, LinguisticVariable quantifier,
            List<LinguisticVariable> summarizers, LinguisticVariable qualifier, string connector)
        {
            if (qualifier != null) // zdanie z kwalifikatorem
            {
                // nowa baza D' - strona  150 a.n.
                var fifaPlayersPrime = fifaPlayers
                    .Where(player => qualifier.CountMembership(player) > 0)
                    .ToList();

                // wzór na r
                double d = 0;
                double u = 0;
                foreach (var x in fifaPlayersPrime)
                {
                    u += Math.Min(qualifier.CountMembership(x), CountMembershipValue(summarizers, connector, x));
                    d += qualifier.CountMembership(x);
                }

                return quantifier.QuantifierAbsolute
                    ? quantifier.MembershipFunction.CountValue(u)
                    : quantifier.MembershipFunction.CountValue(u / d);
            }

            // zdanie bez kwalifikatora
            var r = fifaPlayers.Sum(x => CountMembershipValue(summarizers, connector, x));
            return quantifier.QuantifierAbsolute
                ? quantifier.MembershipFunction.CountValue(r)
                : quantifier.MembershipFunction.CountValue(r / fifaPlayers.Count);
        }


        // T2
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

        // T3
        public static double DegreeOfCovering(List<FifaPlayer> fifaPlayers,
            List<LinguisticVariable> summarizers, LinguisticVariable qualifier, string connector)
        {
            if (qualifier == null) // 8.44 8.47 8.48
            {
                double sumh = fifaPlayers.Count;
                double sumt = 0;
                foreach (var fp in fifaPlayers)
                {
                    var miS = CountMembershipValue(summarizers, connector, fp);
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
                    var miS = CountMembershipValue(summarizers, connector, fp);
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

        // T4
        public static double DegreeOfAppropriateness(List<FifaPlayer> fifaPlayers,
            List<LinguisticVariable> summarizers, double t3)
        {
            double mul = 1;
            foreach (var summarizer in summarizers)
            {
                mul *= CountRforT4(summarizer, fifaPlayers);
            }

            return Math.Abs(mul - t3);
        }

        private static double CountRforT4(LinguisticVariable summarizer,
            List<FifaPlayer> fifaPlayers)
        {
            double sumG = 0;
            foreach (var fp in fifaPlayers)
            {
                var miS = summarizer.CountMembership(fp);
                if (miS > 0)
                    sumG++;
            }

            return sumG / fifaPlayers.Count;
        }

        // T5
        public static double LengthOfASummary(List<LinguisticVariable> summarizers)
        {
            return 2 * Math.Pow(0.5, summarizers.Count);
        }

        // T6
        public static double DegreeOfQuantifierImprecision(LinguisticVariable quantifier, List<FifaPlayer> fifaPlayers)
        {
            FuzzySet fs;
            if (quantifier.QuantifierAbsolute)
                fs = new FuzzySet("Quantifier Absolute", quantifier.MembershipFunction);
            else
                fs = new FuzzySet("Quantifier", quantifier.MembershipFunction);
            return 1 - fs.DegreeOfFuzziness(fifaPlayers);
        }

        // T7
        public static double DegreeOfQuantifierCardinality(LinguisticVariable quantifier, List<FifaPlayer> fifaPlayers)
        {
            var x = quantifier.MembershipFunction.CountArea();
            return 1 - x / fifaPlayers.Count;
        }

        // T8
        public static double DegreeOfSummarizerCardinality(List<LinguisticVariable> summarizers)
        {
            double mul = 1;
            foreach (var summarizer in summarizers)
            {
                var sj = summarizer.MembershipFunction.CountArea();
                var x = summarizer.MembershipFunction.GetMax() - summarizer.MembershipFunction.GetMin();
                mul *= (sj / x);
            }

            return 1 - Math.Pow(mul, (double) 1 / summarizers.Count);
        }

        // T9
        public static double DegreeOfQualifierImprecision(LinguisticVariable qualifier, List<FifaPlayer> fifaPlayers)
        {
            // jeżeli będzie lista kwalifikatorów trzeba zmienić
            var fs = new FuzzySet(qualifier.AttributeName, qualifier.MembershipFunction);
            return 1 - fs.DegreeOfFuzziness(fifaPlayers);
        }

        // T10
        public static double DegreeOfQualifierCardinality(LinguisticVariable qualifier, List<FifaPlayer> fifaPlayers)
        {
            // jeżeli będzie lista kwalifikatorów trzeba zmienić
            var x = qualifier.MembershipFunction.CountArea();
            return 1 - x / fifaPlayers.Count;
        }

        // T11
        public static double LengthOfQualifier(List<LinguisticVariable> qualifiers)
        {
            // jeżeli będzie lista kwalifikatorów trzeba zmienić
            return 2 * Math.Pow(0.5, qualifiers.Count);
            //return 2 * Math.Pow(0.5, 1);
        }
    }
}