using Domain.Interfaces;

namespace Application.UseCase.Player.CreatePlayerMatch;

public class CreatePlayerMatchCommandResult : ICommandResult<string>
{
    public bool Success { get; }
    public string Message { get; }
    public string? Data { get; }

    public CreatePlayerMatchCommandResult(bool success, string message, string? data = null)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}