using Application.Dto;
using Application.UseCase.Player.CreatePlayerMatch;
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

    [HttpPost("create-match")]
    public async Task<ActionResult> CreateGameMatch(
        [FromBody] CreatePlayerMatchDto createPlayerMatchDto
    )
    {
        var createPlayerMatch = new CreatePlayerMatchCommand(
            createPlayerMatchDto.PlayerXName,
            createPlayerMatchDto.PlayerOName,
            createPlayerMatchDto.MovementsX,
            createPlayerMatchDto.MovementsO,
            createPlayerMatchDto.WinnerSide
        );

        var commandResult = await _mediator.Send(createPlayerMatch);
        return Ok(commandResult);
    }
}