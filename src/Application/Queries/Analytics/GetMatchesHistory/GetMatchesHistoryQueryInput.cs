using MediatR;

namespace Application.Queries.Analytics.GetMatchesHistory;


public class GetMatchesHistoryQueryInput : IRequest<List<GetMatchesHistoryViewModel>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
}