namespace Domain.Models;

public class GameMatch : BaseEntity
{
    public Guid Id { get; private set; }
    public Guid PlayerXId { get; private set; }
    public Player PlayerX { get; private set; }
    public Guid PlayerOId { get; private set; }
    public Player PlayerO { get; private set; }
    public int WinSideX { get; private set; }
    public int WinSideO { get; private set; }
    public int Movements { get; private set; }

    private GameMatch()
    {
    }

    public GameMatch(Player playerXId, Player playerOId)
    {
        PlayerX = playerXId;
        PlayerO = playerOId;
    }

    public void SetResult(int winX, int winO)
    {
        WinSideX = winX;
        WinSideO = winO;
    }
}