using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Analytics.GetRanking;

public class GetRankingQueryHandler : IRequestHandler<GetRankingQueryInput, List<GetRankingViewModel>>
{
    private readonly IReadRepository<Player> _playerRepository;
    private readonly IReadRepository<GameMatch> _gameMatchRepository;

    public GetRankingQueryHandler(
        IReadRepository<Player> playerRepository,
        IReadRepository<GameMatch> gameMatchRepository
    )
    {
        _playerRepository = playerRepository;
        _gameMatchRepository = gameMatchRepository;
    }

    public async Task<List<GetRankingViewModel>> Handle(
        GetRankingQueryInput request,
        CancellationToken cancellationToken
    )
    {
        var players = await _playerRepository.Get();

        var matches = await _gameMatchRepository.Get(
            include: q => q
                .Include(x => x.PlayerX)
                .Include(x => x.PlayerO)
        );

        var ranking = players.Select(player =>
            {
                Func<GameMatch, bool> where = m => m.PlayerXId == player.Id || m.PlayerOId == player.Id;
                var playerMatches = matches.Where(where).ToList();

                var wins = playerMatches.Count(m =>
                    (m.PlayerXId == player.Id && m.WinnerSide == WinnerSideEnum.X) ||
                    (m.PlayerOId == player.Id && m.WinnerSide == WinnerSideEnum.O));

                var losses = playerMatches.Count(m =>
                    (m.PlayerXId == player.Id && m.WinnerSide == WinnerSideEnum.O) ||
                    (m.PlayerOId == player.Id && m.WinnerSide == WinnerSideEnum.X));

                var draws = playerMatches.Count(m => m.WinnerSide == WinnerSideEnum.DRAW);

                var bestMoves = playerMatches
                    .Where(m =>
                        (m.PlayerXId == player.Id && m.WinnerSide == WinnerSideEnum.X) ||
                        (m.PlayerOId == player.Id && m.WinnerSide == WinnerSideEnum.O))
                    .Select(m => m.PlayerXId == player.Id ? m.MovementsX : m.MovementsO)
                    .DefaultIfEmpty(int.MaxValue)
                    .Min();

                var totalMatches = playerMatches.Count;
                var winRate = totalMatches == 0
                    ? 0
                    : (int)Math.Round((wins * 100.0) / totalMatches, MidpointRounding.AwayFromZero);

                return new
                {
                    Player = player,
                    Matches = totalMatches,
                    Wins = wins,
                    Losses = losses,
                    Draws = draws,
                    BestMoves = bestMoves,
                    WinRate = winRate
                };
            })
            .OrderByDescending(x => x.WinRate)
            .ThenBy(x => x.BestMoves)
            .Take(5)
            .Select((x, index) => new GetRankingViewModel(
                position: index + 1,
                name: x.Player.Name,
                matches: x.Matches,
                bestMoves: x.BestMoves == int.MaxValue ? 0 : x.BestMoves,
                wins: x.Wins,
                losses: x.Losses,
                draws: x.Draws,
                winRate: x.WinRate
            ))
            .ToList();

        return ranking;
    }
}