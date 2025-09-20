using Domain.Models.Enum;

namespace Application.Queries.Analytics.GetMatchesHistory;

public class GetMatchesHistoryViewModel
{
    public Guid Id { get; private set; }
    public string PlayerX { get; private set; }
    public string PlayerO { get; private set; }
    public string Winner { get; private set; }
    public DateTime Created { get; private set; }

    public GetMatchesHistoryViewModel(
        Guid id,
        string playerX,
        string playerO,
        WinnerSideEnum winner,
        DateTime created
    )
    {
        Id = id;
        PlayerX = playerX;
        PlayerO = playerO;

        string winnerName = winner switch
        {
            WinnerSideEnum.DRAW => "Empate",
            WinnerSideEnum.X => "X",
            WinnerSideEnum.O => "O",
            _ => "Desconhecido"
        };
        Winner = winnerName;

        Created = created;
    }
}