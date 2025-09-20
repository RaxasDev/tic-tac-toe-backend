namespace Application.Queries.Analytics.GetInfoCards;

public class GetInfoCardsViewModel
{
    public int TotalMatches { get; private set; }
    public int TotalPlayers { get; private set; }
    public int AverageMovements  { get; private set; }
    public int MatchWithLessMovements  { get; private set; }

    public GetInfoCardsViewModel(
        int totalMatches, 
        int totalPlayers, 
        int averageMovements, 
        int matchWithLessMovements
    )
    {
        TotalMatches = totalMatches;
        TotalPlayers = totalPlayers;
        AverageMovements = averageMovements;
        MatchWithLessMovements = matchWithLessMovements;
    }
}