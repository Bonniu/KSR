using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class Quantifier
    {
        public static readonly LinguisticVariable PrawieNikt =
            new LinguisticVariable("Almost none", "Quantifier", new TrapezoidalFunction(0, 0, 0.055, 0.164));

        public static readonly LinguisticVariable Mniejszosc =
            new LinguisticVariable("Less", "Quantifier", new TrapezoidalFunction(0.109, 0.164, 0.383, 0.438));

        public static readonly LinguisticVariable Polowa =
            new LinguisticVariable("Half", "Quantifier", new TrapezoidalFunction(0.410, 0.438, 0.547, 0.574));

        public static readonly LinguisticVariable Wiekszosc =
            new LinguisticVariable("Most", "Quantifier", new TrapezoidalFunction(0.547, 0.602, 0.821, 0.875));

        public static readonly LinguisticVariable PrawieWszyscy =
            new LinguisticVariable("Almost all", "Quantifier", new TrapezoidalFunction(0.821, 0.903, 1, 1));

        public static List<LinguisticVariable> GetAllQuantifiers()
        {
            return new List<LinguisticVariable>
            {
                PrawieNikt, Mniejszosc, Polowa, Wiekszosc, PrawieWszyscy
            };
        }
    }
}