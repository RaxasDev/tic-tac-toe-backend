namespace Domain.Interfaces;

public interface ICommandResult<T>
{
    bool Success { get; }
    string Message { get; }
    T? Data { get; }
}