using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Enum;
using MediatR;

namespace Application.Queries.Analytics.GetChartsData;

public class GetChartsDataQueryHandler : IRequestHandler<GetChartsDataQueryInput, List<GetChartsDataViewModel>>
{
    private readonly IReadRepository<GameMatch> _gameMatchRepository;

    public GetChartsDataQueryHandler(
        IReadRepository<GameMatch> gameMatchRepository
    )
    {
        _gameMatchRepository = gameMatchRepository;
    }

    public async Task<List<GetChartsDataViewModel>> Handle(
        GetChartsDataQueryInput request,
        CancellationToken cancellationToken
    )
    {
        var xWins = await _gameMatchRepository.CountAsync(g => g.WinnerSide == WinnerSideEnum.X);
        var oWins = await _gameMatchRepository.CountAsync(g => g.WinnerSide == WinnerSideEnum.O);
        var draws = await _gameMatchRepository.CountAsync(g => g.WinnerSide == WinnerSideEnum.DRAW);

        var totalGames = xWins + oWins + draws;

        return new List<GetChartsDataViewModel>
        {
            new ("Jogador X", "#ef4444", CalculatePercentage(xWins, totalGames)),
            new ("Jogador O", "#3b82f6", CalculatePercentage(oWins, totalGames)),
            new ("Empates", "#9ca3af", CalculatePercentage(draws, totalGames))
        };
    }

    private static int CalculatePercentage(int value, int total)
    {
        if (total == 0) return 0;
        return (int)Math.Round((value * 100.0) / total);
    }
}