using System.Linq.Expressions;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Interfaces;

public interface IReadRepository<T> where T : BaseEntity
{
    Task<T?> FirstAsync(
        Expression<Func<T, bool>>? where = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null!
    );

    Task<List<T>> Get(
        Expression<Func<T, bool>>? where = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null!,
        string order = null!
    );

    Task<IEnumerable<VM>> Select<VM>(
        Expression<Func<T, VM>> selector,
        Expression<Func<T, bool>>? where = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null!,
        string? order = null
    ) where VM : class;

    Task<int> CountAsync(Expression<Func<T, bool>>? where = null);

    Task<List<VM>> SelectPaginatedAsync<VM>(
        Expression<Func<T, VM>> selector,
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? where = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        string? order = null
    ) where VM : class;
}