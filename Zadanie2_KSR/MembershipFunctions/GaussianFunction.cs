using System;

namespace Zadanie2_KSR.MembershipFunctions
{
    public class GaussianFunction : IMembershipFunction
    {
        public readonly double AvgX;
        public readonly double Width;
        public readonly double X1;
        public readonly double X2;

        public GaussianFunction(double avgX, double width, double x1, double x2)
        {
            AvgX = avgX;
            Width = width;
            X1 = x1;
            X2 = x2;
        }

        public GaussianFunction(double avgX, double width)
        {
            AvgX = avgX;
            Width = width;
            X1 = 0;
            X2 = 100;
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
            if(Math.Abs(AvgX - X1) < 0.01 || Math.Abs(AvgX - X2) < 0.01)
                return Math.Sqrt(Math.PI / 2 * Width) / 2;
            return Math.Sqrt(Math.PI / 2 * Width);
        }

        public override string ToString()
        {
            return "AvgX: " + AvgX + " Width: " + Width + " area: " + CountArea();
        }
    }
}