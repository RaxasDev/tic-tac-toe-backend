namespace Application.Queries.Analytics.GetChartsData;

public class MatchesPerDayViewModel
{
    public int Matches { get; private set; }
    public DateTime DateMatches { get; private set; }

    public MatchesPerDayViewModel(DateTime dateMatches, int matches)
    {
        Matches = matches;
        DateMatches = dateMatches;
    }
}