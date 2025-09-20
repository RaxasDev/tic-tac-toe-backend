namespace Application.Queries.Analytics.GetChartsData;

public class GetChartsDataViewModel
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public int Value { get; private set; }

    public GetChartsDataViewModel(string name, string color, int value)
    {
        Name = name;
        Color = color;
        Value = value;
    }
}