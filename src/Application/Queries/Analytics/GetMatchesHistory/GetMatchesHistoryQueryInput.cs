using Domain.Interfaces;
using MediatR;

namespace Application.Queries.Analytics.GetMatchesHistory;

public class GetMatchesHistoryQueryInput : IRequest<IPagedQueryResult<GetMatchesHistoryViewModel>>
{
    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }

    public GetMatchesHistoryQueryInput(int pageNumber = 1, int pageSize = 5)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}