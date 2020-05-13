using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Zadanie2_KSR.MembershipFunctions;

// ReSharper disable StringLiteralTypo

namespace Zadanie2_KSR.Attributes
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class Attributes
    {
        public static readonly LinguisticVariable BardzoMlody =
            new LinguisticVariable("bardzo młody", "Age", new TrapezoidalFunction(16, 16, 18, 21));

        public static readonly LinguisticVariable Mlody =
            new LinguisticVariable("młody", "Age", new TrapezoidalFunction(20, 22, 24, 25));

        public static readonly LinguisticVariable Sredni =
            new LinguisticVariable("średni", "Age", new TrapezoidalFunction(24, 26, 29, 32));

        public static readonly LinguisticVariable Stary =
            new LinguisticVariable("stary", "Age", new TrapezoidalFunction(31, 34, 42, 42));

        public static List<LinguisticVariable> GetAllAgeVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoMlody, Mlody, Sredni, Stary
            };
        }
    }
}