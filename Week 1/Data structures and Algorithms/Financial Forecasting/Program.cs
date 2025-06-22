using System;

namespace FinancialForecasting
{
    class Forecast
    {
        // Recursive method to calculate future value
        public static double PredictFutureValue(double initialValue, double growthRate, int years)
        {
            if (years == 0)
                return initialValue;

            return PredictFutureValue(initialValue, growthRate, years - 1) * (1 + growthRate);
        }

        // Optimized version using memoization
        public static double PredictWithMemo(double initialValue, double growthRate, int years, double[] memo)
        {
            if (years == 0)
                return initialValue;

            if (memo[years] != 0)
                return memo[years];

            memo[years] = PredictWithMemo(initialValue, growthRate, years - 1, memo) * (1 + growthRate);
            return memo[years];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double initial = 1000;
            double rate = 0.10; // 10%
            int years = 5;

            Console.WriteLine("Recursive Forecast:");
            double result = Forecast.PredictFutureValue(initial, rate, years);
            Console.WriteLine($"Future Value after {years} years: {result:F2}");

            Console.WriteLine("\nOptimized Recursive Forecast (Memoization):");
            double[] memo = new double[years + 1];
            double optimizedResult = Forecast.PredictWithMemo(initial, rate, years, memo);
            Console.WriteLine($"Future Value after {years} years: {optimizedResult:F2}");

            Console.ReadLine();
        }
    }
}
