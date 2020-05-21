using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class Quantifier
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
                new TrapezoidalFunction(3000, 3000, 18278, 18278));
        
        public static readonly LinguisticVariable LessThan3000 =
            new LinguisticVariable("Less than 3000", "Quantifier", true,
                new TrapezoidalFunction(0, 0, 3000, 3000));


        public static List<LinguisticVariable> GetAbsoluteQuantifiers()
        {
            return new List<LinguisticVariable>
            {
                About1000, MoreThan3000, LessThan3000
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