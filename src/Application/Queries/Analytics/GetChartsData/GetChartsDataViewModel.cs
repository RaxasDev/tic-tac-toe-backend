namespace Application.Queries.Analytics.GetChartsData;

public class GetChartsDataViewModel
{
    public List<VictoryChartDataViewModel> VictoryData { get; private set; }
    public List<MatchesPerDayViewModel> MatchesPerDay { get; private set; }

    public GetChartsDataViewModel(
        List<VictoryChartDataViewModel> victoryData,
        List<MatchesPerDayViewModel> matchesPerDay
    )
    {
        VictoryData = victoryData;
        MatchesPerDay = matchesPerDay;
    }
}