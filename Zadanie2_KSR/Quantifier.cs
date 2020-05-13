using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class Quantifier
    {
        public static readonly LinguisticVariable PrawieNikt =
            new LinguisticVariable("Prawie nikt", "Quantifier", new TrapezoidalFunction(0, 0, 1000, 3000));

        public static readonly LinguisticVariable Mniejszosc =
            new LinguisticVariable("Mniejszość", "Quantifier", new TrapezoidalFunction(2000, 3000, 7000, 8000));

        public static readonly LinguisticVariable Polowa =
            new LinguisticVariable("Połowa", "Quantifier", new TrapezoidalFunction(7500, 8000, 10000, 10500));

        public static readonly LinguisticVariable Wiekszosc =
            new LinguisticVariable("Wiekszość", "Quantifier", new TrapezoidalFunction(10000, 11000, 15000, 16000));

        public static readonly LinguisticVariable PrawieWszyscy =
            new LinguisticVariable("Prawie wszyscy", "Quantifier", new TrapezoidalFunction(15000, 16500, 18278, 18278));

        public static List<LinguisticVariable> GetAllQuantifiers()
        {
            return new List<LinguisticVariable>
            {
                PrawieNikt, Mniejszosc, Polowa, Wiekszosc, PrawieWszyscy
            };
        }
    }
}