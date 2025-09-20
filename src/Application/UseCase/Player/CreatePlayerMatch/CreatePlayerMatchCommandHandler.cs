using System.Linq.Expressions;
using Domain.Helpers;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.UseCase.Player.CreatePlayerMatch;

public class CreatePlayerMatchHandler : IRequestHandler<CreatePlayerMatchCommand, CreatePlayerMatchCommandResult>
{
    private readonly IRepository<Domain.Models.Player> _playerRepository;

    public CreatePlayerMatchHandler(IRepository<Domain.Models.Player> playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<CreatePlayerMatchCommandResult> Handle(
        CreatePlayerMatchCommand request,
        CancellationToken cancellationToken
    )
    {
        if (request.PlayerXName.EqualsIgnoreCaseAndAccents(request.PlayerOName))
        {
            return new CreatePlayerMatchCommandResult(false, "Os jogadores devem ser diferentes");
        }

        Expression<Func<Domain.Models.Player, bool>> where = p =>
            p.Name == request.PlayerXName || p.Name == request.PlayerOName;
        var players = await _playerRepository.Get(where);

        bool isNewPlayerX = false;
        var playerX = players.FirstOrDefault(p => p.Name == request.PlayerXName);
        if (playerX == null)
        {
            playerX = new Domain.Models.Player(request.PlayerXName);
            isNewPlayerX = true;
        }

        bool isNewPlayerO = false;
        var playerO = players.FirstOrDefault(p => p.Name == request.PlayerOName);
        if (playerO == null)
        {
            playerO = new Domain.Models.Player(request.PlayerOName);
            isNewPlayerO = true;
        }

        GameMatch gameMatch = new GameMatch(
            playerX,
            playerO,
            request.MovementsX,
            request.MovementsO,
            request.WinnerSide
        );

        playerX.AddGameMatchAsX(gameMatch);
        playerO.AddGameMatchAsO(gameMatch);

        if (isNewPlayerX) _playerRepository.Add(playerX);
        if (isNewPlayerO) _playerRepository.Add(playerO);

        var success = await _playerRepository.Commit(cancellationToken);
        if (!success)
        {
            return new CreatePlayerMatchCommandResult(false, "Não foi possivel registrar partida!");
        }

        return new CreatePlayerMatchCommandResult(true, "Partida registrada com sucesso.");
    }
}