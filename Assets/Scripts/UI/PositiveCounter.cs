public class PositiveCounter : Counter
{
    private void OnEnable()
    {
        Statistic.OnPositivePointsChanged += UpdateText;
    }

    private void OnDisable()
    {
        Statistic.OnPositivePointsChanged -= UpdateText;
    }
}
