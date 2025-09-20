using Domain.Models.Enum;

namespace Domain.Models;

public class GameMatch : BaseEntity
{
    public Guid PlayerXId { get; private set; }
    public Player PlayerX { get; private set; }
    public Guid PlayerOId { get; private set; }
    public Player PlayerO { get; private set; }
    public int MovementsX { get; private set; }
    public int MovementsO { get; private set; }
    public WinnerSideEnum WinnerSide { get; private set; }

    private GameMatch()
    {
    }

    public GameMatch(
        Player playerX, 
        Player playerO,
        int movementsX,
        int movementsO,
        WinnerSideEnum winnerSide
    )
    {
        PlayerX = playerX;
        PlayerO = playerO;
        PlayerXId = playerX.Id;
        PlayerOId = playerO.Id;
        MovementsX = movementsX;
        MovementsO = movementsO;
        WinnerSide = winnerSide;
    }
}