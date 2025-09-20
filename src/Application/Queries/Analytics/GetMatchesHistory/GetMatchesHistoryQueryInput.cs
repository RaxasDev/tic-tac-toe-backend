using MediatR;

namespace Application.Queries.Analytics.GetMatchesHistory;

public class GetMatchesHistoryQueryInput : IRequest<List<GetMatchesHistoryViewModel>>
{
    
};