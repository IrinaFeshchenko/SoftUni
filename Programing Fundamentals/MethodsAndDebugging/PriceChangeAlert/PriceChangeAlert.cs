using System;

class PriceChangeAlert
{
    static void Main()
    {
        int numberOfPieces = int.Parse(Console.ReadLine());
        double treshold = double.Parse(Console.ReadLine());
        double lastPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPieces - 1; i++)
        {
            double currentPrice = double.Parse(Console.ReadLine());
            double priceDifference = GetPriceDifference(lastPrice, currentPrice);
            double priceDifferencePercents = priceDifference * 100;
            bool isSignificantDifference = EvaluateTheDifference(priceDifference, treshold);
            string message = GetMesssage(currentPrice, lastPrice, priceDifferencePercents, isSignificantDifference);
            Console.WriteLine(message);
            lastPrice = currentPrice;
        }
    }

    private static string GetMesssage(double currentPrice, double lastPrice, double priceDifference, bool isSignificantDifference)
    {
        string message = "";

        if (priceDifference == 0)
        {
            message = string.Format("NO CHANGE: {0}", currentPrice);
        }
        else if (!isSignificantDifference)
        {
            message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, priceDifference);
        }
        else if (isSignificantDifference && (priceDifference > 0))
        {
            message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, priceDifference);
        }
        else if (isSignificantDifference && (priceDifference < 0))
        {
            message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, priceDifference);
        }

        return message;
    }

    private static bool EvaluateTheDifference(double priceDifference, double treshold)
    {
        if (Math.Abs(priceDifference) >= treshold)
        {
            return true;
        }
        return false;
    }

    private static double GetPriceDifference(double lastPrice, double currentPrice)
    {
        double priceDifference = (currentPrice - lastPrice)/lastPrice;
        return priceDifference;
    }
}