using MediatR;

namespace Application.Queries.Analytics.GetChartsData;

public class GetChartsDataQueryInput : IRequest<GetChartsDataViewModel>;