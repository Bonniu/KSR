using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR
{
    public class Quantifier
    {
        private static readonly TrapezoidalFunction Func = new TrapezoidalFunction();

        public double PrawieNikt(int x)
        {
            const int a = 0;
            const int b = 0;
            const int c = 1000;
            const int d = 3000;
            return Func.CountValue(a, b, c, d, x);
        }

        public double Mniejszosc(int x)
        {
            const int a = 2000;
            const int b = 3000;
            const int c = 7000;
            const int d = 8000;
            return Func.CountValue(a, b, c, d, x);
        }

        public double Polowa(int x)
        {
            const int a = 7500;
            const int b = 8000;
            const int c = 10000;
            const int d = 10500;
            return Func.CountValue(a, b, c, d, x);
        }

        public double Większosc(int x)
        {
            const int a = 10000;
            const int b = 11000;
            const int c = 15000;
            const int d = 16000;
            return Func.CountValue(a, b, c, d, x);
        }

        public double PrawieWszyscy(int x)
        {
            const int a = 15000;
            const int b = 16500;
            const int c = 18278;
            const int d = 18278;
            return Func.CountValue(a, b, c, d, x);
        }
    }
}