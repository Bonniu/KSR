namespace Zadanie2_KSR.MembershipFunctions
{
    public interface IMembershipFunction
    {
        public double CountValue(double x);
        public double GetMin();
        public double GetMax();
        public double CountArea();
    }
}