namespace Delegates.Services
{
    public static class CalculationService
    {
        public static double Max(double n1, double n2)
        {
            return (n1 > n2) ? n1 : n2;
        }

        public static double Sum(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Square(double value)
        {
            return value * value;
        }
    }
}