using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Queries.Analytics.GetInfoCards;

public class GetInfoCardsHandler : IRequestHandler<GetInfoCardsQueryInput, GetInfoCardsViewModel>
{
    private readonly IReadRepository<Player> _playerRepository;
    private readonly IReadRepository<GameMatch> _gameMatchRepository;

    public GetInfoCardsHandler(
        IReadRepository<Player> playerRepository,
        IReadRepository<GameMatch> gameMatchRepository
    )
    {
        _playerRepository = playerRepository;
        _gameMatchRepository = gameMatchRepository;
    }

    public async Task<GetInfoCardsViewModel> Handle(
        GetInfoCardsQueryInput request,
        CancellationToken cancellationToken
    )
    {
        var totalPlayers = await _playerRepository.CountAsync();

        var totalMatches = await _gameMatchRepository.CountAsync();

        var movements = (await _gameMatchRepository
                .Select(g => new { g.TotalMovements }))
            .ToList();

        int averageMovements = 0;
        int matchWithLessMovements = 0;

        if (movements.Any())
        {
            averageMovements = (int)movements.Average(m => m.TotalMovements);
            matchWithLessMovements = movements.Min(m => m.TotalMovements);
        }

        var result = new GetInfoCardsViewModel(
            totalMatches,
            totalPlayers,
            averageMovements,
            matchWithLessMovements
        );

        return result;
    }
}