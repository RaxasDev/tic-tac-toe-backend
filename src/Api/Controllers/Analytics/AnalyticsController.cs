using Application.Queries.Analytics.GetChartsData;
using Application.Queries.Analytics.GetInfoCards;
using Application.Queries.Analytics.GetMatchesHistory;
using Application.Queries.Analytics.GetRanking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Analytics;

[Route("api/v1/analytics")]
public class AnalyticsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AnalyticsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("info-cards")]
    public async Task<IActionResult> GetInfoCards()
    {
        var result = await _mediator.Send(new GetInfoCardsQueryInput());
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpGet("charts-data")]
    public async Task<IActionResult> GetChartsData()
    {
        var result = await _mediator.Send(new GetChartsDataQueryInput());
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpGet("ranking")]
    public async Task<IActionResult> GetPlayerRanking()
    {
        var result = await _mediator.Send(new GetRankingQueryInput());
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpGet("matches-history")]
    public async Task<IActionResult> GetMatchesHistory()
    {
        var result = await _mediator.Send(new GetMatchesHistoryQueryInput());
        return result == null ? NotFound() : Ok(result);
    }
}