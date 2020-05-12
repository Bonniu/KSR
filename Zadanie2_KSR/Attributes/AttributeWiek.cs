using System.Diagnostics.CodeAnalysis;
using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR.Attributes
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class AttributeWiek : Attribute
    {
        private static readonly TrapezoidalFunction Func = new TrapezoidalFunction();

        public static double BardzoMlody(int x)
        {
            const int a = 16;
            const int b = 16;
            const int c = 18;
            const int d = 21;
            return Func.CountValue(a, b, c, d, x);
        }

        public static double Mlody(int x)
        {
            const int a = 20;
            const int b = 22;
            const int c = 24;
            const int d = 25;
            return Func.CountValue(a, b, c, d, x);
        }

        public static double Sredni(int x)
        {
            const int a = 24;
            const int b = 26;
            const int c = 29;
            const int d = 32;
            return Func.CountValue(a, b, c, d, x);
        }

        public static double Stary(int x)
        {
            const int a = 31;
            const int b = 34;
            const int c = 42;
            const int d = 42;
            return Func.CountValue(a, b, c, d, x);
        }
    }
}