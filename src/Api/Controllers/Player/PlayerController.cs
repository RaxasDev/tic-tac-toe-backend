using Application.Queries.Player.GetAllPlayers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Player;

[Route("api/v1/player")]
public class PlayerController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public PlayerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("all-players")]
    public async Task<IActionResult> GetPlayers()
    {
        var result = await _mediator.Send(new GetAllPlayersQueryInput());
        return result == null ? NotFound() : Ok(result);
    }
}