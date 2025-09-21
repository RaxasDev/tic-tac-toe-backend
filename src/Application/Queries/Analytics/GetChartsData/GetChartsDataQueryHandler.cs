using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Enum;
using MediatR;

namespace Application.Queries.Analytics.GetChartsData;

public class GetChartsDataQueryHandler : IRequestHandler<GetChartsDataQueryInput, GetChartsDataViewModel>
{
    private readonly IReadRepository<GameMatch> _gameMatchRepository;

    public GetChartsDataQueryHandler(
        IReadRepository<GameMatch> gameMatchRepository
    )
    {
        _gameMatchRepository = gameMatchRepository;
    }

    public async Task<GetChartsDataViewModel> Handle(
        GetChartsDataQueryInput request,
        CancellationToken cancellationToken
    )
    {
        var xWins = await _gameMatchRepository.CountAsync(g => g.WinnerSide == WinnerSideEnum.X);
        var oWins = await _gameMatchRepository.CountAsync(g => g.WinnerSide == WinnerSideEnum.O);
        var draws = await _gameMatchRepository.CountAsync(g => g.WinnerSide == WinnerSideEnum.DRAW);

        var totalGames = xWins + oWins + draws;

        var victoryChartData = new List<VictoryChartDataViewModel>
        {
            new("Jogador X", "#ef4444", CalculatePercentage(xWins, totalGames)),
            new("Jogador O", "#3b82f6", CalculatePercentage(oWins, totalGames)),
            new("Empates", "#9ca3af", CalculatePercentage(draws, totalGames))
        };

        var startDate = DateTime.UtcNow.Date.AddDays(-6);

        Expression<Func<GameMatch, bool>> where = g => g.Created.Date >= startDate;
        var gameMatchesLastSevenDays = await _gameMatchRepository.Get(where);
        var groupdMatches = gameMatchesLastSevenDays
            .GroupBy(g => g.Created.Date)
            .Select(g => new MatchesPerDayViewModel(
                g.Key,
                g.Count()
            ))
            .OrderBy(x => x.DateMatches)
            .ToList();

        var resultList = Enumerable.Range(0, 7)
            .Select(offset => startDate.AddDays(offset))
            .Select(date => groupdMatches.FirstOrDefault(x => x.DateMatches == date)
                            ?? new MatchesPerDayViewModel(date, 0))
            .ToList();

        return new GetChartsDataViewModel(victoryChartData, resultList);
    }

    private static int CalculatePercentage(int value, int total)
    {
        if (total == 0) return 0;
        return (int)Math.Round((value * 100.0) / total);
    }
}