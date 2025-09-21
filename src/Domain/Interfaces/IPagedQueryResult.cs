namespace Domain.Interfaces;

public interface IPagedQueryResult<T> where T : class
{
    int PageSize { get; }
    int TotalItems { get; }
    int PageNumber { get; }
    int TotalPages { get; }
    List<T> Items { get; }
}