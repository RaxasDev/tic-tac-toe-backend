using Domain.Models.Enum;
using MediatR;

namespace Application.UseCase.Player.CreatePlayerMatch;

public class CreatePlayerMatchCommand : IRequest<CreatePlayerMatchCommandResult>
{
    public string PlayerXName { get; private set; }
    public string PlayerOName { get; private set; }
    public int MovementsX { get; private set; }
    public int MovementsO { get; private set; }
    public WinnerSideEnum WinnerSide { get; private set; }

    public CreatePlayerMatchCommand(
        string playerXName,
        string playerOName,
        int movementsX,
        int movementsO,
        WinnerSideEnum winnerSide
    )
    {
        PlayerXName = playerXName;
        PlayerOName = playerOName;
        MovementsX = movementsX;
        MovementsO = movementsO;
        WinnerSide = winnerSide;
    }
}