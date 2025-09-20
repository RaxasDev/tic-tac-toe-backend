using System.Linq.Expressions;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Interfaces;

public interface IRepository<T> where T : class, IAggregateRoot
{
    void Add(T entity);

    void AddRange(List<T> entities);

    void Update(T entity);

    void UpdateRange(List<T> entities);

    void Delete(T entity);

    void DeleteRange(IEnumerable<T> entities);

    Task<T?> GetById(Guid id);

    Task<List<T>> Get(
        Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null
    );

    Task<bool> Commit(CancellationToken cancellationToken = default);

    Task<T?> FirstAsync(
        Expression<Func<T, bool>>? where,
        Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null
    );
}