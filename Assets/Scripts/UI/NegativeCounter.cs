public class NegativeCounter : Counter
{
    private void OnEnable()
    {
        Statistic.OnNegativePointsChanged += UpdateText;
    }

    private void OnDisable()
    {
        Statistic.OnNegativePointsChanged -= UpdateText;
    }
}
