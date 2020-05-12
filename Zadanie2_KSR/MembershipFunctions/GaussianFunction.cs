using System;

namespace Zadanie2_KSR.MembershipFunctions
{
    public class GaussianFunction : MembershipFunction
    {
        public double CountValue(double avgX, double width, int x)
        {
            var tmpFraction = (x - avgX) / width;
            return Math.Exp(-tmpFraction * tmpFraction);
        }
    }
}