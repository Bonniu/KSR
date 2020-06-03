using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Zadanie2_KSR.Fuzzy
{
    public class Measures
    {
        private LinguisticVariable _quantifier;
        private List<LinguisticVariable> _qualifiers;
        private List<LinguisticVariable> _summarizers;
        private readonly List<FifaPlayer> _fifaPlayers;
        private readonly List<FifaPlayer> _p1;
        private readonly List<FifaPlayer> _p2;
        private List<double> _weights;
        private readonly int _type;

        // One subject summaries
        public Measures(LinguisticVariable quantifier, List<LinguisticVariable> qualifiers,
            List<LinguisticVariable> summarizers, List<FifaPlayer> fifaPlayers, List<double> weights)
        {
            SetFields(quantifier, qualifiers, summarizers, weights);
            _fifaPlayers = fifaPlayers;
            _weights = weights;
        }

        // Multi subject summaries
        public Measures(LinguisticVariable quantifier, List<LinguisticVariable> qualifiers,
            List<LinguisticVariable> summarizers, List<FifaPlayer> p1, List<FifaPlayer> p2, List<double> wages,
            int type)
        {
            SetFields(quantifier, qualifiers, summarizers, wages);
            _fifaPlayers = new List<FifaPlayer>();
            _fifaPlayers.AddRange(p1);
            _fifaPlayers.AddRange(p2);
            _p1 = p1;
            _p2 = p2;
            _type = type;
        }


        [SuppressMessage("ReSharper", "ParameterHidesMember")]
        private void SetFields(
            LinguisticVariable quantifier, List<LinguisticVariable> qualifiers,
            List<LinguisticVariable> summarizers, List<double> wages)
        {
            _quantifier = quantifier;
            _qualifiers = qualifiers;
            _summarizers = summarizers;
            _weights = wages;
        }

        public List<double> CountMeasuresOneSubject()
        {
            var t1 = DegreeOfTruth(_fifaPlayers, _quantifier, _summarizers, _qualifiers);
            var t2 = DegreeOfImprecision(_fifaPlayers, _summarizers);
            var t3 = DegreeOfCovering(_fifaPlayers, _summarizers, _qualifiers);
            var t4 = DegreeOfAppropriateness(_fifaPlayers, _summarizers, t3);
            var t5 = LengthOfASummary(_summarizers);
            var t6 = DegreeOfQuantifierImprecision(_quantifier, _fifaPlayers);
            var t7 = DegreeOfQuantifierCardinality(_quantifier, _fifaPlayers);
            var t8 = DegreeOfSummarizerCardinality(_summarizers);
            var t9 = DegreeOfQualifierImprecision(_qualifiers, _fifaPlayers);
            var t10 = DegreeOfQualifierCardinality(_qualifiers);
            var t11 = LengthOfQualifier(_qualifiers);
            var measures = new List<double>
            {
                Math.Round(t1, 3), Math.Round(t2, 3), Math.Round(t3, 3),
                Math.Round(t4, 3), Math.Round(t5, 3), Math.Round(t6, 3), Math.Round(t7, 3),
                Math.Round(t8, 3), Math.Round(t9, 3), Math.Round(t10, 3), Math.Round(t11, 3)
            };
            double t;
            if (_weights == null || _weights.Count < 11)
            {
                t = 0.4 * t1 + 0.06 * t2 + 0.06 * t3 + 0.06 * t4 + 0.06 * t5 + 0.06 * t6 +
                    0.06 * t7 + 0.06 * t8 + 0.06 * t9 + 0.06 * t10 + 0.06 * t11;
            }
            else
            {
                t = _weights[0] * t1 + _weights[1] * t2 + _weights[2] * t3 + _weights[3] * t4 + _weights[4] * t5 +
                    _weights[5] * t6 +
                    _weights[6] * t7 + _weights[7] * t8 + _weights[8] * t9 + _weights[9] * t10 + _weights[10] * t11;
            }

            measures.Add(t);
            return measures;
        }


        public List<double> CountMeasuresMultiSubject()
        {
            var t1 = DegreeOfTruthMultiSubject(_p1, _p2, _quantifier, _summarizers, _qualifiers, _type);
            var t2 = DegreeOfImprecision(_fifaPlayers, _summarizers);
            var t3 = DegreeOfCovering(_fifaPlayers, _summarizers, _qualifiers);
            var t4 = DegreeOfAppropriateness(_fifaPlayers, _summarizers, t3);
            var t5 = LengthOfASummary(_summarizers);
            var t6 = DegreeOfQuantifierImprecision(_quantifier, _fifaPlayers);
            var t7 = DegreeOfQuantifierCardinality(_quantifier, _fifaPlayers);
            var t8 = DegreeOfSummarizerCardinality(_summarizers);
            var t9 = DegreeOfQualifierImprecision(_qualifiers, _fifaPlayers);
            var t10 = DegreeOfQualifierCardinality(_qualifiers);
            var t11 = LengthOfQualifier(_qualifiers);

            var measures = new List<double>
            {
                Math.Round(t1, 3), Math.Round(t2, 3), Math.Round(t3, 3),
                Math.Round(t4, 3), Math.Round(t5, 3), Math.Round(t6, 3), Math.Round(t7, 3),
                Math.Round(t8, 3), Math.Round(t9, 3), Math.Round(t10, 3), Math.Round(t11, 3)
            };
            double t;
            if (_weights == null || _weights.Count < 11)
            {
                t = 0.4 * t1 + 0.06 * t2 + 0.06 * t3 + 0.06 * t4 + 0.06 * t5 + 0.06 * t6 +
                    0.06 * t7 + 0.06 * t8 + 0.06 * t9 + 0.06 * t10 + 0.06 * t11;
            }
            else
            {
                t = _weights[0] * t1 + _weights[1] * t2 + _weights[2] * t3 + _weights[3] * t4 + _weights[4] * t5 +
                    _weights[5] * t6 +
                    _weights[6] * t7 + _weights[7] * t8 + _weights[8] * t9 + _weights[9] * t10 + _weights[10] * t11;
            }
            measures.Add(t);
            return measures;
        }

        // counts value from all Linguistic variables with connector ( f.e. miS(di))
        private static double CountMembershipValue(List<LinguisticVariable> list, FifaPlayer fifaPlayer)
        {
            if (list.Count == 1)
                return list[0].CountMembership(fifaPlayer);

            double min = 2;
            foreach (var summarizer in list)
            {
                var t = summarizer.CountMembership(fifaPlayer);
                if (t < min)
                    min = t;
            }

            return min;
        }

        // T1
        public static double DegreeOfTruth(List<FifaPlayer> fifaPlayers, LinguisticVariable quantifier,
            List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            if (qualifiers != null) // zdanie z kwalifikatorem
            {
                // nowa baza D' - strona  150 a.n.
                var fifaPlayersPrime = fifaPlayers
                    .Where(player => CountMembershipValue(qualifiers, player) > 0)
                    .ToList();

                // wzór na r
                double d = 0;
                double u = 0;
                foreach (var x in fifaPlayersPrime)
                {
                    u += Math.Min(CountMembershipValue(qualifiers, x), CountMembershipValue(summarizers, x));
                    d += CountMembershipValue(qualifiers, x);
                }

                return quantifier.QuantifierAbsolute
                    ? quantifier.MembershipFunction.CountValue(u)
                    : quantifier.MembershipFunction.CountValue(u / d);
            }

            // zdanie bez kwalifikatora
            var r = fifaPlayers.Sum(x => CountMembershipValue(summarizers, x));
            return quantifier.QuantifierAbsolute
                ? quantifier.MembershipFunction.CountValue(r)
                : quantifier.MembershipFunction.CountValue(r / fifaPlayers.Count);
        }


        public static double DegreeOfTruthMultiSubject(List<FifaPlayer> p1, List<FifaPlayer> p2,
            LinguisticVariable quantifier, List<LinguisticVariable> summarizers,
            List<LinguisticVariable> qualifiers, int type)
        {
            var mp1 = p1.Count;
            var mp2 = p2.Count;
            var sumP1 = p1.Sum(x => CountMembershipValue(summarizers, x));
            var sumP2 = p2.Sum(x => CountMembershipValue(summarizers, x));

            switch (type)
            {
                case 1:
                    var upperCase1 = sumP1 / mp1;
                    var lowerCase1 = sumP1 / mp1 + sumP2 / mp2;
                    return quantifier.MembershipFunction.CountValue(upperCase1 / lowerCase1);
                case 2:
                    var sumP2W = p2.Sum(x =>
                        Math.Min(CountMembershipValue(summarizers, x), CountMembershipValue(qualifiers, x)));
                    var upperCase2 = sumP1 / mp1;
                    var lowerCase2 = sumP1 / mp1 + sumP2W / mp2;
                    return quantifier.MembershipFunction.CountValue(upperCase2 / lowerCase2);
                case 3:
                    var sumP1W = p1.Sum(x =>
                        Math.Min(CountMembershipValue(summarizers, x), CountMembershipValue(qualifiers, x)));
                    var upperCase3 = sumP1W / mp1;
                    var lowerCase3 = sumP1W / mp1 + sumP2 / mp2;
                    return quantifier.MembershipFunction.CountValue(upperCase3 / lowerCase3);
                case 4:
                    return sumP1 / (sumP1 + sumP2);
                default:
                    return -121321;
            }
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
            List<LinguisticVariable> summarizers, List<LinguisticVariable> qualifiers)
        {
            if (qualifiers == null) // 8.44 8.47 8.48
            {
                double sumh = fifaPlayers.Count;
                double sumt = 0;
                foreach (var fp in fifaPlayers)
                {
                    var miS = CountMembershipValue(summarizers, fp);
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
                    var miS = CountMembershipValue(summarizers, fp);
                    var miW = CountMembershipValue(qualifiers, fp);
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
        public static double DegreeOfQualifierImprecision(List<LinguisticVariable> qualifiers,
            List<FifaPlayer> fifaPlayers)
        {
            double mul = 1;
            if (qualifiers == null)
                return 0;
            foreach (var qualifier in qualifiers)
            {
                var fuzzySet = new FuzzySet(qualifier.AttributeName, qualifier.MembershipFunction);
                mul *= fuzzySet.DegreeOfFuzziness(fifaPlayers);
            }

            return 1 - Math.Pow(mul, (double) 1 / qualifiers.Count);
        }

        // T10
        public static double DegreeOfQualifierCardinality(List<LinguisticVariable> qualifiers)
        {
            double mul = 1;
            if (qualifiers == null)
                return 0;
            foreach (var qualifier in qualifiers)
            {
                var sj = qualifier.MembershipFunction.CountArea();
                var x = qualifier.MembershipFunction.GetMax() - qualifier.MembershipFunction.GetMin();
                mul *= (sj / x);
            }

            return 1 - Math.Pow(mul, (double) 1 / qualifiers.Count);
        }

        // T11
        public static double LengthOfQualifier(List<LinguisticVariable> qualifiers)
        {
            if (qualifiers == null)
                return 0;
            return 2 * Math.Pow(0.5, qualifiers.Count);
        }
    }
}