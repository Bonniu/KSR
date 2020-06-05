using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR.Fuzzy
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public static class Quantifiers
    {
        public static readonly LinguisticVariable AlmostNone =
            new LinguisticVariable("Almost none", "Quantifier", false,
                new TrapezoidalFunction(0, 0, 0.055, 0.164));

        public static readonly LinguisticVariable Less =
            new LinguisticVariable("Less", "Quantifier", false,
                new TrapezoidalFunction(0.109, 0.164, 0.383, 0.438));

        public static readonly LinguisticVariable Half =
            new LinguisticVariable("Half", "Quantifier", false,
                new TrapezoidalFunction(0.410, 0.438, 0.547, 0.574));

        public static readonly LinguisticVariable Most =
            new LinguisticVariable("Most", "Quantifier", false,
                new TrapezoidalFunction(0.547, 0.602, 0.821, 0.875));

        public static readonly LinguisticVariable AlmostAll =
            new LinguisticVariable("Almost all", "Quantifier", false,
                new TrapezoidalFunction(0.821, 0.903, 1, 1));


        public static List<LinguisticVariable> GetRelativeQuantifiers()
        {
            return new List<LinguisticVariable>
            {
                AlmostNone, Less, Half, Most, AlmostAll
            };
        }

        public static readonly LinguisticVariable About1000 =
            new LinguisticVariable("About 1000", "Quantifier", true,
                new TrapezoidalFunction(900, 960, 1040, 1100));

        public static readonly LinguisticVariable MoreThan3000 =
            new LinguisticVariable("More than 3000", "Quantifier", true,
                new TrapezoidalFunction(2990, 3010, 18278, 18278));

        public static readonly LinguisticVariable LessThan3000 =
            new LinguisticVariable("Less than 3000", "Quantifier", true,
                new TrapezoidalFunction(0, 0, 2990, 3010));
        
        public static readonly LinguisticVariable Around500 =
            new LinguisticVariable("Around 500", "Quantifier", true,
                new TrapezoidalFunction(450, 480, 520, 550));
        
        public static readonly LinguisticVariable Around100 =
            new LinguisticVariable("Around 100", "Quantifier", true,
                new TrapezoidalFunction(80, 90, 110, 120));


        public static List<LinguisticVariable> GetAbsoluteQuantifiers()
        {
            return new List<LinguisticVariable>
            {
                About1000, MoreThan3000, LessThan3000, Around500, Around100
            };
        }


        public static List<LinguisticVariable> GetAllQuantifiers()
        {
            var list = new List<LinguisticVariable>();
            list.AddRange(GetRelativeQuantifiers());
            list.AddRange(GetAbsoluteQuantifiers());
            return list;
        }
    }
}