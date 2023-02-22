using System;

public class Statistic
{
    public static event Action<int> OnPositivePointsChanged;
    public static event Action<int> OnNegativePointsChanged;
    
    private static int positivePoints;
    private static int negativePoints;

    public static void AddPositivePoints(int value)
    {
        positivePoints += value;
        OnPositivePointsChanged?.Invoke(positivePoints);
    }
    
    public static void AddNegativePoints(int value)
    {
        negativePoints += value;
        OnNegativePointsChanged?.Invoke(negativePoints);
    }
}
