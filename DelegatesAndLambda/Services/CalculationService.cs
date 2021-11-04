using System;

namespace DelegatesAndLambda.Services
{
    public static class CalculationService
    {
        public static double Max(double n1, double n2)
        {
            return (n1 > n2) ? n1 : n2;
        }

        public static void ShowMax(double n1, double n2)
        {
            var max = Max(n1, n2);
            Console.WriteLine(max);
        }

        public static double Sum(double n1, double n2)
        {
            return n1 + n2;
        }

        public static void ShowSum(double n1, double n2)
        {
            var sum = Sum(n1, n2);
            Console.WriteLine(sum);
        }

        public static double Square(double value)
        {
            return value * value;
        }
        
    }
}