using System;

namespace Zadanie2_KSR.MembershipFunctions
{
    public class GaussianFunction : IMembershipFunction
    {
        public readonly double AvgX;
        public readonly double Width;

        public GaussianFunction(double avgX, double width)
        {
            AvgX = avgX;
            Width = width;
        }

        public double CountValue(double x)
        {
            var tmpFraction = (x - AvgX) / Width;
            return Math.Exp(-tmpFraction * tmpFraction);
        }

        public double GetMin()
        {
            for (int x = -100000; x < 100000; x++)
            {
                if (CountValue(x) > 0.0001)
                {
                    return x;
                }
            }

            return int.MinValue;
        }

        public double GetMax()
        {
            for (int x = 100000; x > -100000; x--)
            {
                if (CountValue(x) > 0.0001)
                {
                    return x;
                }
            }

            return int.MaxValue;
        }

        public double CountArea()
        {
            double odchylenie = 0.1;
            return Math.Sqrt(Math.PI / 2 * odchylenie);
        }

        public override string ToString()
        {
            return "AvgX: " + AvgX + " Width: " + Width + " area: " + CountArea();
        }
    }
}