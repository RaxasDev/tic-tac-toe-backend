using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Analytics.GetMatchesHistory;

public class GetMatchesHistoryQueryHandler
    : IRequestHandler<GetMatchesHistoryQueryInput, IPagedQueryResult<GetMatchesHistoryViewModel>>
{
    private readonly IReadRepository<GameMatch> _gameMatchRepository;

    public GetMatchesHistoryQueryHandler(IReadRepository<GameMatch> gameMatchRepository)
    {
        _gameMatchRepository = gameMatchRepository;
    }

    public async Task<IPagedQueryResult<GetMatchesHistoryViewModel>> Handle(
        GetMatchesHistoryQueryInput request,
        CancellationToken cancellationToken
    )
    {
        Console.WriteLine("Batata");
        
        var matches = await _gameMatchRepository.SelectPaginatedAsync(
            m => new GetMatchesHistoryViewModel(
                m.Id,
                m.PlayerX.Name,
                m.PlayerO.Name,
                m.WinnerSide,
                m.Created
            ),
            request.PageNumber,
            request.PageSize,
            include: q => q
                .Include(m => m.PlayerX)
                .Include(m => m.PlayerO),
            order: "Created desc"
        );

        return matches;
    }
}