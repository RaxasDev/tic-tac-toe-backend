namespace Application.Queries.Analytics.GetRanking;

public class GetRankingViewModel
{
    public int Position { get; private set; }
    public string Name { get; private set; }
    public int Matches { get; private set; }
    public int BestMoves { get; private set; }
    public int Wins { get; private set; }
    public int Losses { get; private set; }
    public int Draws { get; private set; }
    public int WinRate { get; private set; }

    public GetRankingViewModel(
        int position,
        string name,
        int matches,
        int bestMoves,
        int wins,
        int losses,
        int draws,
        int winRate
    )
    {
        Position = position;
        Name = name;
        Matches = matches;
        BestMoves = bestMoves;
        Wins = wins;
        Losses = losses;
        Draws = draws;
        WinRate = winRate;
    }
}