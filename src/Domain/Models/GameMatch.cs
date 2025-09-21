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
    public int TotalMovements => GetTotalMovements();

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

        Validate();
    }

    private void Validate()
    {
        int minMovementsPerMatch = 5;
        int maxMovementsPerMatch = 9;
        int minMovementsPerPlayer = 2;
        int maxMovementsPerPlayer = 5;
        List<string> errors = new List<string>();

        if (MovementsX < minMovementsPerPlayer || MovementsX > maxMovementsPerPlayer)
            errors.Add("O Jogador X deve realizar movimentos.");

        if (MovementsO < minMovementsPerPlayer || MovementsO > maxMovementsPerPlayer)
            errors.Add("Movimentos do jogador O são inválidos.");

        if (TotalMovements < minMovementsPerMatch || TotalMovements > maxMovementsPerMatch)
            errors.Add("Quantidade de movimentos não permitida.");
        
        if (errors.Any())
            throw new ArgumentException(string.Join(" | ", errors));
    }

    private int GetTotalMovements()
    {
        return MovementsX + MovementsO;
    }
}