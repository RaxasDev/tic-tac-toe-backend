using Domain.Interfaces;

namespace Application.Common;

public class CommandResult<T> : ICommandResult<T>
{
    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T? Data { get; private set; }

    private CommandResult(bool success, string message, T? data = default)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static CommandResult<T> Ok(T data, string message = "OK") =>
        new CommandResult<T>(true, message, data);

    public static CommandResult<T> Fail(string message) =>
        new CommandResult<T>(false, message);
}